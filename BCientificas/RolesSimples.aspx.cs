using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BCientificas
{
    public partial class Formulario_web114 : System.Web.UI.Page
    {
        UsuariosLog logica = new UsuariosLog();
        PrivilegiosUsuariosLog roles = new PrivilegiosUsuariosLog();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ListBox1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            CargarUsuarios();
        }
        private void CargarUsuarios()
        {
            DataSet ds = new DataSet();
            ds = logica.CargarUsuarios();
            ListBox1.DataSource = ds.Tables[0];
            ListBox1.DataTextField = ds.Tables[0].Columns["Usuario"].ColumnName.ToString();
            ListBox1.DataValueField = ds.Tables[0].Columns["ID"].ColumnName.ToString();
            ListBox1.DataBind();
        }
    }
}