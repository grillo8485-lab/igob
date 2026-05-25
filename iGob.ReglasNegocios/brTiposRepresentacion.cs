using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brTiposRepresentacion:brConexion
		 {
	public int guardarTiposRepresentacion(beTiposRepresentacion obeTiposRepresentacion)
	{
		int IdTipoRepresentacion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daTiposRepresentacion odaTiposRepresentacion= new daTiposRepresentacion();
			IdTipoRepresentacion =  odaTiposRepresentacion.guardarTiposRepresentacion(con, obeTiposRepresentacion);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoRepresentacion;
			}
	}

	public int actualizarTiposRepresentacion(beTiposRepresentacion obeTiposRepresentacion)
	{
		int IdTipoRepresentacion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposRepresentacion odaTiposRepresentacion= new daTiposRepresentacion();
				IdTipoRepresentacion =  odaTiposRepresentacion.actualizarTiposRepresentacion(con, obeTiposRepresentacion);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoRepresentacion;
			}
	}

	public int eliminarTiposRepresentacion(int IdTipoRepresentacion)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposRepresentacion odaTiposRepresentacion= new daTiposRepresentacion();
				IdTipoRepresentacion =  odaTiposRepresentacion.eliminarTiposRepresentacion(con, IdTipoRepresentacion);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoRepresentacion;
			}
	}

	public beTiposRepresentacion traerTiposRepresentacion_x_IdTipoRepresentacion (int IdTipoRepresentacion)
	{
		beTiposRepresentacion obeTiposRepresentacion=new beTiposRepresentacion();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposRepresentacion odaTiposRepresentacion= new daTiposRepresentacion();
				 obeTiposRepresentacion =  odaTiposRepresentacion.traerTiposRepresentacion_x_IdTipoRepresentacion(con, IdTipoRepresentacion);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposRepresentacion;
			}
	}

	public List<beTiposRepresentacion> listarTodos_TiposRepresentacion()
	 {
		List<beTiposRepresentacion> lbeTiposRepresentacion =new List<beTiposRepresentacion>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposRepresentacion odaTiposRepresentacion= new daTiposRepresentacion();
				 lbeTiposRepresentacion =  odaTiposRepresentacion.listarTodos_TiposRepresentacion(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposRepresentacion;
		}
	}
}
}
