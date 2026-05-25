using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daFormaAbastecimiento
 {
	public int guardarFormaAbastecimiento(SqlConnection Conexion, beFormaAbastecimiento obeFormaAbastecimiento)
	{
		int Id=0;
		string sp = "Proc_FormaAbastecimientoInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdFormaAbastecimiento", SqlDbType.Int).Value = obeFormaAbastecimiento.IdFormaAbastecimiento;
				cmd.Parameters.Add("@FormaAbastecimiento", SqlDbType.VarChar).Value = obeFormaAbastecimiento.FormaAbastecimiento;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeFormaAbastecimiento.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarFormaAbastecimiento(SqlConnection Conexion, beFormaAbastecimiento obeFormaAbastecimiento)
	{
		string sp = "Proc_FormaAbastecimientoActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdFormaAbastecimiento", SqlDbType.Int).Value = obeFormaAbastecimiento.IdFormaAbastecimiento;
				cmd.Parameters.Add("@FormaAbastecimiento", SqlDbType.VarChar).Value = obeFormaAbastecimiento.FormaAbastecimiento;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeFormaAbastecimiento.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarFormaAbastecimiento(SqlConnection Conexion,int pIdFormaAbastecimiento)
	{
		string sp = "Proc_FormaAbastecimientoEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdFormaAbastecimiento", SqlDbType.Int).Value = pIdFormaAbastecimiento;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beFormaAbastecimiento traerFormaAbastecimiento_x_IdFormaAbastecimiento(SqlConnection Conexion,int IdFormaAbastecimiento)
	{
		string sp = "Proc_FormaAbastecimiento_x_IdFormaAbastecimiento";
		List<beFormaAbastecimiento> lbeFormaAbastecimiento = null;
				beFormaAbastecimiento obeFormaAbastecimiento=new beFormaAbastecimiento();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdFormaAbastecimiento", SqlDbType.Int).Value = IdFormaAbastecimiento;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeFormaAbastecimiento = new List<beFormaAbastecimiento>();
				while (datard.Read())
					{
					 obeFormaAbastecimiento = new beFormaAbastecimiento();
						obeFormaAbastecimiento.IdFormaAbastecimiento =  datard.GetInt32(0);
						obeFormaAbastecimiento.FormaAbastecimiento =  datard.GetString(1);
						obeFormaAbastecimiento.Activo =  datard.GetBoolean(2);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeFormaAbastecimiento;
			}
	}
	public List< beFormaAbastecimiento> listarTodos_FormaAbastecimiento(SqlConnection Conexion)
	 {
		string sp = "Proc_FormaAbastecimiento_Traer_Todos";
		List<beFormaAbastecimiento> lbeFormaAbastecimiento = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeFormaAbastecimiento = new List<beFormaAbastecimiento>();
				beFormaAbastecimiento obeFormaAbastecimiento;
				while (datard.Read())
				{
					 obeFormaAbastecimiento = new beFormaAbastecimiento();
					obeFormaAbastecimiento.IdFormaAbastecimiento =  datard.GetInt32(0);
					obeFormaAbastecimiento.FormaAbastecimiento =  datard.GetString(1);
					obeFormaAbastecimiento.Activo =  datard.GetBoolean(2);
					lbeFormaAbastecimiento.Add(obeFormaAbastecimiento);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeFormaAbastecimiento;
		}
	}
	public DataTable listarFormaAbastecimiento_x_(SqlConnection Conexion,int IdFormaAbastecimiento)
	 {
		string sp = "Proc_FormaAbastecimiento_Traer_Todos";
		DataTable dtFormaAbastecimiento = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdFormaAbastecimiento", SqlDbType.Int).Value = IdFormaAbastecimiento;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtFormaAbastecimiento = new DataTable();
				dtFormaAbastecimiento.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtFormaAbastecimiento;
		}
	}
}
}
