namespace projetomecanicaapi.Models
{
    public class usuario
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public object Nome { get; internal set; }
        public object Senha { get; internal set; }
    }
}
