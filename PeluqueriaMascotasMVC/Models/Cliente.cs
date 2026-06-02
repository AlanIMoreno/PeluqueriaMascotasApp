namespace PeluqueriaMascotasMVC.Models
{
    public class Cliente : Persona
    {
        private List<Mascota> _mascotas;

        public Cliente()
        {
            _mascotas = new List<Mascota>();
        }

        public Cliente(string usuario, string nombre, string apellido, string email, int dni)
            : base(usuario, nombre, apellido, email)
        {
            Dni = dni;
            _mascotas = new List<Mascota>();
        }

        public List<Mascota> Mascotas
        {
            get { return _mascotas; }
            set { _mascotas = value ?? new List<Mascota>(); }
        }
    }
}
