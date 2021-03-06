using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SilentAuction.Models
{
    public class Auction
    {
        public int ID { get; set; }

        [Required]
        public int OrganizationID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Auction Name")]
        public string AuctionName { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string Date { get; set;}

        public Organization Organization { get; set; }

        public ICollection<Item> Items { get; set; }

    }
}