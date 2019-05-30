using Rently.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rently.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> GenreTypes { get; set; }
        public Movie Movie { get; set; }
    }
}