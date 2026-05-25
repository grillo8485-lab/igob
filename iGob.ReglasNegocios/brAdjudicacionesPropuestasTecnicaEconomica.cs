using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brAdjudicacionesPropuestasTecnicaEconomica:brConexion
		 {
	public int guardarAdjudicacionesPropuestasTecnicaEconomica(beAdjudicacionesPropuestasTecnicaEconomica obeAdjudicacionesPropuestasTecnicaEconomica)
	{
		int IdAdjudicionPropuestaTecEco;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daAdjudicacionesPropuestasTecnicaEconomica odaAdjudicacionesPropuestasTecnicaEconomica= new daAdjudicacionesPropuestasTecnicaEconomica();
			IdAdjudicionPropuestaTecEco =  odaAdjudicacionesPropuestasTecnicaEconomica.guardarAdjudicacionesPropuestasTecnicaEconomica(con, obeAdjudicacionesPropuestasTecnicaEconomica);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicionPropuestaTecEco;
			}
	}

	public int actualizarAdjudicacionesPropuestasTecnicaEconomica(beAdjudicacionesPropuestasTecnicaEconomica obeAdjudicacionesPropuestasTecnicaEconomica)
	{
		int IdAdjudicionPropuestaTecEco;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesPropuestasTecnicaEconomica odaAdjudicacionesPropuestasTecnicaEconomica= new daAdjudicacionesPropuestasTecnicaEconomica();
				IdAdjudicionPropuestaTecEco =  odaAdjudicacionesPropuestasTecnicaEconomica.actualizarAdjudicacionesPropuestasTecnicaEconomica(con, obeAdjudicacionesPropuestasTecnicaEconomica);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicionPropuestaTecEco;
			}
	}

	public int eliminarAdjudicacionesPropuestasTecnicaEconomica(int IdAdjudicionPropuestaTecEco)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesPropuestasTecnicaEconomica odaAdjudicacionesPropuestasTecnicaEconomica= new daAdjudicacionesPropuestasTecnicaEconomica();
				IdAdjudicionPropuestaTecEco =  odaAdjudicacionesPropuestasTecnicaEconomica.eliminarAdjudicacionesPropuestasTecnicaEconomica(con, IdAdjudicionPropuestaTecEco);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdAdjudicionPropuestaTecEco;
			}
	}

	public beAdjudicacionesPropuestasTecnicaEconomica traerAdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicionPropuestaTecEco (int IdAdjudicionPropuestaTecEco)
	{
		beAdjudicacionesPropuestasTecnicaEconomica obeAdjudicacionesPropuestasTecnicaEconomica=new beAdjudicacionesPropuestasTecnicaEconomica();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesPropuestasTecnicaEconomica odaAdjudicacionesPropuestasTecnicaEconomica= new daAdjudicacionesPropuestasTecnicaEconomica();
				 obeAdjudicacionesPropuestasTecnicaEconomica =  odaAdjudicacionesPropuestasTecnicaEconomica.traerAdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicionPropuestaTecEco(con, IdAdjudicionPropuestaTecEco);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesPropuestasTecnicaEconomica;
			}
	}

	public List<beAdjudicacionesPropuestasTecnicaEconomica> listarTodos_AdjudicacionesPropuestasTecnicaEconomica()
	 {
		List<beAdjudicacionesPropuestasTecnicaEconomica> lbeAdjudicacionesPropuestasTecnicaEconomica =new List<beAdjudicacionesPropuestasTecnicaEconomica>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesPropuestasTecnicaEconomica odaAdjudicacionesPropuestasTecnicaEconomica= new daAdjudicacionesPropuestasTecnicaEconomica();
				 lbeAdjudicacionesPropuestasTecnicaEconomica =  odaAdjudicacionesPropuestasTecnicaEconomica.listarTodos_AdjudicacionesPropuestasTecnicaEconomica(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesPropuestasTecnicaEconomica;
		}
	}
	public List<beAdjudicacionesPropuestasTecnicaEconomica> listarTodos_AdjudicacionesPropuestasTecnicaEconomica_GetAll()
	 {
		List<beAdjudicacionesPropuestasTecnicaEconomica> lbeAdjudicacionesPropuestasTecnicaEconomica =new List<beAdjudicacionesPropuestasTecnicaEconomica>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesPropuestasTecnicaEconomica odaAdjudicacionesPropuestasTecnicaEconomica= new daAdjudicacionesPropuestasTecnicaEconomica();
				 lbeAdjudicacionesPropuestasTecnicaEconomica =  odaAdjudicacionesPropuestasTecnicaEconomica.listar_AdjudicacionesPropuestasTecnicaEconomica_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesPropuestasTecnicaEconomica;
		}
	}

        public List<beAdjudicacionesPropuestasTecnicaEconomica> traerAdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicionProveedor(int IdAdjudicionProveedor)
        {
           List<beAdjudicacionesPropuestasTecnicaEconomica> obeAdjudicacionesPropuestasTecnicaEconomica = new List<beAdjudicacionesPropuestasTecnicaEconomica>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daAdjudicacionesPropuestasTecnicaEconomica odaAdjudicacionesPropuestasTecnicaEconomica = new daAdjudicacionesPropuestasTecnicaEconomica();
                    obeAdjudicacionesPropuestasTecnicaEconomica = odaAdjudicacionesPropuestasTecnicaEconomica.traerAdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicionProveedor(con, IdAdjudicionProveedor);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeAdjudicacionesPropuestasTecnicaEconomica;
            }
        }

        //public List<beAdjudicacionesPropuestasTecnicaEconomica> listarAdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicacion(int IdAdjudicacion)
        //{
        //    List<beAdjudicacionesPropuestasTecnicaEconomica> obeAdjudicacionesPropuestasTecnicaEconomica = new List<beAdjudicacionesPropuestasTecnicaEconomica>();
        //    using (SqlConnection con = new SqlConnection(CadenaConexion))
        //    {
        //        try
        //        {
        //            con.Open();
        //            daAdjudicacionesPropuestasTecnicaEconomica odaAdjudicacionesPropuestasTecnicaEconomica = new daAdjudicacionesPropuestasTecnicaEconomica();
        //            obeAdjudicacionesPropuestasTecnicaEconomica = odaAdjudicacionesPropuestasTecnicaEconomica.listarAdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicacion(con, IdAdjudicacion);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        return obeAdjudicacionesPropuestasTecnicaEconomica;
        //    }

        //}
    }
}
