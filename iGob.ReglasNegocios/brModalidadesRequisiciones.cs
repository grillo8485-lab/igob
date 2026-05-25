using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;
using iGob.ReglasNegocios;

namespace iGob.ReglasNegocios
	{
		public class brModalidadesRequisiciones:brConexion
		 {
	public int guardarModalidadesRequisiciones(beModalidadesRequisiciones obeModalidadesRequisiciones)
	{
		int IdModalidadRequisicion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daModalidadesRequisiciones odaModalidadesRequisiciones= new daModalidadesRequisiciones();
			IdModalidadRequisicion =  odaModalidadesRequisiciones.guardarModalidadesRequisiciones(con, obeModalidadesRequisiciones);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdModalidadRequisicion;
			}
	}

	public int actualizarModalidadesRequisiciones(beModalidadesRequisiciones obeModalidadesRequisiciones)
	{
		int IdModalidadRequisicion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daModalidadesRequisiciones odaModalidadesRequisiciones= new daModalidadesRequisiciones();
				IdModalidadRequisicion =  odaModalidadesRequisiciones.actualizarModalidadesRequisiciones(con, obeModalidadesRequisiciones);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdModalidadRequisicion;
			}
	}

	public int eliminarModalidadesRequisiciones(int IdModalidadRequisicion)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daModalidadesRequisiciones odaModalidadesRequisiciones= new daModalidadesRequisiciones();
				IdModalidadRequisicion =  odaModalidadesRequisiciones.eliminarModalidadesRequisiciones(con, IdModalidadRequisicion);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdModalidadRequisicion;
			}
	}

	public beModalidadesRequisiciones traerModalidadesRequisiciones_x_IdModalidadRequisicion (int IdModalidadRequisicion)
	{
		beModalidadesRequisiciones obeModalidadesRequisiciones=new beModalidadesRequisiciones();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daModalidadesRequisiciones odaModalidadesRequisiciones= new daModalidadesRequisiciones();
				 obeModalidadesRequisiciones =  odaModalidadesRequisiciones.traerModalidadesRequisiciones_x_IdModalidadRequisicion(con, IdModalidadRequisicion);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeModalidadesRequisiciones;
			}
	}

	public List<beModalidadesRequisiciones> listarTodos_ModalidadesRequisiciones()
	 {
		List<beModalidadesRequisiciones> lbeModalidadesRequisiciones =new List<beModalidadesRequisiciones>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daModalidadesRequisiciones odaModalidadesRequisiciones= new daModalidadesRequisiciones();
				 lbeModalidadesRequisiciones =  odaModalidadesRequisiciones.listarTodos_ModalidadesRequisiciones(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeModalidadesRequisiciones;
		}
	}
}
}
