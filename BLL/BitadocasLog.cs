using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BitadocasLog
    {

        #region Constructor

        public BitadocasLog()
        {
        }

        public BitadocasLog(string cod_Usuario, string fecha_Inicio, string fecha_Final, string tipo, string descripcion, string link, string fecha_Hora, string consecutivo, string registro_Detalle, string cod_Bitacora, SqlConnection cnn, string error, int numeroError, string sql, DataSet ds)
        {
            Cod_Usuario = cod_Usuario;
            Fecha_Inicio = fecha_Inicio;
            Fecha_Final = fecha_Final;
            Tipo = tipo;
            Descripcion = descripcion;
            Link = link;
            Fecha_Hora = fecha_Hora;
            Consecutivo = consecutivo;
            Registro_Detalle = registro_Detalle;
            Cod_Bitacora = cod_Bitacora;
            this.cnn = cnn;
            this.error = error;
            this.numeroError = numeroError;
            this.sql = sql;
            this.ds = ds;
        }



        #endregion


        #region Propiedades
        public string Cod_Usuario { get; set; }
        public string Fecha_Inicio { get; set; }
        public string Fecha_Final { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string Link { get; set; }
        public string Fecha_Hora { get; set; }
        public string Consecutivo { get; set; }
        public string Registro_Detalle { get; set; }
        public string Cod_Bitacora { get; set; }


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

