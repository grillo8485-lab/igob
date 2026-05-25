using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brRequisiciones:brConexion
		 {
	public int guardarRequisiciones(beRequisiciones obeRequisiciones)
	{
		int IdRequisicion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daRequisiciones odaRequisiciones= new daRequisiciones();
			IdRequisicion =  odaRequisiciones.guardarRequisiciones(con, obeRequisiciones);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdRequisicion;
			}
	}

	public int actualizarRequisiciones(beRequisiciones obeRequisiciones)
	{
		int IdRequisicion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisiciones odaRequisiciones= new daRequisiciones();
				IdRequisicion =  odaRequisiciones.actualizarRequisiciones(con, obeRequisiciones);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdRequisicion;
			}
	}

	public int eliminarRequisiciones(int IdRequisicion)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisiciones odaRequisiciones= new daRequisiciones();
				IdRequisicion =  odaRequisiciones.eliminarRequisiciones(con, IdRequisicion);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdRequisicion;
			}
	}

	public beRequisiciones traerRequisiciones_x_IdRequisicion (int IdRequisicion)
	{
		beRequisiciones obeRequisiciones=new beRequisiciones();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisiciones odaRequisiciones= new daRequisiciones();
				 obeRequisiciones =  odaRequisiciones.traerRequisiciones_x_IdRequisicion(con, IdRequisicion);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeRequisiciones;
			}
	}

	public List<beRequisiciones> listarTodos_Requisiciones()
	 {
		List<beRequisiciones> lbeRequisiciones =new List<beRequisiciones>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisiciones odaRequisiciones= new daRequisiciones();
				 lbeRequisiciones =  odaRequisiciones.listarTodos_Requisiciones(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisiciones;
		}
	}
	public List<beRequisiciones> listarTodos_Requisiciones_GetAll()
	 {
		List<beRequisiciones> lbeRequisiciones =new List<beRequisiciones>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisiciones odaRequisiciones= new daRequisiciones();
				 lbeRequisiciones =  odaRequisiciones.listar_Requisiciones_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisiciones;
		}
	}
}
}
