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
    public class ErroresLog
    {

        #region Constructores
        public ErroresLog()
        {
        }

        public ErroresLog(int cod_Error, string fecha_Hora, string numero_Error, string descripcion, string cod_Usuario)
        {
            Cod_Error = cod_Error;
            Fecha_Hora = fecha_Hora;
            Numero_Error = numero_Error;
            Descripcion = descripcion;
            Cod_Usuario = cod_Usuario;
        }


        #endregion


        #region Propiedades
        public int Cod_Error { get; set; }
        public string Fecha_Hora { get; set; }
        public string Numero_Error { get; set; }
        public string Descripcion { get; set; }
        public string Cod_Usuario { get; set; }


        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #region Metodos

        public DataTable CargaError(string fechaI, string fechaF)
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return null;
            }
            else
            {
                sql = "sp_Lista_Error";
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
                    ds.Tables[0].Columns[1].ColumnName = "Fecha y hora";
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    DataTable resultados = new DataTable();
                    resultados.Columns.Add("Codigo");
                    resultados.Columns.Add("Fecha y hora");
                    resultados.Columns.Add("Numero_Error");
                    resultados.Columns.Add("Descripcion");
                    resultados.Columns.Add("Codigo Usuario");
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
                    resultados.Columns.RemoveAt(2);
                    resultados.Columns.RemoveAt(3);
                    return resultados;
                }
            }
        }

        #endregion  

    }
}
