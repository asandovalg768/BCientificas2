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
    public partial class Formulario_web2 : System.Web.UI.Page
    {
        PuestosLog logica = new PuestosLog();
        RolLaboratorioLog rolesLogica = new RolLaboratorioLog();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRoles();
                CargarPuestos();
            }
        }

        private void CargarPuestos()
        {
            gvPuestos.DataSource = logica.CargaPuesto().Tables[0];
            gvPuestos.DataBind();
            btnActualizar.Visible = false;
            btnLimpiar.Visible = false;
            btnEliminar.Visible = false;
        }

        private void CargarRoles()
        {
            DataSet ds = new DataSet();
            ds = rolesLogica.CargasRolesLaboratorio();
            ddlRoles.DataSource = ds.Tables[0];
            ddlRoles.DataTextField = ds.Tables[0].Columns["Nombre"].ColumnName.ToString();
            ddlRoles.DataValueField = ds.Tables[0].Columns["ID"].ColumnName.ToString();
            ddlRoles.DataBind();
        }

        private void Limpiar()
        {
            txtID.Text = "";
            txtNombre.Text = "";
        }

        protected void gvPuestos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvPuestos.Rows[index];
            string id = row.Cells[1].Text;



            PuestosLog puesto = new PuestosLog();
            puesto = logica.BuscaPuesto(id);

            txtID.Text = puesto.Cod_Puesto;
            txtNombre.Text = puesto.Nombre;
            ddlRoles.SelectedValue = puesto.RolLaboratorio_id;

            btnActualizar.Visible = true;
            btnLimpiar.Visible = true;
            btnEliminar.Visible = true;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                PuestosLog puesto = new PuestosLog();
                puesto.Cod_Puesto = txtID.Text;
                puesto.Nombre = txtNombre.Text;
                puesto.RolLaboratorio_id = ddlRoles.SelectedValue;

                if (logica.ActualizaPuesto(puesto))
                {
                    lblMensaje.Text = "Puesto  " + txtNombre.Text + " actualizado correctamente";
                    this.CargarRoles();
                    this.CargarPuestos();
                    Limpiar();
                }
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearPuesto.aspx");
        }


    }
}