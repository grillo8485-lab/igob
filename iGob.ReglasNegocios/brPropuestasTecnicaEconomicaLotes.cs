using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brPropuestasTecnicaEconomicaLotes:brConexion
		 {
	public int guardarPropuestasTecnicaEconomicaLotes(bePropuestasTecnicaEconomicaLotes obePropuestasTecnicaEconomicaLotes)
	{
		int IdPropuestaTecnicaEconomica;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daPropuestasTecnicaEconomicaLotes odaPropuestasTecnicaEconomicaLotes= new daPropuestasTecnicaEconomicaLotes();
			IdPropuestaTecnicaEconomica =  odaPropuestasTecnicaEconomicaLotes.guardarPropuestasTecnicaEconomicaLotes(con, obePropuestasTecnicaEconomicaLotes);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdPropuestaTecnicaEconomica;
			}
	}

	public int actualizarPropuestasTecnicaEconomicaLotes(bePropuestasTecnicaEconomicaLotes obePropuestasTecnicaEconomicaLotes)
	{
		int IdPropuestaTecnicaEconomica;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPropuestasTecnicaEconomicaLotes odaPropuestasTecnicaEconomicaLotes= new daPropuestasTecnicaEconomicaLotes();
				IdPropuestaTecnicaEconomica =  odaPropuestasTecnicaEconomicaLotes.actualizarPropuestasTecnicaEconomicaLotes(con, obePropuestasTecnicaEconomicaLotes);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPropuestaTecnicaEconomica;
			}
	}

	public int eliminarPropuestasTecnicaEconomicaLotes(int IdPropuestaTecnicaEconomica)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPropuestasTecnicaEconomicaLotes odaPropuestasTecnicaEconomicaLotes= new daPropuestasTecnicaEconomicaLotes();
				IdPropuestaTecnicaEconomica =  odaPropuestasTecnicaEconomicaLotes.eliminarPropuestasTecnicaEconomicaLotes(con, IdPropuestaTecnicaEconomica);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPropuestaTecnicaEconomica;
			}
	}

	public bePropuestasTecnicaEconomicaLotes traerPropuestasTecnicaEconomicaLotes_x_IdPropuestaTecnicaEconomica (int IdPropuestaTecnicaEconomica)
	{
		bePropuestasTecnicaEconomicaLotes obePropuestasTecnicaEconomicaLotes=new bePropuestasTecnicaEconomicaLotes();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPropuestasTecnicaEconomicaLotes odaPropuestasTecnicaEconomicaLotes= new daPropuestasTecnicaEconomicaLotes();
				 obePropuestasTecnicaEconomicaLotes =  odaPropuestasTecnicaEconomicaLotes.traerPropuestasTecnicaEconomicaLotes_x_IdPropuestaTecnicaEconomica(con, IdPropuestaTecnicaEconomica);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obePropuestasTecnicaEconomicaLotes;
			}
	}

	public List<bePropuestasTecnicaEconomicaLotes> listarTodos_PropuestasTecnicaEconomicaLotes()
	 {
		List<bePropuestasTecnicaEconomicaLotes> lbePropuestasTecnicaEconomicaLotes =new List<bePropuestasTecnicaEconomicaLotes>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPropuestasTecnicaEconomicaLotes odaPropuestasTecnicaEconomicaLotes= new daPropuestasTecnicaEconomicaLotes();
				 lbePropuestasTecnicaEconomicaLotes =  odaPropuestasTecnicaEconomicaLotes.listarTodos_PropuestasTecnicaEconomicaLotes(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePropuestasTecnicaEconomicaLotes;
		}
	}
	public List<bePropuestasTecnicaEconomicaLotes> listarTodos_PropuestasTecnicaEconomicaLotes_GetAll()
	 {
		List<bePropuestasTecnicaEconomicaLotes> lbePropuestasTecnicaEconomicaLotes =new List<bePropuestasTecnicaEconomicaLotes>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPropuestasTecnicaEconomicaLotes odaPropuestasTecnicaEconomicaLotes= new daPropuestasTecnicaEconomicaLotes();
				 lbePropuestasTecnicaEconomicaLotes =  odaPropuestasTecnicaEconomicaLotes.listar_PropuestasTecnicaEconomicaLotes_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePropuestasTecnicaEconomicaLotes;
		}
	}
}
}
