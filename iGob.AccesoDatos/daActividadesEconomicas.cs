using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daActividadesEconomicas
 {
	public int guardarActividadesEconomicas(SqlConnection Conexion, beActividadesEconomicas obeActividadesEconomicas)
	{
		int Id=0;
		string sp = "Proc_ActividadesEconomicasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdActividadEconomica", SqlDbType.Int).Value = obeActividadesEconomicas.IdActividadEconomica;
				cmd.Parameters.Add("@Codigo", SqlDbType.Int).Value = obeActividadesEconomicas.Codigo;
				cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = obeActividadesEconomicas.Descripcion;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeActividadesEconomicas.Activo;
			
				Id =(int)cmd.ExecuteScalar();

                }
                catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarActividadesEconomicas(SqlConnection Conexion, beActividadesEconomicas obeActividadesEconomicas)
	{
		string sp = "Proc_ActividadesEconomicasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdActividadEconomica", SqlDbType.Int).Value = obeActividadesEconomicas.IdActividadEconomica;
				cmd.Parameters.Add("@Codigo", SqlDbType.Int).Value = obeActividadesEconomicas.Codigo;
				cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = obeActividadesEconomicas.Descripcion;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeActividadesEconomicas.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarActividadesEconomicas(SqlConnection Conexion,int pIdActividadEconomica)
	{
		string sp = "Proc_ActividadesEconomicasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdActividadEconomica", SqlDbType.Int).Value = pIdActividadEconomica;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beActividadesEconomicas traerActividadesEconomicas_x_IdActividadEconomica(SqlConnection Conexion,int IdActividadEconomica)
	{
		string sp = "Proc_ActividadesEconomicas_x_IdActividadEconomica";
		List<beActividadesEconomicas> lbeActividadesEconomicas = null;
				beActividadesEconomicas obeActividadesEconomicas=new beActividadesEconomicas();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdActividadEconomica", SqlDbType.Int).Value = IdActividadEconomica;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeActividadesEconomicas = new List<beActividadesEconomicas>();
				while (datard.Read())
					{
					 obeActividadesEconomicas = new beActividadesEconomicas();
						obeActividadesEconomicas.IdActividadEconomica =  datard.GetInt32(0);
						obeActividadesEconomicas.Codigo =  datard.GetInt32(1);
						obeActividadesEconomicas.Descripcion =  datard.GetString(2);
						obeActividadesEconomicas.Activo =  datard.GetBoolean(3);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeActividadesEconomicas;
			}
	}
	public List< beActividadesEconomicas> listarTodos_ActividadesEconomicas(SqlConnection Conexion)
	 {
		string sp = "Proc_ActividadesEconomicas_Traer_Todos";
		List<beActividadesEconomicas> lbeActividadesEconomicas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeActividadesEconomicas = new List<beActividadesEconomicas>();
				beActividadesEconomicas obeActividadesEconomicas;
				while (datard.Read())
				{
					 obeActividadesEconomicas = new beActividadesEconomicas();
					obeActividadesEconomicas.IdActividadEconomica =  datard.GetInt32(0);
					obeActividadesEconomicas.Codigo =  datard.GetInt32(1);
					obeActividadesEconomicas.Descripcion =  datard.GetString(2);
					obeActividadesEconomicas.Activo =  datard.GetBoolean(3);
					lbeActividadesEconomicas.Add(obeActividadesEconomicas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeActividadesEconomicas;
		}
	}
	public DataTable listarActividadesEconomicas_x_(SqlConnection Conexion,int IdActividadEconomica)
	 {
		string sp = "Proc_ActividadesEconomicas_Traer_Todos";
		DataTable dtActividadesEconomicas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdActividadEconomica", SqlDbType.Int).Value = IdActividadEconomica;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtActividadesEconomicas = new DataTable();
				dtActividadesEconomicas.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtActividadesEconomicas;
		}
	}
}
}
