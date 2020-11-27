using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Moviess.Models;

namespace Moviess.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Customer customer { get; set; }
    }
}