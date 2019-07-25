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
        TipoConsecutivoLog tipoCon = new TipoConsecutivoLog();
        static int cod = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void ddlDescripcion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ConsecutivosLog consecutivo = new ConsecutivosLog();
                consecutivo.Cod_Consecutivo = cod;
                consecutivo.Descripcion = txtDescripcion.Text;
                consecutivo.Valor = txtConsecutivo.Text;
                if (chkPoseePrefijo.Checked)
                {
                    consecutivo.Posee_Prefijo = "true";
                    consecutivo.Prefijo = txtPrefijo.Text;
                }
                else
                {
                    consecutivo.Posee_Prefijo = "false";
                    consecutivo.Prefijo = "";
                }
                if (chkPoseeRango.Checked)
                {
                    consecutivo.Posee_Rango = "true";
                    consecutivo.Rango_Inicio = txtRangoIni.Text;
                    consecutivo.Rango_Final = txtRangoFin.Text;
                }
                else
                {
                    consecutivo.Posee_Rango = "false";
                    consecutivo.Rango_Inicio = "0";
                    consecutivo.Rango_Final = "0";
                }
                consecutivo.Tipo_Consecutivo_Cod = logica.BuscaConsecutivo(cod).Tipo_Consecutivo_Cod;
                if (logica.ActualizaConsecutivo(consecutivo))
                {

                    lblMensaje.Text = "El Consecutivo " + lblMensaje.Text + " ha sido actualizado correctamente";
                }
            }

        }

        protected void chkPoseePrefijo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPoseePrefijo.Checked == true)
            {
                txtPrefijo.ReadOnly = false;
            }
            else
            {
                txtPrefijo.ReadOnly = true;
            }
        }

        protected void chkPoseeRango_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPoseeRango.Checked == true)
            {
                txtRangoIni.ReadOnly = false;
                txtRangoFin.ReadOnly = false;
            }
            else
            {
                txtRangoIni.ReadOnly = true;
                txtRangoFin.ReadOnly = true;
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