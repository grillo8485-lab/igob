using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brAdjudicacionesLotes:brConexion
		 {
	public int guardarAdjudicacionesLotes(beAdjudicacionesLotes obeAdjudicacionesLotes)
	{
		int IdLote;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daAdjudicacionesLotes odaAdjudicacionesLotes= new daAdjudicacionesLotes();
			IdLote =  odaAdjudicacionesLotes.guardarAdjudicacionesLotes(con, obeAdjudicacionesLotes);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdLote;
			}
	}

	public int actualizarAdjudicacionesLotes(beAdjudicacionesLotes obeAdjudicacionesLotes)
	{
		int IdLote;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesLotes odaAdjudicacionesLotes= new daAdjudicacionesLotes();
				IdLote =  odaAdjudicacionesLotes.actualizarAdjudicacionesLotes(con, obeAdjudicacionesLotes);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdLote;
			}
	}

	public int eliminarAdjudicacionesLotes(int IdLote)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesLotes odaAdjudicacionesLotes= new daAdjudicacionesLotes();
				IdLote =  odaAdjudicacionesLotes.eliminarAdjudicacionesLotes(con, IdLote);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdLote;
			}
	}

	public beAdjudicacionesLotes traerAdjudicacionesLotes_x_IdLote (int IdLote)
	{
		beAdjudicacionesLotes obeAdjudicacionesLotes=new beAdjudicacionesLotes();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesLotes odaAdjudicacionesLotes= new daAdjudicacionesLotes();
				 obeAdjudicacionesLotes =  odaAdjudicacionesLotes.traerAdjudicacionesLotes_x_IdLote(con, IdLote);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesLotes;
			}
	}

	public List<beAdjudicacionesLotes> listarTodos_AdjudicacionesLotes()
	 {
		List<beAdjudicacionesLotes> lbeAdjudicacionesLotes =new List<beAdjudicacionesLotes>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesLotes odaAdjudicacionesLotes= new daAdjudicacionesLotes();
				 lbeAdjudicacionesLotes =  odaAdjudicacionesLotes.listarTodos_AdjudicacionesLotes(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesLotes;
		}
	}
	public List<beAdjudicacionesLotes> listarTodos_AdjudicacionesLotes_GetAll()
	 {
		List<beAdjudicacionesLotes> lbeAdjudicacionesLotes =new List<beAdjudicacionesLotes>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daAdjudicacionesLotes odaAdjudicacionesLotes= new daAdjudicacionesLotes();
				 lbeAdjudicacionesLotes =  odaAdjudicacionesLotes.listar_AdjudicacionesLotes_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesLotes;
		}
	}

        // nueva 

    public List<beAdjudicacionesLotes> listarTodos_AdjudicacionesLotes_x_IdAdjudicacion(int IdAdjudicacion)
    {
        List<beAdjudicacionesLotes> lbeAdjudicacionesLotes = new List<beAdjudicacionesLotes>();
        using (SqlConnection con = new SqlConnection(CadenaConexion))
        {
            try
            {
                con.Open();
                daAdjudicacionesLotes odaAdjudicacionesLotes = new daAdjudicacionesLotes();
                lbeAdjudicacionesLotes = odaAdjudicacionesLotes.traerAdjudicacionesLotes_x_IdAdjudicacion(con, IdAdjudicacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeAdjudicacionesLotes;
        }
    }
        public List<beAdjudicacionesLotes> listarTodos_AdjudicacionesProveedoresLotes_x_IdAdjudicacion(int IdAdjudicacion)
        {
            List<beAdjudicacionesLotes> lbeAdjudicacionesLotes = new List<beAdjudicacionesLotes>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daAdjudicacionesLotes odaAdjudicacionesLotes = new daAdjudicacionesLotes();
                    lbeAdjudicacionesLotes = odaAdjudicacionesLotes.traerAdjudicacionesProveedoresLotes_x_IdAdjudicacion(con, IdAdjudicacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAdjudicacionesLotes;
            }
        }
        

    public List<beGenerica> listarTodos_AdjudicacionesLotes_x_IdPartida_BienServicio(beGenerica oGenerica)
    {
        List<beGenerica> lbeAdjudicacionesLotes = new List<beGenerica>();
        using (SqlConnection con = new SqlConnection(CadenaConexion))
        {
            try
            {
                con.Open();
                daAdjudicacionesLotes odaAdjudicacionesLotes = new daAdjudicacionesLotes();
                    lbeAdjudicacionesLotes = odaAdjudicacionesLotes.listarTodos_AdjudicacionesLotes_x_IdPartida_BienServicio(con, oGenerica);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeAdjudicacionesLotes;
        }
    }

    public beGenerica traerAdjudicacionesLotes_x_IdBienServicio(int IdBienServicio)
    {
        beGenerica oGenerica = new beGenerica();
        using (SqlConnection con = new SqlConnection(CadenaConexion))
        {
            try
            {
                con.Open();
                daAdjudicacionesLotes odaAdjudicacionesLotes = new daAdjudicacionesLotes();
                oGenerica = odaAdjudicacionesLotes.traerAdjudicacionesLotes_x_IdBienServicio(con, IdBienServicio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oGenerica;
        }
    }

    }
}
