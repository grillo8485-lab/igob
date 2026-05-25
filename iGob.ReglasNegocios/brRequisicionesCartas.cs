using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brRequisicionesCartas:brConexion
		 {
	public int guardarRequisicionesCartas(beRequisicionesCartas obeRequisicionesCartas)
	{
		int IdProveedorRequisicionCarta;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daRequisicionesCartas odaRequisicionesCartas= new daRequisicionesCartas();
			IdProveedorRequisicionCarta =  odaRequisicionesCartas.guardarRequisicionesCartas(con, obeRequisicionesCartas);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdProveedorRequisicionCarta;
			}
	}

	public int actualizarRequisicionesCartas(beRequisicionesCartas obeRequisicionesCartas)
	{
		int IdProveedorRequisicionCarta;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesCartas odaRequisicionesCartas= new daRequisicionesCartas();
				IdProveedorRequisicionCarta =  odaRequisicionesCartas.actualizarRequisicionesCartas(con, obeRequisicionesCartas);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdProveedorRequisicionCarta;
			}
	}

	public int eliminarRequisicionesCartas(int IdProveedorRequisicionCarta)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesCartas odaRequisicionesCartas= new daRequisicionesCartas();
				IdProveedorRequisicionCarta =  odaRequisicionesCartas.eliminarRequisicionesCartas(con, IdProveedorRequisicionCarta);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdProveedorRequisicionCarta;
			}
	}

	public beRequisicionesCartas traerRequisicionesCartas_x_IdProveedorRequisicionCarta (int IdProveedorRequisicionCarta)
	{
		beRequisicionesCartas obeRequisicionesCartas=new beRequisicionesCartas();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesCartas odaRequisicionesCartas= new daRequisicionesCartas();
				 obeRequisicionesCartas =  odaRequisicionesCartas.traerRequisicionesCartas_x_IdProveedorRequisicionCarta(con, IdProveedorRequisicionCarta);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeRequisicionesCartas;
			}
	}

	public List<beRequisicionesCartas> listarTodos_RequisicionesCartas()
	 {
		List<beRequisicionesCartas> lbeRequisicionesCartas =new List<beRequisicionesCartas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesCartas odaRequisicionesCartas= new daRequisicionesCartas();
				 lbeRequisicionesCartas =  odaRequisicionesCartas.listarTodos_RequisicionesCartas(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesCartas;
		}
	}
	public List<beRequisicionesCartas> listarTodos_RequisicionesCartas_GetAll()
	 {
		List<beRequisicionesCartas> lbeRequisicionesCartas =new List<beRequisicionesCartas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesCartas odaRequisicionesCartas= new daRequisicionesCartas();
				 lbeRequisicionesCartas =  odaRequisicionesCartas.listar_RequisicionesCartas_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesCartas;
		}
	}
}
}
