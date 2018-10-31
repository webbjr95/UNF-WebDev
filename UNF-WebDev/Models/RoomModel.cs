using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
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




        public enum UnitedStatesDropDown
        {
            Alabama,
            Alaska,
            Arizona,
            Arkansas,
            California,
            Colorado,
            Connecticut,
            Delaware,
            [DefaultValue("District of Columbia")]
            District_of_Columbia,
            Florida,
            Georgia,
            Hawaii,
            Idaho,
            Illinois,
            Indiana,
            Iowa,
            Kansas,
            Kentucky,
            Louisiana,
            Maine,
            Maryland,
            Massachusetts,
            Michigan,
            Minnesota,
            Mississippi,
            Missouri,
            Montana,
            Nebraska,
            Nevada,
            [Display(Name = "New Hampshire")]
            New_Hampshire,
            [Display(Name = "New Jersey")]
            New_Jersey,
            [Display(Name = "New Mexico")]
            New_Mexico,
            [Display(Name = "New York")]
            New_York,
            [Display(Name = "North Carolina")]
            North_Carolina,
            [Display(Name = "North Dakota")]
            North_Dakota,
            Ohio,
            Oklahoma,
            Oregon,
            Pennsylvania,
            [Display(Name = "Rhode Island")]
            Rhode_Island,
            [Display(Name = "South Carolina")]
            South_Carolina,
            [Display(Name = "South Dakota")]
            South_Dakota,
            Tennessee,
            Texas,
            Utah,
            Vermont,
            Virginia,
            Washington,
            [Display(Name = "West Virginia")]
            West_Virginia,
            Wisconsin,
            Wyoming,
        }//End of the enum for the United Stest of America

        List<string> currentStateList = new List<string>(Enum.GetNames(typeof(UnitedStatesDropDown)));

        public void UpdatedStateList()
        {
            foreach (string state in currentStateList)
            {
                if (state.Contains("_"))
                {
                    state.Replace("_", " ");
                }
            }
        }

    }//End of the Room Model class

    

    public class RoomModelDb : ApplicationDbContext
    {
        //Create the tables for the DB
        public DbSet<RoomModel> Room { get; set; }
        public DbSet<CustomerModel> Customer { get; set; }
    }
}

