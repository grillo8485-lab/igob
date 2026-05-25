using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daFormasPago
 {
	public int guardarFormasPago(SqlConnection Conexion, beFormasPago obeFormasPago)
	{
		int Id=0;
		string sp = "Proc_FormasPagoInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdFormaPago", SqlDbType.Int).Value = obeFormasPago.IdFormaPago;
				cmd.Parameters.Add("@Clave", SqlDbType.Char).Value = obeFormasPago.Clave;
				cmd.Parameters.Add("@FormaPago", SqlDbType.VarChar).Value = obeFormasPago.FormaPago;
				cmd.Parameters.Add("@Bancarizado", SqlDbType.Char).Value = obeFormasPago.Bancarizado;
				cmd.Parameters.Add("@Fechainiciovigencia",SqlDbType.DateTime ).Value = obeFormasPago.Fechainiciovigencia;
				cmd.Parameters.Add("@Version", SqlDbType.Char).Value = obeFormasPago.Version;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeFormasPago.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarFormasPago(SqlConnection Conexion, beFormasPago obeFormasPago)
	{
		string sp = "Proc_FormasPagoActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdFormaPago", SqlDbType.Int).Value = obeFormasPago.IdFormaPago;
				cmd.Parameters.Add("@Clave", SqlDbType.Char).Value = obeFormasPago.Clave;
				cmd.Parameters.Add("@FormaPago", SqlDbType.VarChar).Value = obeFormasPago.FormaPago;
				cmd.Parameters.Add("@Bancarizado", SqlDbType.Char).Value = obeFormasPago.Bancarizado;
				cmd.Parameters.Add("@Fechainiciovigencia", SqlDbType.DateTime).Value = obeFormasPago.Fechainiciovigencia;
				cmd.Parameters.Add("@Version", SqlDbType.Char).Value = obeFormasPago.Version;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeFormasPago.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarFormasPago(SqlConnection Conexion,int pIdFormaPago)
	{
		string sp = "Proc_FormasPagoEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdFormaPago", SqlDbType.Int).Value = pIdFormaPago;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beFormasPago traerFormasPago_x_IdFormaPago(SqlConnection Conexion,int IdFormaPago)
	{
		string sp = "Proc_FormasPago_x_IdFormaPago";
		List<beFormasPago> lbeFormasPago = null;
				beFormasPago obeFormasPago=new beFormasPago();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdFormaPago", SqlDbType.Int).Value = IdFormaPago;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeFormasPago = new List<beFormasPago>();
				while (datard.Read())
					{
					 obeFormasPago = new beFormasPago();
						obeFormasPago.IdFormaPago =  datard.GetInt32(0);
						obeFormasPago.Clave =  datard.GetString(1);
						obeFormasPago.FormaPago =  datard.GetString(2);
						obeFormasPago.Bancarizado =  datard.GetString(3);
						obeFormasPago.Fechainiciovigencia =  datard.GetDateTime(4);
						obeFormasPago.Version =  datard.GetString(5);
						obeFormasPago.Activo =  datard.GetBoolean(6);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeFormasPago;
			}
	}
	public List< beFormasPago> listarTodos_FormasPago(SqlConnection Conexion)
	 {
		string sp = "Proc_FormasPago_Traer_Todos";
		List<beFormasPago> lbeFormasPago = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeFormasPago = new List<beFormasPago>();
				beFormasPago obeFormasPago;
				while (datard.Read())
				{
					 obeFormasPago = new beFormasPago();
					obeFormasPago.IdFormaPago =  datard.GetInt32(0);
					obeFormasPago.Clave =  datard.GetString(1);
					obeFormasPago.FormaPago =  datard.GetString(2);
					obeFormasPago.Bancarizado =  datard.GetString(3);
					obeFormasPago.Fechainiciovigencia =  datard.GetDateTime(4);
					obeFormasPago.Version =  datard.GetString(5);
					obeFormasPago.Activo =  datard.GetBoolean(6);
					lbeFormasPago.Add(obeFormasPago);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeFormasPago;
		}
	}
	public DataTable listarFormasPago_x_(SqlConnection Conexion,int IdFormaPago)
	 {
		string sp = "Proc_FormasPago_Traer_Todos";
		DataTable dtFormasPago = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdFormaPago", SqlDbType.Int).Value = IdFormaPago;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtFormasPago = new DataTable();
				dtFormasPago.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtFormasPago;
		}
	}
}
}
