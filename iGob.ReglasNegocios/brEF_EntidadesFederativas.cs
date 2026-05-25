using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brEF_EntidadesFederativas:brConexion
		 {
	public int guardarEF_EntidadesFederativas(beEF_EntidadesFederativas obeEF_EntidadesFederativas)
	{
		int ClaveEstado;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daEF_EntidadesFederativas odaEF_EntidadesFederativas= new daEF_EntidadesFederativas();
			ClaveEstado =  odaEF_EntidadesFederativas.guardarEF_EntidadesFederativas(con, obeEF_EntidadesFederativas);
			}
			catch (Exception ex) {
				throw ex;
			}
			return ClaveEstado;
			}
	}

	public int actualizarEF_EntidadesFederativas(beEF_EntidadesFederativas obeEF_EntidadesFederativas)
	{
		int ClaveEstado;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEF_EntidadesFederativas odaEF_EntidadesFederativas= new daEF_EntidadesFederativas();
				ClaveEstado =  odaEF_EntidadesFederativas.actualizarEF_EntidadesFederativas(con, obeEF_EntidadesFederativas);
				}
			catch (Exception ex) {
				throw ex;
			}
			return ClaveEstado;
			}
	}

	public int eliminarEF_EntidadesFederativas(string ClaveEstado)
	{
            int resultado = 0;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEF_EntidadesFederativas odaEF_EntidadesFederativas= new daEF_EntidadesFederativas();
                    resultado =  odaEF_EntidadesFederativas.eliminarEF_EntidadesFederativas(con, ClaveEstado);
				}
			catch (Exception ex) {
				throw ex;
			}
			return resultado;
			}
	}

	public beEF_EntidadesFederativas traerEF_EntidadesFederativas_x_ClaveEstado (string ClaveEstado)
	{
		beEF_EntidadesFederativas obeEF_EntidadesFederativas=new beEF_EntidadesFederativas();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEF_EntidadesFederativas odaEF_EntidadesFederativas= new daEF_EntidadesFederativas();
				 obeEF_EntidadesFederativas =  odaEF_EntidadesFederativas.traerEF_EntidadesFederativas_x_ClaveEstado(con, ClaveEstado);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeEF_EntidadesFederativas;
			}
	}

	public List<beEF_EntidadesFederativas> listarTodos_EF_EntidadesFederativas()
	 {
		List<beEF_EntidadesFederativas> lbeEF_EntidadesFederativas =new List<beEF_EntidadesFederativas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEF_EntidadesFederativas odaEF_EntidadesFederativas= new daEF_EntidadesFederativas();
				 lbeEF_EntidadesFederativas =  odaEF_EntidadesFederativas.listarTodos_EF_EntidadesFederativas(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEF_EntidadesFederativas;
		}
	}
	public List<beEF_EntidadesFederativas> listarTodos_EF_EntidadesFederativas_GetAll()
	 {
		List<beEF_EntidadesFederativas> lbeEF_EntidadesFederativas =new List<beEF_EntidadesFederativas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daEF_EntidadesFederativas odaEF_EntidadesFederativas= new daEF_EntidadesFederativas();
				 lbeEF_EntidadesFederativas =  odaEF_EntidadesFederativas.listar_EF_EntidadesFederativas_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEF_EntidadesFederativas;
		}
	}

        public List<beEF_EntidadesFederativas> listarTodos_EF_EntidadesFederativasEstMer()
        {
            List<beEF_EntidadesFederativas> lbeEF_EntidadesFederativas = new List<beEF_EntidadesFederativas>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daEF_EntidadesFederativas odaEF_EntidadesFederativas = new daEF_EntidadesFederativas();
                    lbeEF_EntidadesFederativas = odaEF_EntidadesFederativas.listarTodos_EF_EntidadesFederativasEstMerc(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeEF_EntidadesFederativas;
            }
        }
    }
}
