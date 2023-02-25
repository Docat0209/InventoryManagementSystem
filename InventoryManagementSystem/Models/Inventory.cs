using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("PurchaseLog")]
        public int PurchaseLogId { get; set; }
        public virtual PurchaseLog PurchaseLog { get; set; }
    }
}
