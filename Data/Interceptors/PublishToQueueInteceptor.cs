using Microsoft.EntityFrameworkCore.Diagnostics;
using Premier.API.Core.MessageQueue;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Premier.API.FileUploadDownload.Data.Interceptors
{
    public class MessageToPublish
    {
        public string routingKey { get; set; }

        public List<object> messages { get; set; } = new List<object>();
    }

    public class PublishToQueueInteceptor : SaveChangesInterceptor
    {
        protected readonly IPublisher _publisher;
        protected readonly string _customerID = string.Empty;
        protected readonly string _userID = string.Empty;

        protected Dictionary<string, object> _messageQueueHeader = new Dictionary<string, object>();

        protected Dictionary<int, string> _entityState = new Dictionary<int, string>();

        public PublishToQueueInteceptor(IPublisher publisher, string customerID, string userID)
        {
            _publisher = publisher;
            _customerID = customerID;
            _userID = userID;

            _messageQueueHeader.Add("CustomerID", _customerID);
            _messageQueueHeader.Add("UserID", _userID);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            _entityState.Clear();

            int keyCounter = 0;
            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                _entityState.Add(keyCounter, entry.State.ToString());
                keyCounter++;
            }

            return new ValueTask<InterceptionResult<int>>(result);
        }

        public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            string uniqueID = Guid.NewGuid().ToString();

            if (_messageQueueHeader.ContainsKey("MessageGroupID"))
                _messageQueueHeader["MessageGroupID"] = uniqueID;
            else
                _messageQueueHeader.Add("MessageGroupID", uniqueID);

            int keyCounter = 0;

            // create list of messages grouped by routing key - the same type messages will be published as a list
            List<MessageToPublish> msgs = new List<MessageToPublish>();

            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                string state = _entityState[keyCounter];
                string routingKey = $"{entry.Entity.GetType().Name}.{state}";

                MessageToPublish msg = msgs.Where(i => i.routingKey == routingKey).FirstOrDefault();

                if (msg == null)
                {
                    msg = new MessageToPublish();
                    msg.routingKey = routingKey;
                    msgs.Add(msg);
                }

                msg.messages.Add(entry.Entity);
                keyCounter++;
            }

            foreach(MessageToPublish msg in msgs)
            {
                _publisher.Publish<object>(msg.messages, msg.routingKey, _messageQueueHeader);
            }

            _messageQueueHeader.Remove("MessageGroupID");

            _entityState.Clear();

            return new ValueTask<int>(result);
        }
    }
}
