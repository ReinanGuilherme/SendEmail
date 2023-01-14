namespace SendEmail.Utils.Methods
{
    public class MontarHTML
    {
        public static string Gerar(string subject, string body)
        {
            var html = "<!DOCTYPE html>\r\n<html lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\">\r\n<head>\r\n  <meta charset=\"UTF-8\">\r\n  <meta name=\"viewport\" content=\"width=device-width,initial-scale=1\">\r\n  <meta name=\"x-apple-disable-message-reformatting\">\r\n  <title></title>\r\n  <!--[if mso]>\r\n  <noscript>\r\n    <xml>\r\n      <o:OfficeDocumentSettings>\r\n        <o:PixelsPerInch>96</o:PixelsPerInch>\r\n      </o:OfficeDocumentSettings>\r\n    </xml>\r\n  </noscript>\r\n  <![endif]-->\r\n  <style>\r\n    table, td, div, h1, p {font-family: Arial, sans-serif;}\r\n  </style>\r\n</head>\r\n<body style=\"margin:0;padding:0;\">\r\n  <table role=\"presentation\" style=\"width:100%;border-collapse:collapse;border:0;border-spacing:0;background:#ffffff;\">\r\n    <tr>\r\n      <td align=\"center\" style=\"padding:0;\">\r\n        <table role=\"presentation\" style=\"width:602px;border-collapse:collapse;border:1px solid #cccccc;border-spacing:0;text-align:left;\">\r\n          <tr>\r\n            <td align=\"center\" style=\"padding:40px 0 30px 0;background:#70bbd9;\">\r\n";

            var contentSubject = $"<h1 style=\"font-size:24px;color:#fff;margin:0 0 20px 0;font-family:Arial,sans-serif;\">{subject}</h1>\r\n</td>\r\n          </tr>\r\n          <tr>\r\n            <td style=\"padding:36px 30px 42px 30px;\">\r\n              <table role=\"presentation\" style=\"width:100%;border-collapse:collapse;border:0;border-spacing:0;\">\r\n                <tr>\r\n                  <td style=\"padding:0 0 36px 0;color:#153643;\">";

            var contentBody = $"<p style=\"margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;\">{body}</p></td>\r\n</tr> \r\n</table>\r\n</body>\r\n</html>";



            return html + contentSubject + contentBody;
        }
    }
}
