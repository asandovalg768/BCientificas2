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

        public UsuariosLog(string cod_Usuario, string nombre, string primer_Apellido, string segundo_Apellido, string telefono, string username, string pass, float easy_Pay, string rol, string cod_Nivel_Academico, string cod_Puesto, string url_Firma, string url_Foto, SqlConnection cnn, string error, int numeroError, string sql, DataSet ds)
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
            Url_Firma = url_Firma;
            Url_Foto = url_Foto;
        }




        #endregion

        #region Propiedades
        public string Cod_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string Segundo_Apellido { get; set; }
        public string Telefono { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public float Easy_Pay { get; set; }
        public string Rol { get; set; }
        public string Cod_Nivel_Academico { get; set; }
        public string Cod_Puesto { get; set; }

        public string Url_Firma { get; set; }

        public string Url_Foto { get; set; }

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
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return false;
            }
            else
            {
                sql = "usp_Usuarios_Login";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Password", SqlDbType.VarChar, "password");
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Usuario", SqlDbType.VarChar, username);
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
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
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return false;
            }
            else
            {
                sql = "usp_Usuarios_Insert";
                ParamStruct[] parametros = new ParamStruct[13];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Usuario", SqlDbType.Int, username.Cod_Usuario);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Nombre", SqlDbType.VarChar, username.Nombre);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Primer_Apellido", SqlDbType.VarChar, username.Primer_Apellido);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Segundo_Apellido", SqlDbType.VarChar, username.Segundo_Apellido);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Telefono", SqlDbType.VarChar, username.Telefono);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Username", SqlDbType.VarChar, username.Username);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@Pass", SqlDbType.VarChar, username.Pass);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@Easy_Pay", SqlDbType.VarChar, username.Easy_Pay);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 8, "@Rol", SqlDbType.VarChar, username.Rol);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 9, "@Cod_Nivel_Academico", SqlDbType.VarChar, username.Cod_Nivel_Academico);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 10, "@Cod_Puesto", SqlDbType.VarChar, username.Cod_Puesto);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 11, "@Url_Foto", SqlDbType.VarChar, username.Url_Foto);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 11, "@Url_Firma", SqlDbType.VarChar, username.Url_Firma);
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

        public UsuariosLog BuscaUsuario(string userCode)
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return null;
            }
            else
            {
                sql = "sp_load***************";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Usuario_id", SqlDbType.VarChar, userCode);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Password", SqlDbType.VarChar, "password");
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return null;
                }
                else
                {
                    UsuariosLog user = new UsuariosLog();
                    user.Cod_Usuario = ds.Tables[0].Rows[0][0].ToString();
                    user.Nombre = ds.Tables[0].Rows[0][1].ToString();
                    user.Primer_Apellido = ds.Tables[0].Rows[0][2].ToString();
                    user.Segundo_Apellido = ds.Tables[0].Rows[0][3].ToString();
                    user.Telefono = ds.Tables[0].Rows[0][4].ToString();
                    user.Username = ds.Tables[0].Rows[0][5].ToString();
                    user.Pass = ds.Tables[0].Rows[0][6].ToString();
                    //user.Easy_Pay = ds.Tables[0].Rows[0][7].ToString();
                    user.Rol = ds.Tables[0].Rows[0][8].ToString();
                    user.Cod_Nivel_Academico = ds.Tables[0].Rows[0][9].ToString();
                    user.Cod_Puesto = ds.Tables[0].Rows[0][10].ToString();

                    return user;
                }
            }
        }


        #endregion

    }
}

