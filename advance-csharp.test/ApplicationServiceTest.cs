using advance_csharp.dto.Request.AppVersion;
using advance_csharp.dto.Response.AppVersion;
using advance_csharp.service;
using advance_csharp.service.Interface;

namespace advance_csharp.test
{
    [TestClass]
    public class ApplicationServiceTest
    {
        private IApplicationService _ApplicationService;

        public ApplicationServiceTest()
        {
            _ApplicationService = new ApplicationService();
        }

        /// <summary>
        /// GetApplicationVersionList happy case request
        /// </summary>
        [TestMethod]
        public async Task GetApplicationVersionListTestAsync()
        {
            // Input
            AppVersionGetListRequest request = new AppVersionGetListRequest()
            {
                PageIndex = 1,
                PageSize = 10,
                Version = string.Empty
            };
            // Output
            AppVersionGetListResponse response = await _ApplicationService.GetApplicationVersionList(request);
            Assert.IsNotNull(response); // response not null
            Assert.IsTrue(response.Data.Count > 0); // response data > 0
        }

        /// <summary>
        /// GetApplicationVersionListWithVersion exception case request
        /// </summary>
        [TestMethod]
        public async Task GetApplicationVersionListWithVersionTestAsync()
        {
            // Input
            AppVersionGetListRequest request = new AppVersionGetListRequest()
            {
                PageIndex = 1,
                PageSize = 10,
                Version = "0.0.1"
            };
            // Output
            AppVersionGetListResponse response = await _ApplicationService.GetApplicationVersionList(request);
            Assert.IsNotNull(response); // response not null
            Assert.IsTrue(response.Data.Count == 1); // response data > 0
        }
    }
}