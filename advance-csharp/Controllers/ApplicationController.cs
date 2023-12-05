using advance_csharp.dto.Request.AppVersion;
using advance_csharp.dto.Response.AppVersion;
using advance_csharp.service;
using advance_csharp.service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace advance_csharp.Controllers
{
    [Route("api/application")]
    [ApiController]

    public class ApplicationController : ControllerBase
    {
        private readonly ILoggingService _loggingService;
        private readonly IApplicationService _applicationService;

        public ApplicationController()
        {
            _applicationService = new ApplicationService();
            _loggingService = new LoggingService();
        }

        [Route("get-version")]
        [HttpGet()]
        //[MyAppAuthentication("User")]
        public async Task<IActionResult> GetVersion([FromQuery] AppVersionGetListRequest request)
        {
            try
            {
                AppVersionGetListResponse response = await _applicationService.GetApplicationVersionList(request);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                // send to logging service
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }

        [Route("get-version-admin")]
        [HttpGet()]
        [MyAppAuthentication("Admin")]
        public async Task<IActionResult> GetVersionAdmin([FromQuery] AppVersionGetListRequest request)
        {
            try
            {
                AppVersionGetListResponse response = await _applicationService.GetApplicationVersionList(request);
                _loggingService.LogInfo(JsonSerializer.Serialize(response));
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                // send to logging service
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
