namespace PeluqueriaMascotasMVC.Models
{
    public class Cliente : Persona
    {

        private List<Mascota> _mascotas;

        public Cliente()
        {
            _mascotas = new List<Mascota>();
        }

        public Cliente(string nombre, string apellido, string email, int dni)
               : base(nombre, apellido)
        {
            Dni = dni;
            Email = email;
            _mascotas = new List<Mascota>();
        }

        /// <summary>
        /// Foreign key a la tabla AspNetUsers (Identity).
        /// Permite relacionar un Cliente con su usuario autenticado.
        /// Nullable porque los Clientes existentes pueden no tener Identity aún.
        /// </summary>
        public string? IdentityUserId { get; set; }

        public List<Mascota> Mascotas
        {
            get { return _mascotas; }
            set { _mascotas = value ?? new List<Mascota>(); }
        }
    }
}
