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

        public ConsecutivosLog(int cod_Consecutivo, string tipo_Consecutivo, string descripcion, string valor, string posee_Prefijo, string prefijo)
        {
            Cod_Consecutivo = cod_Consecutivo;
            Tipo_Consecutivo = tipo_Consecutivo;
            Descripcion = descripcion;
            Valor = valor;
            Posee_Prefijo = posee_Prefijo;
            Prefijo = prefijo;
        }

        #endregion


        #region Propiedades
        public int Cod_Consecutivo { get; set; }
        public string Tipo_Consecutivo { get; set; }

        public string Descripcion { get; set; }
        public string Valor { get; set; }
        public string Posee_Prefijo { get; set; }
        public string Prefijo { get; set; }


        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #region Metodos
        public DataSet CargaConsecutivo()
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return null;
            }
            else
            {
                sql = "sp_Lista_Consecutivo";
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
                    ds.Tables[0].Columns[0].ColumnName = "Codigo";
                    ds.Tables[0].Columns[1].ColumnName = "Tipo Consecutivo";
                    ds.Tables[0].Columns[2].ColumnName = "Descripcion";
                    return ds;
                }
            }
        }

        public ConsecutivosLog BuscaConsecutivo(int consecutivoID)
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return null;
            }
            else
            {
                sql = "sp_Carga_Consecutivo";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Consecutivo", SqlDbType.Int, consecutivoID);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Password", SqlDbType.VarChar, "password");
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return null;
                }
                else
                {
                    ConsecutivosLog consecutivo = new ConsecutivosLog();
                    consecutivo.Cod_Consecutivo = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    consecutivo.Tipo_Consecutivo = ds.Tables[0].Rows[0][1].ToString();
                    consecutivo.Descripcion = ds.Tables[0].Rows[0][2].ToString();
                    consecutivo.Valor = ds.Tables[0].Rows[0][3].ToString();
                    consecutivo.Posee_Prefijo = ds.Tables[0].Rows[0][4].ToString();
                    consecutivo.Prefijo = ds.Tables[0].Rows[0][5].ToString();
                    return consecutivo;
                }
            }
        }

        public Boolean ActualizaConsecutivo(ConsecutivosLog consecutivo)
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return false;
            }
            else
            {
                sql = "sp_Actualiza_Consecutivo";
                ParamStruct[] parametros = new ParamStruct[7];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Consecutivo", SqlDbType.Int, consecutivo.Cod_Consecutivo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Tipo_Consecutivo", SqlDbType.VarChar, consecutivo.Tipo_Consecutivo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Descripcion", SqlDbType.VarChar, consecutivo.Descripcion);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Valor", SqlDbType.VarChar, consecutivo.Valor);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Posee_Prefijo", SqlDbType.VarChar, consecutivo.Posee_Prefijo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Prefijo", SqlDbType.VarChar, consecutivo.Prefijo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 9, "@Password", SqlDbType.VarChar, "password");
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

        public Boolean InsertaConsecutivo(ConsecutivosLog consecutivo)
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return false;
            }
            else
            {
                sql = "sp_Inserta_Consecutivo";
                ParamStruct[] parametros = new ParamStruct[7];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Consecutivo", SqlDbType.Int, consecutivo.Cod_Consecutivo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Tipo_Consecutivo", SqlDbType.VarChar, consecutivo.Tipo_Consecutivo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Descripcion", SqlDbType.VarChar, consecutivo.Descripcion);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Valor", SqlDbType.VarChar, consecutivo.Valor);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Posee_Prefijo", SqlDbType.VarChar, consecutivo.Posee_Prefijo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Prefijo", SqlDbType.VarChar, consecutivo.Prefijo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 9, "@Password", SqlDbType.VarChar, "password");
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

