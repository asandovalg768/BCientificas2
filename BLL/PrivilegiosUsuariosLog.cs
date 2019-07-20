using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PrivilegiosUsuariosLog
    {

        #region Constructores
        public PrivilegiosUsuariosLog()
        {
        }

        public PrivilegiosUsuariosLog(int cod_Privilegio, string cod_Usuario, bool activo)
        {
            Cod_Privilegio = cod_Privilegio;
            Cod_Usuario = cod_Usuario;
            Activo = activo;
        }


        #endregion


        #region Propiedades
        public int Cod_Privilegio { get; set; }
        public string Cod_Usuario { get; set; }
        public Boolean Activo { get; set; }


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

