using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UNF_WebDev.Models
{
    public class HotelModel
    {
        [Key]
        public int hotelId { get; set; }
        public string hotelName { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipCode { get; set; }
        public int NumOfRooms { get; set; }
    }

    //Create a separate Tickets DB for the tickets. Hindsight, using a separate table within
    // the initial DB would've been fine since it would've allowed easier razor page design. 
    //ViewModel might be needed now to incorporate the available techs to the ticket dropdown.
    public class Hotels : System.Data.Entity.DbContext
    {
        public Hotels()
            : base()
        {

        }

        public System.Data.Entity.DbSet<HotelModel> Hotel { get; set; }
    }
}