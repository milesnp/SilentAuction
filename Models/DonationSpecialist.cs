using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SilentAuction.Models
{
    [Table("DonationSpecialists")]
    public class DonationSpecialist : Person
    {
        public int ID { get; set; }
        public ICollection<Organization> Organizations { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<WinningBid> WinningBids { get; set; }
    }
}