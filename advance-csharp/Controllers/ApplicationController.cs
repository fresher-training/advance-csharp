using advance_csharp.database;
using advance_csharp.database.Models;
using advance_csharp.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace advance_csharp.Controllers
{
    [Route("api/application")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        [Route("get-version")]
        [HttpGet()]
        public async Task<IEnumerable<AppVersion>> Get([FromQuery] string version)
        {
            List<AppVersion> versions = new List<AppVersion>();
            using (AdvanceCsharpContext context = new AdvanceCsharpContext())
            {
                versions = await context.AppVersions.Where(a => a.Version.Contains(version)).ToListAsync();
            }
            return versions;
        }
    }
}
