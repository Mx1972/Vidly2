using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage= "Title is a required field.")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Release Date is a required field.")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Added Date  is a required field.")]
        [Display(Name ="Date Added")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AddedDate { get; set; }

        [Required(ErrorMessage = "Number In Stock is a required field.")]
        [Range(1, 20, ErrorMessage = "Must be between 1 to 20")]
        [Display(Name = "Number In Stock")]
        public byte NumberInStock { get; set; }


        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
    }
}