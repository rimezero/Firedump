using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using static System.Windows.Forms.Control;
using Firedump.models.databaseUtils;

namespace Firedump.models.email
{
    public class emailform
    {
        public static string from { set; get; }
        public static string to { set; get; }
        public static string pass { set; get; }
        public static string server { set; get; }
        public static int port { set; get; }

        

        public static MailMessage message = new MailMessage();

        

        public static void sendmail()
        {
            try
            {
                SmtpClient smtp = new SmtpClient(server);
                smtp.EnableSsl = true;
                smtp.Port = port;
                smtp.Credentials = new NetworkCredential(from, pass);

                message.Sender = new MailAddress(from,
        from);
                message.From = new MailAddress(from,
        from);

                message.To.Add(new MailAddress(to,
                   to));
                DbConnection con = DbConnection.Instance();
                if (con.testConnection().wasSuccessful)
                {
                    message.Subject = "Success Mail";
                    message.Body = string.Format("<h1>Connection Succeeded</h1>< p >"+con.connectionString +" </ p > ");
                }
                else
                {
                    message.Subject = "Fail Mail";
                    message.Body = string.Format("<h1>Connection Failed</h1>< p >" + con.connectionString + " </ p > ");
                }
                


                message.IsBodyHtml = true;
                smtp.Send(message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine ("ArithmeticException Handler: {0}", e.ToString());
            }
            catch (SmtpException e)
            {
                Console.WriteLine("Generic Exception Handler: {0}", e.ToString());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Generic Exception Handler: {0}", e.ToString());
            }
            
        }

        

    }
}
