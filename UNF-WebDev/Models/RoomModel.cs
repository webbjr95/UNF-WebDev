using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UNF_WebDev.Models
{
    public class RoomModel
    {
        [Key]
        public int roomId { get; set; }
        public string hotelName { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipCode { get; set; }
        public int roomSquareFootage { get; set; }
        public int peoplePerRoom { get; set; }
        public double pricePerNight { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
    }

    //Create a separate Tickets DB for the tickets. Hindsight, using a separate table within
    // the initial DB would've been fine since it would've allowed easier razor page design. 
    //ViewModel might be needed now to incorporate the available techs to the ticket dropdown.
    public class Rooms : System.Data.Entity.DbContext
    {
        public Rooms()
            : base()
        {

        }

        public System.Data.Entity.DbSet<RoomModel> Room { get; set; }
    }
}