namespace PeluqueriaMascotasMVC.Models
{
    public class Turno
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int MascotaId { get; set; }
        public Mascota? Mascota { get; set; }
        public int ServicioId { get; set; }
        public Servicio? Servicio { get; set; }
        public string Estado { get; set; }
        public string Notas { get; set; }

        public Turno()
        {
            Estado = string.Empty;
            Notas = string.Empty;
        }
    }
}
