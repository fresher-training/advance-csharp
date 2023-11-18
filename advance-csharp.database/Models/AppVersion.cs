using System.ComponentModel.DataAnnotations.Schema;

namespace advance_csharp.database.Models
{
    [Table("appVersion")]
    public class AppVersion
    {
        public Guid Id { get; set; }
        public string Version { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; }
    }
}
