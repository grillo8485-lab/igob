using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brCuentasBancariasDependencias : brConexion
    {
        public int guardarCuentasBancariasDependencias(beCuentasBancariasDependencias obeCuentasBancariasDependencias)
        {
            int IdCuentaBancaria;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCuentasBancariasDependencias odaCuentasBancariasDependencias = new daCuentasBancariasDependencias();
                    IdCuentaBancaria = odaCuentasBancariasDependencias.guardarCuentasBancariasDependencias(con, obeCuentasBancariasDependencias);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdCuentaBancaria;
            }
        }

        public int actualizarCuentasBancariasDependencias(beCuentasBancariasDependencias obeCuentasBancariasDependencias)
        {
            int IdCuentaBancaria;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCuentasBancariasDependencias odaCuentasBancariasDependencias = new daCuentasBancariasDependencias();
                    IdCuentaBancaria = odaCuentasBancariasDependencias.actualizarCuentasBancariasDependencias(con, obeCuentasBancariasDependencias);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdCuentaBancaria;
            }
        }

        public int eliminarCuentasBancariasDependencias(int IdCuentaBancaria)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCuentasBancariasDependencias odaCuentasBancariasDependencias = new daCuentasBancariasDependencias();
                    IdCuentaBancaria = odaCuentasBancariasDependencias.eliminarCuentasBancariasDependencias(con, IdCuentaBancaria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdCuentaBancaria;
            }
        }

        public beCuentasBancariasDependencias traerCuentasBancariasDependencias_x_IdCuentaBancaria(int IdCuentaBancaria)
        {
            beCuentasBancariasDependencias obeCuentasBancariasDependencias = new beCuentasBancariasDependencias();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCuentasBancariasDependencias odaCuentasBancariasDependencias = new daCuentasBancariasDependencias();
                    obeCuentasBancariasDependencias = odaCuentasBancariasDependencias.traerCuentasBancariasDependencias_x_IdCuentaBancaria(con, IdCuentaBancaria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeCuentasBancariasDependencias;
            }
        }

        public List<beCuentasBancariasDependencias> listarTodos_CuentasBancariasDependencias()
        {
            List<beCuentasBancariasDependencias> lbeCuentasBancariasDependencias = new List<beCuentasBancariasDependencias>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCuentasBancariasDependencias odaCuentasBancariasDependencias = new daCuentasBancariasDependencias();
                    lbeCuentasBancariasDependencias = odaCuentasBancariasDependencias.listarTodos_CuentasBancariasDependencias(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCuentasBancariasDependencias;
            }
        }
        public List<beCuentasBancariasDependencias> listarTodos_CuentasBancariasDependencias_GetAll()
        {
            List<beCuentasBancariasDependencias> lbeCuentasBancariasDependencias = new List<beCuentasBancariasDependencias>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCuentasBancariasDependencias odaCuentasBancariasDependencias = new daCuentasBancariasDependencias();
                    lbeCuentasBancariasDependencias = odaCuentasBancariasDependencias.listar_CuentasBancariasDependencias_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCuentasBancariasDependencias;
            }
        }

        public List<beCuentasBancariasDependencias> listar_CuentasBancariasDependenciasIngProp_TraerTodas(int IdDependencia)
        {
            List<beCuentasBancariasDependencias> lbeCuentasBancariasDependencias = new List<beCuentasBancariasDependencias>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCuentasBancariasDependencias odaCuentasBancariasDependencias = new daCuentasBancariasDependencias();
                    lbeCuentasBancariasDependencias = odaCuentasBancariasDependencias.listar_CuentasBancariasDependenciasIngProp_TraerTodas(con,IdDependencia);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCuentasBancariasDependencias;
            }
        }
        //Usado en cuentas bancarias
        public List<beCuentasBancariasDependencias> listarTodosCuentasBancariasPorDependencias()
        {
            List<beCuentasBancariasDependencias> lbeCuentasBancariasDependencias = new List<beCuentasBancariasDependencias>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCuentasBancariasDependencias odaCuentasBancariasDependencias = new daCuentasBancariasDependencias();
                    lbeCuentasBancariasDependencias = odaCuentasBancariasDependencias.listarTodosCuentasBancariasPorDependencias(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCuentasBancariasDependencias;
            }
        }
        //Usado en cuentas bancarias
        public List<beCuentasBancariasDependencias> ListadoCuentasBancariasFiltradasPorDependencias(int IdDependencia)
        {
            List<beCuentasBancariasDependencias> lbeCuentasBancariasDependencias = new List<beCuentasBancariasDependencias>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCuentasBancariasDependencias odaCuentasBancariasDependencias = new daCuentasBancariasDependencias();
                    lbeCuentasBancariasDependencias = odaCuentasBancariasDependencias.ListadoCuentasBancariasFiltradasPorDependencias(con, IdDependencia);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCuentasBancariasDependencias;
            }
        }
    }
}
