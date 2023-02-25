using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models
{
    public class Authority
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
