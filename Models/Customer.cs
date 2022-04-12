using System;
using System.ComponentModel.DataAnnotations;
using Vidly2.BusinessRules;

namespace Vidly2.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage= "Name is a required field.")]
        [MaxLength(75, ErrorMessage = "Maximum length for the Name is 75 characters.")]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }        
        public MembershipType MembershipType { get; set; }


        [Required(ErrorMessage = "Membership Type is a required field.")]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

                 
        [Display(Name="Date Of Birth")]
        [MinAgeRule]
        public DateTime? DOB { get; set; }

    }
}