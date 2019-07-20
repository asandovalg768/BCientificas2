using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DescargasLog
    {

        #region Constructores
        public DescargasLog()
        {
        }

        public DescargasLog(int cod_Descargas, string cod_Usuario, string fecha, string cod_Proyecto)
        {
            Cod_Descargas = cod_Descargas;
            Cod_Usuario = cod_Usuario;
            Fecha = fecha;
            Cod_Proyecto = cod_Proyecto;
        }


        #endregion


        #region Propiedades
        public int Cod_Descargas { get; set; }
        public string Cod_Usuario { get; set; }
        public string Fecha { get; set; }
        public string Cod_Proyecto { get; set; }


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
