using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RamasCientificasLog
    {
        #region Constructores
        public RamasCientificasLog()
        {
        }

        public RamasCientificasLog(int cod_Rama, string nombre)
        {
            Cod_Rama = cod_Rama;
            Nombre = nombre;
        }


        #endregion


        #region Propiedades
        public int Cod_Rama { get; set; }
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

