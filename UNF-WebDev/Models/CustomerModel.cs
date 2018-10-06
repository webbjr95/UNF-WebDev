using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UNF_WebDev.Models
{
    public class CustomerModel
    {
        [Key]
        public int customerId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipCode { get; set; }

    }

    //Create a separate Tickets DB for the tickets. Hindsight, using a separate table within
    // the initial DB would've been fine since it would've allowed easier razor page design. 
    //ViewModel might be needed now to incorporate the available techs to the ticket dropdown.
    public class Customers : System.Data.Entity.DbContext
    {
        public Customers()
            : base()
        {

        }

        public System.Data.Entity.DbSet<CustomerModel> Customer { get; set; }
    }
}