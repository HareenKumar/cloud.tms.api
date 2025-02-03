using cloud.tms.domain.Common;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace cloud.tms.domain.Masters.User
{
    [Table("Users")]
    public class UserEntity : BaseEntity
    {       
        public string CompanyId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; } // Store hashed password
        public string PasswordSalt { get; set; } // Store salt for extra security

        [Column(TypeName  = "jsonb")]
        public JsonDocument JsonData { get; set; }

        //// Optional: Helper Property to Serialize/Deserialize JSON Objects
        //[NotMapped]
        //[Newtonsoft.Json.JsonIgnore] // Prevents EF from mapping this field
        //public Dictionary<string, object>? JsonDataObject
        //{
        //    get => JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonData);
        //    set => JsonData = JsonConvert.SerializeObject(value);
        //}

        
    }
}
