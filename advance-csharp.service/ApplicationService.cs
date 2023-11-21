using advance_csharp.database;
using advance_csharp.database.Models;
using advance_csharp.dto.Request.AppVersion;
using advance_csharp.dto.Response.AppVersion;
using advance_csharp.service.Interface;
using Microsoft.EntityFrameworkCore;

namespace advance_csharp.service
{
    public class ApplicationService : IApplicationService
    {
        public async Task<AppVersionGetListResponse> GetApplicationVersionList(AppVersionGetListRequest request)
        {
            AppVersionGetListResponse appVersionGetListResponse = new AppVersionGetListResponse()
            {
                PageSize = request.PageSize,
                PageIndex = request.PageIndex
            };
            using (AdvanceCsharpContext context = new AdvanceCsharpContext())
            {
                IQueryable<AppVersion> query = context.AppVersions.Where(a=>a.Version.Contains(request.Version)); // not excute
                appVersionGetListResponse.Data = await query.Select(a=> new AppVersionResponse
                {
                    Id = a.Id,
                    Version = a.Version
                }).ToListAsync();
            }
            return appVersionGetListResponse;
        }
    }
}