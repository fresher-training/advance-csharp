using advance_csharp.dto.Request.AppVersion;
using advance_csharp.dto.Response.AppVersion;

namespace advance_csharp.service.Interface
{
    public interface IApplicationService
    {
        /// <summary>
        /// Get application by version string
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<AppVersionGetListResponse> GetApplicationVersionList(AppVersionGetListRequest request);
    }
}
