using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brImpuestos:brConexion
		 {
	public int guardarImpuestos(beImpuestos obeImpuestos)
	{
		int IdImpuesto;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daImpuestos odaImpuestos= new daImpuestos();
			IdImpuesto =  odaImpuestos.guardarImpuestos(con, obeImpuestos);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdImpuesto;
			}
	}

	public int actualizarImpuestos(beImpuestos obeImpuestos)
	{
		int IdImpuesto;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daImpuestos odaImpuestos= new daImpuestos();
				IdImpuesto =  odaImpuestos.actualizarImpuestos(con, obeImpuestos);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdImpuesto;
			}
	}

	public int eliminarImpuestos(int IdImpuesto)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daImpuestos odaImpuestos= new daImpuestos();
				IdImpuesto =  odaImpuestos.eliminarImpuestos(con, IdImpuesto);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdImpuesto;
			}
	}

	public beImpuestos traerImpuestos_x_IdImpuesto (int IdImpuesto)
	{
		beImpuestos obeImpuestos=new beImpuestos();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daImpuestos odaImpuestos= new daImpuestos();
				 obeImpuestos =  odaImpuestos.traerImpuestos_x_IdImpuesto(con, IdImpuesto);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeImpuestos;
			}
	}

	public List<beImpuestos> listarTodos_Impuestos()
	 {
		List<beImpuestos> lbeImpuestos =new List<beImpuestos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daImpuestos odaImpuestos= new daImpuestos();
				 lbeImpuestos =  odaImpuestos.listarTodos_Impuestos(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeImpuestos;
		}
	}
}
}
