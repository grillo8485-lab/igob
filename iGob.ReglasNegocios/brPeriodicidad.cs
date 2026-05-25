using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brPeriodicidad:brConexion
		 {
	public int guardarPeriodicidad(bePeriodicidad obePeriodicidad)
	{
		int IdPeriodicidad;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daPeriodicidad odaPeriodicidad= new daPeriodicidad();
			IdPeriodicidad =  odaPeriodicidad.guardarPeriodicidad(con, obePeriodicidad);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdPeriodicidad;
			}
	}

	public int actualizarPeriodicidad(bePeriodicidad obePeriodicidad)
	{
		int IdPeriodicidad;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPeriodicidad odaPeriodicidad= new daPeriodicidad();
				IdPeriodicidad =  odaPeriodicidad.actualizarPeriodicidad(con, obePeriodicidad);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPeriodicidad;
			}
	}

	public int eliminarPeriodicidad(int IdPeriodicidad)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPeriodicidad odaPeriodicidad= new daPeriodicidad();
				IdPeriodicidad =  odaPeriodicidad.eliminarPeriodicidad(con, IdPeriodicidad);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPeriodicidad;
			}
	}

	public bePeriodicidad traerPeriodicidad_x_IdPeriodicidad (int IdPeriodicidad)
	{
		bePeriodicidad obePeriodicidad=new bePeriodicidad();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPeriodicidad odaPeriodicidad= new daPeriodicidad();
				 obePeriodicidad =  odaPeriodicidad.traerPeriodicidad_x_IdPeriodicidad(con, IdPeriodicidad);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obePeriodicidad;
			}
	}

	public List<bePeriodicidad> listarTodos_Periodicidad()
	 {
		List<bePeriodicidad> lbePeriodicidad =new List<bePeriodicidad>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPeriodicidad odaPeriodicidad= new daPeriodicidad();
				 lbePeriodicidad =  odaPeriodicidad.listarTodos_Periodicidad(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePeriodicidad;
		}
	}
	public List<bePeriodicidad> listarTodos_Periodicidad_GetAll()
	 {
		List<bePeriodicidad> lbePeriodicidad =new List<bePeriodicidad>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPeriodicidad odaPeriodicidad= new daPeriodicidad();
				 lbePeriodicidad =  odaPeriodicidad.listar_Periodicidad_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePeriodicidad;
		}
	}
}
}
