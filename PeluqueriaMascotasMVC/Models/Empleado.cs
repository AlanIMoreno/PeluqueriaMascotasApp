namespace PeluqueriaMascotasMVC.Models
{
    public class Empleado : Persona
    {
        public Empleado()
        {
        }

        public Empleado(string usuario, string contraseña, string mail, DateTime fechaAlta,
            string nombre, string apellido, string telefono, string direccion)
            : base(usuario, contraseña, mail, fechaAlta, nombre, apellido, telefono, direccion)
        {
        }
    }
}
