using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daModalidades
 {
	public int guardarModalidades(SqlConnection Conexion, beModalidades obeModalidades)
	{
		int Id=0;
		string sp = "Proc_ModalidadesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdModalidad", SqlDbType.Int).Value = obeModalidades.IdModalidad;
				cmd.Parameters.Add("@Modalidad", SqlDbType.NVarChar).Value = obeModalidades.Modalidad;
				cmd.Parameters.Add("@Abreviatura", SqlDbType.NChar).Value = obeModalidades.Abreviatura;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeModalidades.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarModalidades(SqlConnection Conexion, beModalidades obeModalidades)
	{
		string sp = "Proc_ModalidadesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdModalidad", SqlDbType.Int).Value = obeModalidades.IdModalidad;
				cmd.Parameters.Add("@Modalidad", SqlDbType.NVarChar).Value = obeModalidades.Modalidad;
				cmd.Parameters.Add("@Abreviatura", SqlDbType.NChar).Value = obeModalidades.Abreviatura;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeModalidades.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarModalidades(SqlConnection Conexion,int pIdModalidad)
	{
		string sp = "Proc_ModalidadesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdModalidad", SqlDbType.Int).Value = pIdModalidad;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beModalidades traerModalidades_x_IdModalidad(SqlConnection Conexion,int IdModalidad)
	{
		string sp = "Proc_Modalidades_x_IdModalidad";
		List<beModalidades> lbeModalidades = null;
				beModalidades obeModalidades=new beModalidades();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdModalidad", SqlDbType.Int).Value = IdModalidad;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeModalidades = new List<beModalidades>();
				while (datard.Read())
					{
					 obeModalidades = new beModalidades();
						obeModalidades.IdModalidad =  datard.GetInt32(0);
						obeModalidades.Modalidad =  datard.GetString(1);
						obeModalidades.Abreviatura =  datard.GetString(2);
						obeModalidades.Activo =  datard.GetBoolean(3);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeModalidades;
			}
	}
	public List< beModalidades> listarTodos_Modalidades(SqlConnection Conexion)
	 {
		string sp = "Proc_Modalidades_Traer_Todos";
		List<beModalidades> lbeModalidades = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeModalidades = new List<beModalidades>();
				beModalidades obeModalidades;
				while (datard.Read())
				{
					 obeModalidades = new beModalidades();
					obeModalidades.IdModalidad =  datard.GetInt32(0);
					obeModalidades.Modalidad =  datard.GetString(1);
					obeModalidades.Abreviatura =  datard.GetString(2);
					obeModalidades.Activo =  datard.GetBoolean(3);
					lbeModalidades.Add(obeModalidades);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeModalidades;
		}
	}
	public DataTable listarModalidades_x_(SqlConnection Conexion,int IdModalidad)
	 {
		string sp = "Proc_Modalidades_Traer_Todos";
		DataTable dtModalidades = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdModalidad", SqlDbType.Int).Value = IdModalidad;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtModalidades = new DataTable();
				dtModalidades.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtModalidades;
		}
	}
}
}
