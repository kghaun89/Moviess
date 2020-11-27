using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Moviess.Models;

namespace Moviess.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set;  }

        public Movie movie { get; set; }
    }
}