using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daRequisicionesCondicionesPagosDetalles
 {
	public int guardarRequisicionesCondicionesPagosDetalles(SqlConnection Conexion, beRequisicionesCondicionesPagosDetalles obeRequisicionesCondicionesPagosDetalles)
	{
		int Id=0;
		string sp = "Proc_RequisicionesCondicionesPagosDetallesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdRqCondicionPagoDetalle", SqlDbType.Int).Value = obeRequisicionesCondicionesPagosDetalles.IdRqCondicionPagoDetalle;
				cmd.Parameters.Add("@IdRequiscionCondicionPago", SqlDbType.Int).Value = obeRequisicionesCondicionesPagosDetalles.IdRequiscionCondicionPago;
				cmd.Parameters.Add("@FechaPago", SqlDbType.DateTime).Value = obeRequisicionesCondicionesPagosDetalles.FechaPago;
				cmd.Parameters.Add("@PorcentajePago", SqlDbType.Decimal).Value = obeRequisicionesCondicionesPagosDetalles.PorcentajePago;
				cmd.Parameters.Add("@NumeroPago", SqlDbType.Int).Value = obeRequisicionesCondicionesPagosDetalles.NumeroPago;
				cmd.Parameters.Add("@ImportePago", SqlDbType.Decimal).Value = obeRequisicionesCondicionesPagosDetalles.ImportePago;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarRequisicionesCondicionesPagosDetalles(SqlConnection Conexion, beRequisicionesCondicionesPagosDetalles obeRequisicionesCondicionesPagosDetalles)
	{
		string sp = "Proc_RequisicionesCondicionesPagosDetallesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdRqCondicionPagoDetalle", SqlDbType.Int).Value = obeRequisicionesCondicionesPagosDetalles.IdRqCondicionPagoDetalle;
				cmd.Parameters.Add("@IdRequiscionCondicionPago", SqlDbType.Int).Value = obeRequisicionesCondicionesPagosDetalles.IdRequiscionCondicionPago;
				cmd.Parameters.Add("@FechaPago", SqlDbType.DateTime).Value = obeRequisicionesCondicionesPagosDetalles.FechaPago;
				cmd.Parameters.Add("@PorcentajePago", SqlDbType.Decimal).Value = obeRequisicionesCondicionesPagosDetalles.PorcentajePago;
				cmd.Parameters.Add("@NumeroPago", SqlDbType.Int).Value = obeRequisicionesCondicionesPagosDetalles.NumeroPago;
				cmd.Parameters.Add("@ImportePago", SqlDbType.Decimal).Value = obeRequisicionesCondicionesPagosDetalles.ImportePago;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarRequisicionesCondicionesPagosDetalles(SqlConnection Conexion,int IdRequiscionCondicionPago)
	{
		string sp = "Proc_RequisicionesCondicionesPagosDetallesEliminar_x_IdRequiscionCondicionPago";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdRequiscionCondicionPago", SqlDbType.Int).Value = IdRequiscionCondicionPago;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
        public int eliminarRequisicionesCondicionesPagosDetalles_x_IdRequiscionCondicionPago(SqlConnection Conexion, int IdRequiscionCondicionPago)
        {
            string sp = "Proc_RequisicionesCondicionesPagosDetallesEliminar_x_IdRequiscionCondicionPago";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdRequiscionCondicionPago", SqlDbType.Int).Value = IdRequiscionCondicionPago;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }


        
    public beRequisicionesCondicionesPagosDetalles traerRequisicionesCondicionesPagosDetalles_x_IdRqCondicionPagoDetalle(SqlConnection Conexion,int IdRqCondicionPagoDetalle)
	{
		string sp = "Proc_RequisicionesCondicionesPagosDetalles_x_IdRqCondicionPagoDetalle";
				beRequisicionesCondicionesPagosDetalles obeRequisicionesCondicionesPagosDetalles=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdRqCondicionPagoDetalle", SqlDbType.Int).Value = IdRqCondicionPagoDetalle;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdRqCondicionPagoDetalle = datard.GetOrdinal("IdRqCondicionPagoDetalle");
						int posIdRequiscionCondicionPago = datard.GetOrdinal("IdRequiscionCondicionPago");
						int posFechaPago = datard.GetOrdinal("FechaPago");
						int posPorcentajePago = datard.GetOrdinal("PorcentajePago");
						int posNumeroPago = datard.GetOrdinal("NumeroPago");
						int posImportePago = datard.GetOrdinal("ImportePago");
					 obeRequisicionesCondicionesPagosDetalles = new beRequisicionesCondicionesPagosDetalles();
				while (datard.Read())
					{
						obeRequisicionesCondicionesPagosDetalles.IdRqCondicionPagoDetalle =  datard.GetInt32(posIdRqCondicionPagoDetalle);
						obeRequisicionesCondicionesPagosDetalles.IdRequiscionCondicionPago =  datard.GetInt32(posIdRequiscionCondicionPago);
						obeRequisicionesCondicionesPagosDetalles.FechaPago =  datard.GetDateTime(posFechaPago);
						obeRequisicionesCondicionesPagosDetalles.PorcentajePago =  datard.GetDecimal(posPorcentajePago);
						obeRequisicionesCondicionesPagosDetalles.NumeroPago =  datard.GetInt32(posNumeroPago);
						obeRequisicionesCondicionesPagosDetalles.ImportePago =  datard.GetDecimal(posImportePago);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeRequisicionesCondicionesPagosDetalles;
			}
	}
	public List< beRequisicionesCondicionesPagosDetalles> listarTodos_RequisicionesCondicionesPagosDetalles(SqlConnection Conexion)
	 {
		string sp = "Proc_RequisicionesCondicionesPagosDetalles_Traer_Todos";
		List<beRequisicionesCondicionesPagosDetalles> lbeRequisicionesCondicionesPagosDetalles = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdRqCondicionPagoDetalle = datard.GetOrdinal("IdRqCondicionPagoDetalle");
						int posIdRequiscionCondicionPago = datard.GetOrdinal("IdRequiscionCondicionPago");
						int posFechaPago = datard.GetOrdinal("FechaPago");
						int posPorcentajePago = datard.GetOrdinal("PorcentajePago");
						int posNumeroPago = datard.GetOrdinal("NumeroPago");
						int posImportePago = datard.GetOrdinal("ImportePago");
				lbeRequisicionesCondicionesPagosDetalles = new List<beRequisicionesCondicionesPagosDetalles>();
				beRequisicionesCondicionesPagosDetalles obeRequisicionesCondicionesPagosDetalles;
				while (datard.Read())
				{
					 obeRequisicionesCondicionesPagosDetalles = new beRequisicionesCondicionesPagosDetalles();
					obeRequisicionesCondicionesPagosDetalles.IdRqCondicionPagoDetalle =  datard.GetInt32(posIdRqCondicionPagoDetalle);
					obeRequisicionesCondicionesPagosDetalles.IdRequiscionCondicionPago =  datard.GetInt32(posIdRequiscionCondicionPago);
					obeRequisicionesCondicionesPagosDetalles.FechaPago =  datard.GetDateTime(posFechaPago);
					obeRequisicionesCondicionesPagosDetalles.PorcentajePago =  datard.GetDecimal(posPorcentajePago);
					obeRequisicionesCondicionesPagosDetalles.NumeroPago =  datard.GetInt32(posNumeroPago);
					obeRequisicionesCondicionesPagosDetalles.ImportePago =  datard.GetDecimal(posImportePago);
					lbeRequisicionesCondicionesPagosDetalles.Add(obeRequisicionesCondicionesPagosDetalles);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesCondicionesPagosDetalles;
		}
	}
	public List< beRequisicionesCondicionesPagosDetalles> listar_RequisicionesCondicionesPagosDetalles_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_RequisicionesCondicionesPagosDetalles_TraerTodos_GetAll";
		List<beRequisicionesCondicionesPagosDetalles> lbeRequisicionesCondicionesPagosDetalles = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdRqCondicionPagoDetalle = datard.GetOrdinal("IdRqCondicionPagoDetalle");
						int posIdRequiscionCondicionPago = datard.GetOrdinal("IdRequiscionCondicionPago");
						int posFechaPago = datard.GetOrdinal("FechaPago");
						int posPorcentajePago = datard.GetOrdinal("PorcentajePago");
						int posNumeroPago = datard.GetOrdinal("NumeroPago");
						int posImportePago = datard.GetOrdinal("ImportePago");
				lbeRequisicionesCondicionesPagosDetalles = new List<beRequisicionesCondicionesPagosDetalles>();
				beRequisicionesCondicionesPagosDetalles obeRequisicionesCondicionesPagosDetalles;
				while (datard.Read())
				{
					 obeRequisicionesCondicionesPagosDetalles = new beRequisicionesCondicionesPagosDetalles();
					obeRequisicionesCondicionesPagosDetalles.IdRqCondicionPagoDetalle =  datard.GetInt32(posIdRqCondicionPagoDetalle);
					obeRequisicionesCondicionesPagosDetalles.IdRequiscionCondicionPago =  datard.GetInt32(posIdRequiscionCondicionPago);
					obeRequisicionesCondicionesPagosDetalles.FechaPago =  datard.GetDateTime(posFechaPago);
					obeRequisicionesCondicionesPagosDetalles.PorcentajePago =  datard.GetDecimal(posPorcentajePago);
					obeRequisicionesCondicionesPagosDetalles.NumeroPago =  datard.GetInt32(posNumeroPago);
					obeRequisicionesCondicionesPagosDetalles.ImportePago =  datard.GetDecimal(posImportePago);
			// debe agregar campos de la Vista
					lbeRequisicionesCondicionesPagosDetalles.Add(obeRequisicionesCondicionesPagosDetalles);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRequisicionesCondicionesPagosDetalles;
		}
	}
}
}
