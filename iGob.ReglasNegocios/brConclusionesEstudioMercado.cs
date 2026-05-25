using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brConclusionesEstudioMercado:brConexion
		 {
	public int guardarConclusionesEstudioMercado(beConclusionesEstudioMercado obeConclusionesEstudioMercado)
	{
		int IdConclusionEstudioMercado;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daConclusionesEstudioMercado odaConclusionesEstudioMercado= new daConclusionesEstudioMercado();
			IdConclusionEstudioMercado =  odaConclusionesEstudioMercado.guardarConclusionesEstudioMercado(con, obeConclusionesEstudioMercado);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdConclusionEstudioMercado;
			}
	}

	public int actualizarConclusionesEstudioMercado(beConclusionesEstudioMercado obeConclusionesEstudioMercado)
	{
		int IdConclusionEstudioMercado;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daConclusionesEstudioMercado odaConclusionesEstudioMercado= new daConclusionesEstudioMercado();
				IdConclusionEstudioMercado =  odaConclusionesEstudioMercado.actualizarConclusionesEstudioMercado(con, obeConclusionesEstudioMercado);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdConclusionEstudioMercado;
			}
	}

	public int eliminarConclusionesEstudioMercado(int IdConclusionEstudioMercado)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daConclusionesEstudioMercado odaConclusionesEstudioMercado= new daConclusionesEstudioMercado();
				IdConclusionEstudioMercado =  odaConclusionesEstudioMercado.eliminarConclusionesEstudioMercado(con, IdConclusionEstudioMercado);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdConclusionEstudioMercado;
			}
	}

	public beConclusionesEstudioMercado traerConclusionesEstudioMercado_x_IdConclusionEstudioMercado (int IdConclusionEstudioMercado)
	{
		beConclusionesEstudioMercado obeConclusionesEstudioMercado=new beConclusionesEstudioMercado();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daConclusionesEstudioMercado odaConclusionesEstudioMercado= new daConclusionesEstudioMercado();
				 obeConclusionesEstudioMercado =  odaConclusionesEstudioMercado.traerConclusionesEstudioMercado_x_IdConclusionEstudioMercado(con, IdConclusionEstudioMercado);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeConclusionesEstudioMercado;
			}
	}

	public List<beConclusionesEstudioMercado> listarTodos_ConclusionesEstudioMercado()
	 {
		List<beConclusionesEstudioMercado> lbeConclusionesEstudioMercado =new List<beConclusionesEstudioMercado>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daConclusionesEstudioMercado odaConclusionesEstudioMercado= new daConclusionesEstudioMercado();
				 lbeConclusionesEstudioMercado =  odaConclusionesEstudioMercado.listarTodos_ConclusionesEstudioMercado(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeConclusionesEstudioMercado;
		}
	}
	public List<beConclusionesEstudioMercado> listarTodos_ConclusionesEstudioMercado_GetAll()
	 {
		List<beConclusionesEstudioMercado> lbeConclusionesEstudioMercado =new List<beConclusionesEstudioMercado>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daConclusionesEstudioMercado odaConclusionesEstudioMercado= new daConclusionesEstudioMercado();
				 lbeConclusionesEstudioMercado =  odaConclusionesEstudioMercado.listar_ConclusionesEstudioMercado_GetAll(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeConclusionesEstudioMercado;
		}
	}

        public List<beConclusionesEstudioMercado> listarTodos_ConclusionesEstudioMercadoEstMerc(int IdDatoEstudioMercado)
        {
            List<beConclusionesEstudioMercado> lbeConclusionesEstudioMercado = new List<beConclusionesEstudioMercado>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daConclusionesEstudioMercado odaConclusionesEstudioMercado = new daConclusionesEstudioMercado();
                    lbeConclusionesEstudioMercado = odaConclusionesEstudioMercado.listarTodos_ConclusionesEstudioMercadoEstMerc(con, IdDatoEstudioMercado);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeConclusionesEstudioMercado;
            }
        }
    }
}
