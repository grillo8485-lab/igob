using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brSysPerfilesFunciones:brConexion
		 {
	public int guardarSysPerfilesFunciones(beSysPerfilesFunciones obeSysPerfilesFunciones)
	{
		int IdPerfilFuncion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daSysPerfilesFunciones odaSysPerfilesFunciones= new daSysPerfilesFunciones();
			IdPerfilFuncion =  odaSysPerfilesFunciones.guardarSysPerfilesFunciones(con, obeSysPerfilesFunciones);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdPerfilFuncion;
			}
	}

	public int actualizarSysPerfilesFunciones(beSysPerfilesFunciones obeSysPerfilesFunciones)
	{
		int IdPerfilFuncion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daSysPerfilesFunciones odaSysPerfilesFunciones= new daSysPerfilesFunciones();
				IdPerfilFuncion =  odaSysPerfilesFunciones.actualizarSysPerfilesFunciones(con, obeSysPerfilesFunciones);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPerfilFuncion;
			}
	}

	public int eliminarSysPerfilesFunciones(int IdPerfilFuncion)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daSysPerfilesFunciones odaSysPerfilesFunciones= new daSysPerfilesFunciones();
				IdPerfilFuncion =  odaSysPerfilesFunciones.eliminarSysPerfilesFunciones(con, IdPerfilFuncion);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPerfilFuncion;
			}
	}

	public beSysPerfilesFunciones traerSysPerfilesFunciones_x_IdPerfilFuncion (int IdPerfilFuncion)
	{
		beSysPerfilesFunciones obeSysPerfilesFunciones=new beSysPerfilesFunciones();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daSysPerfilesFunciones odaSysPerfilesFunciones= new daSysPerfilesFunciones();
				 obeSysPerfilesFunciones =  odaSysPerfilesFunciones.traerSysPerfilesFunciones_x_IdPerfilFuncion(con, IdPerfilFuncion);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeSysPerfilesFunciones;
			}
	}
        public List<beSysPerfilesFunciones> traerSysPerfilesFunciones_x_IdPerfil(int IdPerfil)
        {
            List<beSysPerfilesFunciones> obeSysPerfilesFunciones = new List<beSysPerfilesFunciones>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daSysPerfilesFunciones odaSysPerfilesFunciones = new daSysPerfilesFunciones();
                    obeSysPerfilesFunciones = odaSysPerfilesFunciones.traerSysPerfilesFunciones_x_IdPerfil(con, IdPerfil);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeSysPerfilesFunciones;
            }
        }

        public List<beSysPerfilesFunciones> listarTodos_SysPerfilesFunciones()
	 {
		List<beSysPerfilesFunciones> lbeSysPerfilesFunciones =new List<beSysPerfilesFunciones>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daSysPerfilesFunciones odaSysPerfilesFunciones= new daSysPerfilesFunciones();
				 lbeSysPerfilesFunciones =  odaSysPerfilesFunciones.listarTodos_SysPerfilesFunciones(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeSysPerfilesFunciones;
		}
	}

	public DataTable listarTodos_SysPerfilesFunciones_GetAll()
	 {
		DataTable odtSysPerfilesFunciones =new DataTable();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daSysPerfilesFunciones odaSysPerfilesFunciones= new daSysPerfilesFunciones();
				 odtSysPerfilesFunciones =  odaSysPerfilesFunciones.listarSysPerfilesFunciones_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return odtSysPerfilesFunciones;
		}
	}
}
}
