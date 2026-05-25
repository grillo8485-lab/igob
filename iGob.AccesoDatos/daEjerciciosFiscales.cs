using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daEjerciciosFiscales
 {
	public int guardarEjerciciosFiscales(SqlConnection Conexion, beEjerciciosFiscales obeEjerciciosFiscales)
	{
		int Id=0;
		string sp = "Proc_EjerciciosFiscalesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdEjercicioFiscal", SqlDbType.Int).Value = obeEjerciciosFiscales.IdEjercicioFiscal;
				cmd.Parameters.Add("@Ejercicio", SqlDbType.Int).Value = obeEjerciciosFiscales.Ejercicio;
				cmd.Parameters.Add("@FechaInicial", SqlDbType.DateTime).Value = obeEjerciciosFiscales.FechaInicial;
				cmd.Parameters.Add("@FechaFinal", SqlDbType.DateTime).Value = obeEjerciciosFiscales.FechaFinal;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeEjerciciosFiscales.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarEjerciciosFiscales(SqlConnection Conexion, beEjerciciosFiscales obeEjerciciosFiscales)
	{
		string sp = "Proc_EjerciciosFiscalesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdEjercicioFiscal", SqlDbType.Int).Value = obeEjerciciosFiscales.IdEjercicioFiscal;
				cmd.Parameters.Add("@Ejercicio", SqlDbType.Int).Value = obeEjerciciosFiscales.Ejercicio;
				cmd.Parameters.Add("@FechaInicial", SqlDbType.DateTime).Value = obeEjerciciosFiscales.FechaInicial;
				cmd.Parameters.Add("@FechaFinal", SqlDbType.DateTime).Value = obeEjerciciosFiscales.FechaFinal;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeEjerciciosFiscales.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarEjerciciosFiscales(SqlConnection Conexion,int pIdEjercicioFiscal)
	{
		string sp = "Proc_EjerciciosFiscalesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdEjercicioFiscal", SqlDbType.Int).Value = pIdEjercicioFiscal;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beEjerciciosFiscales traerEjerciciosFiscales_x_IdEjercicioFiscal(SqlConnection Conexion,int IdEjercicioFiscal)
	{
		string sp = "Proc_EjerciciosFiscales_x_IdEjercicioFiscal";
		List<beEjerciciosFiscales> lbeEjerciciosFiscales = null;
				beEjerciciosFiscales obeEjerciciosFiscales=new beEjerciciosFiscales();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdEjercicioFiscal", SqlDbType.Int).Value = IdEjercicioFiscal;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeEjerciciosFiscales = new List<beEjerciciosFiscales>();
				while (datard.Read())
					{
					 obeEjerciciosFiscales = new beEjerciciosFiscales();
						obeEjerciciosFiscales.IdEjercicioFiscal =  datard.GetInt32(0);
						obeEjerciciosFiscales.Ejercicio =  datard.GetInt32(1);
						obeEjerciciosFiscales.FechaInicial =  datard.GetDateTime(2);
						obeEjerciciosFiscales.FechaFinal =  datard.GetDateTime(3);
						obeEjerciciosFiscales.Activo =  datard.GetBoolean(4);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeEjerciciosFiscales;
			}
	}
	public List< beEjerciciosFiscales> listarTodos_EjerciciosFiscales(SqlConnection Conexion)
	 {
		string sp = "Proc_EjerciciosFiscales_Traer_Todos";
		List<beEjerciciosFiscales> lbeEjerciciosFiscales = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeEjerciciosFiscales = new List<beEjerciciosFiscales>();
				beEjerciciosFiscales obeEjerciciosFiscales;
				while (datard.Read())
				{
					 obeEjerciciosFiscales = new beEjerciciosFiscales();
					obeEjerciciosFiscales.IdEjercicioFiscal =  datard.GetInt32(0);
					obeEjerciciosFiscales.Ejercicio =  datard.GetInt32(1);
					obeEjerciciosFiscales.FechaInicial =  datard.GetDateTime(2);
					obeEjerciciosFiscales.FechaFinal =  datard.GetDateTime(3);
					obeEjerciciosFiscales.Activo =  datard.GetBoolean(4);
					lbeEjerciciosFiscales.Add(obeEjerciciosFiscales);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEjerciciosFiscales;
		}
	}
	public DataTable listarEjerciciosFiscales_x_(SqlConnection Conexion,int IdEjercicioFiscal)
	 {
		string sp = "Proc_EjerciciosFiscales_Traer_Todos";
		DataTable dtEjerciciosFiscales = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdEjercicioFiscal", SqlDbType.Int).Value = IdEjercicioFiscal;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtEjerciciosFiscales = new DataTable();
				dtEjerciciosFiscales.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtEjerciciosFiscales;
		}
	}
}
}
