using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.Models
{
    public class PurchaseLog
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        public string Description { get; set; }
    }
}
