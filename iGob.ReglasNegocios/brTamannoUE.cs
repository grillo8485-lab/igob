using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brTamannoUE:brConexion
		 {
	public int guardarTamannoUE(beTamannoUE obeTamannoUE)
	{
		int IdTamannoUE;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daTamannoUE odaTamannoUE= new daTamannoUE();
			IdTamannoUE =  odaTamannoUE.guardarTamannoUE(con, obeTamannoUE);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdTamannoUE;
			}
	}

	public int actualizarTamannoUE(beTamannoUE obeTamannoUE)
	{
		int IdTamannoUE;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTamannoUE odaTamannoUE= new daTamannoUE();
				IdTamannoUE =  odaTamannoUE.actualizarTamannoUE(con, obeTamannoUE);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTamannoUE;
			}
	}

	public int eliminarTamannoUE(int IdTamannoUE)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTamannoUE odaTamannoUE= new daTamannoUE();
				IdTamannoUE =  odaTamannoUE.eliminarTamannoUE(con, IdTamannoUE);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTamannoUE;
			}
	}

	public beTamannoUE traerTamannoUE_x_IdTamannoUE (int IdTamannoUE)
	{
		beTamannoUE obeTamannoUE=new beTamannoUE();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTamannoUE odaTamannoUE= new daTamannoUE();
				 obeTamannoUE =  odaTamannoUE.traerTamannoUE_x_IdTamannoUE(con, IdTamannoUE);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTamannoUE;
			}
	}

	public List<beTamannoUE> listarTodos_TamannoUE()
	 {
		List<beTamannoUE> lbeTamannoUE =new List<beTamannoUE>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTamannoUE odaTamannoUE= new daTamannoUE();
				 lbeTamannoUE =  odaTamannoUE.listarTodos_TamannoUE(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTamannoUE;
		}
	}
	public List<beTamannoUE> listarTodos_TamannoUE_GetAll()
	 {
		List<beTamannoUE> lbeTamannoUE =new List<beTamannoUE>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTamannoUE odaTamannoUE= new daTamannoUE();
				 lbeTamannoUE =  odaTamannoUE.listar_TamannoUE_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTamannoUE;
		}
	}
}
}
