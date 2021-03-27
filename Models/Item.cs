using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SilentAuction.Models
{
    public enum ItemStatus 
    {
        Raffle, Booked, Printed, Sold, Paid, MarketPlace, SubItem
    }
    public enum ItemCategory
    {
        Recreation,Jewelry,Home,Photography,Food,Memorabilia,Services,
        Gifts,Automotive,Travel,LastMinute,Clothing,Educational
    }
    public class Item
    {
        public int ItemID { get; set; }

        public int AuctionID { get; set; }

        public int DonorSpecialistID { get; set; }
        public int DonorID { get; set; }

        [Required]
        public bool SuppressDonor { get; set;}

        [Required]
        [DataType(DataType.Currency)]
        public decimal Value { get; set; }
        
        [DataType(DataType.Currency)]
        public decimal? BuyItNowPrice { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal StartingBid { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal BiddingIncrement { get; set; }

        public int GroupID { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        public ItemStatus ItemStatus { get; set; }

        public string Description { get; set; }

        public string Restrictions { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        public ItemCategory ItemCategory { get; set; }

        public Auction Auction { get; set; }
        public Organization Donor { get; set; }
        public DonationSpecialist DonationSpecialist { get; set; }
        #nullable enable
        public WinningBid? WinningBid { get; set; }
        #nullable disable
    }
}