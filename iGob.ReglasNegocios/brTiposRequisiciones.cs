using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brTiposRequisiciones:brConexion
		 {
	public int guardarTiposRequisiciones(beTiposRequisiciones obeTiposRequisiciones)
	{
		int IdTipoRequisicion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daTiposRequisiciones odaTiposRequisiciones= new daTiposRequisiciones();
			IdTipoRequisicion =  odaTiposRequisiciones.guardarTiposRequisiciones(con, obeTiposRequisiciones);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoRequisicion;
			}
	}

	public int actualizarTiposRequisiciones(beTiposRequisiciones obeTiposRequisiciones)
	{
		int IdTipoRequisicion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposRequisiciones odaTiposRequisiciones= new daTiposRequisiciones();
				IdTipoRequisicion =  odaTiposRequisiciones.actualizarTiposRequisiciones(con, obeTiposRequisiciones);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoRequisicion;
			}
	}

	public int eliminarTiposRequisiciones(int IdTipoRequisicion)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposRequisiciones odaTiposRequisiciones= new daTiposRequisiciones();
				IdTipoRequisicion =  odaTiposRequisiciones.eliminarTiposRequisiciones(con, IdTipoRequisicion);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdTipoRequisicion;
			}
	}

	public beTiposRequisiciones traerTiposRequisiciones_x_IdTipoRequisicion (int IdTipoRequisicion)
	{
		beTiposRequisiciones obeTiposRequisiciones=new beTiposRequisiciones();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposRequisiciones odaTiposRequisiciones= new daTiposRequisiciones();
				 obeTiposRequisiciones =  odaTiposRequisiciones.traerTiposRequisiciones_x_IdTipoRequisicion(con, IdTipoRequisicion);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposRequisiciones;
			}
	}

	public List<beTiposRequisiciones> listarTodos_TiposRequisiciones()
	 {
		List<beTiposRequisiciones> lbeTiposRequisiciones =new List<beTiposRequisiciones>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposRequisiciones odaTiposRequisiciones= new daTiposRequisiciones();
				 lbeTiposRequisiciones =  odaTiposRequisiciones.listarTodos_TiposRequisiciones(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposRequisiciones;
		}
	}
	public List<beTiposRequisiciones> listarTodos_TiposRequisiciones_GetAll()
	 {
		List<beTiposRequisiciones> lbeTiposRequisiciones =new List<beTiposRequisiciones>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daTiposRequisiciones odaTiposRequisiciones= new daTiposRequisiciones();
				 lbeTiposRequisiciones =  odaTiposRequisiciones.listar_TiposRequisiciones_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposRequisiciones;
		}
	}
        public List<beTiposRequisiciones> listar_TiposRequisiciones_Abiertas()
        {
            List<beTiposRequisiciones> lbeTiposRequisiciones = new List<beTiposRequisiciones>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTiposRequisiciones odaTiposRequisiciones = new daTiposRequisiciones();
                    lbeTiposRequisiciones = odaTiposRequisiciones.listar_TiposRequisiciones_Abiertas(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeTiposRequisiciones;
            }
        }
    }
}
