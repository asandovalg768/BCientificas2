using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace BCientificas
{
    
    public partial class Formulario_web115 : System.Web.UI.Page
    {

        ConsecutivosLog logica = new ConsecutivosLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, EventArgs e)
        {
            //int index = Convert.ToInt32(e.CommandArgument);
            //GridViewRow row = gvConsecutivos.Rows[index];
            //ConsecutivoLogica consecutivo = new ConsecutivoLogica();
            //consecutivo = logica.BuscarConsecutivo(index + 1);

            //id = consecutivo.Consecutivo_id;
            //txtDescripcion.Text = consecutivo.Nombre;
            //txtConsecutivo.Text = consecutivo.Consecutivo;
            //chkBoxPrefijo.Checked = Convert.ToBoolean(consecutivo.PoseePrefijo);
            //if (chkBoxPrefijo.Checked)
            //{
            //    txtPrefijo.ReadOnly = false;
            //    txtPrefijo.Text = consecutivo.Prefijo;
            //}
            //else
            //{
            //    txtPrefijo.ReadOnly = true;
            //    txtPrefijo.Text = "";
            //}

            //chkBoxRango.Checked = Convert.ToBoolean(consecutivo.PoseeRango);
            //if (chkBoxRango.Checked)
            //{
            //    txtInicio.ReadOnly = false;
            //    txtInicio.Text = consecutivo.Inicio;
            //    txtFinal.ReadOnly = false;
            //    txtFinal.Text = consecutivo.Fin;
            //}
            //else
            //{
            //    txtInicio.ReadOnly = true;
            //    txtInicio.Text = "";
            //    txtFinal.ReadOnly = true;
            //    txtFinal.Text = "";
            //}
        }
    }
}