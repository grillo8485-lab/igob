using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using System.Globalization;

namespace iGob.AccesoDatos
{
public class daSysModulos
 {
	public int guardarSysModulos(SqlConnection Conexion, beSysModulos obeSysModulos)
	{
		int Id=0;
		string sp = "SysProc_SysModulosInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdModulo", SqlDbType.Int).Value = obeSysModulos.IdModulo;
				cmd.Parameters.Add("@Modulo", SqlDbType.VarChar).Value = obeSysModulos.Modulo;
				cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = obeSysModulos.Descripcion;
				cmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = obeSysModulos.Clave;
				cmd.Parameters.Add("@Orden", SqlDbType.TinyInt).Value = obeSysModulos.Orden;
				cmd.Parameters.Add("@Icono", SqlDbType.VarChar).Value = obeSysModulos.Icono;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeSysModulos.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarSysModulos(SqlConnection Conexion, beSysModulos obeSysModulos)
	{
		string sp = "SysProc_SysModulosActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdModulo", SqlDbType.Int).Value = obeSysModulos.IdModulo;
				cmd.Parameters.Add("@Modulo", SqlDbType.VarChar).Value = obeSysModulos.Modulo;
				cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = obeSysModulos.Descripcion;
				cmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = obeSysModulos.Clave;
				cmd.Parameters.Add("@Orden", SqlDbType.TinyInt).Value = obeSysModulos.Orden;
				cmd.Parameters.Add("@Icono", SqlDbType.VarChar).Value = obeSysModulos.Icono;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeSysModulos.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarSysModulos(SqlConnection Conexion,int pIdModulo)
	{
		string sp = "SysProc_SysModulosEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdModulo", SqlDbType.Int).Value = pIdModulo;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beSysModulos traerSysModulos_x_IdModulo(SqlConnection Conexion,int IdModulo)
	{
		string sp = "SysProc_SysModulos_x_IdModulo";
		List<beSysModulos> lbeSysModulos = null;
				beSysModulos obeSysModulos=new beSysModulos();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdModulo", SqlDbType.Int).Value = IdModulo;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeSysModulos = new List<beSysModulos>();
				while (datard.Read())
					{
					 obeSysModulos = new beSysModulos();
						obeSysModulos.IdModulo =  datard.GetInt32(0);
						obeSysModulos.Modulo = CultureInfo.CurrentCulture.TextInfo.ToUpper(datard.GetString(1));
						obeSysModulos.Descripcion = CultureInfo.CurrentCulture.TextInfo.ToUpper(datard.GetString(2));
						obeSysModulos.Clave =  datard.GetString(3);
						obeSysModulos.Orden =  datard.GetByte(4);
						obeSysModulos.Icono =  datard.GetString(5);
						obeSysModulos.Activo =  datard.GetBoolean(6);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeSysModulos;
			}
	}
	public List< beSysModulos> listarTodos_SysModulos(SqlConnection Conexion)
	 {
		string sp = "SysProc_SysModulos_Traer_Todos";
		List<beSysModulos> lbeSysModulos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeSysModulos = new List<beSysModulos>();
				beSysModulos obeSysModulos;
				while (datard.Read())
				{
					 obeSysModulos = new beSysModulos();
					obeSysModulos.IdModulo =  datard.GetInt32(0);
					obeSysModulos.Modulo =  datard.GetString(1);
					obeSysModulos.Descripcion =  datard.GetString(2);
					obeSysModulos.Clave =  datard.GetString(3);
					obeSysModulos.Orden =  datard.GetByte(4);
					obeSysModulos.Icono =  datard.GetString(5);
					obeSysModulos.Activo =  datard.GetBoolean(6);
					lbeSysModulos.Add(obeSysModulos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeSysModulos;
		}
	}
	public DataTable listarSysModulos_GetAll(SqlConnection Conexion)
	 {
		string sp = "SysProc_SysModulos_Traer_Todos_GetAll";
		DataTable dtSysModulos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtSysModulos = new DataTable();
				dtSysModulos.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtSysModulos;
		}
	}
}
}
