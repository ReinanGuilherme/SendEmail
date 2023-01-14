using SendEmail.Utils.EntityAux;
using SendEmail.Utils.Methods;

namespace SendEmail.EndPoints.SendEmail
{
    public class SendEmailRequest
    {
        public string ToAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool BodyHtml { get; set; }

        public ValidRequest ValidRequest;

        public SendEmailRequest(string toAddress, string subject, string body, bool bodyHtml = false)
        {
            ValidRequest = ValidateFields(toAddress, subject, body);
            ToAddress = toAddress;
            Subject = subject;
            Body = body;
            BodyHtml = bodyHtml;
        }

        private ValidRequest ValidateFields(string toAddress, string subject, string body)
        {

            ValidRequest Valid = new ValidRequest();

            if (string.IsNullOrEmpty(subject))
            {
                Valid.MsgError.Add("Subject é um campo obrigatório.");
            }

            if (string.IsNullOrEmpty(body))
            {
                Valid.MsgError.Add("Body é um campo obrigatório.");
            }

            if (!ValidateEmailAddress.IsValidEmail(toAddress))
            {
                Valid.MsgError.Add("E-mail inválido.");
            }

            return Valid;
        }
    }
}