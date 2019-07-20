using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



        #endregion  
    }
}