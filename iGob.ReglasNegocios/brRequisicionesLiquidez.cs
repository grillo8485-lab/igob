using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brRequisicionesLiquidez:brConexion
		 {
	public int guardarRequisicionesLiquidez(beRequisicionesLiquidez obeRequisicionesLiquidez)
	{
		int IdRequisicionLiquidez;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daRequisicionesLiquidez odaRequisicionesLiquidez= new daRequisicionesLiquidez();
			IdRequisicionLiquidez =  odaRequisicionesLiquidez.guardarRequisicionesLiquidez(con, obeRequisicionesLiquidez);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdRequisicionLiquidez;
			}
	}

	public int actualizarRequisicionesLiquidez(beRequisicionesLiquidez obeRequisicionesLiquidez)
	{
		int IdRequisicionLiquidez;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesLiquidez odaRequisicionesLiquidez= new daRequisicionesLiquidez();
				IdRequisicionLiquidez =  odaRequisicionesLiquidez.actualizarRequisicionesLiquidez(con, obeRequisicionesLiquidez);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdRequisicionLiquidez;
			}
	}

	public int eliminarRequisicionesLiquidez(int IdRequisicionLiquidez)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesLiquidez odaRequisicionesLiquidez= new daRequisicionesLiquidez();
				IdRequisicionLiquidez =  odaRequisicionesLiquidez.eliminarRequisicionesLiquidez(con, IdRequisicionLiquidez);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdRequisicionLiquidez;
			}
	}

	public beRequisicionesLiquidez traerRequisicionesLiquidez_x_IdRequisicionLiquidez (int IdRequisicionLiquidez)
	{
		beRequisicionesLiquidez obeRequisicionesLiquidez=new beRequisicionesLiquidez();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesLiquidez odaRequisicionesLiquidez= new daRequisicionesLiquidez();
				 obeRequisicionesLiquidez =  odaRequisicionesLiquidez.traerRequisicionesLiquidez_x_IdRequisicionLiquidez(con, IdRequisicionLiquidez);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeRequisicionesLiquidez;
			}
	}

	public List<beRequisicionesLiquidez> listarTodos_RequisicionesLiquidez()
	 {
		List<beRequisicionesLiquidez> lbeRequisicionesLiquidez =new List<beRequisicionesLiquidez>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesLiquidez odaRequisicionesLiquidez= new daRequisicionesLiquidez();
				 lbeRequisicionesLiquidez =  odaRequisicionesLiquidez.listarTodos_RequisicionesLiquidez(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesLiquidez;
		}
	}
	public List<beRequisicionesLiquidez> listarTodos_RequisicionesLiquidez_GetAll()
	 {
		List<beRequisicionesLiquidez> lbeRequisicionesLiquidez =new List<beRequisicionesLiquidez>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daRequisicionesLiquidez odaRequisicionesLiquidez= new daRequisicionesLiquidez();
				 lbeRequisicionesLiquidez =  odaRequisicionesLiquidez.listar_RequisicionesLiquidez_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesLiquidez;
		}
	}

    public List<beRequisicionesLiquidez> Listar_RequisicionLiquidez_x_IdRequisicion(int idRequisicion)
    {
        List<beRequisicionesLiquidez> lbeRequisicionesLiquidez = new List<beRequisicionesLiquidez>();
        using (SqlConnection con = new SqlConnection(CadenaConexion))
        {
            try
            {
                con.Open();
                daRequisicionesLiquidez odaRequisicionesLiquidez = new daRequisicionesLiquidez();
                lbeRequisicionesLiquidez = odaRequisicionesLiquidez.Listar_RequisicionLiquidez_x_IdRequisicion(con, idRequisicion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeRequisicionesLiquidez;
        }
    }

        public List<beRequisicionesLiquidez> RequisicionesLiquidez_Traer_IdRequisicion(int idRequisicion)
        {
            List<beRequisicionesLiquidez> lbeRequisicionesLiquidez = new List<beRequisicionesLiquidez>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesLiquidez odaRequisicionesLiquidez = new daRequisicionesLiquidez();
                    lbeRequisicionesLiquidez = odaRequisicionesLiquidez.RequisicionesLiquidez_Traer_IdRequisicion(con, idRequisicion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesLiquidez;
            }
        }

    }
}
