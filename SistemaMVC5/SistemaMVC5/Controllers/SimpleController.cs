using SistemaMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaMVC5.Controllers
{
    public class SimpleController : Controller
    {
        // GET: Simple
        public ActionResult Index()
        {
            var person = new Person
            {
                FirstName = "Roque",
                LastName = "Galan",
                BirthDate = new DateTime(1989, 2, 7),
                LikesMusic = true,
                EmailAddress = "roque.ggalan@gmail.com",
                Skills = new List<string>() { "Math", "Science", "History" }
            };

            return View(person);
        }

        public ActionResult Create()
        {
            var person = new Person();
            return View(person);
        }
    }
}