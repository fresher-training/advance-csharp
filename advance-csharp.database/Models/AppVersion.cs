using advance_csharp.database.Interface;
using advance_csharp.dto.Response.AppVersion;
using System.ComponentModel.DataAnnotations.Schema;

namespace advance_csharp.database.Models
{
    [Table("appVersion")]
    public class AppVersion : BaseEntity, ITransform<AppVersionResponse>
    {
        public string Version { get; set; } = string.Empty;

        public AppVersionResponse Transform()
        {
            return new AppVersionResponse()
            {
                Id = Id,
                Version = Version
            };
        }
    }
}
