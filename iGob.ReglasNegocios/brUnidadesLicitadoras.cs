using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brUnidadesLicitadoras:brConexion
		 {
	public int guardarUnidadesLicitadoras(beUnidadesLicitadoras obeUnidadesLicitadoras)
	{
		int IdUnidadLicitadora;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daUnidadesLicitadoras odaUnidadesLicitadoras= new daUnidadesLicitadoras();
			IdUnidadLicitadora =  odaUnidadesLicitadoras.guardarUnidadesLicitadoras(con, obeUnidadesLicitadoras);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdUnidadLicitadora;
			}
	}

	public int actualizarUnidadesLicitadoras(beUnidadesLicitadoras obeUnidadesLicitadoras)
	{
		int IdUnidadLicitadora;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daUnidadesLicitadoras odaUnidadesLicitadoras= new daUnidadesLicitadoras();
				IdUnidadLicitadora =  odaUnidadesLicitadoras.actualizarUnidadesLicitadoras(con, obeUnidadesLicitadoras);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdUnidadLicitadora;
			}
	}

	public int eliminarUnidadesLicitadoras(int IdUnidadLicitadora)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daUnidadesLicitadoras odaUnidadesLicitadoras= new daUnidadesLicitadoras();
				IdUnidadLicitadora =  odaUnidadesLicitadoras.eliminarUnidadesLicitadoras(con, IdUnidadLicitadora);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdUnidadLicitadora;
			}
	}

	public beUnidadesLicitadoras traerUnidadesLicitadoras_x_IdUnidadLicitadora (int IdUnidadLicitadora)
	{
		beUnidadesLicitadoras obeUnidadesLicitadoras=new beUnidadesLicitadoras();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daUnidadesLicitadoras odaUnidadesLicitadoras= new daUnidadesLicitadoras();
				 obeUnidadesLicitadoras =  odaUnidadesLicitadoras.traerUnidadesLicitadoras_x_IdUnidadLicitadora(con, IdUnidadLicitadora);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeUnidadesLicitadoras;
			}
	}

	public List<beUnidadesLicitadoras> listarTodos_UnidadesLicitadoras()
	 {
		List<beUnidadesLicitadoras> lbeUnidadesLicitadoras =new List<beUnidadesLicitadoras>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daUnidadesLicitadoras odaUnidadesLicitadoras= new daUnidadesLicitadoras();
				 lbeUnidadesLicitadoras =  odaUnidadesLicitadoras.listarTodos_UnidadesLicitadoras(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeUnidadesLicitadoras;
		}
	}
    public List<beUnidadesLicitadoras> listarTodos_UnidadesLicitadoras_GetAll()
    {
        List<beUnidadesLicitadoras> lbeUnidadesLicitadoras = new List<beUnidadesLicitadoras>();
        using (SqlConnection con = new SqlConnection(CadenaConexion))
        {
            try
            {
                con.Open();
                daUnidadesLicitadoras odaUnidadesLicitadoras = new daUnidadesLicitadoras();
                lbeUnidadesLicitadoras = odaUnidadesLicitadoras.listarTodos_UnidadesLicitadoras_GetAll(con);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeUnidadesLicitadoras;
        }
    }
    }
}
