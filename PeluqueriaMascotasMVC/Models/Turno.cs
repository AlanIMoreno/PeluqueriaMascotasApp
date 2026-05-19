namespace PeluqueriaMascotasMVC.Models
{
    public class Turno
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Mascota Mascota { get; set; }
        public Servicio Servicio { get; set; }
        public string Estado { get; set; }
        public string Notas { get; set; }
    }
}