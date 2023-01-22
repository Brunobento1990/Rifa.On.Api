using MailKit.Net.Smtp;
using MimeKit;
using Rifa_On.Models;
using Rifa_On.Services.Interfaces;

namespace Rifa_On.Services.Classes
{
    public class EmailService : IEmailService
    {
        private IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public MimeMessage CriarEmail(Message message)
        {
            var mensagem = new MimeMessage();
            
            mensagem.From.Add(new MailboxAddress("", _configuration.GetValue<string>("EmailSettings:From")));
            mensagem.To.AddRange(message.Destinatario);
            mensagem.Subject = message.Assunto;
            mensagem.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = message.Conteudo
            };

            return mensagem;

        }

        public void EnviarEmail(string[] destinatario, string assunto, int id, string code)
        {
            Message message = new Message(destinatario,assunto,id,code);

            var mensagemDeEmail = CriarEmail(message);

            Email(mensagemDeEmail);
        }
        public void Email(MimeMessage mimeMessage)
        {
            using (var client = new SmtpClient()) 
            {
                try
                {
                    client.Connect(_configuration.GetValue<string>("EmailSettings:SmtpServer"),
                        _configuration.GetValue<int>("EmailSettings:Port"),
                        true
                        );

                    client.AuthenticationMechanisms.Remove("XOUATH2");

                    client.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),
                        _configuration.GetValue<string>("EmailSettings:Password"));

                    client.Send(mimeMessage);

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
