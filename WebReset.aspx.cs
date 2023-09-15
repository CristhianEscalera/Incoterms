using SolucionesMedicasBilbaoDAO.Implementacion;
using SolucionesMedicasBilbaoDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolucionesMedicasBilbaoWeb
{
    public partial class WebReset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionClass.SessionUserName == null)
            {
                Response.Redirect("WebLogin.aspx");
            }

            if(SessionClass.StatusPass == 1)
            {
                divPass.Visible = false;
            }
            else
            {
                divPass.Visible = true;
            }

        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (SessionClass.StatusPass == 1)
                {
                    UserImpl implUser = new UserImpl();
                    DataTable tb = implUser.Login2(SessionClass.SessionUserName);
                    if (tb.Rows.Count > 0)
                    {
                        SessionClass.SessionCont = int.Parse(tb.Rows[0][0].ToString());

                        if (validarLetras(txtNewPass.Text))
                        {
                            if (validarNum(txtNewPass.Text))
                            {
                                if (validarCarac(txtNewPass.Text))
                                {
                                    if (txtNewPass.Text == txtNewPass2.Text)
                                    {
                                        UserImpl impl = new UserImpl();
                                        User user = new User(SessionClass.SessionUserName, txtNewPass.Text);
                                        impl.UpdatePassword(user);
                                        if (SessionClass.SessionRole != "Administrador")
                                        {
                                            if (SessionClass.SessionRole == "Ingresos")
                                            {
                                                Response.Redirect("Ingresos.aspx");
                                            }
                                            else if (SessionClass.SessionRole == "Empleado")
                                            {
                                                Response.Redirect("Empleado.aspx");
                                            }
                                        }
                                        else
                                        {
                                            Response.Redirect("Default.aspx");
                                        }
                                    }
                                    else
                                    {
                                        txtError.InnerText = "La nueva contraseña tiene que ser igual a la confirmacion";
                                    }
                                }
                                else
                                {
                                    txtError.InnerText = "la nueva contraseña no contiene caracteres especiales";
                                }
                            }
                            else
                            {
                                txtError.InnerText = "la nueva contraseña no contiene ningun numero";
                            }
                        }
                        else
                        {
                            txtError.InnerText = "la nueva contraseña debe contener Mayusculas/minusculas";
                        }
                    }
                    else
                    {
                        txtError.InnerText = "Ingrese Usuario/Contraseña correcta";
                    }
                }
                else
                {
                    UserImpl implUser = new UserImpl();
                    DataTable tb = implUser.Login(SessionClass.SessionUserName, txtPassword.Text);
                    if (tb.Rows.Count > 0)
                    {
                        SessionClass.SessionCont = int.Parse(tb.Rows[0][0].ToString());

                        if (validarLetras(txtNewPass.Text))
                        {
                            if (validarNum(txtNewPass.Text))
                            {
                                if (validarCarac(txtNewPass.Text))
                                {
                                    if (txtNewPass.Text == txtNewPass2.Text)
                                    {
                                        UserImpl impl = new UserImpl();
                                        User user = new User(SessionClass.SessionUserName, txtNewPass.Text);
                                        impl.UpdatePassword(user);
                                        Response.Redirect("WebLogin.aspx");
                                    }
                                    else
                                    {
                                        txtError.InnerText = "La nueva contraseña tiene que ser igual a la confirmacion";
                                    }
                                }
                                else
                                {
                                    txtError.InnerText = "la nueva contraseña no contiene caracteres especiales";
                                }
                            }
                            else
                            {
                                txtError.InnerText = "la nueva contraseña no contiene ningun numero";
                            }
                        }
                        else
                        {
                            txtError.InnerText = "la nueva contraseña debe contener Mayusculas/minusculas";
                        }
                    }
                    else
                    {
                        txtError.InnerText = "Ingrese Usuario/Contraseña correcta";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (SessionClass.SessionRole != "Administrador")
                {
                    if (SessionClass.SessionRole == "Ingresos")
                    {
                        Response.Redirect("Ingresos.aspx");
                    }
                    else if (SessionClass.SessionRole == "Empleado")
                    {
                        Response.Redirect("Empleado.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected bool validarLetras(string passw)
        {
            Regex letrasMins = new Regex("[^a-z]+");
            Regex letrasMayus = new Regex("[^A-Z]+");
            if (!letrasMins.IsMatch(passw)) return false;
            if (!letrasMayus.IsMatch(passw)) return false;
            return true;
        }

        protected bool validarNum(string passw)
        {
            Regex numeros = new Regex(@"[0-9]");
            if (!numeros.IsMatch(passw)) return false;
            return true;
        }
        protected bool validarCarac(string passw)
        {
            Regex caracEsp = new Regex("[!@#$%^&*()_+=<>?]");

            if (!caracEsp.IsMatch(passw)) return false;
            return true;
        }
    }
}