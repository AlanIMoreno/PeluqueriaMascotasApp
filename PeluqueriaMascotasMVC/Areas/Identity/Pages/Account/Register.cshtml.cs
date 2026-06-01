using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeluqueriaMascotasMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace PeluqueriaMascotasMVC.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; } = default!;

        [TempData]
        public string? ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "El nombre es requerido")]
            [StringLength(100)]
            public string Nombre { get; set; } = "";

            [Required(ErrorMessage = "El apellido es requerido")]
            [StringLength(100)]
            public string Apellido { get; set; } = "";

            [Required(ErrorMessage = "El correo electrónico es requerido")]
            [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
            public string Email { get; set; } = "";

            [Phone(ErrorMessage = "El teléfono no es válido")]
            public string? Telefono { get; set; }

            [Required(ErrorMessage = "El DNI es requerido")]
            [Range(0, int.MaxValue, ErrorMessage = "El DNI debe ser un número válido")]
            public int Dni { get; set; }

            [Required(ErrorMessage = "La contraseña es requerida")]
            [StringLength(100, ErrorMessage = "La contraseña debe tener entre {2} y {1} caracteres", MinimumLength = 8)]
            [DataType(DataType.Password)]
            public string Password { get; set; } = "";

            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
            public string ConfirmPassword { get; set; } = "";
        }

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    Nombre = Input.Nombre,
                    Apellido = Input.Apellido,
                    PhoneNumber = Input.Telefono,
                    Dni = Input.Dni
                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("Usuario {Email} creó una cuenta", Input.Email);

                    // Asignar rol de Cliente por defecto
                    await _userManager.AddToRoleAsync(user, "Cliente");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect("~/");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}
