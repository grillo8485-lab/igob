using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brCondicionesPagosEntrega:brConexion
		 {
	public int guardarCondicionesPagosEntrega(beCondicionesPagosEntrega obeCondicionesPagosEntrega)
	{
		int IdCondicion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daCondicionesPagosEntrega odaCondicionesPagosEntrega= new daCondicionesPagosEntrega();
			IdCondicion =  odaCondicionesPagosEntrega.guardarCondicionesPagosEntrega(con, obeCondicionesPagosEntrega);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdCondicion;
			}
	}

	public int actualizarCondicionesPagosEntrega(beCondicionesPagosEntrega obeCondicionesPagosEntrega)
	{
		int IdCondicion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daCondicionesPagosEntrega odaCondicionesPagosEntrega= new daCondicionesPagosEntrega();
				IdCondicion =  odaCondicionesPagosEntrega.actualizarCondicionesPagosEntrega(con, obeCondicionesPagosEntrega);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdCondicion;
			}
	}

	public int eliminarCondicionesPagosEntrega(int IdCondicion)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daCondicionesPagosEntrega odaCondicionesPagosEntrega= new daCondicionesPagosEntrega();
				IdCondicion =  odaCondicionesPagosEntrega.eliminarCondicionesPagosEntrega(con, IdCondicion);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdCondicion;
			}
	}

	public beCondicionesPagosEntrega traerCondicionesPagosEntrega_x_IdCondicion (int IdCondicion)
	{
		beCondicionesPagosEntrega obeCondicionesPagosEntrega=new beCondicionesPagosEntrega();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daCondicionesPagosEntrega odaCondicionesPagosEntrega= new daCondicionesPagosEntrega();
				 obeCondicionesPagosEntrega =  odaCondicionesPagosEntrega.traerCondicionesPagosEntrega_x_IdCondicion(con, IdCondicion);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeCondicionesPagosEntrega;
			}
	}

	public List<beCondicionesPagosEntrega> listarTodos_CondicionesPagosEntrega()
	 {
		List<beCondicionesPagosEntrega> lbeCondicionesPagosEntrega =new List<beCondicionesPagosEntrega>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daCondicionesPagosEntrega odaCondicionesPagosEntrega= new daCondicionesPagosEntrega();
				 lbeCondicionesPagosEntrega =  odaCondicionesPagosEntrega.listarTodos_CondicionesPagosEntrega(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeCondicionesPagosEntrega;
		}
	}
    /* Proc_Cartas_TraerTodos_GetAll --- 24/08/2018 */
    public List<beCondicionesPagosEntrega> listarTodos_CondicionesPagosEntrega_GetAll()
    {
        List<beCondicionesPagosEntrega> lbeCondicionesPagosEntrega = new List<beCondicionesPagosEntrega>();
        using (SqlConnection con = new SqlConnection(CadenaConexion))
        {
            try
            {
                con.Open();
                daCondicionesPagosEntrega odaCondicionesPagosEntrega = new daCondicionesPagosEntrega();
                lbeCondicionesPagosEntrega = odaCondicionesPagosEntrega.listarTodos_CondicionesPagosEntrega_GetAll(con);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeCondicionesPagosEntrega;
        }
    }
    /**/
    }
}
