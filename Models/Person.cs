using System.ComponentModel.DataAnnotations;

namespace SilentAuction.Models
{ 
    public class Person {
        public int PersonID{ get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Cell Number")]
        public uint CellNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public uint PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string AddressOne { get; set; }

        public string AddressTwo { get; set; }

        public string City { get; set; }

        [DataType(DataType.PostalCode)]
        public int ZipCode { get; set; }

        public string Notes { get; set; }


    }
}