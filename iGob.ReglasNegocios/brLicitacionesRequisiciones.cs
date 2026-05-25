using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brLicitacionesRequisiciones:brConexion
		 {
	public int guardarLicitacionesRequisiciones(beLicitacionesRequisiciones obeLicitacionesRequisiciones)
	{
		int IdLicitacionRequisicion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daLicitacionesRequisiciones odaLicitacionesRequisiciones= new daLicitacionesRequisiciones();
			IdLicitacionRequisicion =  odaLicitacionesRequisiciones.guardarLicitacionesRequisiciones(con, obeLicitacionesRequisiciones);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdLicitacionRequisicion;
			}
	}

	public int actualizarLicitacionesRequisiciones(beLicitacionesRequisiciones obeLicitacionesRequisiciones)
	{
		int IdLicitacionRequisicion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daLicitacionesRequisiciones odaLicitacionesRequisiciones= new daLicitacionesRequisiciones();
				IdLicitacionRequisicion =  odaLicitacionesRequisiciones.actualizarLicitacionesRequisiciones(con, obeLicitacionesRequisiciones);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdLicitacionRequisicion;
			}
	}

	public int eliminarLicitacionesRequisiciones(int IdLicitacionRequisicion)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daLicitacionesRequisiciones odaLicitacionesRequisiciones= new daLicitacionesRequisiciones();
				IdLicitacionRequisicion =  odaLicitacionesRequisiciones.eliminarLicitacionesRequisiciones(con, IdLicitacionRequisicion);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdLicitacionRequisicion;
			}
	}

	public beLicitacionesRequisiciones traerLicitacionesRequisiciones_x_IdLicitacionRequisicion (int IdLicitacionRequisicion)
	{
		beLicitacionesRequisiciones obeLicitacionesRequisiciones=new beLicitacionesRequisiciones();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daLicitacionesRequisiciones odaLicitacionesRequisiciones= new daLicitacionesRequisiciones();
				 obeLicitacionesRequisiciones =  odaLicitacionesRequisiciones.traerLicitacionesRequisiciones_x_IdLicitacionRequisicion(con, IdLicitacionRequisicion);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeLicitacionesRequisiciones;
			}
	}

	public List<beLicitacionesRequisiciones> listarTodos_LicitacionesRequisiciones()
	 {
		List<beLicitacionesRequisiciones> lbeLicitacionesRequisiciones =new List<beLicitacionesRequisiciones>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daLicitacionesRequisiciones odaLicitacionesRequisiciones= new daLicitacionesRequisiciones();
				 lbeLicitacionesRequisiciones =  odaLicitacionesRequisiciones.listarTodos_LicitacionesRequisiciones(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeLicitacionesRequisiciones;
		}
	}
	public List<beLicitacionesRequisiciones> listarTodos_LicitacionesRequisiciones_GetAll()
	 {
		List<beLicitacionesRequisiciones> lbeLicitacionesRequisiciones =new List<beLicitacionesRequisiciones>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daLicitacionesRequisiciones odaLicitacionesRequisiciones= new daLicitacionesRequisiciones();
				 lbeLicitacionesRequisiciones =  odaLicitacionesRequisiciones.listar_LicitacionesRequisiciones_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeLicitacionesRequisiciones;
		}
	}
}
}
