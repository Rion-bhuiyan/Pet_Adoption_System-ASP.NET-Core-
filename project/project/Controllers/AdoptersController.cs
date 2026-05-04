using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;
using project.Models.ViewModels;

namespace project.Controllers
{
    public class AdoptersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _he;

        public AdoptersController(ApplicationDbContext context, IWebHostEnvironment he)
        {
            _context = context;
            _he = he;
        }

        public async Task<IActionResult> Index()
        {
            var adopters = await _context.Adopters
                .Include(x => x.AdoptionEntries)
                .ThenInclude(y => y.Pet)
                .ToListAsync();
            return View(adopters);
        }

        public IActionResult AddNewPet(int? id)
        {
            ViewBag.petList = new SelectList(_context.Pets, "PetId", "PetName", id);
            return PartialView("_addNewPet");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdopterVM adopterVM, int[] petId)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest(errors);
            }

            var adopter = new Adopter()
            {
                AdopterName = adopterVM.AdopterName.Trim(),
                BirthDate = adopterVM.BirthDate,
                Age = adopterVM.Age,
                MaritalStatus = adopterVM.Maritalstatus
            };

            if (adopterVM.PictureFile != null)
            {
                string folder = "Images";
                string ext = Path.GetExtension(adopterVM.PictureFile.FileName);
                string imgFileName = Path.GetRandomFileName() + ext;
                string fileSave = Path.Combine(_he.WebRootPath, folder, imgFileName);

                using (var stream = new FileStream(fileSave, FileMode.Create))
                {
                    await adopterVM.PictureFile.CopyToAsync(stream);
                }

                adopter.Picture = "/" + folder + "/" + imgFileName;
            }

            _context.Adopters.Add(adopter);
            await _context.SaveChangesAsync();

            if (petId != null && petId.Length > 0)
            {
                foreach (var item in petId)
                {
                    _context.AdoptionEntries.Add(new AdoptionEntry
                    {
                        AdopterId = adopter.AdopterId,
                        PetId = item
                    });
                }
                await _context.SaveChangesAsync();
            }

            return Ok("success");
        }

        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            var adopter = await _context.Adopters
                .Include(x => x.AdoptionEntries)
                .FirstOrDefaultAsync(x => x.AdopterId == id);

            if (adopter == null) return NotFound();

            var adopterVM = new AdopterVM()
            {
                AdopterId = adopter.AdopterId,
                AdopterName = adopter.AdopterName,
                BirthDate = adopter.BirthDate,
                Age = adopter.Age,
                Picture = adopter.Picture,
                Maritalstatus = adopter.MaritalStatus
            };

            foreach (var item in adopter.AdoptionEntries)
            {
                adopterVM.PetList.Add(item.PetId);
            }

            return View(adopterVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AdopterVM adopterVM, int[] petId)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest(errors);
            }

            var adopter = await _context.Adopters.FindAsync(adopterVM.AdopterId);
            if (adopter == null) return NotFound();

            adopter.AdopterName = adopterVM.AdopterName.Trim();
            adopter.BirthDate = adopterVM.BirthDate;
            adopter.Age = adopterVM.Age;
            adopter.MaritalStatus = adopterVM.Maritalstatus;

            if (adopterVM.PictureFile != null)
            {
                string folder = "Images";
                string ext = Path.GetExtension(adopterVM.PictureFile.FileName);
                string imgFileName = Path.GetRandomFileName() + ext;
                string fileSave = Path.Combine(_he.WebRootPath, folder, imgFileName);

                using (var stream = new FileStream(fileSave, FileMode.Create))
                {
                    await adopterVM.PictureFile.CopyToAsync(stream);
                }

                adopter.Picture = "/" + folder + "/" + imgFileName;
            }

            var oldEntries = _context.AdoptionEntries.Where(x => x.AdopterId == adopter.AdopterId).ToList();
            _context.AdoptionEntries.RemoveRange(oldEntries);

            if (petId != null && petId.Length > 0)
            {
                foreach (var item in petId)
                {
                    _context.AdoptionEntries.Add(new AdoptionEntry
                    {
                        AdopterId = adopter.AdopterId,
                        PetId = item
                    });
                }
            }

            _context.Update(adopter);
            await _context.SaveChangesAsync();

            return Ok("success");
        }

        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            var adopter = await _context.Adopters.FindAsync(id);
            if (adopter != null)
            {
                var relatedEntries = _context.AdoptionEntries.Where(x => x.AdopterId == id).ToList();
                _context.AdoptionEntries.RemoveRange(relatedEntries);
                _context.Adopters.Remove(adopter);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}