using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daRequisicionesCondicionesEntregas
 {
	public int guardarRequisicionesCondicionesEntregas(SqlConnection Conexion, beRequisicionesCondicionesEntregas obeRequisicionesCondicionesEntregas)
	{
		int Id=0;
		string sp = "Proc_RequisicionesCondicionesEntregasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdRequisicionCondicionEntrega", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregas.IdRequisicionCondicionEntrega;
				cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregas.IdRequisicion;
				cmd.Parameters.Add("@IdTipoDia", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregas.IdTipoDia;
				cmd.Parameters.Add("@IdPlazoEntegra", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregas.IdPlazoEntegra;
				cmd.Parameters.Add("@PlazoEntregaCantidad", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregas.PlazoEntregaCantidad;
				cmd.Parameters.Add("@FechaLimite", SqlDbType.DateTime).Value = obeRequisicionesCondicionesEntregas.FechaLimite;
				cmd.Parameters.Add("@IdTipoEntrega", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregas.IdTipoEntrega;
				cmd.Parameters.Add("@Observaciones", SqlDbType.Text).Value = obeRequisicionesCondicionesEntregas.Observaciones;
				cmd.Parameters.Add("@NotaEspecial", SqlDbType.Text).Value = obeRequisicionesCondicionesEntregas.NotaEspecial;
				cmd.Parameters.Add("@IdEstatus", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregas.IdEstatus;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregas.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRequisicionesCondicionesEntregas.FechaRegistro;
				cmd.Parameters.Add("@IdPlazoTiempo", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregas.IdPlazoTiempo;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarRequisicionesCondicionesEntregas(SqlConnection Conexion, beRequisicionesCondicionesEntregas obeRequisicionesCondicionesEntregas)
	{
		string sp = "Proc_RequisicionesCondicionesEntregasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdRequisicionCondicionEntrega", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregas.IdRequisicionCondicionEntrega;
				cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregas.IdRequisicion;
				cmd.Parameters.Add("@IdTipoDia", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregas.IdTipoDia;
				cmd.Parameters.Add("@IdPlazoEntegra", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregas.IdPlazoEntegra;
				cmd.Parameters.Add("@PlazoEntregaCantidad", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregas.PlazoEntregaCantidad;
				cmd.Parameters.Add("@FechaLimite", SqlDbType.DateTime).Value = obeRequisicionesCondicionesEntregas.FechaLimite;
				cmd.Parameters.Add("@IdTipoEntrega", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregas.IdTipoEntrega;
				cmd.Parameters.Add("@Observaciones", SqlDbType.Text).Value = obeRequisicionesCondicionesEntregas.Observaciones;
				cmd.Parameters.Add("@NotaEspecial", SqlDbType.Text).Value = obeRequisicionesCondicionesEntregas.NotaEspecial;
				cmd.Parameters.Add("@IdEstatus", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregas.IdEstatus;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregas.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRequisicionesCondicionesEntregas.FechaRegistro;
				cmd.Parameters.Add("@IdPlazoTiempo", SqlDbType.Int).Value = obeRequisicionesCondicionesEntregas.IdPlazoTiempo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarRequisicionesCondicionesEntregas(SqlConnection Conexion,int pIdRequisicionCondicionEntrega)
	{
		string sp = "Proc_RequisicionesCondicionesEntregasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdRequisicionCondicionEntrega", SqlDbType.Int).Value = pIdRequisicionCondicionEntrega;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beRequisicionesCondicionesEntregas traerRequisicionesCondicionesEntregas_x_IdRequisicionCondicionEntrega(SqlConnection Conexion,int IdRequisicionCondicionEntrega)
	{
		string sp = "Proc_RequisicionesCondicionesEntregas_x_IdRequisicionCondicionEntrega";
				beRequisicionesCondicionesEntregas obeRequisicionesCondicionesEntregas=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdRequisicionCondicionEntrega", SqlDbType.Int).Value = IdRequisicionCondicionEntrega;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdRequisicionCondicionEntrega = datard.GetOrdinal("IdRequisicionCondicionEntrega");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posIdTipoDia = datard.GetOrdinal("IdTipoDia");
						int posIdPlazoEntegra = datard.GetOrdinal("IdPlazoEntegra");
						int posPlazoEntregaCantidad = datard.GetOrdinal("PlazoEntregaCantidad");
						int posFechaLimite = datard.GetOrdinal("FechaLimite");
						int posIdTipoEntrega = datard.GetOrdinal("IdTipoEntrega");
						int posObservaciones = datard.GetOrdinal("Observaciones");
						int posNotaEspecial = datard.GetOrdinal("NotaEspecial");
						int posIdEstatus = datard.GetOrdinal("IdEstatus");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posIdPlazoTiempo = datard.GetOrdinal("IdPlazoTiempo");
					 obeRequisicionesCondicionesEntregas = new beRequisicionesCondicionesEntregas();
				while (datard.Read())
					{
						obeRequisicionesCondicionesEntregas.IdRequisicionCondicionEntrega =  datard.GetInt32(posIdRequisicionCondicionEntrega);
						obeRequisicionesCondicionesEntregas.IdRequisicion =  datard.GetInt32(posIdRequisicion);
						obeRequisicionesCondicionesEntregas.IdTipoDia =  datard.GetInt32(posIdTipoDia);
						obeRequisicionesCondicionesEntregas.IdPlazoEntegra =  datard.GetInt32(posIdPlazoEntegra);
						obeRequisicionesCondicionesEntregas.PlazoEntregaCantidad =  datard.GetInt32(posPlazoEntregaCantidad);
						obeRequisicionesCondicionesEntregas.FechaLimite =  datard.GetDateTime(posFechaLimite);
						obeRequisicionesCondicionesEntregas.IdTipoEntrega =  datard.GetInt32(posIdTipoEntrega);
						obeRequisicionesCondicionesEntregas.Observaciones =  datard.GetString(posObservaciones);
						obeRequisicionesCondicionesEntregas.NotaEspecial =  datard.GetString(posNotaEspecial);
						obeRequisicionesCondicionesEntregas.IdEstatus =  datard.GetInt32(posIdEstatus);
						obeRequisicionesCondicionesEntregas.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
						obeRequisicionesCondicionesEntregas.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
						obeRequisicionesCondicionesEntregas.IdPlazoTiempo =  datard.GetInt32(posIdPlazoTiempo);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeRequisicionesCondicionesEntregas;
			}
	}
	public List< beRequisicionesCondicionesEntregas> listarTodos_RequisicionesCondicionesEntregas(SqlConnection Conexion)
	 {
		string sp = "Proc_RequisicionesCondicionesEntregas_Traer_Todos";
		List<beRequisicionesCondicionesEntregas> lbeRequisicionesCondicionesEntregas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdRequisicionCondicionEntrega = datard.GetOrdinal("IdRequisicionCondicionEntrega");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posIdTipoDia = datard.GetOrdinal("IdTipoDia");
						int posIdPlazoEntegra = datard.GetOrdinal("IdPlazoEntegra");
						int posPlazoEntregaCantidad = datard.GetOrdinal("PlazoEntregaCantidad");
						int posFechaLimite = datard.GetOrdinal("FechaLimite");
						int posIdTipoEntrega = datard.GetOrdinal("IdTipoEntrega");
						int posObservaciones = datard.GetOrdinal("Observaciones");
						int posNotaEspecial = datard.GetOrdinal("NotaEspecial");
						int posIdEstatus = datard.GetOrdinal("IdEstatus");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posIdPlazoTiempo = datard.GetOrdinal("IdPlazoTiempo");
				lbeRequisicionesCondicionesEntregas = new List<beRequisicionesCondicionesEntregas>();
				beRequisicionesCondicionesEntregas obeRequisicionesCondicionesEntregas;
				while (datard.Read())
				{
					 obeRequisicionesCondicionesEntregas = new beRequisicionesCondicionesEntregas();
					obeRequisicionesCondicionesEntregas.IdRequisicionCondicionEntrega =  datard.GetInt32(posIdRequisicionCondicionEntrega);
					obeRequisicionesCondicionesEntregas.IdRequisicion =  datard.GetInt32(posIdRequisicion);
					obeRequisicionesCondicionesEntregas.IdTipoDia =  datard.GetInt32(posIdTipoDia);
					obeRequisicionesCondicionesEntregas.IdPlazoEntegra =  datard.GetInt32(posIdPlazoEntegra);
					obeRequisicionesCondicionesEntregas.PlazoEntregaCantidad =  datard.GetInt32(posPlazoEntregaCantidad);
					obeRequisicionesCondicionesEntregas.FechaLimite =  datard.GetDateTime(posFechaLimite);
					obeRequisicionesCondicionesEntregas.IdTipoEntrega =  datard.GetInt32(posIdTipoEntrega);
					obeRequisicionesCondicionesEntregas.Observaciones =  datard.GetString(posObservaciones);
					obeRequisicionesCondicionesEntregas.NotaEspecial =  datard.GetString(posNotaEspecial);
					obeRequisicionesCondicionesEntregas.IdEstatus =  datard.GetInt32(posIdEstatus);
					obeRequisicionesCondicionesEntregas.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeRequisicionesCondicionesEntregas.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					obeRequisicionesCondicionesEntregas.IdPlazoTiempo =  datard.GetInt32(posIdPlazoTiempo);
					lbeRequisicionesCondicionesEntregas.Add(obeRequisicionesCondicionesEntregas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesCondicionesEntregas;
		}
	}
	public List< beRequisicionesCondicionesEntregas> listar_RequisicionesCondicionesEntregas_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_RequisicionesCondicionesEntregas_TraerTodos_GetAll";
		List<beRequisicionesCondicionesEntregas> lbeRequisicionesCondicionesEntregas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdRequisicionCondicionEntrega = datard.GetOrdinal("IdRequisicionCondicionEntrega");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posIdTipoDia = datard.GetOrdinal("IdTipoDia");
						int posIdPlazoEntegra = datard.GetOrdinal("IdPlazoEntegra");
						int posPlazoEntregaCantidad = datard.GetOrdinal("PlazoEntregaCantidad");
						int posFechaLimite = datard.GetOrdinal("FechaLimite");
						int posIdTipoEntrega = datard.GetOrdinal("IdTipoEntrega");
						int posObservaciones = datard.GetOrdinal("Observaciones");
						int posNotaEspecial = datard.GetOrdinal("NotaEspecial");
						int posIdEstatus = datard.GetOrdinal("IdEstatus");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posIdPlazoTiempo = datard.GetOrdinal("IdPlazoTiempo");
				lbeRequisicionesCondicionesEntregas = new List<beRequisicionesCondicionesEntregas>();
				beRequisicionesCondicionesEntregas obeRequisicionesCondicionesEntregas;
				while (datard.Read())
				{
					 obeRequisicionesCondicionesEntregas = new beRequisicionesCondicionesEntregas();
					obeRequisicionesCondicionesEntregas.IdRequisicionCondicionEntrega =  datard.GetInt32(posIdRequisicionCondicionEntrega);
					obeRequisicionesCondicionesEntregas.IdRequisicion =  datard.GetInt32(posIdRequisicion);
					obeRequisicionesCondicionesEntregas.IdTipoDia =  datard.GetInt32(posIdTipoDia);
					obeRequisicionesCondicionesEntregas.IdPlazoEntegra =  datard.GetInt32(posIdPlazoEntegra);
					obeRequisicionesCondicionesEntregas.PlazoEntregaCantidad =  datard.GetInt32(posPlazoEntregaCantidad);
					obeRequisicionesCondicionesEntregas.FechaLimite =  datard.GetDateTime(posFechaLimite);
					obeRequisicionesCondicionesEntregas.IdTipoEntrega =  datard.GetInt32(posIdTipoEntrega);
					obeRequisicionesCondicionesEntregas.Observaciones =  datard.GetString(posObservaciones);
					obeRequisicionesCondicionesEntregas.NotaEspecial =  datard.GetString(posNotaEspecial);
					obeRequisicionesCondicionesEntregas.IdEstatus =  datard.GetInt32(posIdEstatus);
					obeRequisicionesCondicionesEntregas.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeRequisicionesCondicionesEntregas.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					obeRequisicionesCondicionesEntregas.IdPlazoTiempo =  datard.GetInt32(posIdPlazoTiempo);
			// debe agregar campos de la Vista
					lbeRequisicionesCondicionesEntregas.Add(obeRequisicionesCondicionesEntregas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesCondicionesEntregas;
		}
	}
        public beRequisicionesCondicionesEntregas traerRequisicionesCondicionesEntregas_x_IdRequisicion(SqlConnection Conexion, int IdRequisicion)
        {
            string sp = "Proc_RequisicionesCondicionesEntregas_x_IdRequisicion";
            beRequisicionesCondicionesEntregas obeRequisicionesCondicionesEntregas = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = IdRequisicion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdRequisicionCondicionEntrega = datard.GetOrdinal("IdRequisicionCondicionEntrega");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posIdTipoDia = datard.GetOrdinal("IdTipoDia");
                        int posIdPlazoEntegra = datard.GetOrdinal("IdPlazoEntegra");
                        int posPlazoEntregaCantidad = datard.GetOrdinal("PlazoEntregaCantidad");
                        int posFechaLimite = datard.GetOrdinal("FechaLimite");
                        int posIdTipoEntrega = datard.GetOrdinal("IdTipoEntrega");
                        int posObservaciones = datard.GetOrdinal("Observaciones");
                        int posNotaEspecial = datard.GetOrdinal("NotaEspecial");
                        int posIdEstatus = datard.GetOrdinal("IdEstatus");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posIdPlazoTiempo = datard.GetOrdinal("IdPlazoTiempo");
                        obeRequisicionesCondicionesEntregas = new beRequisicionesCondicionesEntregas();
                        while (datard.Read())
                        {
                            obeRequisicionesCondicionesEntregas.IdRequisicionCondicionEntrega = datard.GetInt32(posIdRequisicionCondicionEntrega);
                            obeRequisicionesCondicionesEntregas.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeRequisicionesCondicionesEntregas.IdTipoDia = datard.GetInt32(posIdTipoDia);
                            obeRequisicionesCondicionesEntregas.IdPlazoEntegra = datard.GetInt32(posIdPlazoEntegra);
                            obeRequisicionesCondicionesEntregas.PlazoEntregaCantidad = datard.GetInt32(posPlazoEntregaCantidad);
                            obeRequisicionesCondicionesEntregas.FechaLimite = datard.GetDateTime(posFechaLimite);
                            obeRequisicionesCondicionesEntregas.IdTipoEntrega = datard.GetInt32(posIdTipoEntrega);
                            obeRequisicionesCondicionesEntregas.Observaciones = datard.GetString(posObservaciones);
                            obeRequisicionesCondicionesEntregas.NotaEspecial = datard.GetString(posNotaEspecial);
                            obeRequisicionesCondicionesEntregas.IdEstatus = datard.GetInt32(posIdEstatus);
                            obeRequisicionesCondicionesEntregas.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeRequisicionesCondicionesEntregas.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeRequisicionesCondicionesEntregas.IdPlazoTiempo = datard.GetInt32(posIdPlazoTiempo);
                            obeRequisicionesCondicionesEntregas.IsNUll = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRequisicionesCondicionesEntregas;
            }
        }
    }
}
