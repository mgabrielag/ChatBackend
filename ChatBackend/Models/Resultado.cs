namespace ChatBackend.Models
{
    public class Resultado
    {
        public bool Sucesso { get; set; }
        public List<string> ListaErros = new List<string>();

        public Resultado(bool sucesso) 
        {
            this.Sucesso = sucesso;
        }

        public Resultado(bool sucesso, string mensagemErro)
        {
            this.Sucesso = sucesso;
            this.ListaErros.Add(mensagemErro);
        }
    }
}
