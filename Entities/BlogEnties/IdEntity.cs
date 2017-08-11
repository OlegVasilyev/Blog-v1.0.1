using System.ComponentModel.DataAnnotations;
namespace Entities.Models
{
    public class IdEntity
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
    }
}
