namespace apiblog.Entities
{
    public class Email
    {
        public int IdEmail { get; set; }
        public string Endereco { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}