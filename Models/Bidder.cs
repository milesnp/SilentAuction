using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SilentAuction.Models
{
    [Table("Bidders")]
    public class Bidder : Person
    {
        public ICollection<WinningBid> WinningBids { get; set; }
    }
}