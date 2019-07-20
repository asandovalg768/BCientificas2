using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ExperimentosLog
    {
        #region Constructores
        public ExperimentosLog()
        {
        }

        public ExperimentosLog(string cod_Experimento, string cod_Proyecto, string nombre, string cod_Usuario)
        {
            Cod_Experimento = cod_Experimento;
            Cod_Proyecto = cod_Proyecto;
            Nombre = nombre;
            Cod_Usuario = cod_Usuario;
        }


        #endregion


        #region Propiedades
        public string Cod_Experimento { get; set; }
        public string Cod_Proyecto { get; set; }
        public string Nombre { get; set; }
        public string Cod_Usuario { get; set; }


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

