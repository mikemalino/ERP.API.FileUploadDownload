using System;

using AutoMapper;

using Premier.API.Core.Infrastructure.BaseClasses;
using Premier.API.FileUploadDownload.Data.Entity;

using Premier.API.FileUploadDownload.DTO.Request;
using Premier.API.FileUploadDownload.DTO.Response;
using Premier.API.Core.Contracts;

namespace Premier.API.FileUploadDownload.Infrastructure.AutoMapper
{
    public class MapProfConfig : Profile
    {
        public MapProfConfig()
        {
            CreateMap<NoteUpdateRequest, Note>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.NoteID))
                .ReverseMap();

            CreateMap<FileUploadRequest, FileUpload>(MemberList.None);
				//.ForMember(dest => dest.NoteText, opt => opt.MapFrom(src => src.NoteText))
				//.ForMember(dest => dest.NoteType, opt => opt.MapFrom(src => src.NoteType));

			CreateMap<FileUploadRequest, FileUploadResponse>().ReverseMap();

            /*
			CreateMap<Note, NoteResponse>().ReverseMap();
			CreateMap<NoteRef, NoteRefResponse>().ReverseMap();
			*/
        }
    }
}
