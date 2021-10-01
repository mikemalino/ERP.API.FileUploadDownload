using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Premier.API.Core.Authentication.Service;
using Premier.API.Core.Infrastructure.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premier.API.FileUploadDownload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TestUserController : PremierAPIControllerBase
    {
        private readonly ITestTokenService _testTokenService;
        private readonly IWebHostEnvironment _env;

        public TestUserController(ITestTokenService testTokenService, IWebHostEnvironment env)
        {
            _testTokenService = testTokenService;
            _env = env;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("gettoken/user/{userId}/tenant/{tenantCode}")]
        public IActionResult GetToken(string userId, string tenantCode)
        {
            string newToken = _testTokenService.generateJwtToken(userId, tenantCode);
            return Ok(newToken);
        }
    }
}
