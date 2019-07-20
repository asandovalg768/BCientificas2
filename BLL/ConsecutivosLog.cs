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
    public class ConsecutivosLog
    {
        #region Constructores
        public ConsecutivosLog()
        {
        }

        public ConsecutivosLog(int cod_Consecutivo, int cod_Tipo_Consecutivo, string descripcion, int valor, string posee_Prefijo, string prefijo)
        {
            Cod_Consecutivo = cod_Consecutivo;
            Cod_Tipo_Consecutivo = cod_Tipo_Consecutivo;
            Descripcion = descripcion;
            Valor = valor;
            Posee_Prefijo = posee_Prefijo;
            Prefijo = prefijo;
        }

        #endregion


        #region Propiedades
        public int Cod_Consecutivo { get; set; }
        public int Cod_Tipo_Consecutivo { get; set; }

        public string Descripcion { get; set; }
        public float Valor { get; set; }
        public string Posee_Prefijo { get; set; }
        public string Prefijo { get; set; }


        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #region Metodos
        public Boolean ActualizaConsecutivo(ConsecutivosLog consecutivo)
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return false;
            }
            else
            {
                sql = "usp_Consecutivos_Update";
                ParamStruct[] parametros = new ParamStruct[5];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Tipo_Consecutivo", SqlDbType.Int, consecutivo.Cod_Tipo_Consecutivo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Descripcion", SqlDbType.VarChar, consecutivo.Descripcion);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Valor", SqlDbType.Float, consecutivo.Valor);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Posee_Prefijo", SqlDbType.VarChar, consecutivo.Posee_Prefijo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Prefijo", SqlDbType.VarChar, consecutivo.Prefijo);
                DAL.DAL.conectar(cnn, ref error, ref numeroError);
                DAL.DAL.ejecuta_sqlcommand(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    //insertar en la table de errores
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

        public Boolean InsertaConsecutivo(ConsecutivosLog consecutivo)
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return false;
            }
            else
            {
                sql = "usp_Consecutivos_Insert";
                ParamStruct[] parametros = new ParamStruct[5];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Tipo_Consecutivo", SqlDbType.Int, consecutivo.Cod_Tipo_Consecutivo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Descripcion", SqlDbType.VarChar, consecutivo.Descripcion);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Valor", SqlDbType.Float, consecutivo.Valor);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Posee_Prefijo", SqlDbType.VarChar, consecutivo.Posee_Prefijo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Prefijo", SqlDbType.VarChar, consecutivo.Prefijo);
                DAL.DAL.conectar(cnn, ref error, ref numeroError);
                DAL.DAL.ejecuta_sqlcommand(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    //insertar en la table de errores
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

        public ConsecutivosLog BuscaConsecutivo(int codConsecutivo)
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return null;
            }
            else
            {
                sql = "usp_Consecutivos_Load";
                ParamStruct[] parametros = new ParamStruct[1];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Tipo_Consecutivo", SqlDbType.Int, codConsecutivo);
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return null;
                }
                else
                {
                    ConsecutivosLog consecutivo = new ConsecutivosLog();
                    consecutivo.Cod_Tipo_Consecutivo = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    consecutivo.Descripcion = ds.Tables[0].Rows[0][1].ToString();
                    //consecutivo.Valor = Convert.ds.Tables[0].Rows[0][2].ToString();
                    consecutivo.Posee_Prefijo = ds.Tables[0].Rows[0][3].ToString();
                    consecutivo.Prefijo = ds.Tables[0].Rows[0][4].ToString();
                    consecutivo.Prefijo = ds.Tables[0].Rows[0][5].ToString();
                    return consecutivo;
                }
            }
        }

        public DataSet CargaConsecutivos()
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return null;
            }
            else
            {
                sql = "usp_Consecutivo_Lista";
                ParamStruct[] parametros = new ParamStruct[5];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Tipo_Consecutivo", SqlDbType.Int, "Cod_Tipo_Consecutivo");
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Descripcion", SqlDbType.VarChar, "Descripcion");
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Valor", SqlDbType.Float, "Valor");
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Posee_Prefijo", SqlDbType.VarChar, "Posee_Prefijo");
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Prefijo", SqlDbType.VarChar, "Prefijo");
                DAL.DAL.conectar(cnn, ref error, ref numeroError);
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return null;
                }
                else
                {
                    ds.Tables[0].Columns[0].ColumnName = "Codigo";
                    ds.Tables[0].Columns[1].ColumnName = "Descripcion";
                    ds.Tables[0].Columns[2].ColumnName = "Valor";

                    return ds;
                }
            }
        }


        #endregion

    }
}

