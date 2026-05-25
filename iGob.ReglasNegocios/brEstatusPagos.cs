using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brEstatusPagos:brConexion
		 {
	public int guardarEstatusPagos(beEstatusPagos obeEstatusPagos)
	{
		int IdEstatusPago;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daEstatusPagos odaEstatusPagos= new daEstatusPagos();
			IdEstatusPago =  odaEstatusPagos.guardarEstatusPagos(con, obeEstatusPagos);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdEstatusPago;
			}
	}

	public int actualizarEstatusPagos(beEstatusPagos obeEstatusPagos)
	{
		int IdEstatusPago;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusPagos odaEstatusPagos= new daEstatusPagos();
				IdEstatusPago =  odaEstatusPagos.actualizarEstatusPagos(con, obeEstatusPagos);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdEstatusPago;
			}
	}

	public int eliminarEstatusPagos(int IdEstatusPago)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusPagos odaEstatusPagos= new daEstatusPagos();
				IdEstatusPago =  odaEstatusPagos.eliminarEstatusPagos(con, IdEstatusPago);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdEstatusPago;
			}
	}

	public beEstatusPagos traerEstatusPagos_x_IdEstatusPago (int IdEstatusPago)
	{
		beEstatusPagos obeEstatusPagos=new beEstatusPagos();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusPagos odaEstatusPagos= new daEstatusPagos();
				 obeEstatusPagos =  odaEstatusPagos.traerEstatusPagos_x_IdEstatusPago(con, IdEstatusPago);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeEstatusPagos;
			}
	}

	public List<beEstatusPagos> listarTodos_EstatusPagos()
	 {
		List<beEstatusPagos> lbeEstatusPagos =new List<beEstatusPagos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusPagos odaEstatusPagos= new daEstatusPagos();
				 lbeEstatusPagos =  odaEstatusPagos.listarTodos_EstatusPagos(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEstatusPagos;
		}
	}
	public List<beEstatusPagos> listarTodos_EstatusPagos_GetAll()
	 {
		List<beEstatusPagos> lbeEstatusPagos =new List<beEstatusPagos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEstatusPagos odaEstatusPagos= new daEstatusPagos();
				 lbeEstatusPagos =  odaEstatusPagos.listar_EstatusPagos_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEstatusPagos;
		}
	}
}
}
