using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace BCientificas
{
    public partial class ActualizarUsuario : System.Web.UI.Page
    {
        UsuariosLog usuariosLog = new UsuariosLog();
        PuestosLog puestoLog = new PuestosLog();
        NivelAcademicoLog nivelAcademicoLog = new NivelAcademicoLog();

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarNiveles();
            CargarPuestos();
            CargarUsuarios();
            imgFirma.Visible = false;
            imgFoto.Visible = false;
            txtContra.ReadOnly = true;
            txtConfContra.ReadOnly = true;
        }
        protected void chkCambioContra_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCambioContra.Checked == true)
            {
                txtContra.ReadOnly = false;
                txtConfContra.ReadOnly = false;
            }
            else
            {
                txtContra.ReadOnly = true;
                txtConfContra.ReadOnly = true;
            }
        }

        private void CargarUsuarios()
        {

            GVUsuarios.DataSource = usuariosLog.CargaUsuarios();
            GVUsuarios.DataBind();

            btnGuardar.Visible = false;

        }
        private void CargarNiveles()
        {
            DataSet ds = new DataSet();
            ds = nivelAcademicoLog.CargaNivelAcademico();
            ddlCargaNivelAca.DataSource = ds.Tables[0];
            ddlCargaNivelAca.DataTextField = ds.Tables[0].Columns["Tipo"].ColumnName.ToString();
            ddlCargaNivelAca.DataValueField = ds.Tables[0].Columns["Nombre"].ColumnName.ToString();
            ddlCargaNivelAca.DataTextField = ds.Tables[0].Columns["Completado"].ColumnName.ToString();
            ddlCargaNivelAca.DataValueField = ds.Tables[0].Columns["Detalle"].ColumnName.ToString();
            ddlCargaNivelAca.DataBind();
        }

        private void CargarPuestos()
        {
            DataSet ds = new DataSet();
            ds = puestoLog.CargaPuesto();
            ddlPuesto.DataSource = ds.Tables[0];
            ddlPuesto.DataTextField = ds.Tables[0].Columns["Codigo"].ColumnName.ToString();
            ddlPuesto.DataValueField = ds.Tables[0].Columns["Nombre"].ColumnName.ToString();
            ddlPuesto.DataBind();
        }

        private string GuardarImg(FileUpload file, string directorio)
        {
            string path = String.Empty;
            if (file.HasFile)
            {
                string ext = System.IO.Path.GetExtension(file.FileName);
                ext = ext.ToLower();

                if (ext == ".png" || ext == ".jpg")
                {
                    file.SaveAs(Server.MapPath(directorio + "/" + file.FileName));
                    path = directorio + "/" + file.FileName;

                }
            }
            return path;
        }



        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt2Apellido_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtNickName0_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void ddlPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GVUsuarios_RowCommand(object sender, EventArgs e)
        {
            //int index = Convert.ToInt32(e.CommandArgument);
            //GridViewRow row = GVUsuarios.Rows[index];
            //string id = row.Cells[1].Text;

            //UsuariosLog usuario = new UsuariosLog();
            //usuario = usuariosLog.BuscaUsuario(id);



            //txtCodigo.Text = usuario.Cod_Usuario;
            //txtNombre.Text = usuario.Nombre;
            //txt1Apellido.Text = usuario.Primer_Apellido;
            //txt2Apellido.Text = usuario.Segundo_Apellido;
            //txtTipoRol.Text = usuario.Rol;
            //txtTel0.Text = usuario.Telefono;
            //ddlPuesto.Text = usuario.Cod_Puesto;
            //txtNickName.Text = usuario.Username;
            //ddlCargaNivelAca.Text = usuario.Cod_Nivel_Academico;
            //txtContra.Text = usuario.Pass;
            //txtConfContra.Text = usuario.Pass;
            //imgFirma.Visible = true;
            //imgFoto.Visible = true;
            //imgFirma.ImageUrl = usuario.Img_Firma;
            //imgFoto.ImageUrl = usuario.Img_Foto;



        }

        private void Limpiar()
        {
            //txtCelular.Text = "";
            //txtCodigo.Text = "";
            //txtConfirmarPassword.Text = "";
            //txtNombre.Text = "";
            //txtNombreUsuario.Text = "";
            //txtPassword.Text = "";
            //txtPrimerApellido.Text = "";
            //txtSegundoApellido.Text = "";
            //imgFirma.Visible = false;
            //imgFoto.Visible = false;

        }

    }
}