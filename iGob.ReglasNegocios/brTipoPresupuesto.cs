using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brTipoPresupuesto:brConexion
		 {
	public int guardarTipoPresupuesto(beTipoPresupuesto obeTipoPresupuesto)
	{
		int IdTipoPresuesto;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daTipoPresupuesto odaTipoPresupuesto= new daTipoPresupuesto();
			IdTipoPresuesto =  odaTipoPresupuesto.guardarTipoPresupuesto(con, obeTipoPresupuesto);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoPresuesto;
			}
	}

	public int actualizarTipoPresupuesto(beTipoPresupuesto obeTipoPresupuesto)
	{
		int IdTipoPresuesto;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTipoPresupuesto odaTipoPresupuesto= new daTipoPresupuesto();
				IdTipoPresuesto =  odaTipoPresupuesto.actualizarTipoPresupuesto(con, obeTipoPresupuesto);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoPresuesto;
			}
	}

	public int eliminarTipoPresupuesto(int IdTipoPresuesto)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTipoPresupuesto odaTipoPresupuesto= new daTipoPresupuesto();
				IdTipoPresuesto =  odaTipoPresupuesto.eliminarTipoPresupuesto(con, IdTipoPresuesto);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoPresuesto;
			}
	}

	public beTipoPresupuesto traerTipoPresupuesto_x_IdTipoPresuesto (int IdTipoPresuesto)
	{
		beTipoPresupuesto obeTipoPresupuesto=new beTipoPresupuesto();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTipoPresupuesto odaTipoPresupuesto= new daTipoPresupuesto();
				 obeTipoPresupuesto =  odaTipoPresupuesto.traerTipoPresupuesto_x_IdTipoPresuesto(con, IdTipoPresuesto);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTipoPresupuesto;
			}
	}

	public List<beTipoPresupuesto> listarTodos_TipoPresupuesto()
	 {
		List<beTipoPresupuesto> lbeTipoPresupuesto =new List<beTipoPresupuesto>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTipoPresupuesto odaTipoPresupuesto= new daTipoPresupuesto();
				 lbeTipoPresupuesto =  odaTipoPresupuesto.listarTodos_TipoPresupuesto(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTipoPresupuesto;
		}
	}
}
}
