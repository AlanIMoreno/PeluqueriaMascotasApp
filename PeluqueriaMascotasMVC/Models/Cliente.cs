namespace PeluqueriaMascotasMVC.Models
{
    public class Cliente : Persona
    {
        private int _dni;
        private List<Mascota> _mascotas;

        public Cliente()
        {
            _dni = 0;
            _mascotas = new List<Mascota>();
        }

        public Cliente(string usuario, string contraseña, string mail, DateTime fechaAlta,
            string nombre, string apellido, string telefono, string direccion, int dni)
            : base(usuario, contraseña, mail, fechaAlta, nombre, apellido, telefono, direccion)
        {
            _dni = dni;
            _mascotas = new List<Mascota>();
        }

        public int Dni
        {
            get { return _dni; }
            set { _dni = value; }
        }

        public List<Mascota> Mascotas
        {
            get { return _mascotas; }
            set { _mascotas = value ?? new List<Mascota>(); }
        }
    }
}
