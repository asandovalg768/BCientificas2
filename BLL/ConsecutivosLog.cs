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

        public ConsecutivosLog(int cod_Consecutivo, string tipo_Consecutivo, string descripcion, string valor, string posee_Prefijo, string prefijo, int tipo_Consecutivo_Cod)
        {
            Cod_Consecutivo = cod_Consecutivo;
            Tipo_Consecutivo = tipo_Consecutivo;
            Descripcion = descripcion;
            Valor = valor;
            Posee_Prefijo = posee_Prefijo;
            Prefijo = prefijo;
            Tipo_Consecutivo_Cod = tipo_Consecutivo_Cod;
        }

        public ConsecutivosLog(int cod_Consecutivo, string tipo_Consecutivo, string descripcion, string valor, string posee_Prefijo, string prefijo, string posee_Rango, string rango_Inicio, string rango_Final, int tipo_Consecutivo_Cod)
        {
            Cod_Consecutivo = cod_Consecutivo;
            Tipo_Consecutivo = tipo_Consecutivo;
            Descripcion = descripcion;
            Valor = valor;
            Posee_Prefijo = posee_Prefijo;
            Prefijo = prefijo;
            Posee_Rango = posee_Rango;
            Rango_Inicio = rango_Inicio;
            Rango_Final = rango_Final;
            Tipo_Consecutivo_Cod = tipo_Consecutivo_Cod;
        }

        #endregion





        #region Propiedades
        public int Cod_Consecutivo { get; set; }
        public string Tipo_Consecutivo { get; set; }

        public string Descripcion { get; set; }
        public string Valor { get; set; }
        public string Posee_Prefijo { get; set; }
        public string Prefijo { get; set; }

        public string Posee_Rango { get; set; }

        public string Rango_Inicio { get; set; }

        public string Rango_Final { get; set; }

        public int Tipo_Consecutivo_Cod { get; set; }


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

        public ConsecutivosLog BuscaConsecutivo(int cod_Consecutivo)
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
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Consecutivo", SqlDbType.Int, cod_Consecutivo);
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
                    consecutivo.Posee_Rango = ds.Tables[0].Rows[0][6].ToString();
                    consecutivo.Rango_Inicio = ds.Tables[0].Rows[0][7].ToString();
                    consecutivo.Rango_Final = ds.Tables[0].Rows[0][8].ToString();
                    consecutivo.Tipo_Consecutivo_Cod = Convert.ToInt32(ds.Tables[0].Rows[0][9].ToString());  
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
                ParamStruct[] parametros = new ParamStruct[9];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Consecutivo", SqlDbType.Int, consecutivo.Cod_Consecutivo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Tipo_Consecutivo", SqlDbType.VarChar, consecutivo.Tipo_Consecutivo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Descripcion", SqlDbType.VarChar, consecutivo.Descripcion);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Valor", SqlDbType.VarChar, consecutivo.Valor);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Posee_Prefijo", SqlDbType.VarChar, consecutivo.Posee_Prefijo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Prefijo", SqlDbType.VarChar, consecutivo.Prefijo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@Posee_Rango", SqlDbType.VarChar, consecutivo.Posee_Rango);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@Rango_Inicio", SqlDbType.VarChar, consecutivo.Rango_Inicio);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 8, "@Rango_Final", SqlDbType.VarChar, consecutivo.Rango_Final);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 9, "@Tipo_Consecutivo_Cod", SqlDbType.Int, consecutivo.Tipo_Consecutivo_Cod);

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
                ParamStruct[] parametros = new ParamStruct[9];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Consecutivo", SqlDbType.Int, consecutivo.Cod_Consecutivo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Tipo_Consecutivo", SqlDbType.VarChar, consecutivo.Tipo_Consecutivo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Descripcion", SqlDbType.VarChar, consecutivo.Descripcion);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Valor", SqlDbType.VarChar, consecutivo.Valor);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Posee_Prefijo", SqlDbType.VarChar, consecutivo.Posee_Prefijo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Prefijo", SqlDbType.VarChar, consecutivo.Prefijo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@Posee_Rango", SqlDbType.VarChar, consecutivo.Posee_Rango);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@Rango_Inicio", SqlDbType.VarChar, consecutivo.Rango_Inicio);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 8, "@Rango_Final", SqlDbType.VarChar, consecutivo.Rango_Final);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 9, "@Tipo_Consecutivo_Cod", SqlDbType.Int, consecutivo.Tipo_Consecutivo_Cod);
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

