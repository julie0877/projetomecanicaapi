namespace projetomecanicaapi.Models
{
    public class Agendamentos
    {
        public int Id { get; set; }
        public DateTime Dia_Hora { get; set; }
        public int ClienteId { get; set; }
    }
}
