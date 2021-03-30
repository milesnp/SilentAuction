using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SilentAuction.Models
{
    public enum BidStatus
    {
        Pending, Paid
    }
    public class WinningBid
    {
        [Key]
        public int ItemID { get; set; }

        public int BidderID { get; set;}

        [Required]
        public int DonationSpecialistID { get; set; }
        
        [Required]
        [Display(Name = "Winning Bid")]
        public decimal Amount { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        [Display(Name = "Payment Status")]
        public BidStatus BidStatus { get; set; }

        public DonationSpecialist DonationSpecialist { get; set; }
        public Item Item { get; set; }
        public Bidder Bidder { get; set; }

    }
}