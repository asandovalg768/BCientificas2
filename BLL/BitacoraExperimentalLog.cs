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

        public BitacoraExperimentalLog(int cod_Bitacora_Experimental, string objetivos, string descripcion, string equipo, string procedimientos, int cod_Experimentos, DateTime fecha, bool firma)
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
        public int Cod_Bitacora_Experimental { get; set; }

        public string Objetivos { get; set; }

        public string Descripcion { get; set; }

        public string Equipo { get; set; }

        public string Procedimientos { get; set; }

        public int Cod_Experimentos { get; set; }

        public DateTime Fecha { get; set; }

        public Boolean Firma { get; set; }


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