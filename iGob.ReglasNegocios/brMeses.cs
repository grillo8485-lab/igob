using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brMeses:brConexion
		 {
	public int guardarMeses(beMeses obeMeses)
	{
		int IdMes;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daMeses odaMeses= new daMeses();
			IdMes =  odaMeses.guardarMeses(con, obeMeses);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdMes;
			}
	}

	public int actualizarMeses(beMeses obeMeses)
	{
		int IdMes;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daMeses odaMeses= new daMeses();
				IdMes =  odaMeses.actualizarMeses(con, obeMeses);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdMes;
			}
	}

	public int eliminarMeses(int IdMes)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daMeses odaMeses= new daMeses();
				IdMes =  odaMeses.eliminarMeses(con, IdMes);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdMes;
			}
	}

	public beMeses traerMeses_x_IdMes (int IdMes)
	{
		beMeses obeMeses=new beMeses();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daMeses odaMeses= new daMeses();
				 obeMeses =  odaMeses.traerMeses_x_IdMes(con, IdMes);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeMeses;
			}
	}

	public List<beMeses> listarTodos_Meses()
	 {
		List<beMeses> lbeMeses =new List<beMeses>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daMeses odaMeses= new daMeses();
				 lbeMeses =  odaMeses.listarTodos_Meses(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeMeses;
		}
	}
}
}
