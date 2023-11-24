using SolucionesMedicasBilbaoDAO;
using SolucionesMedicasBilbaoDAO.Implementacion;
using SolucionesMedicasBilbaoDAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

namespace SolucionesMedicasBilbaoWeb
{
    public partial class WebNewUser : System.Web.UI.Page
    {
        User t;
        UserImpl implUser;
        Person p;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                p = new Person(txtCi.Text.Trim(), txtName.Text.Trim(), txtPApellido.Text.Trim(), txtSApellido.Text.Trim());
                t = new User(Rol.Text, txtEmail.Text.Trim(), 1);
                implUser = new UserImpl();
                implUser.Insert(p,t);

                User user = implUser.Mail();
                string userName = user.nameUser;
                string password = user.password;
                string email = user.email;
                if (validarEmail(email))
                {
                    Task.Run(() =>
                    {
                        SendMail(email, userName, password);
                    });

                    Response.Redirect("WebAdmUser.aspx");

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static bool validarEmail(string email)
        {
            try
            {
                MailAddress direccionCoreo = new MailAddress(email);
                return true;

            }
            catch (FormatException)
            {
                return false;
            }
        }

        static void SendMail(string destinatario, string user, string password)
        {
            string senderMail = "bmf0031211@est.univalle.edu";
            string subject = "Cuenta Soluciones Medicas Bilbao";
            string body = "Usuario: " + user + "\nContraseña: " + password + "\nNo comparta esta información con nadie";
            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(senderMail, "Soluciones Medicas Bilbao");
                mail.To.Add(destinatario);
                mail.Subject = subject;
                mail.Body = body;

                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.Credentials = new NetworkCredential(senderMail, "Tonkathiago1011&&$$");
                client.EnableSsl = true;
                client.Send(mail);
                Console.WriteLine("mensaje enviado");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}