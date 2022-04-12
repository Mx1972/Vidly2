using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly2.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(75, ErrorMessage = "Maximum length for the Name is 75 characters.")]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public byte MembershipTypeId { get; set; }
               
        //[MinAgeRule]
        public DateTime? DOB { get; set; }
    }
}