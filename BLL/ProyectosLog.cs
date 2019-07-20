using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProyectosLog
    {

        #region Constructores
        public ProyectosLog()
        {
        }

        public ProyectosLog(int cod_Proyecto, string nombre, string descripcion, int cod_Rama, float precio, string autor, DateTime fecha_Creacion, string idioma)
        {
            Cod_Proyecto = cod_Proyecto;
            Nombre = nombre;
            Descripcion = descripcion;
            Cod_Rama = cod_Rama;
            Precio = precio;
            Autor = autor;
            Fecha_Creacion = fecha_Creacion;
            Idioma = idioma;
        }


        #endregion


        #region Propiedades
        public int Cod_Bitacora_Experimental { get; set; }
        public int Cod_Proyecto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cod_Rama { get; set; }
        public float Precio { get; set; }
        public string Autor { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public string Idioma { get; set; }


        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #region Metodos



        #endregion
    }
}
