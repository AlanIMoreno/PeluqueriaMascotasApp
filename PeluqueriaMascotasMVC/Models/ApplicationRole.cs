using Microsoft.AspNetCore.Identity;

namespace PeluqueriaMascotasMVC.Models
{
    public class ApplicationRole : IdentityRole<int>
    {
        public string? Descripcion { get; set; }

        public ApplicationRole()
        {
        }

        public ApplicationRole(string roleName, string? descripcion = null)
        {
            Name = roleName;
            Descripcion = descripcion;
        }
    }
}
