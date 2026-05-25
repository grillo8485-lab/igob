using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brUnidadesMedidas:brConexion
		 {
	public int guardarUnidadesMedidas(beUnidadesMedidas obeUnidadesMedidas)
	{
		int IdUnidadMedida;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		        daUnidadesMedidas odaUnidadesMedidas= new daUnidadesMedidas();
			    IdUnidadMedida =  odaUnidadesMedidas.guardarUnidadesMedidas(con, obeUnidadesMedidas);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdUnidadMedida;
			}
	}

	public int actualizarUnidadesMedidas(beUnidadesMedidas obeUnidadesMedidas)
	{
		int IdUnidadMedida;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daUnidadesMedidas odaUnidadesMedidas= new daUnidadesMedidas();
				IdUnidadMedida =  odaUnidadesMedidas.actualizarUnidadesMedidas(con, obeUnidadesMedidas);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdUnidadMedida;
			}
	}

	public int eliminarUnidadesMedidas(int IdUnidadMedida)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daUnidadesMedidas odaUnidadesMedidas= new daUnidadesMedidas();
				IdUnidadMedida =  odaUnidadesMedidas.eliminarUnidadesMedidas(con, IdUnidadMedida);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdUnidadMedida;
			}
	}

	public beUnidadesMedidas traerUnidadesMedidas_x_IdUnidadMedida (int IdUnidadMedida)
	{
		beUnidadesMedidas obeUnidadesMedidas=new beUnidadesMedidas();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daUnidadesMedidas odaUnidadesMedidas= new daUnidadesMedidas();
				 obeUnidadesMedidas =  odaUnidadesMedidas.traerUnidadesMedidas_x_IdUnidadMedida(con, IdUnidadMedida);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeUnidadesMedidas;
			}
	}

	public List<beUnidadesMedidas> listarTodos_UnidadesMedidas()
	 {
		List<beUnidadesMedidas> lbeUnidadesMedidas =new List<beUnidadesMedidas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daUnidadesMedidas odaUnidadesMedidas= new daUnidadesMedidas();
				 lbeUnidadesMedidas =  odaUnidadesMedidas.listarTodos_UnidadesMedidas(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeUnidadesMedidas;
		}
	}
}
}
