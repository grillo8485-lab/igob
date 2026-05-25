using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brEF_Colonias:brConexion
		 {
	public int guardarEF_Colonias(beEF_Colonias obeEF_Colonias)
	{
		int IdColonia;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daEF_Colonias odaEF_Colonias= new daEF_Colonias();
			IdColonia =  odaEF_Colonias.guardarEF_Colonias(con, obeEF_Colonias);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdColonia;
			}
	}

	public int actualizarEF_Colonias(beEF_Colonias obeEF_Colonias)
	{
		int IdColonia;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEF_Colonias odaEF_Colonias= new daEF_Colonias();
				IdColonia =  odaEF_Colonias.actualizarEF_Colonias(con, obeEF_Colonias);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdColonia;
			}
	}

	public int eliminarEF_Colonias(string IdColonia)
	{
            int resultado = 0;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEF_Colonias odaEF_Colonias= new daEF_Colonias();
                    resultado =  odaEF_Colonias.eliminarEF_Colonias(con, IdColonia);
				}
			catch (Exception ex) {
				throw ex;
			}
			return resultado;
			}
	}

	public beEF_Colonias traerEF_Colonias_x_IdColonia (string IdColonia)
	{
		beEF_Colonias obeEF_Colonias=new beEF_Colonias();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEF_Colonias odaEF_Colonias= new daEF_Colonias();
				 obeEF_Colonias =  odaEF_Colonias.traerEF_Colonias_x_IdColonia(con, IdColonia);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeEF_Colonias;
			}
	}

	public List<beEF_Colonias> listarTodos_EF_Colonias()
	 {
		List<beEF_Colonias> lbeEF_Colonias =new List<beEF_Colonias>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEF_Colonias odaEF_Colonias= new daEF_Colonias();
				 lbeEF_Colonias =  odaEF_Colonias.listarTodos_EF_Colonias(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEF_Colonias;
		}
	}
	public List<beEF_Colonias> listarTodos_EF_Colonias_GetAll()
	 {
		List<beEF_Colonias> lbeEF_Colonias =new List<beEF_Colonias>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEF_Colonias odaEF_Colonias= new daEF_Colonias();
				 lbeEF_Colonias =  odaEF_Colonias.listar_EF_Colonias_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEF_Colonias;
		}
	}
        public List<beEF_Colonias> listarTodos_EF_ColoniasEstMerc()
        {
            List<beEF_Colonias> lbeEF_Colonias = new List<beEF_Colonias>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daEF_Colonias odaEF_Colonias = new daEF_Colonias();
                    lbeEF_Colonias = odaEF_Colonias.listarTodos_EF_ColoniasEstMerc(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeEF_Colonias;
            }
        }
    }
}
