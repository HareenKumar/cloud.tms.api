using cloud.tms.domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace cloud.tms.domain.Masters.User
{
    [Table("Users")]
    public class UserEntity : BaseEntity
    {       
        public string CompanyId { get; set; }
        public string JsonData { get; set; }
    }
}
