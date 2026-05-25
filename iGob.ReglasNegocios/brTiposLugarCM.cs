using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brTiposLugarCM:brConexion
		 {
	public int guardarTiposLugarCM(beTiposLugarCM obeTiposLugarCM)
	{
		int IdTipoLugarCM;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daTiposLugarCM odaTiposLugarCM= new daTiposLugarCM();
			IdTipoLugarCM =  odaTiposLugarCM.guardarTiposLugarCM(con, obeTiposLugarCM);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoLugarCM;
			}
	}

	public int actualizarTiposLugarCM(beTiposLugarCM obeTiposLugarCM)
	{
		int IdTipoLugarCM;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposLugarCM odaTiposLugarCM= new daTiposLugarCM();
				IdTipoLugarCM =  odaTiposLugarCM.actualizarTiposLugarCM(con, obeTiposLugarCM);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoLugarCM;
			}
	}

	public int eliminarTiposLugarCM(int IdTipoLugarCM)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposLugarCM odaTiposLugarCM= new daTiposLugarCM();
				IdTipoLugarCM =  odaTiposLugarCM.eliminarTiposLugarCM(con, IdTipoLugarCM);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoLugarCM;
			}
	}

	public beTiposLugarCM traerTiposLugarCM_x_IdTipoLugarCM (int IdTipoLugarCM)
	{
		beTiposLugarCM obeTiposLugarCM=new beTiposLugarCM();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposLugarCM odaTiposLugarCM= new daTiposLugarCM();
				 obeTiposLugarCM =  odaTiposLugarCM.traerTiposLugarCM_x_IdTipoLugarCM(con, IdTipoLugarCM);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposLugarCM;
			}
	}

	public List<beTiposLugarCM> listarTodos_TiposLugarCM()
	 {
		List<beTiposLugarCM> lbeTiposLugarCM =new List<beTiposLugarCM>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposLugarCM odaTiposLugarCM= new daTiposLugarCM();
				 lbeTiposLugarCM =  odaTiposLugarCM.listarTodos_TiposLugarCM(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposLugarCM;
		}
	}
	public List<beTiposLugarCM> listarTodos_TiposLugarCM_GetAll()
	 {
		List<beTiposLugarCM> lbeTiposLugarCM =new List<beTiposLugarCM>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposLugarCM odaTiposLugarCM= new daTiposLugarCM();
				 lbeTiposLugarCM =  odaTiposLugarCM.listar_TiposLugarCM_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposLugarCM;
		}
	}
}
}
