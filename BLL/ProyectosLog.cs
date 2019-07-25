using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL
{
    public class ProyectosLog
    {

        #region Constructores
        public ProyectosLog()
        {
        }

        public ProyectosLog(string cod_Proyecto, string nombre, string descripcion, int cod_Rama, string precio, string autor, string fecha_Creacion, string idioma, SqlConnection cnn, string error, int numeroError, string sql, DataSet ds)
        {
            Cod_Proyecto = cod_Proyecto;
            Nombre = nombre;
            Descripcion = descripcion;
            Cod_Rama = cod_Rama;
            Precio = precio;
            Autor = autor;
            Fecha_Creacion = fecha_Creacion;
            Idioma = idioma;
            this.cnn = cnn;
            this.error = error;
            this.numeroError = numeroError;
            this.sql = sql;
            this.ds = ds;
        }




        #endregion


        #region Propiedades
        public string Cod_Proyecto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cod_Rama { get; set; }
        public string Precio { get; set; }
        public string Autor { get; set; }
        public string Fecha_Creacion { get; set; }
        public string Idioma { get; set; }


        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #region Metodos
        public DataTable CargarProyecto()
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return null;
            }
            else
            {
                sql = "sp_Lista_Proyecto";
                ParamStruct[] parametros = new ParamStruct[1];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Password", SqlDbType.VarChar, "password");
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return null;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    dt.Columns[0].ColumnName = "Código";
                    dt.Columns[1].ColumnName = "Nombre";
                    dt.Columns[2].ColumnName = "Rama Cientifica";
                    return dt;
                }
            }
        }

        public Boolean GuardarProyecto(ProyectosLog proyecto)
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return false;
            }
            else
            {
                sql = "sp_Inserta_Proyecto";
                ParamStruct[] parametros = new ParamStruct[8];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Proyecto", SqlDbType.VarChar, proyecto.Cod_Proyecto);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Nombre", SqlDbType.VarChar, proyecto.Nombre);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Descripcion", SqlDbType.VarChar, proyecto.Descripcion);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Cod_Rama", SqlDbType.Int, proyecto.Cod_Rama);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Precio", SqlDbType.VarChar, proyecto.Idioma);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Autor", SqlDbType.VarChar, proyecto.Autor);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Fecha_Creacion", SqlDbType.VarChar, proyecto.Fecha_Creacion);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Idioma", SqlDbType.VarChar, proyecto.Idioma);
                DAL.DAL.conectar(cnn, ref error, ref numeroError);
                DAL.DAL.ejecuta_sqlcommand(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    DAL.DAL.desconectar(cnn, ref error, ref numeroError);
                    return false;
                }
                else
                {
                    DAL.DAL.desconectar(cnn, ref error, ref numeroError);
                    return true;
                }
            }
        }


        public Boolean EliminarProyecto(string id)
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return false;
            }
            else
            {
                sql = "sp_Elimina_Proyecto";
                ParamStruct[] parametros = new ParamStruct[1];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Proyecto", SqlDbType.VarChar, id);
                DAL.DAL.conectar(cnn, ref error, ref numeroError);
                DAL.DAL.ejecuta_sqlcommand(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    DAL.DAL.desconectar(cnn, ref error, ref numeroError);
                    return false;
                }
                else
                {
                    DAL.DAL.desconectar(cnn, ref error, ref numeroError);
                    return true;
                }
            }
        }


        #endregion
    }
}
