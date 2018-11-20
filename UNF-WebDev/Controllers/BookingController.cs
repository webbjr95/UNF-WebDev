using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UNF_WebDev.Models;

namespace UNF_WebDev.Controllers
{
    //TODO: Add in the option for filtering like I did the helpdesk program.
    //Maybe look into building out the form for submissions.
    public class BookingController : Controller
    {
        private RoomModelDb db = new RoomModelDb();

        // GET: Rooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomModel roomModel = db.Room.Find(id);
            if (roomModel == null)
            {
                return HttpNotFound();
            }
            return View(roomModel);
        }

        // GET: Rooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "roomId,bookingStatus,hotelName,city,state,zipCode,peoplePerRoom,pricePerNight,checkIn,checkOut")] RoomModel roomModel)
        {
            if (ModelState.IsValid)
            {
                db.Room.Add(roomModel);
                db.SaveChanges();
                return RedirectToAction("Search");
            }

            return View(roomModel);
        }

        // GET: Rooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomModel roomModel = db.Room.Find(id);
            if (roomModel == null)
            {
                return HttpNotFound();
            }
            return View(roomModel);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "roomId,bookingStatus,hotelName,city,state,zipCode,peoplePerRoom,pricePerNight,checkIn,checkOut")] RoomModel roomModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Search");
            }
            return View(roomModel);
        }

        // GET: Rooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomModel roomModel = db.Room.Find(id);
            if (roomModel == null)
            {
                return HttpNotFound();
            }
            return View(roomModel);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoomModel roomModel = db.Room.Find(id);
            db.Room.Remove(roomModel);
            db.SaveChanges();
            return RedirectToAction("Search");
        }

        public ActionResult Search(string sortOrder)
        {
            return SortFunction(sortOrder, "open");
        }

        /**********************************/
        //Custom function for all the sorting
        //to be handled in one spot versus
        //having all of the same code repeated
        //within each view.
        /**********************************/
        public ViewResult SortFunction(string sortOrder, string bookingStatus)
        {

            //Store the type of sort that needs to be applied to the column
            ViewBag.HotelNameSortParm = (String.IsNullOrEmpty(sortOrder) || sortOrder.Equals("hotel_name_asc")) ? "hotel_name_desc" : "hotel_name_asc";
            ViewBag.CitySortParm = (String.IsNullOrEmpty(sortOrder) || sortOrder.Equals("city_asc")) ? "city_desc" : "city_asc";
            ViewBag.StateSortParm = (String.IsNullOrEmpty(sortOrder) || sortOrder.Equals("state_asc")) ? "state_desc" : "state_asc";
            ViewBag.PeoplePerRoomSortParm = (String.IsNullOrEmpty(sortOrder) || sortOrder.Equals("people_per_room_asc")) ? "people_per_room_desc" : "people_per_room_asc";
            ViewBag.PricePerNightSortParm = (String.IsNullOrEmpty(sortOrder) || sortOrder.Equals("price_per_night_asc")) ? "price_per_night_desc" : "price_per_night_asc";

            //Start the DB query for the sorting.
            var rooms = from t in db.Room
                          select t;

            //Quick test to help with the different ticket status views.
            rooms = rooms.Where(t => t.bookingStatus.Equals("open"));


            //To handle the sorting for each section and which direction is needed.
            switch (sortOrder)
            {
                case "hotel_name_asc":
                    rooms = rooms.OrderBy(t => t.hotelName);
                    break;
                case "hotel_name_desc":
                    rooms = rooms.OrderByDescending(t => t.hotelName);
                    break;
                case "city_asc":
                    rooms = rooms.OrderBy(t => t.city);
                    break;
                case "city_desc":
                    rooms = rooms.OrderByDescending(t => t.city);
                    break;
                case "state_asc":
                    rooms = rooms.OrderBy(t => t.state);
                    break;
                case "state_desc":
                    rooms = rooms.OrderByDescending(t => t.state);
                    break;
                case "people_per_room_asc":
                    rooms = rooms.OrderBy(t => t.peoplePerRoom);
                    break;
                case "people_per_room_desc":
                    rooms = rooms.OrderByDescending(t => t.peoplePerRoom);
                    break;
                case "price_per_night_asc":
                    rooms = rooms.OrderBy(t => t.pricePerNight);
                    break;
                case "price_per_night_desc":
                    rooms = rooms.OrderByDescending(t => t.pricePerNight);
                    break;
            }//End of SWTICH for sortOrder

            return View(rooms.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
