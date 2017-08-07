using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class IdEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
