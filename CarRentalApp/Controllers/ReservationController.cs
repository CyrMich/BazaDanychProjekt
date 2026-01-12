using CarRentalApp.Areas.Identity.Data;
using CarRentalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarRentalApp.Controllers
{
    public class ReservationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;
        public ReservationController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ReservationController
        public ActionResult Index()
        {
            var reservations = _context.Reservations
            .Include(r => r.Car)  
            .Include(r => r.User) 
            .ToList();

            return View(reservations);
        }

        // GET: ReservationController/Details/5
        public ActionResult Details(int id)
        {
            var reservation = _context.Reservations
            .Include(r => r.Car)  
            .Include(r => r.User) 
            .FirstOrDefault(r => r.Id == id);

            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: ReservationController/Create
        public ActionResult Create()
        {
            ViewBag.Cars = new SelectList(_context.Car.ToList(), "Id", "FullName");
            return View();
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(Reservation reservation)
        {
            reservation.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ModelState.Remove("UserId"); 

            if (ModelState.IsValid)
            {
                bool isCarOccupied = _context.Reservations.Any(r =>
                    r.CarId == reservation.CarId &&
                    reservation.StartDate < r.EndDate &&
                    reservation.EndDate > r.StartDate);

                if (isCarOccupied)
                {
                    ModelState.AddModelError("", "Przepraszamy, ten samochód jest już zarezerwowany w wybranym terminie.");

                    ViewData["CarId"] = new SelectList(_context.Car, "Id", "Model", reservation.CarId);
                    return View(reservation);
                }

                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CarId"] = new SelectList(_context.Car , "Id", "Model", reservation.CarId);
            return View(reservation);
        }

        // GET: ReservationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservationController/Edit/5
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

        // GET: ReservationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservationController/Delete/5
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
    }
}
