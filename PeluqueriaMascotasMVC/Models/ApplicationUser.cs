using Microsoft.AspNetCore.Identity;

namespace PeluqueriaMascotasMVC.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }

        // Para los usuarios tipo Cliente
        public int? Dni { get; set; }
        public List<Mascota> Mascotas { get; set; } = new List<Mascota>();

        public ApplicationUser()
        {
            FechaRegistro = DateTime.Now;
            Activo = true;
        }
    }
}
