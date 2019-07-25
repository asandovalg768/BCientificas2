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
    public class BitacoraExperimentalLog
    {

        #region Constructores
        public BitacoraExperimentalLog()
        {
        }

        public BitacoraExperimentalLog(string cod_Bitacora_Experimental, string objetivos, string descripcion, string equipo, string procedimientos, string cod_Experimentos, string fecha, string firma)
        {
            Cod_Bitacora_Experimental = cod_Bitacora_Experimental;
            Objetivos = objetivos;
            Descripcion = descripcion;
            Equipo = equipo;
            Procedimientos = procedimientos;
            Cod_Experimentos = cod_Experimentos;
            Fecha = fecha;
            Firma = firma;
        }


        #endregion


        #region Propiedades
        public string Cod_Bitacora_Experimental { get; set; }

        public string Objetivos { get; set; }

        public string Descripcion { get; set; }

        public string Equipo { get; set; }

        public string Procedimientos { get; set; }

        public string Cod_Experimentos { get; set; }

        public string Fecha { get; set; }

        public string Firma { get; set; }


        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #region Metodos

        public DataTable CargaBitacora()
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return null;
            }
            else
            {
                sql = "sp_Lista_BitacoraExperimental";
                ParamStruct[] parametros = new ParamStruct[1];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@password", SqlDbType.VarChar, "password");
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
                    dt.Columns[1].ColumnName = "Ojetivos";
                    dt.Columns[2].ColumnName = "Descripcion";
                    dt.Columns[3].ColumnName = "Equipo";
                    dt.Columns[4].ColumnName = "Procedimientos";
                    dt.Columns[5].ColumnName = "Cod_Experimentos";
                    dt.Columns[6].ColumnName = "Fecha";
                    dt.Columns[7].ColumnName = "Firma";
                    return dt;
                }
            }
        }


        #endregion  
    }
}