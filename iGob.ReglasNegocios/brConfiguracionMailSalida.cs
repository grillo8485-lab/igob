using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brConfiguracionMailSalida:brConexion
		 {
	public int guardarConfiguracionMailSalida(beConfiguracionMailSalida obeConfiguracionMailSalida)
	{
		int IdConfigMailSalida;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daConfiguracionMailSalida odaConfiguracionMailSalida= new daConfiguracionMailSalida();
			IdConfigMailSalida =  odaConfiguracionMailSalida.guardarConfiguracionMailSalida(con, obeConfiguracionMailSalida);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdConfigMailSalida;
			}
	}

	public int actualizarConfiguracionMailSalida(beConfiguracionMailSalida obeConfiguracionMailSalida)
	{
		int IdConfigMailSalida;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daConfiguracionMailSalida odaConfiguracionMailSalida= new daConfiguracionMailSalida();
				IdConfigMailSalida =  odaConfiguracionMailSalida.actualizarConfiguracionMailSalida(con, obeConfiguracionMailSalida);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdConfigMailSalida;
			}
	}

	public int eliminarConfiguracionMailSalida(int IdConfigMailSalida)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daConfiguracionMailSalida odaConfiguracionMailSalida= new daConfiguracionMailSalida();
				IdConfigMailSalida =  odaConfiguracionMailSalida.eliminarConfiguracionMailSalida(con, IdConfigMailSalida);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdConfigMailSalida;
			}
	}

	public beConfiguracionMailSalida traerConfiguracionMailSalida_x_IdConfigMailSalida (int IdConfigMailSalida)
	{
		beConfiguracionMailSalida obeConfiguracionMailSalida=new beConfiguracionMailSalida();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daConfiguracionMailSalida odaConfiguracionMailSalida= new daConfiguracionMailSalida();
				 obeConfiguracionMailSalida =  odaConfiguracionMailSalida.traerConfiguracionMailSalida_x_IdConfigMailSalida(con, IdConfigMailSalida);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeConfiguracionMailSalida;
			}
	}

	public List<beConfiguracionMailSalida> listarTodos_ConfiguracionMailSalida()
	 {
		List<beConfiguracionMailSalida> lbeConfiguracionMailSalida =new List<beConfiguracionMailSalida>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daConfiguracionMailSalida odaConfiguracionMailSalida= new daConfiguracionMailSalida();
				 lbeConfiguracionMailSalida =  odaConfiguracionMailSalida.listarTodos_ConfiguracionMailSalida(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeConfiguracionMailSalida;
		}
	}
	public List<beConfiguracionMailSalida> listarTodos_ConfiguracionMailSalida_GetAll()
	 {
		List<beConfiguracionMailSalida> lbeConfiguracionMailSalida =new List<beConfiguracionMailSalida>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daConfiguracionMailSalida odaConfiguracionMailSalida= new daConfiguracionMailSalida();
				 lbeConfiguracionMailSalida =  odaConfiguracionMailSalida.listar_ConfiguracionMailSalida_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeConfiguracionMailSalida;
		}
	}
}
}
