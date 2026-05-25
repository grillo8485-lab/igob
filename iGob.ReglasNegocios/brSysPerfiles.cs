using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brSysPerfiles:brConexion
		 {
	public int guardarSysPerfiles(beSysPerfiles obeSysPerfiles)
	{
		int IdPerfil;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daSysPerfiles odaSysPerfiles= new daSysPerfiles();
			IdPerfil =  odaSysPerfiles.guardarSysPerfiles(con, obeSysPerfiles);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdPerfil;
			}
	}

	public int actualizarSysPerfiles(beSysPerfiles obeSysPerfiles)
	{
		int IdPerfil;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daSysPerfiles odaSysPerfiles= new daSysPerfiles();
				IdPerfil =  odaSysPerfiles.actualizarSysPerfiles(con, obeSysPerfiles);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPerfil;
			}
	}

	public int eliminarSysPerfiles(int IdPerfil)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daSysPerfiles odaSysPerfiles= new daSysPerfiles();
				IdPerfil =  odaSysPerfiles.eliminarSysPerfiles(con, IdPerfil);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPerfil;
			}
	}

	public beSysPerfiles traerSysPerfiles_x_IdPerfil (int IdPerfil)
	{
		beSysPerfiles obeSysPerfiles=new beSysPerfiles();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daSysPerfiles odaSysPerfiles= new daSysPerfiles();
				 obeSysPerfiles =  odaSysPerfiles.traerSysPerfiles_x_IdPerfil(con, IdPerfil);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeSysPerfiles;
			}
	}

	public List<beSysPerfiles> listarTodos_SysPerfiles()
	 {
		List<beSysPerfiles> lbeSysPerfiles =new List<beSysPerfiles>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daSysPerfiles odaSysPerfiles= new daSysPerfiles();
				 lbeSysPerfiles =  odaSysPerfiles.listarTodos_SysPerfiles(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeSysPerfiles;
		}
	}

	public DataTable listarTodos_SysPerfiles_GetAll()
	 {
		DataTable odtSysPerfiles =new DataTable();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daSysPerfiles odaSysPerfiles= new daSysPerfiles();
				 odtSysPerfiles =  odaSysPerfiles.listarSysPerfiles_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return odtSysPerfiles;
		}
	}
}
}
