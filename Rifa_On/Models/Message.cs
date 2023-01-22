using MimeKit;

namespace Rifa_On.Models
{
    public class Message
    {
        public List<MailboxAddress> Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }

        public Message(IEnumerable<string> destinatario,string assunto,int id, string code) 
        {
            Destinatario= new List<MailboxAddress>();
            Destinatario.AddRange(destinatario.Select(d => new MailboxAddress("",d.ToLower())));
            Assunto = assunto;
            Conteudo = $"https://localhost:44361/Usuario/AtivaConta?Id={id}&CodigoAtivacao={code}"; 
        }
    }
}
