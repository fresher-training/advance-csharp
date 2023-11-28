using advance_csharp.dto.Request.AppVersion;
using advance_csharp.dto.Response.AppVersion;
using advance_csharp.service;
using advance_csharp.service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace advance_csharp.Controllers
{
    [Route("api/application")]
    [ApiController]

    public class ApplicationController : ControllerBase
    {
        private IApplicationService _ApplicationService;

        public ApplicationController()
        {
            _ApplicationService = new ApplicationService();
        }

        [Route("get-version")]
        [HttpGet()]
        [MyAppAuthentication("User")]
        public async Task<IActionResult> GetVersion([FromQuery] AppVersionGetListRequest request)
        {
            try
            {
                AppVersionGetListResponse response = await _ApplicationService.GetApplicationVersionList(request);
                return new JsonResult(response);
            }
            catch (NullReferenceException nullEX)
            {
                // send to logging service
                Console.WriteLine(nullEX.Message);
                return StatusCode(500, nullEX.Message);
            }
            catch (Exception ex)
            {
                // send to logging service
                Console.WriteLine(ex.Message);
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
                AppVersionGetListResponse response = await _ApplicationService.GetApplicationVersionList(request);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                // send to logging service
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
