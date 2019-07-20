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

        public DataSet CargarNiveleAcademico()
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
                sql = "sp**************** ";
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
                    ds.Tables[0].Columns[0].ColumnName = "Nivel Academico";
                    ds.Tables[0].Columns[1].ColumnName = "Nombre";
                    ds.Tables[0].Columns[2].ColumnName = "Detalle";
                    return ds;
                }
            }
        }



        #endregion


    }
}

