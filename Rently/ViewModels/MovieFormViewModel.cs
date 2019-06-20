using Rently.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rently.ViewModels
{
    public class MovieFormViewModel
    {

        public int? Id { get; set; }

        public string Name { get; set; }
              
        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }
              
        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between {1} and {2}.")]
        [Required]
        public byte? NumberInStock { get; set; }
        public List<Genre> Genres { get; set; }

        public MovieFormViewModel()
        {
            Id = 0;

        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;

        }
    }


}