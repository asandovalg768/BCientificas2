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

        public ConsecutivosLog(int cod_Consecutivo, int cod_Tipo_Consecutivo, string descripcion, int valor, bool posee_Prefijo, string prefijo)
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
        public DataSet CargaConsecutivos()
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
                sql = "sp*************";
                ParamStruct[] parametros = new ParamStruct[1];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Pass", SqlDbType.VarChar, "pass");
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return null;
                }
                else
                {
                    ds.Tables[0].Columns[0].ColumnName = "Codigo";
                    ds.Tables[0].Columns[2].ColumnName = "Descripcion";
                    ds.Tables[0].Columns[5].ColumnName = "Prefijo";
                    return ds;
                }
            }
        }

        public Boolean ActualizaConsecutivo(ConsecutivosLog consecutivo)
        {
            cnn = DAL.DAL.trae_conexion("BDConnectionString", ref error, ref numeroError);
            if (cnn == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return false;
            }
            else
            {
                sql = "sp*****************";
                ParamStruct[] parametros = new ParamStruct[10];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Consecutivo", SqlDbType.Int, consecutivo.Cod_Consecutivo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@nombre", SqlDbType.VarChar, consecutivo.Nombre);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Consecutivo", SqlDbType.VarChar, consecutivo.Consecutivo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Posee_Prefijo", SqlDbType.VarChar, consecutivo.Posee_Prefijo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Prefijo", SqlDbType.VarChar, consecutivo.Prefijo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@PoseeRanGO", SqlDbType.VarChar, consecutivo.PoseeRango);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@Inicio", SqlDbType.VarChar, consecutivo.Inicio);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@Fin", SqlDbType.VarChar, consecutivo.Fin);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 8, "@TipoConsecutivo_Id", SqlDbType.Int, consecutivo.TipoConsecutivo_Id);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 9, "@Password", SqlDbType.VarChar, "password");
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


        #endregion

    }
}

