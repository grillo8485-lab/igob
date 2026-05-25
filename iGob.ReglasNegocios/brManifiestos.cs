using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brManifiestos:brConexion
		 {
	public int guardarManifiestos(beManifiestos obeManifiestos)
	{
		int IdManifiesto;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daManifiestos odaManifiestos= new daManifiestos();
			IdManifiesto =  odaManifiestos.guardarManifiestos(con, obeManifiestos);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdManifiesto;
			}
	}

	public int actualizarManifiestos(beManifiestos obeManifiestos)
	{
		int IdManifiesto;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daManifiestos odaManifiestos= new daManifiestos();
				IdManifiesto =  odaManifiestos.actualizarManifiestos(con, obeManifiestos);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdManifiesto;
			}
	}

	public int eliminarManifiestos(int IdManifiesto)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daManifiestos odaManifiestos= new daManifiestos();
				IdManifiesto =  odaManifiestos.eliminarManifiestos(con, IdManifiesto);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdManifiesto;
			}
	}

	public beManifiestos traerManifiestos_x_IdManifiesto (int IdManifiesto)
	{
		beManifiestos obeManifiestos=new beManifiestos();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daManifiestos odaManifiestos= new daManifiestos();
				 obeManifiestos =  odaManifiestos.traerManifiestos_x_IdManifiesto(con, IdManifiesto);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeManifiestos;
			}
	}

	public List<beManifiestos> listarTodos_Manifiestos()
	 {
		List<beManifiestos> lbeManifiestos =new List<beManifiestos>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daManifiestos odaManifiestos= new daManifiestos();
				 lbeManifiestos =  odaManifiestos.listarTodos_Manifiestos(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeManifiestos;
		}
	}
    
    /* Gobierno 24/08/2018 */
    public List<beManifiestos> listarTodos_Manifiestos_GetAll()
    {
        List<beManifiestos> lbeManifiestos = new List<beManifiestos>();
        using (SqlConnection con = new SqlConnection(CadenaConexion))
        {
            try
            {
                con.Open();
                daManifiestos odaManifiestos = new daManifiestos();
                lbeManifiestos = odaManifiestos.listarTodos_Manifiestos_GetAll(con);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeManifiestos;
        }
    }
    }
}
