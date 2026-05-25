using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brProveedoresRequisicionesCartas:brConexion
		 {
	public int guardarProveedoresRequisicionesCartas(beProveedoresRequisicionesCartas obeProveedoresRequisicionesCartas)
	{
		int IdProveedorCarta;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daProveedoresRequisicionesCartas odaProveedoresRequisicionesCartas= new daProveedoresRequisicionesCartas();
			IdProveedorCarta =  odaProveedoresRequisicionesCartas.guardarProveedoresRequisicionesCartas(con, obeProveedoresRequisicionesCartas);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdProveedorCarta;
			}
	}

	public int actualizarProveedoresRequisicionesCartas(beProveedoresRequisicionesCartas obeProveedoresRequisicionesCartas)
	{
		int IdProveedorCarta;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedoresRequisicionesCartas odaProveedoresRequisicionesCartas= new daProveedoresRequisicionesCartas();
				IdProveedorCarta =  odaProveedoresRequisicionesCartas.actualizarProveedoresRequisicionesCartas(con, obeProveedoresRequisicionesCartas);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdProveedorCarta;
			}
	}

	public int eliminarProveedoresRequisicionesCartas(int IdProveedorCarta)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedoresRequisicionesCartas odaProveedoresRequisicionesCartas= new daProveedoresRequisicionesCartas();
				IdProveedorCarta =  odaProveedoresRequisicionesCartas.eliminarProveedoresRequisicionesCartas(con, IdProveedorCarta);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdProveedorCarta;
			}
	}

	public beProveedoresRequisicionesCartas traerProveedoresRequisicionesCartas_x_IdProveedorCarta (int IdProveedorCarta)
	{
		beProveedoresRequisicionesCartas obeProveedoresRequisicionesCartas=new beProveedoresRequisicionesCartas();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedoresRequisicionesCartas odaProveedoresRequisicionesCartas= new daProveedoresRequisicionesCartas();
				 obeProveedoresRequisicionesCartas =  odaProveedoresRequisicionesCartas.traerProveedoresRequisicionesCartas_x_IdProveedorCarta(con, IdProveedorCarta);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeProveedoresRequisicionesCartas;
			}
	}

	public List<beProveedoresRequisicionesCartas> listarTodos_ProveedoresRequisicionesCartas()
	 {
		List<beProveedoresRequisicionesCartas> lbeProveedoresRequisicionesCartas =new List<beProveedoresRequisicionesCartas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedoresRequisicionesCartas odaProveedoresRequisicionesCartas= new daProveedoresRequisicionesCartas();
				 lbeProveedoresRequisicionesCartas =  odaProveedoresRequisicionesCartas.listarTodos_ProveedoresRequisicionesCartas(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeProveedoresRequisicionesCartas;
		}
	}
	public List<beProveedoresRequisicionesCartas> listarTodos_ProveedoresRequisicionesCartas_GetAll()
	 {
		List<beProveedoresRequisicionesCartas> lbeProveedoresRequisicionesCartas =new List<beProveedoresRequisicionesCartas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedoresRequisicionesCartas odaProveedoresRequisicionesCartas= new daProveedoresRequisicionesCartas();
				 lbeProveedoresRequisicionesCartas =  odaProveedoresRequisicionesCartas.listar_ProveedoresRequisicionesCartas_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeProveedoresRequisicionesCartas;
		}
	}
}
}
