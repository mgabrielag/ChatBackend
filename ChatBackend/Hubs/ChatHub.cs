using ChatBackend.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChatBackend.Hubs
{
    public class ChatHub : Hub
    {
        private IConfiguration _config;

        public ChatHub(IConfiguration config)
        {
            _config = config;
        }

        public async Task<Resultado> AcessarChat(string tema)
        {
            if (VerificaExisteGrupo(tema))
            {
                await this.Groups.AddToGroupAsync(this.Context.ConnectionId, tema);
                return new Resultado(true);
            }
            else
                return new Resultado(false, "Tema não encontrado");
        }

        public async Task SairChat(string tema)
        {
            await this.Groups.RemoveFromGroupAsync(this.Context.ConnectionId, tema);
        }

        public async Task EnviaMensagem(Mensagem mensagem)
        {
            mensagem.CriaHoraTexto();
            await this.Clients.Group(mensagem.Tema).SendAsync("MensagemRecebida", mensagem);
        }

        public bool VerificaExisteGrupo(string grupo)
        {
            if (_config.GetSection("ListaTemasChatHub").Value.Contains(grupo))
                return true;
            else return false;
        }
    }
}
