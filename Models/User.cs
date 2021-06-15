using System;
using System.ComponentModel.DataAnnotations;

namespace UserDirectory.Models
{
    // User data must have Name, Surname, Email, Birth Date, Phone, Location, and optional Photo.
    public class User
    {
        public int Id {get; set;}
        
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must contain minimum 3 characters and maximum 30 characters")]
        [Required(ErrorMessage = "You must provide a name")]
        public string Name {get; set; }
        
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Surname must contain minimum 3 characters and maximum 30 characters")]
        [Required(ErrorMessage = "You must provide a surname")]
        public string Surname {get; set;}

        [Required, DataType(DataType.EmailAddress)]
        public string Email {get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate {get; set; }
        
        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone {get; set;}

        [Required(ErrorMessage = "You must provide a location")]
        public string Location {get; set;} 
    }
}