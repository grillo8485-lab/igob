using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brDispercionMuestraPrecios:brConexion
		 {
	public int guardarDispercionMuestraPrecios(beDispercionMuestraPrecios obeDispercionMuestraPrecios)
	{
		int IdDispercionMuestraPrecio;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daDispercionMuestraPrecios odaDispercionMuestraPrecios= new daDispercionMuestraPrecios();
			IdDispercionMuestraPrecio =  odaDispercionMuestraPrecios.guardarDispercionMuestraPrecios(con, obeDispercionMuestraPrecios);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdDispercionMuestraPrecio;
			}
	}

	public int actualizarDispercionMuestraPrecios(beDispercionMuestraPrecios obeDispercionMuestraPrecios)
	{
		int IdDispercionMuestraPrecio;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daDispercionMuestraPrecios odaDispercionMuestraPrecios= new daDispercionMuestraPrecios();
				IdDispercionMuestraPrecio =  odaDispercionMuestraPrecios.actualizarDispercionMuestraPrecios(con, obeDispercionMuestraPrecios);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdDispercionMuestraPrecio;
			}
	}

	public int eliminarDispercionMuestraPrecios(int IdDispercionMuestraPrecio)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daDispercionMuestraPrecios odaDispercionMuestraPrecios= new daDispercionMuestraPrecios();
				IdDispercionMuestraPrecio =  odaDispercionMuestraPrecios.eliminarDispercionMuestraPrecios(con, IdDispercionMuestraPrecio);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdDispercionMuestraPrecio;
			}
	}

	public beDispercionMuestraPrecios traerDispercionMuestraPrecios_x_IdDispercionMuestraPrecio (int IdDispercionMuestraPrecio)
	{
		beDispercionMuestraPrecios obeDispercionMuestraPrecios=new beDispercionMuestraPrecios();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daDispercionMuestraPrecios odaDispercionMuestraPrecios= new daDispercionMuestraPrecios();
				 obeDispercionMuestraPrecios =  odaDispercionMuestraPrecios.traerDispercionMuestraPrecios_x_IdDispercionMuestraPrecio(con, IdDispercionMuestraPrecio);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeDispercionMuestraPrecios;
			}
	}

	public List<beDispercionMuestraPrecios> listarTodos_DispercionMuestraPrecios()
	 {
		List<beDispercionMuestraPrecios> lbeDispercionMuestraPrecios =new List<beDispercionMuestraPrecios>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daDispercionMuestraPrecios odaDispercionMuestraPrecios= new daDispercionMuestraPrecios();
				 lbeDispercionMuestraPrecios =  odaDispercionMuestraPrecios.listarTodos_DispercionMuestraPrecios(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeDispercionMuestraPrecios;
		}
	}
	public List<beDispercionMuestraPrecios> listarTodos_DispercionMuestraPrecios_GetAll()
	 {
		List<beDispercionMuestraPrecios> lbeDispercionMuestraPrecios =new List<beDispercionMuestraPrecios>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daDispercionMuestraPrecios odaDispercionMuestraPrecios= new daDispercionMuestraPrecios();
				 lbeDispercionMuestraPrecios =  odaDispercionMuestraPrecios.listar_DispercionMuestraPrecios_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeDispercionMuestraPrecios;
		}
	}
}
}
