using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brPartidas:brConexion
		 {
	public int guardarPartidas(bePartidas obePartidas)
	{
		int IdPartida;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daPartidas odaPartidas= new daPartidas();
			IdPartida =  odaPartidas.guardarPartidas(con, obePartidas);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdPartida;
			}
	}

	public int actualizarPartidas(bePartidas obePartidas)
	{
		int IdPartida;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPartidas odaPartidas= new daPartidas();
				IdPartida =  odaPartidas.actualizarPartidas(con, obePartidas);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPartida;
			}
	}

	public int eliminarPartidas(int IdPartida)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPartidas odaPartidas= new daPartidas();
				IdPartida =  odaPartidas.eliminarPartidas(con, IdPartida);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPartida;
			}
	}

	public bePartidas traerPartidas_x_IdPartida (int IdPartida)
	{
		bePartidas obePartidas=new bePartidas();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPartidas odaPartidas= new daPartidas();
				 obePartidas =  odaPartidas.traerPartidas_x_IdPartida(con, IdPartida);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obePartidas;
			}
	}

	public List<bePartidas> listarTodos_Partidas()
	 {
		List<bePartidas> lbePartidas =new List<bePartidas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPartidas odaPartidas= new daPartidas();
				 lbePartidas =  odaPartidas.listarTodos_Partidas(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePartidas;
		}
	}
        public List<bePartidas> listarPartidas_x_IdCapitulo(int pIdCapitulo)
        {
            List<bePartidas> lbePartidas = new List<bePartidas>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daPartidas odaPartidas = new daPartidas();
                    lbePartidas = odaPartidas.listarPartidas_x_IdCapitulo(con, pIdCapitulo);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbePartidas;
            }
        }
    }
}
