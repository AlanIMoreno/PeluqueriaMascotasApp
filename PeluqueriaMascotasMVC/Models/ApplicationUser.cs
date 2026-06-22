namespace PeluqueriaMascotasMVC.Models;

using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public int? ClienteId { get; set; }     // puede ser cliente
    public Cliente Cliente { get; set; }

    public int? EmpleadoId { get; set; }    // puede ser empleado
    public Empleado Empleado { get; set; }
}
