using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daMarcas
 {
	public int guardarMarcas(SqlConnection Conexion, beMarcas obeMarcas)
	{
		int Id=0;
		string sp = "Proc_MarcasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdMarca", SqlDbType.Int).Value = obeMarcas.IdMarca;
				cmd.Parameters.Add("@Marca", SqlDbType.NVarChar).Value = obeMarcas.Marca;
				cmd.Parameters.Add("@Abreviatura", SqlDbType.NChar).Value = obeMarcas.Abreviatura;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeMarcas.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarMarcas(SqlConnection Conexion, beMarcas obeMarcas)
	{
		string sp = "Proc_MarcasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdMarca", SqlDbType.Int).Value = obeMarcas.IdMarca;
				cmd.Parameters.Add("@Marca", SqlDbType.NVarChar).Value = obeMarcas.Marca;
				cmd.Parameters.Add("@Abreviatura", SqlDbType.NChar).Value = obeMarcas.Abreviatura;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeMarcas.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarMarcas(SqlConnection Conexion,int pIdMarca)
	{
		string sp = "Proc_MarcasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdMarca", SqlDbType.Int).Value = pIdMarca;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beMarcas traerMarcas_x_IdMarca(SqlConnection Conexion,int IdMarca)
	{
		string sp = "Proc_Marcas_x_IdMarca";
		List<beMarcas> lbeMarcas = null;
				beMarcas obeMarcas=new beMarcas();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdMarca", SqlDbType.Int).Value = IdMarca;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeMarcas = new List<beMarcas>();
				while (datard.Read())
					{
					 obeMarcas = new beMarcas();
						obeMarcas.IdMarca =  datard.GetInt32(0);
						obeMarcas.Marca =  datard.GetString(1);
						obeMarcas.Abreviatura =  datard.GetString(2);
						obeMarcas.Activo =  datard.GetBoolean(3);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeMarcas;
			}
	}
	public List< beMarcas> listarTodos_Marcas(SqlConnection Conexion)
	 {
		string sp = "Proc_Marcas_Traer_Todos";
		List<beMarcas> lbeMarcas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeMarcas = new List<beMarcas>();
				beMarcas obeMarcas;
				while (datard.Read())
				{
					 obeMarcas = new beMarcas();
					obeMarcas.IdMarca =  datard.GetInt32(0);
					obeMarcas.Marca =  datard.GetString(1);
					obeMarcas.Abreviatura =  datard.GetString(2);
					obeMarcas.Activo =  datard.GetBoolean(3);
					lbeMarcas.Add(obeMarcas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeMarcas;
		}
	}
	public DataTable listarMarcas_x_(SqlConnection Conexion,int IdMarca)
	 {
		string sp = "Proc_Marcas_Traer_Todos";
		DataTable dtMarcas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdMarca", SqlDbType.Int).Value = IdMarca;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtMarcas = new DataTable();
				dtMarcas.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtMarcas;
		}
	}
}
}
