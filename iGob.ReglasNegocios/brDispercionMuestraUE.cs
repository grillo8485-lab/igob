using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brDispercionMuestraUE:brConexion
		 {
	public int guardarDispercionMuestraUE(beDispercionMuestraUE obeDispercionMuestraUE)
	{
		int IdDispercionMuestraUE;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daDispercionMuestraUE odaDispercionMuestraUE= new daDispercionMuestraUE();
			IdDispercionMuestraUE =  odaDispercionMuestraUE.guardarDispercionMuestraUE(con, obeDispercionMuestraUE);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdDispercionMuestraUE;
			}
	}

	public int actualizarDispercionMuestraUE(beDispercionMuestraUE obeDispercionMuestraUE)
	{
		int IdDispercionMuestraUE;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daDispercionMuestraUE odaDispercionMuestraUE= new daDispercionMuestraUE();
				IdDispercionMuestraUE =  odaDispercionMuestraUE.actualizarDispercionMuestraUE(con, obeDispercionMuestraUE);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdDispercionMuestraUE;
			}
	}

	public int eliminarDispercionMuestraUE(int IdDispercionMuestraUE)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daDispercionMuestraUE odaDispercionMuestraUE= new daDispercionMuestraUE();
				IdDispercionMuestraUE =  odaDispercionMuestraUE.eliminarDispercionMuestraUE(con, IdDispercionMuestraUE);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdDispercionMuestraUE;
			}
	}

	public beDispercionMuestraUE traerDispercionMuestraUE_x_IdDispercionMuestraUE (int IdDispercionMuestraUE)
	{
		beDispercionMuestraUE obeDispercionMuestraUE=new beDispercionMuestraUE();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daDispercionMuestraUE odaDispercionMuestraUE= new daDispercionMuestraUE();
				 obeDispercionMuestraUE =  odaDispercionMuestraUE.traerDispercionMuestraUE_x_IdDispercionMuestraUE(con, IdDispercionMuestraUE);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeDispercionMuestraUE;
			}
	}

	public List<beDispercionMuestraUE> listarTodos_DispercionMuestraUE()
	 {
		List<beDispercionMuestraUE> lbeDispercionMuestraUE =new List<beDispercionMuestraUE>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daDispercionMuestraUE odaDispercionMuestraUE= new daDispercionMuestraUE();
				 lbeDispercionMuestraUE =  odaDispercionMuestraUE.listarTodos_DispercionMuestraUE(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeDispercionMuestraUE;
		}
	}
	public List<beDispercionMuestraUE> listarTodos_DispercionMuestraUE_GetAll()
	 {
		List<beDispercionMuestraUE> lbeDispercionMuestraUE =new List<beDispercionMuestraUE>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daDispercionMuestraUE odaDispercionMuestraUE= new daDispercionMuestraUE();
				 lbeDispercionMuestraUE =  odaDispercionMuestraUE.listar_DispercionMuestraUE_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeDispercionMuestraUE;
		}
	}
}
}
