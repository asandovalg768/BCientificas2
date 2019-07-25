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
    public class PrivilegiosLog
    {

        #region Constructores
        public PrivilegiosLog()
        {
        }

        public PrivilegiosLog(int cod_Privilegio, string privilegio)
        {
            Cod_Privilegio = cod_Privilegio;
            Privilegio = privilegio;
        }


        #endregion


        #region Propiedades
        public int Cod_Privilegio { get; set; }
        public string Privilegio { get; set; }


        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #region Metodos
        public DataSet CargaPrivilegiosLog()
        {
            cnn = DAL.DAL.trae_conexion("BDConnectionString", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return null;
            }
            else
            {
                sql = "sp_Lista_RolLaboratorio";
                ParamStruct[] parametros = new ParamStruct[1];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Password", SqlDbType.VarChar, "password");
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
                    ds.Tables[0].Columns[1].ColumnName = "Nombre Privilegio";
                    return ds;
                }
            }
        }

        public PrivilegiosLog BuscaPrivilegiosLog(string cod_priv)
        {
            cnn = DAL.DAL.trae_conexion("BDConnectionString", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return null;
            }
            else
            {
                sql = "sp_Carga_RolLaboratorio";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Privilegio", SqlDbType.Int, cod_priv);               
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return null;
                }
                else
                {
                    PrivilegiosLog priv = new PrivilegiosLog();
                    priv.Cod_Privilegio = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    priv.Privilegio = ds.Tables[0].Rows[0][1].ToString();
                    return priv;
                }
            }
        }

        public Boolean ActualizaPrivilegiosLog(PrivilegiosLog priv)
        {
            cnn = DAL.DAL.trae_conexion("BDConnectionString", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return false;
            }
            else
            {
                sql = "sp_Actualiza_RolLaboratorio";
                ParamStruct[] parametros = new ParamStruct[3];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Privilegio", SqlDbType.Int, priv.Cod_Privilegio);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Privilegio", SqlDbType.VarChar, priv.Privilegio);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Password", SqlDbType.VarChar, "password");
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

        public Boolean InsertarPrivilegiosLog(PrivilegiosLog priv)
        {
            cnn = DAL.DAL.trae_conexion("BDConnectionString", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return false;
            }
            else
            {
                sql = "sp_Inserta_RolLaboratorio";
                ParamStruct[] parametros = new ParamStruct[3];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Privilegio", SqlDbType.Int, priv.Cod_Privilegio);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Privilegio", SqlDbType.VarChar, priv.Privilegio);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Password", SqlDbType.VarChar, "password");
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

