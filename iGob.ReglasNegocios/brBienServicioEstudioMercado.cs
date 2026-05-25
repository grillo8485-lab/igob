using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brBienServicioEstudioMercado:brConexion
		 {
	public int guardarBienServicioEstudioMercado(beBienServicioEstudioMercado obeBienServicioEstudioMercado)
	{
		int IdDatoEstudioMercado;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daBienServicioEstudioMercado odaBienServicioEstudioMercado= new daBienServicioEstudioMercado();
			IdDatoEstudioMercado =  odaBienServicioEstudioMercado.guardarBienServicioEstudioMercado(con, obeBienServicioEstudioMercado);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdDatoEstudioMercado;
			}
	}

	public int actualizarBienServicioEstudioMercado(beBienServicioEstudioMercado obeBienServicioEstudioMercado)
	{
		int IdDatoEstudioMercado;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daBienServicioEstudioMercado odaBienServicioEstudioMercado= new daBienServicioEstudioMercado();
				IdDatoEstudioMercado =  odaBienServicioEstudioMercado.actualizarBienServicioEstudioMercado(con, obeBienServicioEstudioMercado);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdDatoEstudioMercado;
			}
	}

	public int eliminarBienServicioEstudioMercado(int IdDatoEstudioMercado)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daBienServicioEstudioMercado odaBienServicioEstudioMercado= new daBienServicioEstudioMercado();
				IdDatoEstudioMercado =  odaBienServicioEstudioMercado.eliminarBienServicioEstudioMercado(con, IdDatoEstudioMercado);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdDatoEstudioMercado;
			}
	}

	public beBienServicioEstudioMercado traerBienServicioEstudioMercado_x_IdDatoEstudioMercado (int IdDatoEstudioMercado)
	{
		beBienServicioEstudioMercado obeBienServicioEstudioMercado=new beBienServicioEstudioMercado();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daBienServicioEstudioMercado odaBienServicioEstudioMercado= new daBienServicioEstudioMercado();
				 obeBienServicioEstudioMercado =  odaBienServicioEstudioMercado.traerBienServicioEstudioMercado_x_IdDatoEstudioMercado(con, IdDatoEstudioMercado);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeBienServicioEstudioMercado;
			}
	}

	public List<beBienServicioEstudioMercado> listarTodos_BienServicioEstudioMercado()
	 {
		List<beBienServicioEstudioMercado> lbeBienServicioEstudioMercado =new List<beBienServicioEstudioMercado>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daBienServicioEstudioMercado odaBienServicioEstudioMercado= new daBienServicioEstudioMercado();
				 lbeBienServicioEstudioMercado =  odaBienServicioEstudioMercado.listarTodos_BienServicioEstudioMercado(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeBienServicioEstudioMercado;
		}
	}
	public List<beBienServicioEstudioMercado> listarTodos_BienServicioEstudioMercado_GetAll()
	 {
		List<beBienServicioEstudioMercado> lbeBienServicioEstudioMercado =new List<beBienServicioEstudioMercado>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daBienServicioEstudioMercado odaBienServicioEstudioMercado= new daBienServicioEstudioMercado();
				 lbeBienServicioEstudioMercado =  odaBienServicioEstudioMercado.listar_BienServicioEstudioMercado_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeBienServicioEstudioMercado;
		}
	}

        public List<beBienServicioEstudioMercado> listarTodos_BienServicioEstudioMercadoHistorial()
        {
            List<beBienServicioEstudioMercado> lbeBienServicioEstudioMercado = new List<beBienServicioEstudioMercado>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daBienServicioEstudioMercado odaBienServicioEstudioMercado = new daBienServicioEstudioMercado();
                    lbeBienServicioEstudioMercado = odaBienServicioEstudioMercado.listarTodos_BienServicioEstudioMercadoHistorial(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeBienServicioEstudioMercado;
            }
        }
    }
}
