using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AsyncControllerProgram.Controllers
{
    
    public class HomeController : Controller
    {
        AsyncDBOEntities db = new AsyncDBOEntities();
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var list=await db.Employee.ToListAsync();

            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employee.Add(employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}