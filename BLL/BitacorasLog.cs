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
    public class BitacorasLog
    {

        #region Constructor

        public BitacorasLog()
        {
        }

        public BitacorasLog(string cod_Usuario, string fecha_Inicio, string fecha_Final, string tipo, string descripcion, string link, string fecha_Hora, string consecutivo, string registro_Detalle, string cod_Bitacora, SqlConnection cnn, string error, int numeroError, string sql, DataSet ds)
        {
            Cod_Usuario = cod_Usuario;
            Fecha_Inicio = fecha_Inicio;
            Fecha_Final = fecha_Final;
            Tipo = tipo;
            Descripcion = descripcion;
            Link = link;
            Fecha_Hora = fecha_Hora;
            Consecutivo = consecutivo;
            Registro_Detalle = registro_Detalle;
            Cod_Bitacora = cod_Bitacora;
            this.cnn = cnn;
            this.error = error;
            this.numeroError = numeroError;
            this.sql = sql;
            this.ds = ds;
        }



        #endregion


        #region Propiedades
        public string Cod_Usuario { get; set; }
        public string Fecha_Inicio { get; set; }
        public string Fecha_Final { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string Link { get; set; }
        public string Fecha_Hora { get; set; }
        public string Consecutivo { get; set; }
        public string Registro_Detalle { get; set; }
        public string Cod_Bitacora { get; set; }


        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #region Metodos

        public DataTable CargaBitacora(string usearname, string fechaI, string fechaF, string tipo)
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return null;
            }
            else
            {
                sql = "sp_Lista_Bitacora";
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
                    resultados.Columns.Add("Codigo Usuario");
                    resultados.Columns.Add("Fecha Inicial");
                    resultados.Columns.Add("Fecha Final");
                    resultados.Columns.Add("Tipo");
                    resultados.Columns.Add("Descripcion");
                    resultados.Columns.Add("Link");
                    resultados.Columns.Add("Fecha y Hora");
                    resultados.Columns.Add("Consecutivo");
                    resultados.Columns.Add("Registro Detalle");
                    resultados.Columns.Add("Codigo Bitacora");
                    foreach (DataRow row in dt.Rows)
                    {
                        if (usearname != "" && fechaI != "" && fechaF != "")
                        {
                            if (row[5].ToString() == usearname &&
                                Convert.ToInt32(row[1].ToString()) >= Convert.ToInt32(fechaI) &&
                                Convert.ToInt32(row[1].ToString()) <= Convert.ToInt32(fechaF))
                            {
                                if (tipo == "Todas")
                                {
                                    resultados.Rows.Add(row.ItemArray);
                                }
                                else
                                {
                                    if (row[2].ToString() == tipo)
                                    {
                                        resultados.Rows.Add(row.ItemArray);
                                    }
                                }
                            }
                        }
                        else if (fechaI!= "" && fechaF != "")
                        {
                            if (Convert.ToInt32(row[1].ToString()) >= Convert.ToInt32(fechaI) &&
                                Convert.ToInt32(row[1].ToString()) <= Convert.ToInt32(fechaF))
                            {
                                if (tipo == "Todas")
                                {
                                    resultados.Rows.Add(row.ItemArray);
                                }
                                else
                                {
                                    if (row[2].ToString() == tipo)
                                    {
                                        resultados.Rows.Add(row.ItemArray);
                                    }
                                }
                            }
                        }
                        else if (usearname != "")
                        {
                            if (row[5].ToString() == usearname)
                            {
                                if (tipo == "Todas")
                                {
                                    resultados.Rows.Add(row.ItemArray);
                                }
                                else
                                {
                                    if (row[2].ToString() == tipo)
                                    {
                                        resultados.Rows.Add(row.ItemArray);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tipo == "Todas")
                            {
                                resultados.Rows.Add(row.ItemArray);
                            }
                            else
                            {
                                if (row[2].ToString() == tipo)
                                {
                                    resultados.Rows.Add(row.ItemArray);
                                }
                            }
                        }

                    }
                    resultados.Columns.RemoveAt(2);
                    resultados.Columns.RemoveAt(3);
                    resultados.Columns.RemoveAt(3);
                    return resultados;
                }
            }
        }

        public BitacorasLog BuscaBitacora(string codigo)
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
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Password", SqlDbType.VarChar, "password");
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Cod_Bitacora", SqlDbType.VarChar, codigo);
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return null;
                }
                else
                {
                    BitacorasLog bitacora = new BitacorasLog();
                    bitacora.Cod_Bitacora = ds.Tables[0].Rows[0][0].ToString();
                    bitacora.Fecha_Hora = ds.Tables[0].Rows[0][1].ToString();
                    bitacora.Descripcion = ds.Tables[0].Rows[0][2].ToString();
                    return bitacora;
                }
            }
        }

        public Boolean InsertaBitacora(BitacorasLog bitacora)
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return false;
            }
            else
            {
                sql = "sp_Inserta_Bitacora";
                ParamStruct[] parametros = new ParamStruct[10];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Usuario", SqlDbType.VarChar, bitacora.Cod_Usuario);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Fecha_Inicio", SqlDbType.DateTime, bitacora.Fecha_Inicio);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Fecha_Final", SqlDbType.DateTime, bitacora.Fecha_Final);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Tipo", SqlDbType.VarChar, bitacora.Tipo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Descripcion", SqlDbType.VarChar, bitacora.Descripcion);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Link", SqlDbType.VarChar, bitacora.Link);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@RegistroDetallado", SqlDbType.VarChar, bitacora.Fecha_Hora);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@Consecutivo", SqlDbType.VarChar, bitacora.Consecutivo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@Registro_Detalle", SqlDbType.VarChar, bitacora.Registro_Detalle);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 8, "@Cod_Bitacora", SqlDbType.VarChar, bitacora.Cod_Bitacora);
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

