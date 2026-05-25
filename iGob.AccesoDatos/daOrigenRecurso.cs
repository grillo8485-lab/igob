using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daOrigenRecurso
 {
	public int guardarOrigenRecurso(SqlConnection Conexion, beOrigenRecurso obeOrigenRecurso)
	{
		int Id=0;
		string sp = "Proc_OrigenRecursoInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdOrigenRecurso", SqlDbType.Int).Value = obeOrigenRecurso.IdOrigenRecurso;
				cmd.Parameters.Add("@OrigenRecurso", SqlDbType.VarChar).Value = obeOrigenRecurso.OrigenRecurso;
				cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = obeOrigenRecurso.Descripcion;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeOrigenRecurso.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarOrigenRecurso(SqlConnection Conexion, beOrigenRecurso obeOrigenRecurso)
	{
		string sp = "Proc_OrigenRecursoActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdOrigenRecurso", SqlDbType.Int).Value = obeOrigenRecurso.IdOrigenRecurso;
				cmd.Parameters.Add("@OrigenRecurso", SqlDbType.VarChar).Value = obeOrigenRecurso.OrigenRecurso;
				cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = obeOrigenRecurso.Descripcion;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit ).Value = obeOrigenRecurso.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarOrigenRecurso(SqlConnection Conexion,int pIdOrigenRecurso)
	{
		string sp = "Proc_OrigenRecursoEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdOrigenRecurso", SqlDbType.Int).Value = pIdOrigenRecurso;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beOrigenRecurso traerOrigenRecurso_x_IdOrigenRecurso(SqlConnection Conexion,int IdOrigenRecurso)
	{
		string sp = "Proc_OrigenRecurso_x_IdOrigenRecurso";
		List<beOrigenRecurso> lbeOrigenRecurso = null;
				beOrigenRecurso obeOrigenRecurso=new beOrigenRecurso();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdOrigenRecurso", SqlDbType.Int).Value = IdOrigenRecurso;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeOrigenRecurso = new List<beOrigenRecurso>();
				while (datard.Read())
					{
					 obeOrigenRecurso = new beOrigenRecurso();
						obeOrigenRecurso.IdOrigenRecurso =  datard.GetInt32(0);
						obeOrigenRecurso.OrigenRecurso =  datard.GetString(1);
						obeOrigenRecurso.Descripcion =  datard.GetString(2);
						obeOrigenRecurso.Activo =  datard.GetBoolean(3);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeOrigenRecurso;
			}
	}
	public List< beOrigenRecurso> listarTodos_OrigenRecurso(SqlConnection Conexion)
	 {
		string sp = "Proc_OrigenRecurso_Traer_Todos";
		List<beOrigenRecurso> lbeOrigenRecurso = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeOrigenRecurso = new List<beOrigenRecurso>();
				beOrigenRecurso obeOrigenRecurso;
				while (datard.Read())
				{
					 obeOrigenRecurso = new beOrigenRecurso();
					obeOrigenRecurso.IdOrigenRecurso =  datard.GetInt32(0);
					obeOrigenRecurso.OrigenRecurso =  datard.GetString(1);
					obeOrigenRecurso.Descripcion =  datard.GetString(2);
					obeOrigenRecurso.Activo =  datard.GetBoolean(3);
					lbeOrigenRecurso.Add(obeOrigenRecurso);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeOrigenRecurso;
		}
	}
	public DataTable listarOrigenRecurso_x_(SqlConnection Conexion,int IdOrigenRecurso)
	 {
		string sp = "Proc_OrigenRecurso_Traer_Todos";
		DataTable dtOrigenRecurso = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdOrigenRecurso", SqlDbType.Int).Value = IdOrigenRecurso;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtOrigenRecurso = new DataTable();
				dtOrigenRecurso.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtOrigenRecurso;
		}
	}
}
}
