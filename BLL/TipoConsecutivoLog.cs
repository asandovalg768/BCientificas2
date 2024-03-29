﻿using DAL;
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

        public Boolean ActualizaTipoConsecutivo(TipoConsecutivoLog tipo)
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
                sql = "usp_Tipo_ConsecutivoUpdate";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Tipo_Consecutivo", SqlDbType.Int, tipo.Cod_Tipo_Consecutivo);
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Tipo_Consecutivo", SqlDbType.VarChar, tipo.Tipo_Consecutivo);
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

        public Boolean InsertaTipoConsecutivo(TipoConsecutivoLog tipo)
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
                sql = "usp_Tipo_ConsecutivoInsert";
                ParamStruct[] parametros = new ParamStruct[1];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Cod_Tipo_Consecutivo", SqlDbType.VarChar, "Cod_Tipo_Consecutivo");
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

        public DataSet CargaTipoConsecutivo()
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return null;
            }
            else
            {
                sql = "sp_Lista_TipoConsecutivo";
                ParamStruct[] parametros = new ParamStruct[1];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Tipo_Consecutivo", SqlDbType.VarChar, "Cod_Tipo_Consecutivo");
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return null;
                }
                else
                {
                    ds.Tables[0].Columns[0].ColumnName = "Codigo";
                    ds.Tables[0].Columns[1].ColumnName = "Tipo";

                    return ds;
                }
            }
        }

        public TipoConsecutivoLog BuscaTipoConsecutivo(int codConsecutivo)
        {
            cnn = DAL.DAL.trae_conexion("ServiciosWeb", ref error, ref numeroError);
            if (cnn == null)
            {
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                return null;
            }
            else
            {
                sql = "sp_Carga_TipoConsecutivo";
                ParamStruct[] parametros = new ParamStruct[2];
                DAL.DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Cod_Tipo_Consecutivo", SqlDbType.Int, codConsecutivo);
                ds = DAL.DAL.ejecuta_dataset(cnn, sql, true, parametros, ref error, ref numeroError);
                if (numeroError != 0)
                {
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numeroError.ToString() + "&men=" + error);
                    return null;
                }
                else
                {
                    TipoConsecutivoLog tipoConsecutivo = new TipoConsecutivoLog();
                    tipoConsecutivo.Cod_Tipo_Consecutivo = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    tipoConsecutivo.Tipo_Consecutivo = ds.Tables[0].Rows[0][1].ToString();
                    return tipoConsecutivo;
                }
            }
        }


        #endregion

    }
}
