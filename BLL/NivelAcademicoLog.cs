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
    public class NivelAcademicoLog
    {
        #region Constructores
        public NivelAcademicoLog()
        {
        }

        public NivelAcademicoLog(string cod_Nivel_Academico, string tipo, string nombre, string completado, string detalle)
        {
            Cod_Nivel_Academico = cod_Nivel_Academico;
            Tipo = tipo;
            Nombre = nombre;
            Completado = completado;
            Detalle = detalle;
        }

        #endregion


        #region Propiedades
        public string Cod_Nivel_Academico { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public string Completado { get; set; }
        public string Detalle { get; set; }


        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #region Metodos

        public Boolean ActualizaNivelAcademico(NivelAcademicoLog nivel)
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return false;
            }
            else
            {
                sql = "usp_Nivel_Academico_Update";
                ParamStruct[] parametros = new ParamStruct[5];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Nivel_Academico", SqlDbType.VarChar, nivel.Cod_Nivel_Academico);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Tipo", SqlDbType.VarChar, nivel.Tipo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Nombre", SqlDbType.VarChar, nivel.Nombre);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Completado", SqlDbType.VarChar, nivel.Completado);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Detalle", SqlDbType.VarChar, nivel.Detalle);
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

        public Boolean InsertaNivelAcademico(NivelAcademicoLog nivel)
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return false;
            }
            else
            {
                sql = "usp_Nivel_Academico_Insert";
                ParamStruct[] parametros = new ParamStruct[5];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Nivel_Academico", SqlDbType.VarChar, nivel.Cod_Nivel_Academico);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Tipo", SqlDbType.VarChar, nivel.Tipo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Nombre", SqlDbType.VarChar, nivel.Nombre);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Completado", SqlDbType.VarChar, nivel.Completado);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Detalle", SqlDbType.VarChar, nivel.Detalle);
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

        public NivelAcademicoLog BuscaNivelAcademico(string codNivel)
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return null;
            }
            else
            {
                sql = "usp_Nivel_Academico_Load";
                ParamStruct[] parametros = new ParamStruct[1];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Nivel_Academico", SqlDbType.VarChar, codNivel);
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return null;
                }
                else
                {
                    NivelAcademicoLog nivel = new NivelAcademicoLog();
                    nivel.Cod_Nivel_Academico = ds.Tables[0].Rows[0][0].ToString();
                    nivel.Tipo = ds.Tables[0].Rows[0][1].ToString();
                    nivel.Nombre = ds.Tables[0].Rows[0][2].ToString();
                    nivel.Completado = ds.Tables[0].Rows[0][3].ToString();
                    nivel.Detalle = ds.Tables[0].Rows[0][4].ToString();
                    return nivel;
                }
            }
        }

        public DataSet CargaNivelAcademico()
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return null;
            }
            else
            {
                sql = "sp_Lista_NivelAcademico";
                ParamStruct[] parametros = new ParamStruct[1];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Nivel_Academico", SqlDbType.VarChar, "Cod_Nivel_Academico");
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return null;
                }
                else
                {
                    ds.Tables[0].Columns[1].ColumnName = "Tipo";
                    ds.Tables[0].Columns[2].ColumnName = "Nombre";
                    ds.Tables[0].Columns[3].ColumnName = "Completado";
                    ds.Tables[0].Columns[4].ColumnName = "Detalle";
                    return ds;
                }
            }
        }

        #endregion


    }
}

