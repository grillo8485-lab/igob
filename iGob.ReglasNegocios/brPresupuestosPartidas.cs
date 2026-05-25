using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brPresupuestosPartidas:brConexion
		 {
	public int guardarPresupuestosPartidas(bePresupuestosPartidas obePresupuestosPartidas)
	{
		int IdPresupuestoPartida;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daPresupuestosPartidas odaPresupuestosPartidas= new daPresupuestosPartidas();
			IdPresupuestoPartida =  odaPresupuestosPartidas.guardarPresupuestosPartidas(con, obePresupuestosPartidas);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdPresupuestoPartida;
			}
	}

	public int actualizarPresupuestosPartidas(bePresupuestosPartidas obePresupuestosPartidas)
	{
		int IdPresupuestoPartida;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPresupuestosPartidas odaPresupuestosPartidas= new daPresupuestosPartidas();
				IdPresupuestoPartida =  odaPresupuestosPartidas.actualizarPresupuestosPartidas(con, obePresupuestosPartidas);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPresupuestoPartida;
			}
	}

	public int eliminarPresupuestosPartidas(int IdPresupuestoPartida)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPresupuestosPartidas odaPresupuestosPartidas= new daPresupuestosPartidas();
				IdPresupuestoPartida =  odaPresupuestosPartidas.eliminarPresupuestosPartidas(con, IdPresupuestoPartida);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdPresupuestoPartida;
			}
	}

	public bePresupuestosPartidas traerPresupuestosPartidas_x_IdPresupuestoPartida (int IdPresupuestoPartida)
	{
		bePresupuestosPartidas obePresupuestosPartidas=new bePresupuestosPartidas();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPresupuestosPartidas odaPresupuestosPartidas= new daPresupuestosPartidas();
				 obePresupuestosPartidas =  odaPresupuestosPartidas.traerPresupuestosPartidas_x_IdPresupuestoPartida(con, IdPresupuestoPartida);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obePresupuestosPartidas;
			}
	}

	public List<bePresupuestosPartidas> listarTodos_PresupuestosPartidas()
	 {
		List<bePresupuestosPartidas> lbePresupuestosPartidas =new List<bePresupuestosPartidas>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daPresupuestosPartidas odaPresupuestosPartidas= new daPresupuestosPartidas();
				 lbePresupuestosPartidas =  odaPresupuestosPartidas.listarTodos_PresupuestosPartidas(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePresupuestosPartidas;
		}
	}

	    public List<bePresupuestosPartidas> listarTodos_PresupuestosPartidas_GetAll()
	     {
                List<bePresupuestosPartidas> lbePresupuestosPartidas = new List<bePresupuestosPartidas>();
                using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daPresupuestosPartidas odaPresupuestosPartidas= new daPresupuestosPartidas();
                        lbePresupuestosPartidas =  odaPresupuestosPartidas.listar_PresupuestosPartidas_GetAll(con);
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbePresupuestosPartidas;
		    }
	    }
        public bePresupuestosPartidas traerPresupuestosPartidas_x_IdPartida(int IdPartida)
        {
            bePresupuestosPartidas obePresupuestosPartidas = new bePresupuestosPartidas();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daPresupuestosPartidas odaPresupuestosPartidas = new daPresupuestosPartidas();
                    obePresupuestosPartidas = odaPresupuestosPartidas.traerPresupuestosPartidas_x_IdPresupuestoPartida(con, IdPartida);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obePresupuestosPartidas;
            }
        }
        public List<bePresupuestosPartidas> PresupuestosPartidas_Traer_Dependencia(int IdDependencia)
        {
            List<bePresupuestosPartidas> lbePresupuestosPartidas = new List<bePresupuestosPartidas>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daPresupuestosPartidas odaPresupuestosPartidas = new daPresupuestosPartidas();
                    lbePresupuestosPartidas = odaPresupuestosPartidas.PresupuestosPartidas_Traer_Dependencia(con, IdDependencia);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbePresupuestosPartidas;
            }
        }
        public bePresupuestosPartidas PresupuestosPartidas_Traer_IdDependencia_IdPartida(int IdDependencia,int IdPartida)
        {
            bePresupuestosPartidas oPresupuestosPartidas = new bePresupuestosPartidas();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daPresupuestosPartidas odaPresupuestosPartidas = new daPresupuestosPartidas();
                    oPresupuestosPartidas = odaPresupuestosPartidas.PresupuestosPartidas_Traer_IdDependencia_IdPartida(con, IdDependencia, IdPartida);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return oPresupuestosPartidas;
            }
        }
    }
}
