using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daConclusionesEstudioMercado
 {
	public int guardarConclusionesEstudioMercado(SqlConnection Conexion, beConclusionesEstudioMercado obeConclusionesEstudioMercado)
	{
		int Id=0;
		string sp = "Proc_ConclusionesEstudioMercadoInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdConclusionEstudioMercado", SqlDbType.Int).Value = obeConclusionesEstudioMercado.IdConclusionEstudioMercado;
				cmd.Parameters.Add("@IdReactivoConclusionEM", SqlDbType.Int).Value = obeConclusionesEstudioMercado.IdReactivoConclusionEM;
				cmd.Parameters.Add("@IdDatoEstudioMercado", SqlDbType.Int).Value = obeConclusionesEstudioMercado.IdDatoEstudioMercado;
				cmd.Parameters.Add("@Respuesta", SqlDbType.Bit).Value = obeConclusionesEstudioMercado.Respuesta;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarConclusionesEstudioMercado(SqlConnection Conexion, beConclusionesEstudioMercado obeConclusionesEstudioMercado)
	{
		string sp = "Proc_ConclusionesEstudioMercadoActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdConclusionEstudioMercado", SqlDbType.Int).Value = obeConclusionesEstudioMercado.IdConclusionEstudioMercado;
				cmd.Parameters.Add("@IdReactivoConclusionEM", SqlDbType.Int).Value = obeConclusionesEstudioMercado.IdReactivoConclusionEM;
				cmd.Parameters.Add("@IdDatoEstudioMercado", SqlDbType.Int).Value = obeConclusionesEstudioMercado.IdDatoEstudioMercado;
				cmd.Parameters.Add("@Respuesta", SqlDbType.Bit).Value = obeConclusionesEstudioMercado.Respuesta;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarConclusionesEstudioMercado(SqlConnection Conexion,int pIdConclusionEstudioMercado)
	{
		string sp = "Proc_ConclusionesEstudioMercadoEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdConclusionEstudioMercado", SqlDbType.Int).Value = pIdConclusionEstudioMercado;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beConclusionesEstudioMercado traerConclusionesEstudioMercado_x_IdConclusionEstudioMercado(SqlConnection Conexion,int IdConclusionEstudioMercado)
	{
		string sp = "Proc_ConclusionesEstudioMercado_x_IdConclusionEstudioMercado";
				beConclusionesEstudioMercado obeConclusionesEstudioMercado=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdConclusionEstudioMercado", SqlDbType.Int).Value = IdConclusionEstudioMercado;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdConclusionEstudioMercado = datard.GetOrdinal("IdConclusionEstudioMercado");
						int posIdReactivoConclusionEM = datard.GetOrdinal("IdReactivoConclusionEM");
						int posIdDatoEstudioMercado = datard.GetOrdinal("IdDatoEstudioMercado");
						int posRespuesta = datard.GetOrdinal("Respuesta");
					 obeConclusionesEstudioMercado = new beConclusionesEstudioMercado();
				while (datard.Read())
					{
						obeConclusionesEstudioMercado.IdConclusionEstudioMercado =  datard.GetInt32(posIdConclusionEstudioMercado);
						obeConclusionesEstudioMercado.IdReactivoConclusionEM =  datard.GetInt32(posIdReactivoConclusionEM);
						obeConclusionesEstudioMercado.IdDatoEstudioMercado =  datard.GetInt32(posIdDatoEstudioMercado);
						obeConclusionesEstudioMercado.Respuesta =  datard.GetBoolean(posRespuesta);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeConclusionesEstudioMercado;
			}
	}
	public List< beConclusionesEstudioMercado> listarTodos_ConclusionesEstudioMercado(SqlConnection Conexion)
	 {
		string sp = "Proc_ConclusionesEstudioMercado_Traer_Todos";
		List<beConclusionesEstudioMercado> lbeConclusionesEstudioMercado = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdConclusionEstudioMercado = datard.GetOrdinal("IdConclusionEstudioMercado");
						int posIdReactivoConclusionEM = datard.GetOrdinal("IdReactivoConclusionEM");
						int posIdDatoEstudioMercado = datard.GetOrdinal("IdDatoEstudioMercado");
						int posRespuesta = datard.GetOrdinal("Respuesta");
				lbeConclusionesEstudioMercado = new List<beConclusionesEstudioMercado>();
				beConclusionesEstudioMercado obeConclusionesEstudioMercado;
				while (datard.Read())
				{
					 obeConclusionesEstudioMercado = new beConclusionesEstudioMercado();
					obeConclusionesEstudioMercado.IdConclusionEstudioMercado =  datard.GetInt32(posIdConclusionEstudioMercado);
					obeConclusionesEstudioMercado.IdReactivoConclusionEM =  datard.GetInt32(posIdReactivoConclusionEM);
					obeConclusionesEstudioMercado.IdDatoEstudioMercado =  datard.GetInt32(posIdDatoEstudioMercado);
					obeConclusionesEstudioMercado.Respuesta =  datard.GetBoolean(posRespuesta);
					lbeConclusionesEstudioMercado.Add(obeConclusionesEstudioMercado);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeConclusionesEstudioMercado;
		}
	}
	public List< beConclusionesEstudioMercado> listar_ConclusionesEstudioMercado_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_ConclusionesEstudioMercado_TraerTodos_GetAll";
		List<beConclusionesEstudioMercado> lbeConclusionesEstudioMercado = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdConclusionEstudioMercado = datard.GetOrdinal("IdConclusionEstudioMercado");
						int posIdReactivoConclusionEM = datard.GetOrdinal("IdReactivoConclusionEM");
						int posIdDatoEstudioMercado = datard.GetOrdinal("IdDatoEstudioMercado");
						int posRespuesta = datard.GetOrdinal("Respuesta");
				lbeConclusionesEstudioMercado = new List<beConclusionesEstudioMercado>();
				beConclusionesEstudioMercado obeConclusionesEstudioMercado;
				while (datard.Read())
				{
					 obeConclusionesEstudioMercado = new beConclusionesEstudioMercado();
					obeConclusionesEstudioMercado.IdConclusionEstudioMercado =  datard.GetInt32(posIdConclusionEstudioMercado);
					obeConclusionesEstudioMercado.IdReactivoConclusionEM =  datard.GetInt32(posIdReactivoConclusionEM);
					obeConclusionesEstudioMercado.IdDatoEstudioMercado =  datard.GetInt32(posIdDatoEstudioMercado);
					obeConclusionesEstudioMercado.Respuesta =  datard.GetBoolean(posRespuesta);
			// debe agregar campos de la Vista
					lbeConclusionesEstudioMercado.Add(obeConclusionesEstudioMercado);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeConclusionesEstudioMercado;
		}
	}

        public List<beConclusionesEstudioMercado> listarTodos_ConclusionesEstudioMercadoEstMerc(SqlConnection Conexion, int IdDatoEstudioMercado)
        {
            string sp = "Proc_ConclusionesEstudioMercado_IdDatoEstudioMercado";
            List<beConclusionesEstudioMercado> lbeConclusionesEstudioMercado = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdDatoEstudioMercado", SqlDbType.Int).Value = IdDatoEstudioMercado;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdConclusionEstudioMercado = datard.GetOrdinal("IdConclusionEstudioMercado");
                        int posIdReactivoConclusionEM = datard.GetOrdinal("IdReactivoConclusionEM");
                        int posIdDatoEstudioMercado = datard.GetOrdinal("IdDatoEstudioMercado");
                        int posRespuesta = datard.GetOrdinal("Respuesta");
                        int posReactivo = datard.GetOrdinal("Reactivo");
                        lbeConclusionesEstudioMercado = new List<beConclusionesEstudioMercado>();
                        beConclusionesEstudioMercado obeConclusionesEstudioMercado;
                        while (datard.Read())
                        {
                            obeConclusionesEstudioMercado = new beConclusionesEstudioMercado();
                            obeConclusionesEstudioMercado.IdConclusionEstudioMercado = datard.GetInt32(posIdConclusionEstudioMercado);
                            obeConclusionesEstudioMercado.IdReactivoConclusionEM = datard.GetInt32(posIdReactivoConclusionEM);
                            obeConclusionesEstudioMercado.IdDatoEstudioMercado = datard.GetInt32(posIdDatoEstudioMercado);
                            obeConclusionesEstudioMercado.Respuesta = datard.GetBoolean(posRespuesta);
                            obeConclusionesEstudioMercado.Reactivo = datard.GetString(posReactivo);
                            lbeConclusionesEstudioMercado.Add(obeConclusionesEstudioMercado);
                        }
                    }
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
