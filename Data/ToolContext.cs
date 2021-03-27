using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SilentAuction.Models;

namespace SilentAuction.Data
{
    public class ToolContext : DbContext
    {
        public ToolContext (DbContextOptions<ToolContext> options)
            : base(options)
        {
        }

        public DbSet<SilentAuction.Models.Auction> Auctions { get; set; }

        public DbSet<SilentAuction.Models.Bidder> Bidders { get; set; }

        public DbSet<SilentAuction.Models.DonationSpecialist> DonationSpecialists { get; set; }

        public DbSet<SilentAuction.Models.Item> Items { get; set; }

        public DbSet<SilentAuction.Models.Organization> Organizations { get; set; }

        public DbSet<SilentAuction.Models.WinningBid> WinningBids { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auction>().ToTable("Auctions");
            modelBuilder.Entity<Bidder>().ToTable("Bidders");
            modelBuilder.Entity<DonationSpecialist>().ToTable("DonationSpecialists");
            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<Organization>().ToTable("Organizations");
            modelBuilder.Entity<WinningBid>().ToTable("WinningBids");
        }
    }

    
}
