namespace apiblog.Entities
{
    public class Usuario
    {       
        public int IdUsuario { get; set; }
        public Pessoa Pessoa { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }        
    }
}