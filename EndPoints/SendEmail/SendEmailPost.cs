using System.Net.Mail;
using System.Net;
using SendEmail.Utils.Methods;

namespace SendEmail.EndPoints.SendEmail
{
    public class SendEmailPost
    {
        public static string Template => "/SendEmail/";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(SendEmailRequest sendEmailRequest, IConfiguration configuration)
        {
            // Verifica se os campos de entrada são validos, caso contrario retorna o erro.
            if (!sendEmailRequest.ValidRequest.ValidFields())
            {
                return Results.ValidationProblem(sendEmailRequest.ValidRequest.ReturnErrorsDetails());
            }

            try
            {
                // Configurações do provedor (Essas variaveis de configurações estão armazenadas no appsettings.json)
                int port = int.Parse(configuration["ProviderSettings:Port"]);
                bool useSsl = bool.Parse(configuration["ProviderSettings:UseSSL"]);
                string username = configuration["ProviderSettings:UserName"];
                string password = configuration["ProviderSettings:Password"];
                string fromAddress = configuration["ProviderSettings:FromAddress"];
                string toAddress = sendEmailRequest.ToAddress;
                // Verificando qual provedor será utilizado com base no email origem
                string server = fromAddress.Contains("@gmail.com") 
                    ? configuration["ProviderSettings:ServerGmail"] 
                    : configuration["ProviderSettings:ServerOffice365"];

                // Configuração do e-mail
                MailMessage message = new MailMessage();
                message.From = new MailAddress(fromAddress);
                message.To.Add(toAddress);
                message.Subject = sendEmailRequest.Subject;

                // Se BodyHtlm == True então sera enviado com um layout exibido em HTML
                // SeNao enviara apenas um texto simples
                if (sendEmailRequest.BodyHtml)
                {
                    message.Body = MontarHTML.Gerar(sendEmailRequest.Subject, sendEmailRequest.Body);
                    message.IsBodyHtml = true;
                } else
                {
                    message.Body = sendEmailRequest.Body;
                }

                // Enviando o e-mail
                SmtpClient smtp = new SmtpClient(server, port);
                smtp.Credentials = new NetworkCredential(username, password);
                smtp.EnableSsl = useSsl;
                smtp.Send(message);

                return Results.Json(new { Message = "E-mail enviado com sucesso" });
            }
            catch (Exception ex)
            {
                var error = "Erro ao enviar e-mail: " + ex.Message;

                return Results.ValidationProblem(error.ConvertToProblemDetails());
            }

        }
    }
}
