using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daModalidadesRequisiciones
 {
	public int guardarModalidadesRequisiciones(SqlConnection Conexion, beModalidadesRequisiciones obeModalidadesRequisiciones)
	{
		int Id=0;
		string sp = "Proc_ModalidadesRequisicionesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdModalidadRequisicion", SqlDbType.Int).Value = obeModalidadesRequisiciones.IdModalidadRequisicion;
				cmd.Parameters.Add("@ModalidadRequisicion", SqlDbType.NVarChar).Value = obeModalidadesRequisiciones.ModalidadRequisicion;
				cmd.Parameters.Add("@Abreviatura", SqlDbType.NChar).Value = obeModalidadesRequisiciones.Abreviatura;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeModalidadesRequisiciones.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarModalidadesRequisiciones(SqlConnection Conexion, beModalidadesRequisiciones obeModalidadesRequisiciones)
	{
		string sp = "Proc_ModalidadesRequisicionesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdModalidadRequisicion", SqlDbType.Int).Value = obeModalidadesRequisiciones.IdModalidadRequisicion;
				cmd.Parameters.Add("@ModalidadRequisicion", SqlDbType.NVarChar).Value = obeModalidadesRequisiciones.ModalidadRequisicion;
				cmd.Parameters.Add("@Abreviatura", SqlDbType.NChar).Value = obeModalidadesRequisiciones.Abreviatura;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeModalidadesRequisiciones.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarModalidadesRequisiciones(SqlConnection Conexion,int pIdModalidadRequisicion)
	{
		string sp = "Proc_ModalidadesRequisicionesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdModalidadRequisicion", SqlDbType.Int).Value = pIdModalidadRequisicion;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beModalidadesRequisiciones traerModalidadesRequisiciones_x_IdModalidadRequisicion(SqlConnection Conexion,int IdModalidadRequisicion)
	{
		string sp = "Proc_ModalidadesRequisiciones_x_IdModalidadRequisicion";
		List<beModalidadesRequisiciones> lbeModalidadesRequisiciones = null;
				beModalidadesRequisiciones obeModalidadesRequisiciones=new beModalidadesRequisiciones();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdModalidadRequisicion", SqlDbType.Int).Value = IdModalidadRequisicion;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeModalidadesRequisiciones = new List<beModalidadesRequisiciones>();
				while (datard.Read())
					{
					 obeModalidadesRequisiciones = new beModalidadesRequisiciones();
						obeModalidadesRequisiciones.IdModalidadRequisicion =  datard.GetInt32(0);
						obeModalidadesRequisiciones.ModalidadRequisicion =  datard.GetString(1);
						obeModalidadesRequisiciones.Abreviatura =  datard.GetString(2);
						obeModalidadesRequisiciones.Activo =  datard.GetBoolean(3);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeModalidadesRequisiciones;
			}
	}
	public List< beModalidadesRequisiciones> listarTodos_ModalidadesRequisiciones(SqlConnection Conexion)
	 {
		string sp = "Proc_ModalidadesRequisiciones_Traer_Todos";
		List<beModalidadesRequisiciones> lbeModalidadesRequisiciones = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeModalidadesRequisiciones = new List<beModalidadesRequisiciones>();
				beModalidadesRequisiciones obeModalidadesRequisiciones;
				while (datard.Read())
				{
					 obeModalidadesRequisiciones = new beModalidadesRequisiciones();
					obeModalidadesRequisiciones.IdModalidadRequisicion =  datard.GetInt32(0);
					obeModalidadesRequisiciones.ModalidadRequisicion =  datard.GetString(1);
					obeModalidadesRequisiciones.Abreviatura =  datard.GetString(2);
					obeModalidadesRequisiciones.Activo =  datard.GetBoolean(3);
					lbeModalidadesRequisiciones.Add(obeModalidadesRequisiciones);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeModalidadesRequisiciones;
		}
	}
	public DataTable listarModalidadesRequisiciones_x_(SqlConnection Conexion,int IdModalidadRequisicion)
	 {
		string sp = "Proc_ModalidadesRequisiciones_Traer_Todos";
		DataTable dtModalidadesRequisiciones = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdModalidadRequisicion", SqlDbType.Int).Value = IdModalidadRequisicion;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtModalidadesRequisiciones = new DataTable();
				dtModalidadesRequisiciones.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtModalidadesRequisiciones;
		}
	}
}
}
