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
            AppVersionGetListResponse appVersionGetListResponse = new()
            {
                PageSize = request.PageSize,
                PageIndex = request.PageIndex
            };
            throw new NotImplementedException("Log4net bắt đi");
            using (AdvanceCsharpContext context = new())
            {
                if (context.AppVersions != null)
                {
                    IQueryable<AppVersion> query = context.AppVersions
                    .Where(a => a.Version.Contains(request.Version))
                    .OrderBy(a => a.Version)
                    .AsQueryable(); // not excute

                    // Debug linq
                    string queryString = query
                        .Skip(request.PageSize * (request.PageIndex - 1))
                        .Take(request.PageSize).ToQueryString();
                    Console.WriteLine(queryString);

                    appVersionGetListResponse.Data = await query
                        .Skip(request.PageSize * (request.PageIndex - 1))
                        .Take(request.PageSize)
                        .Select(a => new AppVersionResponse
                        {
                            Id = a.Id,
                            Version = a.Version
                        }).ToListAsync();

                    _ = await query.CountAsync();
                }
            }
            return appVersionGetListResponse;
        }
    }
}