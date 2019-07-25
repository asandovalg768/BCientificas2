using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BCientificas
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        public static string usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (usuario != null)
            {
                lblUsuario.Text = usuario;
            }

        }
    

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {

        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {

        }
    }
}