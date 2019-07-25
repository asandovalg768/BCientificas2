using System;
using System.Collections.Generic;
using System.Linq;
//using System.Data;
//using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace BCientificas
{
    public partial class Formulario_web111 : System.Web.UI.Page
    {
        ConsecutivosLog logica = new ConsecutivosLog();
        TipoConsecutivoLog  tipoCon = new TipoConsecutivoLog();
        static int id = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            gvConsecutivos.DataSource = logica.CargaConsecutivos().Tables[0];
            gvConsecutivos.DataBind();
        }

        protected void ddlDescripcion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ConsecutivosLog consecutivo = new ConsecutivosLog();
                consecutivo.Cod_Tipo_Consecutivo = id;
                consecutivo.Descripcion = lblDescripcion.Text;
                consecutivo.Valor = lblConsecutivo.Text;
                if (chkPoseePrefijo.Checked)
                {
                    consecutivo.Posee_Prefijo = "true";
                    consecutivo.Prefijo = lblPrefijo.txt;
                }
                else
                {
                    consecutivo.Posee_Prefijo = "false";
                    consecutivo.Prefijo = "";
                }
                if (chkPoseeRango.Checked)
                {
                    consecutivo.Posee_Rango = "true";
                    consecutivo.Rango_Inicio = lblPoseeRango.Text;
                    consecutivo.Rango_Final = lblPoseeRango0.Text;
                }
                else
                {
                    consecutivo.Posee_Rango = "false";
                    consecutivo.lblPoseeRango = "0";
                    consecutivo.lblPoseeRango0 = "0";
                }
                consecutivo.Cod_Tipo_Consecutivo = logica.BuscaTipoConsecutivo(codConsecutivo).tipoCon.TipoConsecutivo_Id;
                if (logica.ActualizaConsecutivo(consecutivo))
                {

                    lblMensaje.Text = "El Consecutivo " + lblMensaje.Text + " ha sido actualizado correctamente";
                }
            }

        }

        protected void chkPoseePrefijo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPoseeRango.Checked == true)
            {
                lblPoseeRango.ReadOnly = false;
                lblPoseeRango0.ReadOnly = false;
            }
            else
            {
                lblPoseeRango.ReadOnly = true;
                lblPoseeRango0.ReadOnly = true;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {

        }
    }
}