using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brDeterminacionPrecios:brConexion
		 {
	public int guardarDeterminacionPrecios(beDeterminacionPrecios obeDeterminacionPrecios)
	{
		int IdDeterminaPrecioBienServicio;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daDeterminacionPrecios odaDeterminacionPrecios= new daDeterminacionPrecios();
			IdDeterminaPrecioBienServicio =  odaDeterminacionPrecios.guardarDeterminacionPrecios(con, obeDeterminacionPrecios);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdDeterminaPrecioBienServicio;
			}
	}

	public int actualizarDeterminacionPrecios(beDeterminacionPrecios obeDeterminacionPrecios)
	{
		int IdDeterminaPrecioBienServicio;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daDeterminacionPrecios odaDeterminacionPrecios= new daDeterminacionPrecios();
				IdDeterminaPrecioBienServicio =  odaDeterminacionPrecios.actualizarDeterminacionPrecios(con, obeDeterminacionPrecios);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdDeterminaPrecioBienServicio;
			}
	}

	public int eliminarDeterminacionPrecios(int IdDeterminaPrecioBienServicio)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daDeterminacionPrecios odaDeterminacionPrecios= new daDeterminacionPrecios();
				IdDeterminaPrecioBienServicio =  odaDeterminacionPrecios.eliminarDeterminacionPrecios(con, IdDeterminaPrecioBienServicio);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdDeterminaPrecioBienServicio;
			}
	}

	public beDeterminacionPrecios traerDeterminacionPrecios_x_IdDeterminaPrecioBienServicio (int IdDeterminaPrecioBienServicio)
	{
		beDeterminacionPrecios obeDeterminacionPrecios=new beDeterminacionPrecios();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daDeterminacionPrecios odaDeterminacionPrecios= new daDeterminacionPrecios();
				 obeDeterminacionPrecios =  odaDeterminacionPrecios.traerDeterminacionPrecios_x_IdDeterminaPrecioBienServicio(con, IdDeterminaPrecioBienServicio);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeDeterminacionPrecios;
			}
	}

	public List<beDeterminacionPrecios> listarTodos_DeterminacionPrecios()
	 {
		List<beDeterminacionPrecios> lbeDeterminacionPrecios =new List<beDeterminacionPrecios>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daDeterminacionPrecios odaDeterminacionPrecios= new daDeterminacionPrecios();
				 lbeDeterminacionPrecios =  odaDeterminacionPrecios.listarTodos_DeterminacionPrecios(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeDeterminacionPrecios;
		}
	}
	public List<beDeterminacionPrecios> listarTodos_DeterminacionPrecios_GetAll()
	 {
		List<beDeterminacionPrecios> lbeDeterminacionPrecios =new List<beDeterminacionPrecios>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daDeterminacionPrecios odaDeterminacionPrecios= new daDeterminacionPrecios();
				 lbeDeterminacionPrecios =  odaDeterminacionPrecios.listar_DeterminacionPrecios_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeDeterminacionPrecios;
		}
	}
}
}
