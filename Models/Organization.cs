using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SilentAuction.Models {
    public enum DonorStatus {
        New, Contacted, Promised, Ready, PickedUp, Received, Declined
    }   
    public enum PreferredContact{
        Cell, Phone, Email
    }
    [Table("Organizations")]
    public class Organization : Person 
    {
        public int ID { get; set; }
        public int DonorSpecialistID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [StringLength(50)]
        [Display(Name = "Contact Title")]
        public string ContactTitle { get; set; }
        [DataType(DataType.Url)]
        public string Website {get; set; }
        [Column(TypeName = "nvarchar(24)")]
        [Display(Name = "Donor Status")]
        public DonorStatus DonorStatus { get; set;} = DonorStatus.New;

        [Display(Name = "Preferred Contact Method")]
        [Column(TypeName = "nvarchar(24)")]
        public PreferredContact PreferredContact { get; set; }

        public ICollection<Auction> Auctions { get; set; }
        public ICollection<Item> Items { get; set; }
        public DonationSpecialist DonationSpecialist { get; set; }
        
    }
}