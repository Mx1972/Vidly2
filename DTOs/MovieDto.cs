using System;
using System.ComponentModel.DataAnnotations;
using Vidly2.Models;

namespace Vidly2.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is a required field.")]
        [MaxLength(100)]
        public string Title { get; set; }        
        public DateTime ReleaseDate { get; set; }    
        
        public DateTime AddedDate { get; set; }        
        public byte NumberInStock { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
    }
}