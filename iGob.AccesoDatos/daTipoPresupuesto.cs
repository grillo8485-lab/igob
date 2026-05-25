using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daTipoPresupuesto
 {
	public int guardarTipoPresupuesto(SqlConnection Conexion, beTipoPresupuesto obeTipoPresupuesto)
	{
		int Id=0;
		string sp = "Proc_TipoPresupuestoInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoPresuesto", SqlDbType.Int).Value = obeTipoPresupuesto.IdTipoPresuesto;
				cmd.Parameters.Add("@TipoPresuesto", SqlDbType.VarChar).Value = obeTipoPresupuesto.TipoPresuesto;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTipoPresupuesto.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarTipoPresupuesto(SqlConnection Conexion, beTipoPresupuesto obeTipoPresupuesto)
	{
		string sp = "Proc_TipoPresupuestoActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoPresuesto", SqlDbType.Int).Value = obeTipoPresupuesto.IdTipoPresuesto;
				cmd.Parameters.Add("@TipoPresuesto", SqlDbType.VarChar).Value = obeTipoPresupuesto.TipoPresuesto;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTipoPresupuesto.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarTipoPresupuesto(SqlConnection Conexion,int pIdTipoPresuesto)
	{
		string sp = "Proc_TipoPresupuestoEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoPresuesto", SqlDbType.Int).Value = pIdTipoPresuesto;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beTipoPresupuesto traerTipoPresupuesto_x_IdTipoPresuesto(SqlConnection Conexion,int IdTipoPresuesto)
	{
		string sp = "Proc_TipoPresupuesto_x_IdTipoPresuesto";
		List<beTipoPresupuesto> lbeTipoPresupuesto = null;
				beTipoPresupuesto obeTipoPresupuesto=new beTipoPresupuesto();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoPresuesto", SqlDbType.Int).Value = IdTipoPresuesto;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeTipoPresupuesto = new List<beTipoPresupuesto>();
				while (datard.Read())
					{
					 obeTipoPresupuesto = new beTipoPresupuesto();
						obeTipoPresupuesto.IdTipoPresuesto =  datard.GetInt32(0);
						obeTipoPresupuesto.TipoPresuesto =  datard.GetString(1);
						obeTipoPresupuesto.Activo =  datard.GetBoolean(2);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTipoPresupuesto;
			}
	}
	public List< beTipoPresupuesto> listarTodos_TipoPresupuesto(SqlConnection Conexion)
	 {
		string sp = "Proc_TipoPresupuesto_Traer_Todos";
		List<beTipoPresupuesto> lbeTipoPresupuesto = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeTipoPresupuesto = new List<beTipoPresupuesto>();
				beTipoPresupuesto obeTipoPresupuesto;
				while (datard.Read())
				{
					 obeTipoPresupuesto = new beTipoPresupuesto();
					obeTipoPresupuesto.IdTipoPresuesto =  datard.GetInt32(0);
					obeTipoPresupuesto.TipoPresuesto =  datard.GetString(1);
					obeTipoPresupuesto.Activo =  datard.GetBoolean(2);
					lbeTipoPresupuesto.Add(obeTipoPresupuesto);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTipoPresupuesto;
		}
	}
	public DataTable listarTipoPresupuesto_x_(SqlConnection Conexion,int IdTipoPresuesto)
	 {
		string sp = "Proc_TipoPresupuesto_Traer_Todos";
		DataTable dtTipoPresupuesto = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoPresuesto", SqlDbType.Int).Value = IdTipoPresuesto;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtTipoPresupuesto = new DataTable();
				dtTipoPresupuesto.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtTipoPresupuesto;
		}
	}
}
}
