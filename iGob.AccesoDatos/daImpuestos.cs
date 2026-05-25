using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daImpuestos
 {
	public int guardarImpuestos(SqlConnection Conexion, beImpuestos obeImpuestos)
	{
		int Id=0;
		string sp = "Proc_ImpuestosInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdImpuesto", SqlDbType.Int).Value = obeImpuestos.IdImpuesto;
				cmd.Parameters.Add("@Clave", SqlDbType.Char).Value = obeImpuestos.Clave;
				cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = obeImpuestos.Descripcion;
				cmd.Parameters.Add("@Tasa", SqlDbType.Decimal).Value = obeImpuestos.Tasa;
				cmd.Parameters.Add("@Retencion", SqlDbType.Char).Value = obeImpuestos.Retencion;
				cmd.Parameters.Add("@Traslado", SqlDbType.Char).Value = obeImpuestos.Traslado;
				cmd.Parameters.Add("@TipoImpuesto", SqlDbType.Char).Value = obeImpuestos.TipoImpuesto;
				cmd.Parameters.Add("@Entidad", SqlDbType.Char).Value = obeImpuestos.Entidad;
				cmd.Parameters.Add("@FechaVigencia", SqlDbType.DateTime).Value = obeImpuestos.FechaVigencia;
				cmd.Parameters.Add("@Version", SqlDbType.Char).Value = obeImpuestos.Version;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarImpuestos(SqlConnection Conexion, beImpuestos obeImpuestos)
	{
		string sp = "Proc_ImpuestosActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdImpuesto", SqlDbType.Int).Value = obeImpuestos.IdImpuesto;
				cmd.Parameters.Add("@Clave", SqlDbType.Char).Value = obeImpuestos.Clave;
				cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = obeImpuestos.Descripcion;
				cmd.Parameters.Add("@Tasa", SqlDbType.Decimal).Value = obeImpuestos.Tasa;
				cmd.Parameters.Add("@Retencion", SqlDbType.Char).Value = obeImpuestos.Retencion;
				cmd.Parameters.Add("@Traslado", SqlDbType.Char).Value = obeImpuestos.Traslado;
				cmd.Parameters.Add("@TipoImpuesto", SqlDbType.Char).Value = obeImpuestos.TipoImpuesto;
				cmd.Parameters.Add("@Entidad", SqlDbType.Char).Value = obeImpuestos.Entidad;
				cmd.Parameters.Add("@FechaVigencia", SqlDbType.DateTime).Value = obeImpuestos.FechaVigencia;
				cmd.Parameters.Add("@Version", SqlDbType.Char).Value = obeImpuestos.Version;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarImpuestos(SqlConnection Conexion,int pIdImpuesto)
	{
		string sp = "Proc_ImpuestosEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdImpuesto", SqlDbType.Int).Value = pIdImpuesto;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beImpuestos traerImpuestos_x_IdImpuesto(SqlConnection Conexion,int IdImpuesto)
	{
		string sp = "Proc_Impuestos_x_IdImpuesto";
		List<beImpuestos> lbeImpuestos = null;
				beImpuestos obeImpuestos=new beImpuestos();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdImpuesto", SqlDbType.Int).Value = IdImpuesto;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeImpuestos = new List<beImpuestos>();
				while (datard.Read())
					{
					 obeImpuestos = new beImpuestos();
						obeImpuestos.IdImpuesto =  datard.GetInt32(0);
						obeImpuestos.Clave =  datard.GetString(1);
						obeImpuestos.Descripcion =  datard.GetString(2);
						obeImpuestos.Tasa =  datard.GetDecimal(3);
						obeImpuestos.Retencion =  datard.GetString(4);
						obeImpuestos.Traslado =  datard.GetString(5);
						obeImpuestos.TipoImpuesto =  datard.GetString(6);
						obeImpuestos.Entidad =  datard.GetString(7);
						obeImpuestos.FechaVigencia =  datard.GetDateTime(8);
						obeImpuestos.Version =  datard.GetString(9);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeImpuestos;
			}
	}
	public List< beImpuestos> listarTodos_Impuestos(SqlConnection Conexion)
	 {
		string sp = "Proc_Impuestos_Traer_Todos";
		List<beImpuestos> lbeImpuestos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeImpuestos = new List<beImpuestos>();
				beImpuestos obeImpuestos;
				while (datard.Read())
				{
					 obeImpuestos = new beImpuestos();
					obeImpuestos.IdImpuesto =  datard.GetInt32(0);
					obeImpuestos.Clave =  datard.GetString(1);
					obeImpuestos.Descripcion =  datard.GetString(2);
					obeImpuestos.Tasa =  datard.GetDecimal(3);
					obeImpuestos.Retencion =  datard.GetString(4);
					obeImpuestos.Traslado =  datard.GetString(5);
					obeImpuestos.TipoImpuesto =  datard.GetString(6);
					obeImpuestos.Entidad =  datard.GetString(7);
					obeImpuestos.FechaVigencia =  datard.GetDateTime(8);
					obeImpuestos.Version =  datard.GetString(9);
					lbeImpuestos.Add(obeImpuestos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeImpuestos;
		}
	}
	public DataTable listarImpuestos_x_(SqlConnection Conexion,int IdImpuesto)
	 {
		string sp = "Proc_Impuestos_Traer_Todos";
		DataTable dtImpuestos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdImpuesto", SqlDbType.Int).Value = IdImpuesto;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtImpuestos = new DataTable();
				dtImpuestos.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtImpuestos;
		}
	}
}
}
