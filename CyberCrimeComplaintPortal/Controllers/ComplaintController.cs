using Microsoft.AspNetCore.Mvc;
using CyberCrimeComplaintPortal.Data;
using CyberCrimeComplaintPortal.Models;

namespace CyberCrimeComplaintPortal.Controllers
{
    public class ComplaintController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ComplaintController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var complaints = _db.Complaints.ToList();
            return View(complaints);
        }


        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Complaint obj)
        {
            if (ModelState.IsValid)
            {
                _db.Complaints.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Complaint Submitted Successfully!";
                return RedirectToAction(nameof(Index)); // can change this later
            }
            return View(obj);
        }


    }
}
