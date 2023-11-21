using System.ComponentModel.DataAnnotations.Schema;

namespace advance_csharp.database.Models
{
    [Table("appVersion")]
    public class AppVersion : BaseEntity
    {
        public string Version { get; set; } = string.Empty;
    }
}
