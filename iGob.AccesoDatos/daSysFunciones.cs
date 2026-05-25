using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using System.Globalization;

namespace iGob.AccesoDatos
{
public class daSysFunciones
 {
	public int guardarSysFunciones(SqlConnection Conexion, beSysFunciones obeSysFunciones)
	{
		int Id=0;
		string sp = "SysProc_SysFuncionesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdFuncion", SqlDbType.Int).Value = obeSysFunciones.IdFuncion;
				cmd.Parameters.Add("@IdModulo", SqlDbType.Int).Value = obeSysFunciones.IdModulo;
				cmd.Parameters.Add("@Funcion", SqlDbType.VarChar).Value = obeSysFunciones.Funcion;
				cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = obeSysFunciones.Descripcion;
				cmd.Parameters.Add("@Formulario", SqlDbType.VarChar).Value = obeSysFunciones.Formulario;
				cmd.Parameters.Add("@Orden", SqlDbType.TinyInt).Value = obeSysFunciones.Orden;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeSysFunciones.Activo;
				cmd.Parameters.Add("@Icono", SqlDbType.VarChar).Value = obeSysFunciones.Icono;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarSysFunciones(SqlConnection Conexion, beSysFunciones obeSysFunciones)
	{
		string sp = "SysProc_SysFuncionesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdFuncion", SqlDbType.Int).Value = obeSysFunciones.IdFuncion;
				cmd.Parameters.Add("@IdModulo", SqlDbType.Int).Value = obeSysFunciones.IdModulo;
				cmd.Parameters.Add("@Funcion", SqlDbType.VarChar).Value = obeSysFunciones.Funcion;
				cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = obeSysFunciones.Descripcion;
				cmd.Parameters.Add("@Formulario", SqlDbType.VarChar).Value = obeSysFunciones.Formulario;
				cmd.Parameters.Add("@Orden", SqlDbType.TinyInt).Value = obeSysFunciones.Orden;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeSysFunciones.Activo;
				cmd.Parameters.Add("@Icono", SqlDbType.VarChar).Value = obeSysFunciones.Icono;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarSysFunciones(SqlConnection Conexion,int pIdFuncion)
	{
		string sp = "SysProc_SysFuncionesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdFuncion", SqlDbType.Int).Value = pIdFuncion;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beSysFunciones traerSysFunciones_x_IdFuncion(SqlConnection Conexion,int IdFuncion)
	{
		string sp = "SysProc_SysFunciones_x_IdFuncion";
		List<beSysFunciones> lbeSysFunciones = null;
				beSysFunciones obeSysFunciones=new beSysFunciones();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdFuncion", SqlDbType.Int).Value = IdFuncion;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeSysFunciones = new List<beSysFunciones>();
				while (datard.Read())
					{
					 obeSysFunciones = new beSysFunciones();
                          
                        obeSysFunciones.IdFuncion =  datard.GetInt32(0);
						obeSysFunciones.IdModulo =  datard.GetInt32(1);
						obeSysFunciones.Funcion = convertirCadena(datard.GetString(2));
						obeSysFunciones.Descripcion = convertirCadena(datard.GetString(3));
						obeSysFunciones.Formulario =  datard.GetString(4);
						obeSysFunciones.Orden =  datard.GetByte(5);
						obeSysFunciones.Activo =  datard.GetBoolean(6);
						obeSysFunciones.Icono =  datard.GetString(7);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeSysFunciones;
			}
	}
        protected string convertirCadena(string cadena)
        {
            cadena = CultureInfo.CurrentCulture.TextInfo.ToLower(cadena);
            var array = cadena.Split(' ');
            if (array.Length > 1)
            {
                array[0] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(array[0]);
                cadena = String.Join(" ", array);
            }
            else
            {
                cadena = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(cadena);
            }

            return cadena;
        }
	public List< beSysFunciones> listarTodos_SysFunciones(SqlConnection Conexion)
	 {
		string sp = "SysProc_SysFunciones_Traer_Todos";
		List<beSysFunciones> lbeSysFunciones = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeSysFunciones = new List<beSysFunciones>();
				beSysFunciones obeSysFunciones;
				while (datard.Read())
				{
					 obeSysFunciones = new beSysFunciones();
					obeSysFunciones.IdFuncion =  datard.GetInt32(0);
					obeSysFunciones.IdModulo =  datard.GetInt32(1);
					obeSysFunciones.Funcion =  datard.GetString(2);
					obeSysFunciones.Descripcion =  datard.GetString(3);
					obeSysFunciones.Formulario =  datard.GetString(4);
					obeSysFunciones.Orden =  datard.GetByte(5);
					obeSysFunciones.Activo =  datard.GetBoolean(6);
					obeSysFunciones.Icono =  datard.GetString(7);
					lbeSysFunciones.Add(obeSysFunciones);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeSysFunciones;
		}
	}
	public DataTable listarSysFunciones_GetAll(SqlConnection Conexion)
	 {
		string sp = "SysProc_SysFunciones_Traer_Todos_GetAll";
		DataTable dtSysFunciones = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtSysFunciones = new DataTable();
				dtSysFunciones.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtSysFunciones;
		}
	}
}
}
