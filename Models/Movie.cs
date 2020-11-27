using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Moviess.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a movie name.")]
        [StringLength(55)]
        public string Name { get; set; }
        

        
        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Please enter a movie genre.")]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

       
        [Required(ErrorMessage = "Please enter a release date.")]
        [Display(Name = "Release Date")]
        public DateTime?  ReleaseDate { get; set; }

        
        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }

        
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        
        [Required(ErrorMessage = "Please enter how many are in stock.")]
        [Display(Name = "Number in Stock")]
        [Range(1, 20, ErrorMessage =("Number must be 1-20"))]
        public int InStock { get; set; }


    }
}
