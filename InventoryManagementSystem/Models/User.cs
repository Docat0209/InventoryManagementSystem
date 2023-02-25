using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Account { get; set; }
        [Required]
        public string Password { get; set; }

        [ForeignKey("Authority")]
        public int AuthorityId { get; set; }
        public virtual Authority Authority { get; set; }
    }

}
