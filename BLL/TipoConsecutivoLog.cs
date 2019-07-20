using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TipoConsecutivoLog
    {

        #region Constructores
        public TipoConsecutivoLog()
        {
        }

        public TipoConsecutivoLog(int cod_Tipo_Consecutivo, string tipo_Consecutivo)
        {
            Cod_Tipo_Consecutivo = cod_Tipo_Consecutivo;
            Tipo_Consecutivo = tipo_Consecutivo;
        }


        #endregion


        #region Propiedades
        public int Cod_Tipo_Consecutivo { get; set; }
        public string Tipo_Consecutivo { get; set; }

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
