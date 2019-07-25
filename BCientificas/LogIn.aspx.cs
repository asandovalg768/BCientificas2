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
            txtPass.Attributes["type"] = "password";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (log.Login(txtUserName.Text, txtPass.Text))
            {
                log.Login(txtUserName.Text, txtPass.Text);
                Response.Redirect("Default.aspx");
            }else if(txtUserName.Text== null && txtPass.Text == null)
            {
                lblMensaje.Text = "Insert credentials";
            }
        }
    }
}