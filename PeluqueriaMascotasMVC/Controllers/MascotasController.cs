using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeluqueriaMascotasMVC.Data;
using PeluqueriaMascotasMVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PeluqueriaMascotasMVC.Controllers
{
    [Authorize]
    public class MascotasController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MascotasController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // ✅ GET: Mascotas (solo del usuario logueado)
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null || user.ClienteId == null)
                return Unauthorized();

            var mascotas = _context.Mascotas
                .Where(m => m.ClienteId == user.ClienteId)
                .Include(m => m.Cliente);

            return View(await mascotas.ToListAsync());
        }

        // ✅ GET: Mascotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var user = await _userManager.GetUserAsync(User);

            var mascota = await _context.Mascotas
                .Include(m => m.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mascota == null || mascota.ClienteId != user.ClienteId)
                return Unauthorized();

            return View(mascota);
        }

        // ✅ GET: Mascotas/Create
        public IActionResult Create()
        {
            return View();
        }

        // ✅ POST: Mascotas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Tipo,Edad")] Mascota mascota)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null || user.ClienteId == null)
                return Unauthorized();

            mascota.ClienteId = user.ClienteId.Value;

            if (ModelState.IsValid)
            {
                _context.Add(mascota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(mascota);
        }

        // ✅ GET: Mascotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var user = await _userManager.GetUserAsync(User);

            var mascota = await _context.Mascotas.FindAsync(id);

            if (mascota == null || mascota.ClienteId != user.ClienteId)
                return Unauthorized();

            return View(mascota);
        }

        // ✅ POST: Mascotas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Tipo,Edad")] Mascota mascota)
        {
            var user = await _userManager.GetUserAsync(User);

            if (id != mascota.Id)
                return NotFound();

            var mascotaDb = await _context.Mascotas.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (mascotaDb == null || mascotaDb.ClienteId != user.ClienteId)
                return Unauthorized();

            // 🔥 Mantener el ClienteId original
            mascota.ClienteId = mascotaDb.ClienteId;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mascota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Mascotas.Any(e => e.Id == mascota.Id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(mascota);
        }

        // ✅ GET: Mascotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var user = await _userManager.GetUserAsync(User);

            var mascota = await _context.Mascotas
                .Include(m => m.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mascota == null || mascota.ClienteId != user.ClienteId)
                return Unauthorized();

            return View(mascota);
        }

        // ✅ POST: Mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userManager.GetUserAsync(User);

            var mascota = await _context.Mascotas.FindAsync(id);

            if (mascota == null || mascota.ClienteId != user.ClienteId)
                return Unauthorized();

            _context.Mascotas.Remove(mascota);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}