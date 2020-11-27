using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Moviess.Models;

namespace Moviess.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A customer name is Required.")]
        [StringLength(45)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a street address.")]
        [StringLength(30)]
        [Display(Name = "Street Address")]
        public string Add { get; set; }

        [Required(ErrorMessage = "Please enter a city.")]
        [StringLength(30)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state.")]
        [StringLength(2)]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter a Zip code.")]
        public int Zip { get; set; }

        [Required(ErrorMessage = "Please enter a telephone number.")]
        public long Phone { get; set; }

        //[ageValidation]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribed { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

       // [Display(Name = "Membership")]
        //[Required(ErrorMessage = "Please select a membership type.")]
        //public byte MembershipTypeID { get; set; }
    }
}
