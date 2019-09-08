using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ORMCrudOperations.Models;

namespace ORMCrudOperations.Controllers
{
    public class AirlineController : Controller
    {
       private RMSContext ORM = null;
        public AirlineController(RMSContext _ORM)
        {
            ORM = _ORM;
        }


        [HttpGet]
       public IActionResult AddNewAirline()
        {
            return View();
        }

        [HttpPost]
        public   IActionResult AddNewAirline(Airline A)
        {
            try
            {
                ORM.Airline.AddAsync(A);
                ORM.SaveChangesAsync();
                ViewBag.Message = A.Name+ " Airline saved Successfully!";
                ViewBag.MessageType = "S";
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Error in saving the data, please try again.";
                ViewBag.MessageType = "E";
                
                //return View();
            }

            //option 1
            //return RedirectToAction("AddNewAirline

            return View();
        }


        public IActionResult AllAirlines()
        {
            return View(ORM.Airline.ToList());
        }

        public IActionResult DeleteAirline(int id)
        {
            var A = ORM.Airline.Find(id);
            ORM.Airline.Remove(A);
            ORM.SaveChanges();

            return RedirectToAction("AllAirlines");
        }


        [HttpGet]
        public IActionResult EditAirline(int id)
        {
            var A = ORM.Airline.Find(id);
            return View(A);
        }

        [HttpPost]
        public IActionResult EditAirline(Airline A)
        {
            ORM.Airline.Update(A);
            ORM.SaveChanges();
            return RedirectToAction("AllAirlines");
        }

        public IActionResult ViewAirlineDetail(int id)
        {
          return View(ORM.Airline.Find(id));
        }




    }
}