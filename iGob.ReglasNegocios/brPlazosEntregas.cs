using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brPlazosEntregas:brConexion
		 {
	public int guardarPlazosEntregas(bePlazosEntregas obePlazosEntregas)
	{
		int IdPlazoEntrega;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daPlazosEntregas odaPlazosEntregas= new daPlazosEntregas();
			IdPlazoEntrega =  odaPlazosEntregas.guardarPlazosEntregas(con, obePlazosEntregas);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdPlazoEntrega;
			}
	}

	public int actualizarPlazosEntregas(bePlazosEntregas obePlazosEntregas)
	{
		int IdPlazoEntrega;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPlazosEntregas odaPlazosEntregas= new daPlazosEntregas();
				IdPlazoEntrega =  odaPlazosEntregas.actualizarPlazosEntregas(con, obePlazosEntregas);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPlazoEntrega;
			}
	}

	public int eliminarPlazosEntregas(int IdPlazoEntrega)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPlazosEntregas odaPlazosEntregas= new daPlazosEntregas();
				IdPlazoEntrega =  odaPlazosEntregas.eliminarPlazosEntregas(con, IdPlazoEntrega);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPlazoEntrega;
			}
	}

	public bePlazosEntregas traerPlazosEntregas_x_IdPlazoEntrega (int IdPlazoEntrega)
	{
		bePlazosEntregas obePlazosEntregas=new bePlazosEntregas();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPlazosEntregas odaPlazosEntregas= new daPlazosEntregas();
				 obePlazosEntregas =  odaPlazosEntregas.traerPlazosEntregas_x_IdPlazoEntrega(con, IdPlazoEntrega);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obePlazosEntregas;
			}
	}

	public List<bePlazosEntregas> listarTodos_PlazosEntregas()
	 {
		List<bePlazosEntregas> lbePlazosEntregas =new List<bePlazosEntregas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPlazosEntregas odaPlazosEntregas= new daPlazosEntregas();
				 lbePlazosEntregas =  odaPlazosEntregas.listarTodos_PlazosEntregas(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePlazosEntregas;
		}
	}
	public List<bePlazosEntregas> listarTodos_PlazosEntregas_GetAll()
	 {
		List<bePlazosEntregas> lbePlazosEntregas =new List<bePlazosEntregas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPlazosEntregas odaPlazosEntregas= new daPlazosEntregas();
				 lbePlazosEntregas =  odaPlazosEntregas.listar_PlazosEntregas_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePlazosEntregas;
		}
	}
}
}
