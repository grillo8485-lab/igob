using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daAdjudicacionesCondicionesEntregas
 {
	public int guardarAdjudicacionesCondicionesEntregas(SqlConnection Conexion, beAdjudicacionesCondicionesEntregas obeAdjudicacionesCondicionesEntregas)
	{
		int Id=0;
		string sp = "Proc_AdjudicacionesCondicionesEntregasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionCondicionEntrega", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregas.IdAdjudicacionCondicionEntrega;
				cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregas.IdAdjudicacion;
				cmd.Parameters.Add("@IdTipoDia", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregas.IdTipoDia;
				cmd.Parameters.Add("@IdPlazoEntegra", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregas.IdPlazoEntegra;
				cmd.Parameters.Add("@IdPlazoTiempo", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregas.IdPlazoTiempo;
				cmd.Parameters.Add("@PlazoEntregaCantidad", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregas.PlazoEntregaCantidad;
				cmd.Parameters.Add("@FechaLimite", SqlDbType.DateTime).Value = obeAdjudicacionesCondicionesEntregas.FechaLimite;
				cmd.Parameters.Add("@IdTipoEntrega", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregas.IdTipoEntrega;
				cmd.Parameters.Add("@Observaciones", SqlDbType.Text).Value = obeAdjudicacionesCondicionesEntregas.Observaciones;
				cmd.Parameters.Add("@NotaEspecial", SqlDbType.Text).Value = obeAdjudicacionesCondicionesEntregas.NotaEspecial;
				cmd.Parameters.Add("@IdEstatus", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregas.IdEstatus;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregas.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeAdjudicacionesCondicionesEntregas.FechaRegistro;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarAdjudicacionesCondicionesEntregas(SqlConnection Conexion, beAdjudicacionesCondicionesEntregas obeAdjudicacionesCondicionesEntregas)
	{
		string sp = "Proc_AdjudicacionesCondicionesEntregasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionCondicionEntrega", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregas.IdAdjudicacionCondicionEntrega;
				cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregas.IdAdjudicacion;
				cmd.Parameters.Add("@IdTipoDia", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregas.IdTipoDia;
				cmd.Parameters.Add("@IdPlazoEntegra", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregas.IdPlazoEntegra;
				cmd.Parameters.Add("@IdPlazoTiempo", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregas.IdPlazoTiempo;
				cmd.Parameters.Add("@PlazoEntregaCantidad", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregas.PlazoEntregaCantidad;
				cmd.Parameters.Add("@FechaLimite", SqlDbType.DateTime).Value = obeAdjudicacionesCondicionesEntregas.FechaLimite;
				cmd.Parameters.Add("@IdTipoEntrega", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregas.IdTipoEntrega;
				cmd.Parameters.Add("@Observaciones", SqlDbType.Text).Value = obeAdjudicacionesCondicionesEntregas.Observaciones;
				cmd.Parameters.Add("@NotaEspecial", SqlDbType.Text).Value = obeAdjudicacionesCondicionesEntregas.NotaEspecial;
				cmd.Parameters.Add("@IdEstatus", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregas.IdEstatus;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeAdjudicacionesCondicionesEntregas.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeAdjudicacionesCondicionesEntregas.FechaRegistro;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarAdjudicacionesCondicionesEntregas(SqlConnection Conexion,int pIdAdjudicacionCondicionEntrega)
	{
		string sp = "Proc_AdjudicacionesCondicionesEntregasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionCondicionEntrega", SqlDbType.Int).Value = pIdAdjudicacionCondicionEntrega;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beAdjudicacionesCondicionesEntregas traerAdjudicacionesCondicionesEntregas_x_IdAdjudicacionCondicionEntrega(SqlConnection Conexion,int IdAdjudicacionCondicionEntrega)
	{
		string sp = "Proc_AdjudicacionesCondicionesEntregas_x_IdAdjudicacionCondicionEntrega";
				beAdjudicacionesCondicionesEntregas obeAdjudicacionesCondicionesEntregas=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdAdjudicacionCondicionEntrega", SqlDbType.Int).Value = IdAdjudicacionCondicionEntrega;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdAdjudicacionCondicionEntrega = datard.GetOrdinal("IdAdjudicacionCondicionEntrega");
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
						int posIdTipoDia = datard.GetOrdinal("IdTipoDia");
						int posIdPlazoEntegra = datard.GetOrdinal("IdPlazoEntegra");
						int posIdPlazoTiempo = datard.GetOrdinal("IdPlazoTiempo");
						int posPlazoEntregaCantidad = datard.GetOrdinal("PlazoEntregaCantidad");
						int posFechaLimite = datard.GetOrdinal("FechaLimite");
						int posIdTipoEntrega = datard.GetOrdinal("IdTipoEntrega");
						int posObservaciones = datard.GetOrdinal("Observaciones");
						int posNotaEspecial = datard.GetOrdinal("NotaEspecial");
						int posIdEstatus = datard.GetOrdinal("IdEstatus");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
					 obeAdjudicacionesCondicionesEntregas = new beAdjudicacionesCondicionesEntregas();
				while (datard.Read())
					{
						obeAdjudicacionesCondicionesEntregas.IdAdjudicacionCondicionEntrega =  datard.GetInt32(posIdAdjudicacionCondicionEntrega);
						obeAdjudicacionesCondicionesEntregas.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
						obeAdjudicacionesCondicionesEntregas.IdTipoDia =  datard.GetInt32(posIdTipoDia);
						obeAdjudicacionesCondicionesEntregas.IdPlazoEntegra =  datard.GetInt32(posIdPlazoEntegra);
						obeAdjudicacionesCondicionesEntregas.IdPlazoTiempo =  datard.GetInt32(posIdPlazoTiempo);
						obeAdjudicacionesCondicionesEntregas.PlazoEntregaCantidad =  datard.GetInt32(posPlazoEntregaCantidad);
						obeAdjudicacionesCondicionesEntregas.FechaLimite =  datard.GetDateTime(posFechaLimite);
						obeAdjudicacionesCondicionesEntregas.IdTipoEntrega =  datard.GetInt32(posIdTipoEntrega);
						obeAdjudicacionesCondicionesEntregas.Observaciones =  datard.GetString(posObservaciones);
						obeAdjudicacionesCondicionesEntregas.NotaEspecial =  datard.GetString(posNotaEspecial);
						obeAdjudicacionesCondicionesEntregas.IdEstatus =  datard.GetInt32(posIdEstatus);
						obeAdjudicacionesCondicionesEntregas.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
						obeAdjudicacionesCondicionesEntregas.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
                        obeAdjudicacionesCondicionesEntregas.IsNUll = false;

                        }
                    }
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesCondicionesEntregas;
			}
	}
	public List< beAdjudicacionesCondicionesEntregas> listarTodos_AdjudicacionesCondicionesEntregas(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesCondicionesEntregas_Traer_Todos";
		List<beAdjudicacionesCondicionesEntregas> lbeAdjudicacionesCondicionesEntregas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicacionCondicionEntrega = datard.GetOrdinal("IdAdjudicacionCondicionEntrega");
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
						int posIdTipoDia = datard.GetOrdinal("IdTipoDia");
						int posIdPlazoEntegra = datard.GetOrdinal("IdPlazoEntegra");
						int posIdPlazoTiempo = datard.GetOrdinal("IdPlazoTiempo");
						int posPlazoEntregaCantidad = datard.GetOrdinal("PlazoEntregaCantidad");
						int posFechaLimite = datard.GetOrdinal("FechaLimite");
						int posIdTipoEntrega = datard.GetOrdinal("IdTipoEntrega");
						int posObservaciones = datard.GetOrdinal("Observaciones");
						int posNotaEspecial = datard.GetOrdinal("NotaEspecial");
						int posIdEstatus = datard.GetOrdinal("IdEstatus");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
				lbeAdjudicacionesCondicionesEntregas = new List<beAdjudicacionesCondicionesEntregas>();
				beAdjudicacionesCondicionesEntregas obeAdjudicacionesCondicionesEntregas;
				while (datard.Read())
				{
					 obeAdjudicacionesCondicionesEntregas = new beAdjudicacionesCondicionesEntregas();
					obeAdjudicacionesCondicionesEntregas.IdAdjudicacionCondicionEntrega =  datard.GetInt32(posIdAdjudicacionCondicionEntrega);
					obeAdjudicacionesCondicionesEntregas.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
					obeAdjudicacionesCondicionesEntregas.IdTipoDia =  datard.GetInt32(posIdTipoDia);
					obeAdjudicacionesCondicionesEntregas.IdPlazoEntegra =  datard.GetInt32(posIdPlazoEntegra);
					obeAdjudicacionesCondicionesEntregas.IdPlazoTiempo =  datard.GetInt32(posIdPlazoTiempo);
					obeAdjudicacionesCondicionesEntregas.PlazoEntregaCantidad =  datard.GetInt32(posPlazoEntregaCantidad);
					obeAdjudicacionesCondicionesEntregas.FechaLimite =  datard.GetDateTime(posFechaLimite);
					obeAdjudicacionesCondicionesEntregas.IdTipoEntrega =  datard.GetInt32(posIdTipoEntrega);
					obeAdjudicacionesCondicionesEntregas.Observaciones =  datard.GetString(posObservaciones);
					obeAdjudicacionesCondicionesEntregas.NotaEspecial =  datard.GetString(posNotaEspecial);
					obeAdjudicacionesCondicionesEntregas.IdEstatus =  datard.GetInt32(posIdEstatus);
					obeAdjudicacionesCondicionesEntregas.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeAdjudicacionesCondicionesEntregas.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					lbeAdjudicacionesCondicionesEntregas.Add(obeAdjudicacionesCondicionesEntregas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesCondicionesEntregas;
		}
	}
	public List< beAdjudicacionesCondicionesEntregas> listar_AdjudicacionesCondicionesEntregas_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesCondicionesEntregas_TraerTodos_GetAll";
		List<beAdjudicacionesCondicionesEntregas> lbeAdjudicacionesCondicionesEntregas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicacionCondicionEntrega = datard.GetOrdinal("IdAdjudicacionCondicionEntrega");
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
						int posIdTipoDia = datard.GetOrdinal("IdTipoDia");
						int posIdPlazoEntegra = datard.GetOrdinal("IdPlazoEntegra");
						int posIdPlazoTiempo = datard.GetOrdinal("IdPlazoTiempo");
						int posPlazoEntregaCantidad = datard.GetOrdinal("PlazoEntregaCantidad");
						int posFechaLimite = datard.GetOrdinal("FechaLimite");
						int posIdTipoEntrega = datard.GetOrdinal("IdTipoEntrega");
						int posObservaciones = datard.GetOrdinal("Observaciones");
						int posNotaEspecial = datard.GetOrdinal("NotaEspecial");
						int posIdEstatus = datard.GetOrdinal("IdEstatus");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
				lbeAdjudicacionesCondicionesEntregas = new List<beAdjudicacionesCondicionesEntregas>();
				beAdjudicacionesCondicionesEntregas obeAdjudicacionesCondicionesEntregas;
				while (datard.Read())
				{
					 obeAdjudicacionesCondicionesEntregas = new beAdjudicacionesCondicionesEntregas();
					obeAdjudicacionesCondicionesEntregas.IdAdjudicacionCondicionEntrega =  datard.GetInt32(posIdAdjudicacionCondicionEntrega);
					obeAdjudicacionesCondicionesEntregas.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
					obeAdjudicacionesCondicionesEntregas.IdTipoDia =  datard.GetInt32(posIdTipoDia);
					obeAdjudicacionesCondicionesEntregas.IdPlazoEntegra =  datard.GetInt32(posIdPlazoEntegra);
					obeAdjudicacionesCondicionesEntregas.IdPlazoTiempo =  datard.GetInt32(posIdPlazoTiempo);
					obeAdjudicacionesCondicionesEntregas.PlazoEntregaCantidad =  datard.GetInt32(posPlazoEntregaCantidad);
					obeAdjudicacionesCondicionesEntregas.FechaLimite =  datard.GetDateTime(posFechaLimite);
					obeAdjudicacionesCondicionesEntregas.IdTipoEntrega =  datard.GetInt32(posIdTipoEntrega);
					obeAdjudicacionesCondicionesEntregas.Observaciones =  datard.GetString(posObservaciones);
					obeAdjudicacionesCondicionesEntregas.NotaEspecial =  datard.GetString(posNotaEspecial);
					obeAdjudicacionesCondicionesEntregas.IdEstatus =  datard.GetInt32(posIdEstatus);
					obeAdjudicacionesCondicionesEntregas.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeAdjudicacionesCondicionesEntregas.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
			// debe agregar campos de la Vista
					lbeAdjudicacionesCondicionesEntregas.Add(obeAdjudicacionesCondicionesEntregas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesCondicionesEntregas;
		}
	}
}
}
