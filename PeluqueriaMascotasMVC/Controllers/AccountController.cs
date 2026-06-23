namespace PeluqueriaMascotasMVC.Controllers;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PeluqueriaMascotasMVC.Data;
using PeluqueriaMascotasMVC.Models;

public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly AppDbContext _context;

    public AccountController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        AppDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }

    // ✅ ---------------- LOGIN ----------------

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(
            email,
            password,
            false,
            false);

        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "Usuario o contraseña incorrectos");
        return View();
    }

    // ✅ ---------------- LOGOUT ----------------

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    // ✅ ---------------- REGISTER CLIENTE ----------------

    [HttpGet]
    public IActionResult RegisterCliente()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterCliente(
        string nombre,
        string apellido,
        string email,
        int dni,
        string password)
    {
        // 1️⃣ Crear Cliente
        var cliente = new Cliente
        {
            Nombre = nombre,
            Apellido = apellido,
            Email = email,
            Dni = dni
        };

        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        // 2️⃣ Crear usuario Identity
        var user = new ApplicationUser
        {
            UserName = email,
            Email = email,
            ClienteId = cliente.Id
        };

        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Home");
        }

        // Si falla, mostrar errores
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }

        return View();
    }

    // ✅ ---------------- REGISTER EMPLEADO ----------------

    [HttpGet]
    public IActionResult RegisterEmpleado()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterEmpleado(
        string nombre,
        string apellido,
        string email,
        string password)
    {
        // 1️⃣ Crear Empleado
        var empleado = new Empleado
        {
            Nombre = nombre,
            Apellido = apellido,
            Email = email
        };

        _context.Empleados.Add(empleado);
        await _context.SaveChangesAsync();

        // 2️⃣ Crear usuario Identity
        var user = new ApplicationUser
        {
            UserName = email,
            Email = email,
            EmpleadoId = empleado.Id
        };

        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Home");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }

        return View();
    }
}