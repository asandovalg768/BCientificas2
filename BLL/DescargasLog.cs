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
    public class DescargasLog
    {

        #region Constructores
        public DescargasLog()
        {
        }

        public DescargasLog(int cod_Descargas, string cod_Usuario, string fecha, string cod_Proyecto)
        {
            Cod_Descargas = cod_Descargas;
            Cod_Usuario = cod_Usuario;
            Fecha = fecha;
            Cod_Proyecto = cod_Proyecto;
        }


        #endregion


        #region Propiedades
        public int Cod_Descargas { get; set; }
        public string Cod_Usuario { get; set; }
        public string Fecha { get; set; }
        public string Cod_Proyecto { get; set; }


        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #region Metodos

        public DataTable CargaDescarga(string fechaI, string fechaF)
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return null;
            }
            else
            {
                sql = "sp_Lista_Descarga";
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
                    DataTable resultados = new DataTable();
                    resultados.Columns.Add("Codigo");
                    resultados.Columns.Add("Cod_Usuario");
                    resultados.Columns.Add("Fecha");
                    resultados.Columns.Add("Cod_Proyecto");
                    foreach (DataRow row in dt.Rows)
                    {
                        if (fechaI != "" && fechaF != "")
                        {
                            if (Convert.ToDateTime(row[1].ToString()) >= Convert.ToDateTime(fechaI) &&
                                Convert.ToDateTime(row[1].ToString()) <= Convert.ToDateTime(fechaF))
                            {
                                resultados.Rows.Add(row.ItemArray);
                            }
                        }
                        else
                        {
                            resultados.Rows.Add(row.ItemArray);

                        }
                    }
                    resultados.Columns.RemoveAt(3);
                    return resultados;
                }
            }
        }

        #endregion 
    }
}
