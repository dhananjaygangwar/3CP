using Microsoft.AspNetCore.Mvc;
using CyberCrimeComplaintPortal.Data;
using CyberCrimeComplaintPortal.Models;
using Microsoft.AspNetCore.Authorization;

namespace CyberCrimeComplaintPortal.Controllers
{
    public class ComplaintController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ComplaintController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Authorize(Roles = "Admin")]
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
        //[Authorize(Roles = "Admin")]//kill me ;-;, eff this line
        [ValidateAntiForgeryToken]
        public IActionResult Create(Complaint obj)
        {
            if (ModelState.IsValid)
            {
                _db.Complaints.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Complaint Submitted Successfully!";
                return RedirectToAction("ThankYou");// can change this later

            }
            return View(obj);
        }
        public IActionResult ThankYou()
        {
            return View();
        }


        // Edit section for admin panel
        // GET : Edit
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var complaintFromDb = _db.Complaints.Find(id);

            if (complaintFromDb == null)
            {
                return NotFound();
            }
            return View(complaintFromDb);

        }

        //POST : Edit
        [HttpPost]
        [Authorize(Roles = "Admin")] 
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Complaint obj)
        {
            if (ModelState.IsValid)
            {
                _db.Complaints.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Complaint status updated Successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // GET : DELETE
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var complaintFromDb = _db.Complaints.Find(id);

            if (complaintFromDb == null)
            {
                return NotFound();
            }
            return View(complaintFromDb);

        }

        //POST : DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            var obj = _db.Complaints.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Complaints.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Complaint Deleted succesfully!";
            return RedirectToAction(nameof(Index));
                        
        }


    }
}
