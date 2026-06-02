namespace PeluqueriaMascotasMVC.Models
{
    public class Empleado : Persona
    {
        public Empleado()
        {
        }

        public Empleado(string usuario, string nombre, string apellido, string email)
            : base(usuario, nombre, apellido, email)
        {
        }
    }
}
