using CarRentalApp.Areas.Identity.Data;
using CarRentalApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            return View(_context.Reservations.ToList());
        }

        // GET: ReservationController/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.Reservations.Find(id));
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
        public async Task<IActionResult> Create(Reservation reservation)
        {
            reservation.UserId = _userManager.GetUserId(User);

            bool isCarUnavailable = _context.Reservations.Any(r =>
                r.CarId == reservation.CarId &&
                reservation.StartDate < r.EndDate &&
                reservation.EndDate > r.StartDate
            );

            if (isCarUnavailable)
            {
                ModelState.AddModelError("", "Ten samochód jest już zarezerwowany w wybranym terminie.");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Cars = new SelectList(_context.Car.ToList(), "Id", "FullName");
                return View(reservation);
            }

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
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
