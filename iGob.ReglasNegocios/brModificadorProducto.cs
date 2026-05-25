using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brModificadorProducto:brConexion
		 {
	public int guardarModificadorProducto(beModificadorProducto obeModificadorProducto)
	{
		int IdModificador;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daModificadorProducto odaModificadorProducto= new daModificadorProducto();
			IdModificador =  odaModificadorProducto.guardarModificadorProducto(con, obeModificadorProducto);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdModificador;
			}
	}

	public int actualizarModificadorProducto(beModificadorProducto obeModificadorProducto)
	{
		int IdModificador;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daModificadorProducto odaModificadorProducto= new daModificadorProducto();
				IdModificador =  odaModificadorProducto.actualizarModificadorProducto(con, obeModificadorProducto);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdModificador;
			}
	}

	public int eliminarModificadorProducto(int IdModificador)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daModificadorProducto odaModificadorProducto= new daModificadorProducto();
				IdModificador =  odaModificadorProducto.eliminarModificadorProducto(con, IdModificador);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdModificador;
			}
	}

	public beModificadorProducto traerModificadorProducto_x_IdModificador (int IdModificador)
	{
		beModificadorProducto obeModificadorProducto=new beModificadorProducto();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daModificadorProducto odaModificadorProducto= new daModificadorProducto();
				 obeModificadorProducto =  odaModificadorProducto.traerModificadorProducto_x_IdModificador(con, IdModificador);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeModificadorProducto;
			}
	}

	public List<beModificadorProducto> listarTodos_ModificadorProducto()
	 {
		List<beModificadorProducto> lbeModificadorProducto =new List<beModificadorProducto>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daModificadorProducto odaModificadorProducto= new daModificadorProducto();
				 lbeModificadorProducto =  odaModificadorProducto.listarTodos_ModificadorProducto(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeModificadorProducto;
		}
	}
}
}
