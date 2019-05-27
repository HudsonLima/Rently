using Rently.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rently.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MemberShipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}