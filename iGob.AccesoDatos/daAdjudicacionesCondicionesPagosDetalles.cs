using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daAdjudicacionesCondicionesPagosDetalles
 {
	public int guardarAdjudicacionesCondicionesPagosDetalles(SqlConnection Conexion, beAdjudicacionesCondicionesPagosDetalles obeAdjudicacionesCondicionesPagosDetalles)
	{
		int Id=0;
		string sp = "Proc_AdjudicacionesCondicionesPagosDetallesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdCondicionPagoDetalle", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagosDetalles.IdAdCondicionPagoDetalle;
				cmd.Parameters.Add("@IdAdjudicacionCondicionPago", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagosDetalles.IdAdjudicacionCondicionPago;
				cmd.Parameters.Add("@FechaPago", SqlDbType.DateTime).Value = obeAdjudicacionesCondicionesPagosDetalles.FechaPago;
				cmd.Parameters.Add("@PorcentajePago", SqlDbType.Decimal).Value = obeAdjudicacionesCondicionesPagosDetalles.PorcentajePago;
				cmd.Parameters.Add("@NumeroPago", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagosDetalles.NumeroPago;
				cmd.Parameters.Add("@ImportePago", SqlDbType.Decimal).Value = obeAdjudicacionesCondicionesPagosDetalles.ImportePago;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarAdjudicacionesCondicionesPagosDetalles(SqlConnection Conexion, beAdjudicacionesCondicionesPagosDetalles obeAdjudicacionesCondicionesPagosDetalles)
	{
		string sp = "Proc_AdjudicacionesCondicionesPagosDetallesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdCondicionPagoDetalle", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagosDetalles.IdAdCondicionPagoDetalle;
				cmd.Parameters.Add("@IdAdjudicacionCondicionPago", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagosDetalles.IdAdjudicacionCondicionPago;
				cmd.Parameters.Add("@FechaPago", SqlDbType.DateTime).Value = obeAdjudicacionesCondicionesPagosDetalles.FechaPago;
				cmd.Parameters.Add("@PorcentajePago", SqlDbType.Decimal).Value = obeAdjudicacionesCondicionesPagosDetalles.PorcentajePago;
				cmd.Parameters.Add("@NumeroPago", SqlDbType.Int).Value = obeAdjudicacionesCondicionesPagosDetalles.NumeroPago;
				cmd.Parameters.Add("@ImportePago", SqlDbType.Decimal).Value = obeAdjudicacionesCondicionesPagosDetalles.ImportePago;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarAdjudicacionesCondicionesPagosDetalles(SqlConnection Conexion,int pIdAdCondicionPagoDetalle)
	{
		string sp = "Proc_AdjudicacionesCondicionesPagosDetallesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdCondicionPagoDetalle", SqlDbType.Int).Value = pIdAdCondicionPagoDetalle;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}

        public int eliminarAdjudicacionesCondicionesPagosDetalles_x_IdAdjudicacionCondicionPago(SqlConnection Conexion, int IdAdjudicacionCondicionPago)
        {
            string sp = "Proc_AdjudicacionesCondicionesPagosDetallesEliminar_x_IdAdjudicacionCondicionPago"; 
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdAdjudicacionCondicionPago", SqlDbType.Int).Value = IdAdjudicacionCondicionPago;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

        public beAdjudicacionesCondicionesPagosDetalles traerAdjudicacionesCondicionesPagosDetalles_x_IdAdCondicionPagoDetalle(SqlConnection Conexion,int IdAdCondicionPagoDetalle)
	{
		string sp = "Proc_AdjudicacionesCondicionesPagosDetalles_x_IdAdCondicionPagoDetalle";
				beAdjudicacionesCondicionesPagosDetalles obeAdjudicacionesCondicionesPagosDetalles=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdAdCondicionPagoDetalle", SqlDbType.Int).Value = IdAdCondicionPagoDetalle;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdAdCondicionPagoDetalle = datard.GetOrdinal("IdAdCondicionPagoDetalle");
						int posIdAdjudicacionCondicionPago = datard.GetOrdinal("IdAdjudicacionCondicionPago");
						int posFechaPago = datard.GetOrdinal("FechaPago");
						int posPorcentajePago = datard.GetOrdinal("PorcentajePago");
						int posNumeroPago = datard.GetOrdinal("NumeroPago");
						int posImportePago = datard.GetOrdinal("ImportePago");
					 obeAdjudicacionesCondicionesPagosDetalles = new beAdjudicacionesCondicionesPagosDetalles();
				while (datard.Read())
					{
						obeAdjudicacionesCondicionesPagosDetalles.IdAdCondicionPagoDetalle =  datard.GetInt32(posIdAdCondicionPagoDetalle);
						obeAdjudicacionesCondicionesPagosDetalles.IdAdjudicacionCondicionPago =  datard.GetInt32(posIdAdjudicacionCondicionPago);
						obeAdjudicacionesCondicionesPagosDetalles.FechaPago =  datard.GetDateTime(posFechaPago);
						obeAdjudicacionesCondicionesPagosDetalles.PorcentajePago =  datard.GetDecimal(posPorcentajePago);
						obeAdjudicacionesCondicionesPagosDetalles.NumeroPago =  datard.GetInt32(posNumeroPago);
						obeAdjudicacionesCondicionesPagosDetalles.ImportePago =  datard.GetDecimal(posImportePago);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesCondicionesPagosDetalles;
			}
	}
	public List< beAdjudicacionesCondicionesPagosDetalles> listarTodos_AdjudicacionesCondicionesPagosDetalles(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesCondicionesPagosDetalles_Traer_Todos";
		List<beAdjudicacionesCondicionesPagosDetalles> lbeAdjudicacionesCondicionesPagosDetalles = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdCondicionPagoDetalle = datard.GetOrdinal("IdAdCondicionPagoDetalle");
						int posIdAdjudicacionCondicionPago = datard.GetOrdinal("IdAdjudicacionCondicionPago");
						int posFechaPago = datard.GetOrdinal("FechaPago");
						int posPorcentajePago = datard.GetOrdinal("PorcentajePago");
						int posNumeroPago = datard.GetOrdinal("NumeroPago");
						int posImportePago = datard.GetOrdinal("ImportePago");
				lbeAdjudicacionesCondicionesPagosDetalles = new List<beAdjudicacionesCondicionesPagosDetalles>();
				beAdjudicacionesCondicionesPagosDetalles obeAdjudicacionesCondicionesPagosDetalles;
				while (datard.Read())
				{
					 obeAdjudicacionesCondicionesPagosDetalles = new beAdjudicacionesCondicionesPagosDetalles();
					obeAdjudicacionesCondicionesPagosDetalles.IdAdCondicionPagoDetalle =  datard.GetInt32(posIdAdCondicionPagoDetalle);
					obeAdjudicacionesCondicionesPagosDetalles.IdAdjudicacionCondicionPago =  datard.GetInt32(posIdAdjudicacionCondicionPago);
					obeAdjudicacionesCondicionesPagosDetalles.FechaPago =  datard.GetDateTime(posFechaPago);
					obeAdjudicacionesCondicionesPagosDetalles.PorcentajePago =  datard.GetDecimal(posPorcentajePago);
					obeAdjudicacionesCondicionesPagosDetalles.NumeroPago =  datard.GetInt32(posNumeroPago);
					obeAdjudicacionesCondicionesPagosDetalles.ImportePago =  datard.GetDecimal(posImportePago);
					lbeAdjudicacionesCondicionesPagosDetalles.Add(obeAdjudicacionesCondicionesPagosDetalles);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesCondicionesPagosDetalles;
		}
	}
	public List< beAdjudicacionesCondicionesPagosDetalles> listar_AdjudicacionesCondicionesPagosDetalles_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesCondicionesPagosDetalles_TraerTodos_GetAll";
		List<beAdjudicacionesCondicionesPagosDetalles> lbeAdjudicacionesCondicionesPagosDetalles = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdCondicionPagoDetalle = datard.GetOrdinal("IdAdCondicionPagoDetalle");
						int posIdAdjudicacionCondicionPago = datard.GetOrdinal("IdAdjudicacionCondicionPago");
						int posFechaPago = datard.GetOrdinal("FechaPago");
						int posPorcentajePago = datard.GetOrdinal("PorcentajePago");
						int posNumeroPago = datard.GetOrdinal("NumeroPago");
						int posImportePago = datard.GetOrdinal("ImportePago");
				lbeAdjudicacionesCondicionesPagosDetalles = new List<beAdjudicacionesCondicionesPagosDetalles>();
				beAdjudicacionesCondicionesPagosDetalles obeAdjudicacionesCondicionesPagosDetalles;
				while (datard.Read())
				{
					 obeAdjudicacionesCondicionesPagosDetalles = new beAdjudicacionesCondicionesPagosDetalles();
					obeAdjudicacionesCondicionesPagosDetalles.IdAdCondicionPagoDetalle =  datard.GetInt32(posIdAdCondicionPagoDetalle);
					obeAdjudicacionesCondicionesPagosDetalles.IdAdjudicacionCondicionPago =  datard.GetInt32(posIdAdjudicacionCondicionPago);
					obeAdjudicacionesCondicionesPagosDetalles.FechaPago =  datard.GetDateTime(posFechaPago);
					obeAdjudicacionesCondicionesPagosDetalles.PorcentajePago =  datard.GetDecimal(posPorcentajePago);
					obeAdjudicacionesCondicionesPagosDetalles.NumeroPago =  datard.GetInt32(posNumeroPago);
					obeAdjudicacionesCondicionesPagosDetalles.ImportePago =  datard.GetDecimal(posImportePago);
			// debe agregar campos de la Vista
					lbeAdjudicacionesCondicionesPagosDetalles.Add(obeAdjudicacionesCondicionesPagosDetalles);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesCondicionesPagosDetalles;
		}
	}
}
}
