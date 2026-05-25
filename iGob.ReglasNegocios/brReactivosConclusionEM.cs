using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brReactivosConclusionEM:brConexion
		 {
	public int guardarReactivosConclusionEM(beReactivosConclusionEM obeReactivosConclusionEM)
	{
		int IdReactivoConclusionEM;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daReactivosConclusionEM odaReactivosConclusionEM= new daReactivosConclusionEM();
			IdReactivoConclusionEM =  odaReactivosConclusionEM.guardarReactivosConclusionEM(con, obeReactivosConclusionEM);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdReactivoConclusionEM;
			}
	}

	public int actualizarReactivosConclusionEM(beReactivosConclusionEM obeReactivosConclusionEM)
	{
		int IdReactivoConclusionEM;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daReactivosConclusionEM odaReactivosConclusionEM= new daReactivosConclusionEM();
				IdReactivoConclusionEM =  odaReactivosConclusionEM.actualizarReactivosConclusionEM(con, obeReactivosConclusionEM);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdReactivoConclusionEM;
			}
	}

	public int eliminarReactivosConclusionEM(int IdReactivoConclusionEM)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daReactivosConclusionEM odaReactivosConclusionEM= new daReactivosConclusionEM();
				IdReactivoConclusionEM =  odaReactivosConclusionEM.eliminarReactivosConclusionEM(con, IdReactivoConclusionEM);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdReactivoConclusionEM;
			}
	}

	public beReactivosConclusionEM traerReactivosConclusionEM_x_IdReactivoConclusionEM (int IdReactivoConclusionEM)
	{
		beReactivosConclusionEM obeReactivosConclusionEM=new beReactivosConclusionEM();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daReactivosConclusionEM odaReactivosConclusionEM= new daReactivosConclusionEM();
				 obeReactivosConclusionEM =  odaReactivosConclusionEM.traerReactivosConclusionEM_x_IdReactivoConclusionEM(con, IdReactivoConclusionEM);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeReactivosConclusionEM;
			}
	}

	public List<beReactivosConclusionEM> listarTodos_ReactivosConclusionEM()
	 {
		List<beReactivosConclusionEM> lbeReactivosConclusionEM =new List<beReactivosConclusionEM>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daReactivosConclusionEM odaReactivosConclusionEM= new daReactivosConclusionEM();
				 lbeReactivosConclusionEM =  odaReactivosConclusionEM.listarTodos_ReactivosConclusionEM(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeReactivosConclusionEM;
		}
	}
	public List<beReactivosConclusionEM> listarTodos_ReactivosConclusionEM_GetAll()
	 {
		List<beReactivosConclusionEM> lbeReactivosConclusionEM =new List<beReactivosConclusionEM>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daReactivosConclusionEM odaReactivosConclusionEM= new daReactivosConclusionEM();
				 lbeReactivosConclusionEM =  odaReactivosConclusionEM.listar_ReactivosConclusionEM_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeReactivosConclusionEM;
		}
	}
}
}
