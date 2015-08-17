using MvcModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcModels.Controllers
{
    public class HomeController : Controller
    {
        private Person[] personData = {
            new Person { PersonId = 1, FirstName = "Adam", 
                LastName = "Freeman", Role = Role.Admin}, 
            new Person { PersonId = 2, FirstName = "Steven", 
                LastName = "Sanderson", Role = Role.Admin},
            new Person { PersonId = 3, FirstName = "Jacqui", 
                LastName = "Griffyth", Role = Role.Admin},
            new Person { PersonId = 4, FirstName = "John", 
                LastName = "Smith", Role = Role.Admin},
            new Person { PersonId = 5, FirstName = "Anne", 
                LastName = "Jones", Role = Role.Admin}
        };

        public ActionResult Index(int? id = 1)
        {
            Person dataItem = personData.Where(p => p.PersonId == id).First();
            return View(dataItem);
        }

        public ActionResult CreatePerson()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult CreatePerson(Person model)
        {
            return View("Index", model);
        }

        public ActionResult DisplaySummary([Bind(Prefix="HomeAddress")]AddressSummary summary)
        {
            return View(summary);
        }

        public ActionResult Names(IList<string> names)
        {
            names = names ?? new List<string>();
            return View(names);
        }

        public ActionResult AddressOld(FormCollection formData)
        {
            IList<AddressSummary> addresses = new List<AddressSummary>();
            try
            {
                UpdateModel(addresses, formData);
            }
            catch (InvalidOperationException ex)
            {
                //provide feedback to user
            }
            return View(addresses);
        }
        public ActionResult Address()
        {
            IList<AddressSummary> addresses = new List<AddressSummary>();
            if (TryUpdateModel(addresses))
            {
                // preceed as normal
            }
            else
            {
                // provide feedback to user
            }
            return View(addresses);
        }
    }
}
