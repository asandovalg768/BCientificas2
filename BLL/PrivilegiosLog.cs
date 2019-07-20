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
    public class PrivilegiosLog
    {

        #region Constructores
        public PrivilegiosLog()
        {
        }

        public PrivilegiosLog(int cod_Privilegio, string privilegio)
        {
            Cod_Privilegio = cod_Privilegio;
            Privilegio = privilegio;
        }


        #endregion


        #region Propiedades
        public int Cod_Privilegio { get; set; }
        public string Privilegio { get; set; }


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

