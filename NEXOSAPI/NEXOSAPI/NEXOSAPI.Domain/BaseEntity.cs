using System.ComponentModel.DataAnnotations;

namespace NEXOSAPI.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
