using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brRequisicionesCondicionesPagos:brConexion
		 {
	public int guardarRequisicionesCondicionesPagos(beRequisicionesCondicionesPagos obeRequisicionesCondicionesPagos)
	{
		int IdRequisicionCondicionPago;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		    daRequisicionesCondicionesPagos odaRequisicionesCondicionesPagos= new daRequisicionesCondicionesPagos();
			IdRequisicionCondicionPago =  odaRequisicionesCondicionesPagos.guardarRequisicionesCondicionesPagos(con, obeRequisicionesCondicionesPagos);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdRequisicionCondicionPago;
			}
	}

	public int actualizarRequisicionesCondicionesPagos(beRequisicionesCondicionesPagos obeRequisicionesCondicionesPagos)
	{
		int IdRequisicionCondicionPago;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesCondicionesPagos odaRequisicionesCondicionesPagos= new daRequisicionesCondicionesPagos();
				IdRequisicionCondicionPago =  odaRequisicionesCondicionesPagos.actualizarRequisicionesCondicionesPagos(con, obeRequisicionesCondicionesPagos);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdRequisicionCondicionPago;
			}
	}

	public int eliminarRequisicionesCondicionesPagos(int IdRequisicionCondicionPago)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesCondicionesPagos odaRequisicionesCondicionesPagos= new daRequisicionesCondicionesPagos();
				IdRequisicionCondicionPago =  odaRequisicionesCondicionesPagos.eliminarRequisicionesCondicionesPagos(con, IdRequisicionCondicionPago);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdRequisicionCondicionPago;
			}
	}

	public beRequisicionesCondicionesPagos traerRequisicionesCondicionesPagos_x_IdRequisicionCondicionPago (int IdRequisicionCondicionPago)
	{
		beRequisicionesCondicionesPagos obeRequisicionesCondicionesPagos=new beRequisicionesCondicionesPagos();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesCondicionesPagos odaRequisicionesCondicionesPagos= new daRequisicionesCondicionesPagos();
				 obeRequisicionesCondicionesPagos =  odaRequisicionesCondicionesPagos.traerRequisicionesCondicionesPagos_x_IdRequisicionCondicionPago(con, IdRequisicionCondicionPago);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeRequisicionesCondicionesPagos;
			}
	}

	public List<beRequisicionesCondicionesPagos> listarTodos_RequisicionesCondicionesPagos()
	 {
		List<beRequisicionesCondicionesPagos> lbeRequisicionesCondicionesPagos =new List<beRequisicionesCondicionesPagos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesCondicionesPagos odaRequisicionesCondicionesPagos= new daRequisicionesCondicionesPagos();
				 lbeRequisicionesCondicionesPagos =  odaRequisicionesCondicionesPagos.listarTodos_RequisicionesCondicionesPagos(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesCondicionesPagos;
		}
	}
	public List<beRequisicionesCondicionesPagos> listarTodos_RequisicionesCondicionesPagos_GetAll()
	 {
		List<beRequisicionesCondicionesPagos> lbeRequisicionesCondicionesPagos =new List<beRequisicionesCondicionesPagos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesCondicionesPagos odaRequisicionesCondicionesPagos= new daRequisicionesCondicionesPagos();
				 lbeRequisicionesCondicionesPagos =  odaRequisicionesCondicionesPagos.listar_RequisicionesCondicionesPagos_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesCondicionesPagos;
		}
	}
}
}
