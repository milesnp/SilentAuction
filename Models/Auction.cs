using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SilentAuction.Models
{
    public class Auction
    {
        public int AuctionID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Auction Name")]
        public string AuctionName { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.Date)]

        public Organization Organization { get; set; }

        public ICollection<Item> Items { get; set; }

    }
}