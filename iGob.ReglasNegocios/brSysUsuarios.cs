using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brSysUsuarios : brConexion
    {
        public int guardarSysUsuarios(beSysUsuarios obeSysUsuarios)
        {
            int IdUsuario = 0;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daSysUsuarios odaSysUsuarios = new daSysUsuarios();
                    IdUsuario = odaSysUsuarios.guardarSysUsuarios(con, obeSysUsuarios);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdUsuario;
            }
        }

        public int actualizarSysUsuarios(beSysUsuarios obeSysUsuarios)
        {
            int IdUsuario;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daSysUsuarios odaSysUsuarios = new daSysUsuarios();
                    IdUsuario = odaSysUsuarios.actualizarSysUsuarios(con, obeSysUsuarios);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdUsuario;
            }
        }

        public int eliminarSysUsuarios(int IdUsuario)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daSysUsuarios odaSysUsuarios = new daSysUsuarios();
                    IdUsuario = odaSysUsuarios.eliminarSysUsuarios(con, IdUsuario);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdUsuario;
            }
        }

        public beSysUsuarios traerSysUsuarios_x_IdUsuario(int IdUsuario)
        {
            beSysUsuarios obeSysUsuarios = new beSysUsuarios();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daSysUsuarios odaSysUsuarios = new daSysUsuarios();
                    obeSysUsuarios = odaSysUsuarios.traerSysUsuarios_x_IdUsuario(con, IdUsuario);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeSysUsuarios;
            }
        }

        public List<beSysUsuarios> listarTodos_SysUsuarios()
        {
            List<beSysUsuarios> lbeSysUsuarios = new List<beSysUsuarios>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daSysUsuarios odaSysUsuarios = new daSysUsuarios();
                    lbeSysUsuarios = odaSysUsuarios.listarTodos_SysUsuarios(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeSysUsuarios;
            }
        }

        public beSysUsuarios traerSysUsuario_x_Usuario_X_Password(string _username, string _password = "")
        {
            beSysUsuarios obeSysUsuarios = new beSysUsuarios();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daSysUsuarios odaSysUsuarios = new daSysUsuarios();
                    obeSysUsuarios = odaSysUsuarios.traerSysUsuario_x_Usuario_X_Password(con, _username, _password);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeSysUsuarios;
            }
        }

        public List<beSysUsuarios> Usuarios_Traer_IdPerfil(int IdPerfil)
        {
            List<beSysUsuarios> lbeSysUsuarios = new List<beSysUsuarios>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daSysUsuarios odaSysUsuarios = new daSysUsuarios();
                    lbeSysUsuarios = odaSysUsuarios.Usuarios_Traer_IdPerfil(con, IdPerfil);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeSysUsuarios;
            }
        }

    }
}
