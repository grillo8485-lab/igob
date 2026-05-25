using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brPartidasActividadesEconomicas:brConexion
		 {
	public int guardarPartidasActividadesEconomicas(bePartidasActividadesEconomicas obePartidasActividadesEconomicas)
	{
		int IdPartidaActEconomica;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daPartidasActividadesEconomicas odaPartidasActividadesEconomicas= new daPartidasActividadesEconomicas();
			IdPartidaActEconomica =  odaPartidasActividadesEconomicas.guardarPartidasActividadesEconomicas(con, obePartidasActividadesEconomicas);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdPartidaActEconomica;
			}
	}

	public int actualizarPartidasActividadesEconomicas(bePartidasActividadesEconomicas obePartidasActividadesEconomicas)
	{
		int IdPartidaActEconomica;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPartidasActividadesEconomicas odaPartidasActividadesEconomicas= new daPartidasActividadesEconomicas();
				IdPartidaActEconomica =  odaPartidasActividadesEconomicas.actualizarPartidasActividadesEconomicas(con, obePartidasActividadesEconomicas);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPartidaActEconomica;
			}
	}

	public int eliminarPartidasActividadesEconomicas(int IdPartidaActEconomica)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPartidasActividadesEconomicas odaPartidasActividadesEconomicas= new daPartidasActividadesEconomicas();
				IdPartidaActEconomica =  odaPartidasActividadesEconomicas.eliminarPartidasActividadesEconomicas(con, IdPartidaActEconomica);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPartidaActEconomica;
			}
	}

	public bePartidasActividadesEconomicas traerPartidasActividadesEconomicas_x_IdPartidaActEconomica (int IdPartidaActEconomica)
	{
		bePartidasActividadesEconomicas obePartidasActividadesEconomicas=new bePartidasActividadesEconomicas();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPartidasActividadesEconomicas odaPartidasActividadesEconomicas= new daPartidasActividadesEconomicas();
				 obePartidasActividadesEconomicas =  odaPartidasActividadesEconomicas.traerPartidasActividadesEconomicas_x_IdPartidaActEconomica(con, IdPartidaActEconomica);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obePartidasActividadesEconomicas;
			}
	}

	public List<bePartidasActividadesEconomicas> listarTodos_PartidasActividadesEconomicas()
	 {
		List<bePartidasActividadesEconomicas> lbePartidasActividadesEconomicas =new List<bePartidasActividadesEconomicas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPartidasActividadesEconomicas odaPartidasActividadesEconomicas= new daPartidasActividadesEconomicas();
				 lbePartidasActividadesEconomicas =  odaPartidasActividadesEconomicas.listarTodos_PartidasActividadesEconomicas(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePartidasActividadesEconomicas;
		}
	}
        public List<bePartidasActividadesEconomicas> listarTodos_PartidasActividadesEconomicas_GetAll()
        {
            List<bePartidasActividadesEconomicas> lbePartidasActividadesEconomicas = new List<bePartidasActividadesEconomicas>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daPartidasActividadesEconomicas odaPartidasActividadesEconomicas = new daPartidasActividadesEconomicas();
                    lbePartidasActividadesEconomicas = odaPartidasActividadesEconomicas.listar_PartidasActividadesEconomicas_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbePartidasActividadesEconomicas;
            }
        }
    }
}
