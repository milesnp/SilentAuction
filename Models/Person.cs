using System.ComponentModel.DataAnnotations;

namespace SilentAuction.Models
{ 
    public class Person {
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }
        
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Cell Number")]
        public string CellNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Address Line 1")]
        public string AddressOne { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressTwo { get; set; }

        public string City { get; set; }

        [StringLength(2)]
        [RegularExpression("[A-Z][A-Z]")]
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        [DataType(DataType.PostalCode)]
        public int ZipCode { get; set; }

        public string Notes { get; set; }


    }
}