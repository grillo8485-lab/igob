using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brFormasPago:brConexion
		 {
	public int guardarFormasPago(beFormasPago obeFormasPago)
	{
		int IdFormaPago;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daFormasPago odaFormasPago= new daFormasPago();
			IdFormaPago =  odaFormasPago.guardarFormasPago(con, obeFormasPago);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdFormaPago;
			}
	}

	public int actualizarFormasPago(beFormasPago obeFormasPago)
	{
		int IdFormaPago;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daFormasPago odaFormasPago= new daFormasPago();
				IdFormaPago =  odaFormasPago.actualizarFormasPago(con, obeFormasPago);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdFormaPago;
			}
	}

	public int eliminarFormasPago(int IdFormaPago)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daFormasPago odaFormasPago= new daFormasPago();
				IdFormaPago =  odaFormasPago.eliminarFormasPago(con, IdFormaPago);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdFormaPago;
			}
	}

	public beFormasPago traerFormasPago_x_IdFormaPago (int IdFormaPago)
	{
		beFormasPago obeFormasPago=new beFormasPago();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daFormasPago odaFormasPago= new daFormasPago();
				 obeFormasPago =  odaFormasPago.traerFormasPago_x_IdFormaPago(con, IdFormaPago);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeFormasPago;
			}
	}

	public List<beFormasPago> listarTodos_FormasPago()
	 {
		List<beFormasPago> lbeFormasPago =new List<beFormasPago>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daFormasPago odaFormasPago= new daFormasPago();
				 lbeFormasPago =  odaFormasPago.listarTodos_FormasPago(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeFormasPago;
		}
	}
}
}
