using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daRequisicionesCartas
 {
	public int guardarRequisicionesCartas(SqlConnection Conexion, beRequisicionesCartas obeRequisicionesCartas)
	{
		int Id=0;
		string sp = "Proc_RequisicionesCartasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdProveedorRequisicionCarta", SqlDbType.Int).Value = obeRequisicionesCartas.IdProveedorRequisicionCarta;
				cmd.Parameters.Add("@IdCarta", SqlDbType.Int).Value = obeRequisicionesCartas.IdCarta;
				cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obeRequisicionesCartas.IdRequisicion;
				cmd.Parameters.Add("@Autorizada", SqlDbType.Int).Value = obeRequisicionesCartas.Autorizada;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRequisicionesCartas.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRequisicionesCartas.FechaRegistro;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarRequisicionesCartas(SqlConnection Conexion, beRequisicionesCartas obeRequisicionesCartas)
	{
		string sp = "Proc_RequisicionesCartasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdProveedorRequisicionCarta", SqlDbType.Int).Value = obeRequisicionesCartas.IdProveedorRequisicionCarta;
				cmd.Parameters.Add("@IdCarta", SqlDbType.Int).Value = obeRequisicionesCartas.IdCarta;
				cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obeRequisicionesCartas.IdRequisicion;
				cmd.Parameters.Add("@Autorizada", SqlDbType.Int).Value = obeRequisicionesCartas.Autorizada;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRequisicionesCartas.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRequisicionesCartas.FechaRegistro;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarRequisicionesCartas(SqlConnection Conexion,int pIdProveedorRequisicionCarta)
	{
		string sp = "Proc_RequisicionesCartasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdProveedorRequisicionCarta", SqlDbType.Int).Value = pIdProveedorRequisicionCarta;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beRequisicionesCartas traerRequisicionesCartas_x_IdProveedorRequisicionCarta(SqlConnection Conexion,int IdProveedorRequisicionCarta)
	{
		string sp = "Proc_RequisicionesCartas_x_IdProveedorRequisicionCarta";
				beRequisicionesCartas obeRequisicionesCartas=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdProveedorRequisicionCarta", SqlDbType.Int).Value = IdProveedorRequisicionCarta;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdProveedorRequisicionCarta = datard.GetOrdinal("IdProveedorRequisicionCarta");
						int posIdCarta = datard.GetOrdinal("IdCarta");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posAutorizada = datard.GetOrdinal("Autorizada");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
					 obeRequisicionesCartas = new beRequisicionesCartas();
				while (datard.Read())
					{
						obeRequisicionesCartas.IdProveedorRequisicionCarta =  datard.GetInt32(posIdProveedorRequisicionCarta);
						obeRequisicionesCartas.IdCarta =  datard.GetInt32(posIdCarta);
						obeRequisicionesCartas.IdRequisicion =  datard.GetInt32(posIdRequisicion);
						obeRequisicionesCartas.Autorizada =  datard.GetInt32(posAutorizada);
						obeRequisicionesCartas.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
						obeRequisicionesCartas.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeRequisicionesCartas;
			}
	}
	public List< beRequisicionesCartas> listarTodos_RequisicionesCartas(SqlConnection Conexion)
	 {
		string sp = "Proc_RequisicionesCartas_Traer_Todos";
		List<beRequisicionesCartas> lbeRequisicionesCartas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdProveedorRequisicionCarta = datard.GetOrdinal("IdProveedorRequisicionCarta");
						int posIdCarta = datard.GetOrdinal("IdCarta");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posAutorizada = datard.GetOrdinal("Autorizada");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
				lbeRequisicionesCartas = new List<beRequisicionesCartas>();
				beRequisicionesCartas obeRequisicionesCartas;
				while (datard.Read())
				{
					 obeRequisicionesCartas = new beRequisicionesCartas();
					obeRequisicionesCartas.IdProveedorRequisicionCarta =  datard.GetInt32(posIdProveedorRequisicionCarta);
					obeRequisicionesCartas.IdCarta =  datard.GetInt32(posIdCarta);
					obeRequisicionesCartas.IdRequisicion =  datard.GetInt32(posIdRequisicion);
					obeRequisicionesCartas.Autorizada =  datard.GetInt32(posAutorizada);
					obeRequisicionesCartas.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeRequisicionesCartas.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					lbeRequisicionesCartas.Add(obeRequisicionesCartas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesCartas;
		}
	}
	public List< beRequisicionesCartas> listar_RequisicionesCartas_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_RequisicionesCartas_TraerTodos_GetAll";
		List<beRequisicionesCartas> lbeRequisicionesCartas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdProveedorRequisicionCarta = datard.GetOrdinal("IdProveedorRequisicionCarta");
						int posIdCarta = datard.GetOrdinal("IdCarta");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posAutorizada = datard.GetOrdinal("Autorizada");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
				lbeRequisicionesCartas = new List<beRequisicionesCartas>();
				beRequisicionesCartas obeRequisicionesCartas;
				while (datard.Read())
				{
					 obeRequisicionesCartas = new beRequisicionesCartas();
					obeRequisicionesCartas.IdProveedorRequisicionCarta =  datard.GetInt32(posIdProveedorRequisicionCarta);
					obeRequisicionesCartas.IdCarta =  datard.GetInt32(posIdCarta);
					obeRequisicionesCartas.IdRequisicion =  datard.GetInt32(posIdRequisicion);
					obeRequisicionesCartas.Autorizada =  datard.GetInt32(posAutorizada);
					obeRequisicionesCartas.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeRequisicionesCartas.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
			// debe agregar campos de la Vista
					lbeRequisicionesCartas.Add(obeRequisicionesCartas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesCartas;
		}
	}
}
}
