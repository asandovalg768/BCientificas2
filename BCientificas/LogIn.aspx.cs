using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace BCientificas
{
    public partial class LogIn : System.Web.UI.Page
    {
        UsuariosLog log = new UsuariosLog();


        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)

        {
            if (log.Login(txtUserName.Text, txtPass.Text))
            {
                log.Login(txtUserName.Text, txtPass.Text);
                
                
                Response.Redirect("Default.aspx");
            }else if(txtUserName.Text == "" || txtPass.Text == "")
            {
                lblMensaje.Text = "No deje los campos en blanco";
            }
            else
            {
                lblMensaje.Text = "Datos incorrectos";

            }
        }
        

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

        }

        protected void Login1_Authenticate1(object sender, AuthenticateEventArgs e)
        {

        }

        protected void LoginView1_ViewChanged(object sender, EventArgs e)
        {

        }
    }
}