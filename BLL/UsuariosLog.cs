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
    public class UsuariosLog
    {
        #region Constructores
        public UsuariosLog()
        {
        }

        public UsuariosLog(int cod_Usuario, string nombre, string primer_Apellido, string segundo_Apellido, int telefono, string username, string pass, float easy_Pay, string rol, int cod_Nivel_Academico, int cod_Puesto)
        {
            Cod_Usuario = cod_Usuario;
            Nombre = nombre;
            Primer_Apellido = primer_Apellido;
            Segundo_Apellido = segundo_Apellido;
            Telefono = telefono;
            Username = username;
            Pass = pass;
            Easy_Pay = easy_Pay;
            Rol = rol;
            Cod_Nivel_Academico = cod_Nivel_Academico;
            Cod_Puesto = cod_Puesto;
        }
        #endregion

        #region Propiedades
        public int Cod_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string Segundo_Apellido { get; set; }
        public int Telefono { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public float Easy_Pay { get; set; }
        public string Rol { get; set; }
        public int Cod_Nivel_Academico { get; set; }
        public int Cod_Puesto { get; set; }

        #endregion

        SqlConnection cnn;
        string error;
        int numeroError;
        string sql;
        DataSet ds;

        #region Metodos


        public Boolean Login(string username, string pass)
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return false;
            }
            else
            {
                sql = "sp_inserta_usuarios ";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Pass", SqlDbType.VarChar, "pass");
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Username", SqlDbType.VarChar, username);
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return false;
                }
                else
                {
                    foreach (DataTable dt in ds.Tables)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i][1].ToString() == username && dt.Rows[i][2].ToString() == pass)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
            }
        }

        public Boolean CrearUsuario(UsuariosLog username)
        {
            cnn = DAL.DAL.trae_conexion("*****************", ref error, ref numeroError);
            if (cnn == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return false;
            }
            else
            {
                sql = "sp*****************";
                ParamStruct[] parametros = new ParamStruct[12];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Usuario", SqlDbType.Int, username.Cod_Usuario);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Nombre", SqlDbType.VarChar, username.Nombre);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Primer_Apellido", SqlDbType.VarChar, username.Primer_Apellido);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Segundo_Apellido", SqlDbType.VarChar, username.Segundo_Apellido);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Telefono", SqlDbType.VarChar, username.Telefono);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@urlFirma", SqlDbType.VarChar, username.UrlFirma);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@urlFoto", SqlDbType.VarChar, username.UrlFoto);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@Username", SqlDbType.VarChar, username.Username);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 8, "@Pass", SqlDbType.VarChar, username.Pass);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 9, "@Rol", SqlDbType.VarChar, username.Rol);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 10, "@Cod_Nivel_Academico", SqlDbType.VarChar, username.Cod_Nivel_Academico);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 11, "@PasswordE", SqlDbType.VarChar, "password");
                DAL.DAL.conectar(cnn, ref error, ref numeroError);
                DAL.DAL.ejecuta_sqlcommand(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    DAL.DAL.desconectar(cnn, ref error, ref numeroError);
                    return false;
                }
                else
                {
                    DAL.DAL.desconectar(cnn, ref error, ref numeroError);
                    return true;
                }
            }
        }
        #endregion

    }
}

