using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brOrigenRecurso:brConexion
		 {
	public int guardarOrigenRecurso(beOrigenRecurso obeOrigenRecurso)
	{
		int IdOrigenRecurso;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daOrigenRecurso odaOrigenRecurso= new daOrigenRecurso();
			IdOrigenRecurso =  odaOrigenRecurso.guardarOrigenRecurso(con, obeOrigenRecurso);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdOrigenRecurso;
			}
	}

	public int actualizarOrigenRecurso(beOrigenRecurso obeOrigenRecurso)
	{
		int IdOrigenRecurso;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daOrigenRecurso odaOrigenRecurso= new daOrigenRecurso();
				IdOrigenRecurso =  odaOrigenRecurso.actualizarOrigenRecurso(con, obeOrigenRecurso);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdOrigenRecurso;
			}
	}

	public int eliminarOrigenRecurso(int IdOrigenRecurso)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daOrigenRecurso odaOrigenRecurso= new daOrigenRecurso();
				IdOrigenRecurso =  odaOrigenRecurso.eliminarOrigenRecurso(con, IdOrigenRecurso);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdOrigenRecurso;
			}
	}

	public beOrigenRecurso traerOrigenRecurso_x_IdOrigenRecurso (int IdOrigenRecurso)
	{
		beOrigenRecurso obeOrigenRecurso=new beOrigenRecurso();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daOrigenRecurso odaOrigenRecurso= new daOrigenRecurso();
				 obeOrigenRecurso =  odaOrigenRecurso.traerOrigenRecurso_x_IdOrigenRecurso(con, IdOrigenRecurso);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeOrigenRecurso;
			}
	}

	public List<beOrigenRecurso> listarTodos_OrigenRecurso()
	 {
		List<beOrigenRecurso> lbeOrigenRecurso =new List<beOrigenRecurso>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daOrigenRecurso odaOrigenRecurso= new daOrigenRecurso();
				 lbeOrigenRecurso =  odaOrigenRecurso.listarTodos_OrigenRecurso(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeOrigenRecurso;
		}
	}
}
}
