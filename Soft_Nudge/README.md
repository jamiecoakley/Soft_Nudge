using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Soft_Nudge
{
    public class README : Controller
    {
        // GET: README
        public ActionResult Index()
        {
            return View();
        }

        // GET: README/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: README/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: README/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: README/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: README/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: README/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: README/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        #Soft Nudge Application
        Soft Nudge was created to help someone take inititaive to take care of themselves during a hard time, such as a depressive episode or just being stuck in a rut. Users input their own categories and tasks, referred to as "Nudges," so that they can be randomly given to them on the home page as a "Nudge" to go do something. The idea is to help the user break away from bad habits such as mindless scrolling and go do something productive and intentional.
        The code is annotated showing the order of operations (steps 1 - 4).

        This assignment was created for Eleven Fifty Academy Software Development cohort 160, calling for students to build a fully functioning application uzing Blazor or MVC n-tier architechture.

        ##Table of Contents
        - Requirements
        - Installation
        - Troubleshooting
        - Maintainers

        ##Requirements
        Your favorite browser should do the trick, but I recommend Google Chrome.

        ##Installation
        Use the URL: 

        ##Troubleshooting
        Please contact me with any issues.

        ##Maintainer
        - Jamie Coakley (https://github.com/jamiecoakley)

    }
}
