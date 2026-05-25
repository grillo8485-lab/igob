using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brPlazosTiempos:brConexion
		 {
	public int guardarPlazosTiempos(bePlazosTiempos obePlazosTiempos)
	{
		int IdPlazoTiempo;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daPlazosTiempos odaPlazosTiempos= new daPlazosTiempos();
			IdPlazoTiempo =  odaPlazosTiempos.guardarPlazosTiempos(con, obePlazosTiempos);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdPlazoTiempo;
			}
	}

	public int actualizarPlazosTiempos(bePlazosTiempos obePlazosTiempos)
	{
		int IdPlazoTiempo;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPlazosTiempos odaPlazosTiempos= new daPlazosTiempos();
				IdPlazoTiempo =  odaPlazosTiempos.actualizarPlazosTiempos(con, obePlazosTiempos);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPlazoTiempo;
			}
	}

	public int eliminarPlazosTiempos(int IdPlazoTiempo)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPlazosTiempos odaPlazosTiempos= new daPlazosTiempos();
				IdPlazoTiempo =  odaPlazosTiempos.eliminarPlazosTiempos(con, IdPlazoTiempo);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPlazoTiempo;
			}
	}

	public bePlazosTiempos traerPlazosTiempos_x_IdPlazoTiempo (int IdPlazoTiempo)
	{
		bePlazosTiempos obePlazosTiempos=new bePlazosTiempos();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPlazosTiempos odaPlazosTiempos= new daPlazosTiempos();
				 obePlazosTiempos =  odaPlazosTiempos.traerPlazosTiempos_x_IdPlazoTiempo(con, IdPlazoTiempo);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obePlazosTiempos;
			}
	}

	public List<bePlazosTiempos> listarTodos_PlazosTiempos()
	 {
		List<bePlazosTiempos> lbePlazosTiempos =new List<bePlazosTiempos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPlazosTiempos odaPlazosTiempos= new daPlazosTiempos();
				 lbePlazosTiempos =  odaPlazosTiempos.listarTodos_PlazosTiempos(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePlazosTiempos;
		}
	}
	public List<bePlazosTiempos> listarTodos_PlazosTiempos_GetAll()
	 {
		List<bePlazosTiempos> lbePlazosTiempos =new List<bePlazosTiempos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPlazosTiempos odaPlazosTiempos= new daPlazosTiempos();
				 lbePlazosTiempos =  odaPlazosTiempos.listar_PlazosTiempos_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePlazosTiempos;
		}
	}
}
}
