using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PuestosLog
    {

        #region Constructores
        public PuestosLog()
        {
        }

        public PuestosLog(int cod_Puesto, string nombre)
        {
            Cod_Puesto = cod_Puesto;
            Nombre = nombre;
        }


        #endregion


        #region Propiedades
        public int Cod_Puesto { get; set; }
        public string Nombre { get; set; }


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
