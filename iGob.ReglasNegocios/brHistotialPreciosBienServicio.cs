using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brHistotialPreciosBienServicio:brConexion
		 {
	public int guardarHistotialPreciosBienServicio(beHistotialPreciosBienServicio obeHistotialPreciosBienServicio)
	{
		int IdHistorialPrecioBienServicio;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daHistotialPreciosBienServicio odaHistotialPreciosBienServicio= new daHistotialPreciosBienServicio();
			IdHistorialPrecioBienServicio =  odaHistotialPreciosBienServicio.guardarHistotialPreciosBienServicio(con, obeHistotialPreciosBienServicio);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdHistorialPrecioBienServicio;
			}
	}

	public int actualizarHistotialPreciosBienServicio(beHistotialPreciosBienServicio obeHistotialPreciosBienServicio)
	{
		int IdHistorialPrecioBienServicio;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daHistotialPreciosBienServicio odaHistotialPreciosBienServicio= new daHistotialPreciosBienServicio();
				IdHistorialPrecioBienServicio =  odaHistotialPreciosBienServicio.actualizarHistotialPreciosBienServicio(con, obeHistotialPreciosBienServicio);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdHistorialPrecioBienServicio;
			}
	}

	public int eliminarHistotialPreciosBienServicio(int IdHistorialPrecioBienServicio)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daHistotialPreciosBienServicio odaHistotialPreciosBienServicio= new daHistotialPreciosBienServicio();
				IdHistorialPrecioBienServicio =  odaHistotialPreciosBienServicio.eliminarHistotialPreciosBienServicio(con, IdHistorialPrecioBienServicio);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdHistorialPrecioBienServicio;
			}
	}

	public beHistotialPreciosBienServicio traerHistotialPreciosBienServicio_x_IdHistorialPrecioBienServicio (int IdHistorialPrecioBienServicio)
	{
		beHistotialPreciosBienServicio obeHistotialPreciosBienServicio=new beHistotialPreciosBienServicio();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daHistotialPreciosBienServicio odaHistotialPreciosBienServicio= new daHistotialPreciosBienServicio();
				 obeHistotialPreciosBienServicio =  odaHistotialPreciosBienServicio.traerHistotialPreciosBienServicio_x_IdHistorialPrecioBienServicio(con, IdHistorialPrecioBienServicio);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeHistotialPreciosBienServicio;
			}
	}

	public List<beHistotialPreciosBienServicio> listarTodos_HistotialPreciosBienServicio()
	 {
		List<beHistotialPreciosBienServicio> lbeHistotialPreciosBienServicio =new List<beHistotialPreciosBienServicio>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daHistotialPreciosBienServicio odaHistotialPreciosBienServicio= new daHistotialPreciosBienServicio();
				 lbeHistotialPreciosBienServicio =  odaHistotialPreciosBienServicio.listarTodos_HistotialPreciosBienServicio(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeHistotialPreciosBienServicio;
		}
	}
	public List<beHistotialPreciosBienServicio> listarTodos_HistotialPreciosBienServicio_GetAll()
	 {
		List<beHistotialPreciosBienServicio> lbeHistotialPreciosBienServicio =new List<beHistotialPreciosBienServicio>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daHistotialPreciosBienServicio odaHistotialPreciosBienServicio= new daHistotialPreciosBienServicio();
				 lbeHistotialPreciosBienServicio =  odaHistotialPreciosBienServicio.listar_HistotialPreciosBienServicio_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeHistotialPreciosBienServicio;
		}
	}
}
}
