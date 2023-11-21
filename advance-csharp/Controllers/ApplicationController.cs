using advance_csharp.database;
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
        public async Task<IActionResult> Get([FromQuery] AppVersionGetListRequest request)
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
