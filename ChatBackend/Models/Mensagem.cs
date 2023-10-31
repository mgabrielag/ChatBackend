namespace ChatBackend.Models
{
    public class Mensagem
    {
        public string Autor { get; set; }
        public DateTime Hora { get; set; }
        public string Texto { get; set; }
        public string Tema { get; set; }
        public string HoraTexto { get; set; }

        public void CriaHoraTexto()
        {
            this.HoraTexto = this.Hora.ToString();
            this.HoraTexto = $"{this.HoraTexto.Substring(11, 2)}:{this.HoraTexto.Substring(14, 2)}";
        }
    }
}
