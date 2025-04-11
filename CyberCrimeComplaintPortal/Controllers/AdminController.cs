using CyberCrimeComplaintPortal.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace CyberCrimeComplaintPortal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Dashboard()
        {
            ViewBag.TotalComplaints = await _context.Complaints.CountAsync();
            ViewBag.PendingComplaints = await _context.Complaints.CountAsync(c => c.Status == "Pending");
            ViewBag.ResolvedComplaints = await _context.Complaints.CountAsync(c => c.Status == "Resolved");
            ViewBag.TotalUsers = _userManager.Users.Count();

            return View();
        }

        //public IActionResult Dashboard()
        //{
        //    return View();
        //}
    }
}
