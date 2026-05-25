using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brMarcas:brConexion
		 {
	public int guardarMarcas(beMarcas obeMarcas)
	{
		int IdMarca;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daMarcas odaMarcas= new daMarcas();
			IdMarca =  odaMarcas.guardarMarcas(con, obeMarcas);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdMarca;
			}
	}

	public int actualizarMarcas(beMarcas obeMarcas)
	{
		int IdMarca;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daMarcas odaMarcas= new daMarcas();
				IdMarca =  odaMarcas.actualizarMarcas(con, obeMarcas);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdMarca;
			}
	}

	public int eliminarMarcas(int IdMarca)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daMarcas odaMarcas= new daMarcas();
				IdMarca =  odaMarcas.eliminarMarcas(con, IdMarca);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdMarca;
			}
	}

	public beMarcas traerMarcas_x_IdMarca (int IdMarca)
	{
		beMarcas obeMarcas=new beMarcas();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daMarcas odaMarcas= new daMarcas();
				 obeMarcas =  odaMarcas.traerMarcas_x_IdMarca(con, IdMarca);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeMarcas;
			}
	}

	public List<beMarcas> listarTodos_Marcas()
	 {
		List<beMarcas> lbeMarcas =new List<beMarcas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daMarcas odaMarcas= new daMarcas();
				 lbeMarcas =  odaMarcas.listarTodos_Marcas(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeMarcas;
		}
	}
}
}
