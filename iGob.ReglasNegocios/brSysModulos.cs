using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brSysModulos:brConexion
		 {
	public int guardarSysModulos(beSysModulos obeSysModulos)
	{
		int IdModulo;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daSysModulos odaSysModulos= new daSysModulos();
			IdModulo =  odaSysModulos.guardarSysModulos(con, obeSysModulos);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdModulo;
			}
	}

	public int actualizarSysModulos(beSysModulos obeSysModulos)
	{
		int IdModulo;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daSysModulos odaSysModulos= new daSysModulos();
				IdModulo =  odaSysModulos.actualizarSysModulos(con, obeSysModulos);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdModulo;
			}
	}

	public int eliminarSysModulos(int IdModulo)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daSysModulos odaSysModulos= new daSysModulos();
				IdModulo =  odaSysModulos.eliminarSysModulos(con, IdModulo);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdModulo;
			}
	}

	public beSysModulos traerSysModulos_x_IdModulo (int IdModulo)
	{
		beSysModulos obeSysModulos=new beSysModulos();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daSysModulos odaSysModulos= new daSysModulos();
				 obeSysModulos =  odaSysModulos.traerSysModulos_x_IdModulo(con, IdModulo);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeSysModulos;
			}
	}

	public List<beSysModulos> listarTodos_SysModulos()
	 {
		List<beSysModulos> lbeSysModulos =new List<beSysModulos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daSysModulos odaSysModulos= new daSysModulos();
				 lbeSysModulos =  odaSysModulos.listarTodos_SysModulos(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeSysModulos;
		}
	}

	public DataTable listarTodos_SysModulos_GetAll()
	 {
		DataTable odtSysModulos =new DataTable();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daSysModulos odaSysModulos= new daSysModulos();
				 odtSysModulos =  odaSysModulos.listarSysModulos_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return odtSysModulos;
		}
	}
}
}
