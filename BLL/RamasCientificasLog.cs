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
    public class RamasCientificasLog
    {
        #region Constructores
        public RamasCientificasLog()
        {
        }

        public RamasCientificasLog(int cod_Rama, string nombre)
        {
            Cod_Rama = cod_Rama;
            Nombre = nombre;
        }


        #endregion


        #region Propiedades
        public int Cod_Rama { get; set; }
        public string Nombre { get; set; }


        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #region Metodos
        public DataTable CargarRamasCientifica()
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return null;
            }
            else
            {
                sql = "sp_Lista_RamaCientifica";
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
                    dt.Columns[0].ColumnName = "Cod_Rama";
                    dt.Columns[1].ColumnName = "Nombre";
                    return dt;
                }
            }
        }

        public Boolean CrearRamaCientifica(RamasCientificasLog rama)
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return false;
            }
            else
            {
                sql = "sp_Inserta_RamaCientifica";
                ParamStruct[] parametros = new ParamStruct[3];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Rama", SqlDbType.Int, rama.Cod_Rama);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Nombre", SqlDbType.VarChar, rama.Nombre);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Password", SqlDbType.VarChar, "password");
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

        public Boolean EliminarRamaCientifica(string codigo)
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return false;
            }
            else
            {
                sql = "sp_Elimina_RamaCientifica";
                ParamStruct[] parametros = new ParamStruct[1];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Rama", SqlDbType.VarChar, codigo);
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

