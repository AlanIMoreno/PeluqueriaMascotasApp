namespace PeluqueriaMascotasMVC.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        public int MascotaId { get; set; }
        public Mascota? Mascota { get; set; }
        public int ServicioId { get; set; }
        public Servicio? Servicio { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }

        public Consulta()
        {
            Observaciones = string.Empty;
            Diagnostico = string.Empty;
            Tratamiento = string.Empty;
        }
    }
}
