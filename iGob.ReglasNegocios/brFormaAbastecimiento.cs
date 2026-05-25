using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brFormaAbastecimiento:brConexion
		 {
	public int guardarFormaAbastecimiento(beFormaAbastecimiento obeFormaAbastecimiento)
	{
		int IdFormaAbastecimiento;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daFormaAbastecimiento odaFormaAbastecimiento= new daFormaAbastecimiento();
			IdFormaAbastecimiento =  odaFormaAbastecimiento.guardarFormaAbastecimiento(con, obeFormaAbastecimiento);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdFormaAbastecimiento;
			}
	}

	public int actualizarFormaAbastecimiento(beFormaAbastecimiento obeFormaAbastecimiento)
	{
		int IdFormaAbastecimiento;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daFormaAbastecimiento odaFormaAbastecimiento= new daFormaAbastecimiento();
				IdFormaAbastecimiento =  odaFormaAbastecimiento.actualizarFormaAbastecimiento(con, obeFormaAbastecimiento);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdFormaAbastecimiento;
			}
	}

	public int eliminarFormaAbastecimiento(int IdFormaAbastecimiento)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daFormaAbastecimiento odaFormaAbastecimiento= new daFormaAbastecimiento();
				IdFormaAbastecimiento =  odaFormaAbastecimiento.eliminarFormaAbastecimiento(con, IdFormaAbastecimiento);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdFormaAbastecimiento;
			}
	}

	public beFormaAbastecimiento traerFormaAbastecimiento_x_IdFormaAbastecimiento (int IdFormaAbastecimiento)
	{
		beFormaAbastecimiento obeFormaAbastecimiento=new beFormaAbastecimiento();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daFormaAbastecimiento odaFormaAbastecimiento= new daFormaAbastecimiento();
				 obeFormaAbastecimiento =  odaFormaAbastecimiento.traerFormaAbastecimiento_x_IdFormaAbastecimiento(con, IdFormaAbastecimiento);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeFormaAbastecimiento;
			}
	}

	public List<beFormaAbastecimiento> listarTodos_FormaAbastecimiento()
	 {
		List<beFormaAbastecimiento> lbeFormaAbastecimiento =new List<beFormaAbastecimiento>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daFormaAbastecimiento odaFormaAbastecimiento= new daFormaAbastecimiento();
				 lbeFormaAbastecimiento =  odaFormaAbastecimiento.listarTodos_FormaAbastecimiento(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeFormaAbastecimiento;
		}
	}
}
}
