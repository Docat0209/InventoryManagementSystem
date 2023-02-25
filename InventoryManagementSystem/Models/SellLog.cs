using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.Models
{
    public class SellLog
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Inventory")]
        public int InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public DateTime SellDate { get; set; }
    }
}
