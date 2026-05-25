using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brSysFunciones:brConexion
		 {
	public int guardarSysFunciones(beSysFunciones obeSysFunciones)
	{
		int IdFuncion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daSysFunciones odaSysFunciones= new daSysFunciones();
			IdFuncion =  odaSysFunciones.guardarSysFunciones(con, obeSysFunciones);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdFuncion;
			}
	}

	public int actualizarSysFunciones(beSysFunciones obeSysFunciones)
	{
		int IdFuncion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daSysFunciones odaSysFunciones= new daSysFunciones();
				IdFuncion =  odaSysFunciones.actualizarSysFunciones(con, obeSysFunciones);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdFuncion;
			}
	}

	public int eliminarSysFunciones(int IdFuncion)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daSysFunciones odaSysFunciones= new daSysFunciones();
				IdFuncion =  odaSysFunciones.eliminarSysFunciones(con, IdFuncion);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdFuncion;
			}
	}

	public beSysFunciones traerSysFunciones_x_IdFuncion (int IdFuncion)
	{
		beSysFunciones obeSysFunciones=new beSysFunciones();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daSysFunciones odaSysFunciones= new daSysFunciones();
				 obeSysFunciones =  odaSysFunciones.traerSysFunciones_x_IdFuncion(con, IdFuncion);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeSysFunciones;
			}
	}

	public List<beSysFunciones> listarTodos_SysFunciones()
	 {
		List<beSysFunciones> lbeSysFunciones =new List<beSysFunciones>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daSysFunciones odaSysFunciones= new daSysFunciones();
				 lbeSysFunciones =  odaSysFunciones.listarTodos_SysFunciones(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeSysFunciones;
		}
	}


	public DataTable listarTodos_SysFunciones_GetAll()
	 {
		DataTable odtSysFunciones =new DataTable();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daSysFunciones odaSysFunciones= new daSysFunciones();
				 odtSysFunciones =  odaSysFunciones.listarSysFunciones_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return odtSysFunciones;
		}
	}
}
}
