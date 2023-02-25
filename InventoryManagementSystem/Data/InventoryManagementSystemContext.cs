using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Data
{
    public class InventoryManagementSystemContext : DbContext
    {
        public InventoryManagementSystemContext (DbContextOptions<InventoryManagementSystemContext> options)
            : base(options)
        {
        }

        public DbSet<InventoryManagementSystem.Models.Authority> Authority { get; set; } = default!;

        public DbSet<InventoryManagementSystem.Models.User> User { get; set; }

        public DbSet<InventoryManagementSystem.Models.Supplier> Supplier { get; set; }

        public DbSet<InventoryManagementSystem.Models.PurchaseLog> PurchaseLog { get; set; }

        public DbSet<InventoryManagementSystem.Models.Item> Item { get; set; }

        public DbSet<InventoryManagementSystem.Models.Inventory> Inventory { get; set; }

        public DbSet<InventoryManagementSystem.Models.SellLog> SellLog { get; set; }
    }
}
