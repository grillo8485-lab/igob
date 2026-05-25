using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daLicitacionesRequisiciones
 {
	public int guardarLicitacionesRequisiciones(SqlConnection Conexion, beLicitacionesRequisiciones obeLicitacionesRequisiciones)
	{
		int Id=0;
		string sp = "Proc_LicitacionesRequisicionesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdLicitacionRequisicion", SqlDbType.Int).Value = obeLicitacionesRequisiciones.IdLicitacionRequisicion;
				cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = obeLicitacionesRequisiciones.IdLicitacion;
				cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obeLicitacionesRequisiciones.IdRequisicion;
				cmd.Parameters.Add("@FechaAutorizacion", SqlDbType.DateTime).Value = obeLicitacionesRequisiciones.FechaAutorizacion;
				cmd.Parameters.Add("@FechaRecepcion", SqlDbType.DateTime).Value = obeLicitacionesRequisiciones.FechaRecepcion;
				cmd.Parameters.Add("@Seleccionada", SqlDbType.Int).Value = obeLicitacionesRequisiciones.Seleccionada;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeLicitacionesRequisiciones.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeLicitacionesRequisiciones.FechaRegistro;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarLicitacionesRequisiciones(SqlConnection Conexion, beLicitacionesRequisiciones obeLicitacionesRequisiciones)
	{
		string sp = "Proc_LicitacionesRequisicionesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdLicitacionRequisicion", SqlDbType.Int).Value = obeLicitacionesRequisiciones.IdLicitacionRequisicion;
				cmd.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = obeLicitacionesRequisiciones.IdLicitacion;
				cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obeLicitacionesRequisiciones.IdRequisicion;
				cmd.Parameters.Add("@FechaAutorizacion", SqlDbType.DateTime).Value = obeLicitacionesRequisiciones.FechaAutorizacion;
				cmd.Parameters.Add("@FechaRecepcion", SqlDbType.DateTime).Value = obeLicitacionesRequisiciones.FechaRecepcion;
				cmd.Parameters.Add("@Seleccionada", SqlDbType.Int).Value = obeLicitacionesRequisiciones.Seleccionada;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeLicitacionesRequisiciones.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeLicitacionesRequisiciones.FechaRegistro;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarLicitacionesRequisiciones(SqlConnection Conexion,int pIdLicitacionRequisicion)
	{
		string sp = "Proc_LicitacionesRequisicionesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdLicitacionRequisicion", SqlDbType.Int).Value = pIdLicitacionRequisicion;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beLicitacionesRequisiciones traerLicitacionesRequisiciones_x_IdLicitacionRequisicion(SqlConnection Conexion,int IdLicitacionRequisicion)
	{
		string sp = "Proc_LicitacionesRequisiciones_x_IdLicitacionRequisicion";
				beLicitacionesRequisiciones obeLicitacionesRequisiciones=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdLicitacionRequisicion", SqlDbType.Int).Value = IdLicitacionRequisicion;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdLicitacionRequisicion = datard.GetOrdinal("IdLicitacionRequisicion");
						int posIdLicitacion = datard.GetOrdinal("IdLicitacion");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posFechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
						int posFechaRecepcion = datard.GetOrdinal("FechaRecepcion");
						int posSeleccionada = datard.GetOrdinal("Seleccionada");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
					 obeLicitacionesRequisiciones = new beLicitacionesRequisiciones();
				while (datard.Read())
					{
						obeLicitacionesRequisiciones.IdLicitacionRequisicion =  datard.GetInt32(posIdLicitacionRequisicion);
						obeLicitacionesRequisiciones.IdLicitacion =  datard.GetInt32(posIdLicitacion);
						obeLicitacionesRequisiciones.IdRequisicion =  datard.GetInt32(posIdRequisicion);
						obeLicitacionesRequisiciones.FechaAutorizacion =  datard.GetDateTime(posFechaAutorizacion);
						obeLicitacionesRequisiciones.FechaRecepcion =  datard.GetDateTime(posFechaRecepcion);
						obeLicitacionesRequisiciones.Seleccionada =  datard.GetInt32(posSeleccionada);
						obeLicitacionesRequisiciones.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
						obeLicitacionesRequisiciones.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeLicitacionesRequisiciones;
			}
	}
	public List< beLicitacionesRequisiciones> listarTodos_LicitacionesRequisiciones(SqlConnection Conexion)
	 {
		string sp = "Proc_LicitacionesRequisiciones_Traer_Todos";
		List<beLicitacionesRequisiciones> lbeLicitacionesRequisiciones = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdLicitacionRequisicion = datard.GetOrdinal("IdLicitacionRequisicion");
						int posIdLicitacion = datard.GetOrdinal("IdLicitacion");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posFechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
						int posFechaRecepcion = datard.GetOrdinal("FechaRecepcion");
						int posSeleccionada = datard.GetOrdinal("Seleccionada");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
				lbeLicitacionesRequisiciones = new List<beLicitacionesRequisiciones>();
				beLicitacionesRequisiciones obeLicitacionesRequisiciones;
				while (datard.Read())
				{
					 obeLicitacionesRequisiciones = new beLicitacionesRequisiciones();
					obeLicitacionesRequisiciones.IdLicitacionRequisicion =  datard.GetInt32(posIdLicitacionRequisicion);
					obeLicitacionesRequisiciones.IdLicitacion =  datard.GetInt32(posIdLicitacion);
					obeLicitacionesRequisiciones.IdRequisicion =  datard.GetInt32(posIdRequisicion);
					obeLicitacionesRequisiciones.FechaAutorizacion =  datard.GetDateTime(posFechaAutorizacion);
					obeLicitacionesRequisiciones.FechaRecepcion =  datard.GetDateTime(posFechaRecepcion);
					obeLicitacionesRequisiciones.Seleccionada =  datard.GetInt32(posSeleccionada);
					obeLicitacionesRequisiciones.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeLicitacionesRequisiciones.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					lbeLicitacionesRequisiciones.Add(obeLicitacionesRequisiciones);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeLicitacionesRequisiciones;
		}
	}
	public List< beLicitacionesRequisiciones> listar_LicitacionesRequisiciones_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_LicitacionesRequisiciones_TraerTodos_GetAll";
		List<beLicitacionesRequisiciones> lbeLicitacionesRequisiciones = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdLicitacionRequisicion = datard.GetOrdinal("IdLicitacionRequisicion");
						int posIdLicitacion = datard.GetOrdinal("IdLicitacion");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posFechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
						int posFechaRecepcion = datard.GetOrdinal("FechaRecepcion");
						int posSeleccionada = datard.GetOrdinal("Seleccionada");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
				lbeLicitacionesRequisiciones = new List<beLicitacionesRequisiciones>();
				beLicitacionesRequisiciones obeLicitacionesRequisiciones;
				while (datard.Read())
				{
					obeLicitacionesRequisiciones = new beLicitacionesRequisiciones();
					obeLicitacionesRequisiciones.IdLicitacionRequisicion =  datard.GetInt32(posIdLicitacionRequisicion);
					obeLicitacionesRequisiciones.IdLicitacion =  datard.GetInt32(posIdLicitacion);
					obeLicitacionesRequisiciones.IdRequisicion =  datard.GetInt32(posIdRequisicion);
					obeLicitacionesRequisiciones.FechaAutorizacion =  datard.GetDateTime(posFechaAutorizacion);
					obeLicitacionesRequisiciones.FechaRecepcion =  datard.GetDateTime(posFechaRecepcion);
					obeLicitacionesRequisiciones.Seleccionada =  datard.GetInt32(posSeleccionada);
					obeLicitacionesRequisiciones.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeLicitacionesRequisiciones.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
			// debe agregar campos de la Vista
					lbeLicitacionesRequisiciones.Add(obeLicitacionesRequisiciones);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeLicitacionesRequisiciones;
		}
	}
}
}
