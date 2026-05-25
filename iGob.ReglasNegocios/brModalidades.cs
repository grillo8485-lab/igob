using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brModalidades:brConexion
		 {
	public int guardarModalidades(beModalidades obeModalidades)
	{
		int IdModalidad;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daModalidades odaModalidades= new daModalidades();
			IdModalidad =  odaModalidades.guardarModalidades(con, obeModalidades);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdModalidad;
			}
	}

	public int actualizarModalidades(beModalidades obeModalidades)
	{
		int IdModalidad;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daModalidades odaModalidades= new daModalidades();
				IdModalidad =  odaModalidades.actualizarModalidades(con, obeModalidades);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdModalidad;
			}
	}

	public int eliminarModalidades(int IdModalidad)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daModalidades odaModalidades= new daModalidades();
				IdModalidad =  odaModalidades.eliminarModalidades(con, IdModalidad);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdModalidad;
			}
	}

	public beModalidades traerModalidades_x_IdModalidad (int IdModalidad)
	{
		beModalidades obeModalidades=new beModalidades();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daModalidades odaModalidades= new daModalidades();
				 obeModalidades =  odaModalidades.traerModalidades_x_IdModalidad(con, IdModalidad);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeModalidades;
			}
	}

	public List<beModalidades> listarTodos_Modalidades()
	 {
		List<beModalidades> lbeModalidades =new List<beModalidades>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daModalidades odaModalidades= new daModalidades();
				 lbeModalidades =  odaModalidades.listarTodos_Modalidades(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeModalidades;
		}
	}
}
}
