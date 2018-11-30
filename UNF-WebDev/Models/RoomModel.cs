using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UNF_WebDev.Models
{
    public class RoomModel
    {
        [Key]
        public int roomId { get; set; }
        public string bookingStatus { get; set; }
        public string hotelName { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipCode { get; set; }
        public int peoplePerRoom { get; set; }
        public double pricePerNight { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime checkIn { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime checkOut { get; set; }
        public string hotelDescription { get; set; }

        public virtual CustomerModel bookedBy { get; set; }


        public RoomModel()
        {
            bookingStatus = "OPEN";
        }
        public enum BookingStatusDropDown
        {
            OPEN, RESERVE
        }


        public enum UnitedStatesDropDown
        {
            AL,
            AK,
            AZ,
            AR,
            CA,
            CO,
            CT,
            DE,
            FL,
            GA,
            HI,
            ID,
            IL,
            IN,
            IA,
            KS,
            KY,
            LA,
            ME,
            MD,
            MA,
            MI,
            MN,
            MS,
            MO,
            MT,
            NE,
            NV,
            NH,
            NJ,
            NM,
            NY,
            NC,
            ND,
            OH,
            OK,
            OR,
            PA,
            RI,
            SC,
            SD,
            TN,
            TX,
            UT,
            VT,
            VA,
            WA,
            WV,
            WI,
            WY,
        }//End of the enum for the United Stest of America

    }//End of the Room Model class
    public class CustomerModel
    {
        [ForeignKey("RoomModel")]
        [Key]
        public int roomId { get; set; }
        public int customerId { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime checkIn { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime checkOut { get; set; }


        public virtual RoomModel RoomModel { get; set; }
    }


    public class RoomModelDb : ApplicationDbContext
    {
        //Create the tables for the DB
        public DbSet<RoomModel> Room { get; set; }
        public DbSet<CustomerModel> Customer { get; set; }

    }
}

