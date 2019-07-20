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
    public class NivelAcademicoLog
    {
        #region Constructores
        public NivelAcademicoLog()
        {
        }

        public NivelAcademicoLog(string cod_Nivel_Academico, string tipo, string nombre, bool completado, string detalle)
        {
            Cod_Nivel_Academico = cod_Nivel_Academico;
            Tipo = tipo;
            Nombre = nombre;
            Completado = completado;
            Detalle = detalle;
        }

        #endregion


        #region Propiedades
        public string Cod_Nivel_Academico { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public Boolean Completado { get; set; }
        public string Detalle { get; set; }


        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #region Metodos

        public Boolean ActualizaNivelAcademico(NivelAcademicoLog nivel)
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return false;
            }
            else
            {
                sql = "usp_Nivel_Academico_Update";
                ParamStruct[] parametros = new ParamStruct[4];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Tipo", SqlDbType.VarChar, nivel.Tipo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Nombre", SqlDbType.VarChar, nivel.Nombre);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Completado", SqlDbType.VarChar, nivel.Completado);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Detalle", SqlDbType.VarChar, nivel.Detalle);
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

        public Boolean InsertaNivelAcademico(NivelAcademicoLog nivel)
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return false;
            }
            else
            {
                sql = "usp_Nivel_Academico_Insert";
                ParamStruct[] parametros = new ParamStruct[4];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Tipo", SqlDbType.VarChar, nivel.Tipo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Nombre", SqlDbType.VarChar, nivel.Nombre);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Completado", SqlDbType.VarChar, nivel.Completado);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Detalle", SqlDbType.VarChar, nivel.Detalle);
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

