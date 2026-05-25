using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brMuestras:brConexion
		 {
	public int guardarMuestras(beMuestras obeMuestras)
	{
		int IdMuestra;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daMuestras odaMuestras= new daMuestras();
			IdMuestra =  odaMuestras.guardarMuestras(con, obeMuestras);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdMuestra;
			}
	}

	public int actualizarMuestras(beMuestras obeMuestras)
	{
		int IdMuestra;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daMuestras odaMuestras= new daMuestras();
				IdMuestra =  odaMuestras.actualizarMuestras(con, obeMuestras);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdMuestra;
			}
	}

	public int eliminarMuestras(int IdMuestra)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daMuestras odaMuestras= new daMuestras();
				IdMuestra =  odaMuestras.eliminarMuestras(con, IdMuestra);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdMuestra;
			}
	}

	public beMuestras traerMuestras_x_IdMuestra (int IdMuestra)
	{
		beMuestras obeMuestras=new beMuestras();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daMuestras odaMuestras= new daMuestras();
				 obeMuestras =  odaMuestras.traerMuestras_x_IdMuestra(con, IdMuestra);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeMuestras;
			}
	}

	public List<beMuestras> listarTodos_Muestras()
	 {
		List<beMuestras> lbeMuestras =new List<beMuestras>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daMuestras odaMuestras= new daMuestras();
				 lbeMuestras =  odaMuestras.listarTodos_Muestras(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeMuestras;
		}
	}
}
}
