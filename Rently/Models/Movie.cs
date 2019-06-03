using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rently.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }
       
        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between {} and {1}.")]
        public byte NumberInStock { get; set; }
    }
}