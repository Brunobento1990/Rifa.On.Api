using MimeKit;
using Rifa_On.Models;

namespace Rifa_On.Services.Interfaces
{
    public interface IEmailService
    {
        void EnviarEmail(string[] destinatario, string assunto ,int id,string code );
        MimeMessage CriarEmail(Message message);
        void Email(MimeMessage mimeMessage);
    }
}
