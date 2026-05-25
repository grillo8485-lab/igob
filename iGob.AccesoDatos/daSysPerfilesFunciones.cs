using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daSysPerfilesFunciones
 {
	public int guardarSysPerfilesFunciones(SqlConnection Conexion, beSysPerfilesFunciones obeSysPerfilesFunciones)
	{
		int Id=0;
		string sp = "SysProc_SysPerfilesFuncionesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPerfilFuncion", SqlDbType.Int).Value = obeSysPerfilesFunciones.IdPerfilFuncion;
				cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = obeSysPerfilesFunciones.IdPerfil;
				cmd.Parameters.Add("@IdFuncion", SqlDbType.Int).Value = obeSysPerfilesFunciones.IdFuncion;
				cmd.Parameters.Add("@btnNuevo", SqlDbType.Bit).Value = obeSysPerfilesFunciones.btnNuevo;
				cmd.Parameters.Add("@btnEditar", SqlDbType.Bit).Value = obeSysPerfilesFunciones.btnEditar;
				cmd.Parameters.Add("@btnEliminar", SqlDbType.Bit).Value = obeSysPerfilesFunciones.btnEliminar;
				cmd.Parameters.Add("@btnConsultar", SqlDbType.Bit).Value = obeSysPerfilesFunciones.btnConsultar;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarSysPerfilesFunciones(SqlConnection Conexion, beSysPerfilesFunciones obeSysPerfilesFunciones)
	{
		string sp = "SysProc_SysPerfilesFuncionesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPerfilFuncion", SqlDbType.Int).Value = obeSysPerfilesFunciones.IdPerfilFuncion;
				cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = obeSysPerfilesFunciones.IdPerfil;
				cmd.Parameters.Add("@IdFuncion", SqlDbType.Int).Value = obeSysPerfilesFunciones.IdFuncion;
				cmd.Parameters.Add("@btnNuevo", SqlDbType.Bit).Value = obeSysPerfilesFunciones.btnNuevo;
				cmd.Parameters.Add("@btnEditar", SqlDbType.Bit).Value = obeSysPerfilesFunciones.btnEditar;
				cmd.Parameters.Add("@btnEliminar", SqlDbType.Bit).Value = obeSysPerfilesFunciones.btnEliminar;
				cmd.Parameters.Add("@btnConsultar", SqlDbType.Bit).Value = obeSysPerfilesFunciones.btnConsultar;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarSysPerfilesFunciones(SqlConnection Conexion,int pIdPerfilFuncion)
	{
		string sp = "SysProc_SysPerfilesFuncionesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPerfilFuncion", SqlDbType.Int).Value = pIdPerfilFuncion;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beSysPerfilesFunciones traerSysPerfilesFunciones_x_IdPerfilFuncion(SqlConnection Conexion,int IdPerfilFuncion)
	{
		string sp = "SysProc_SysPerfilesFunciones_x_IdPerfilFuncion";
		List<beSysPerfilesFunciones> lbeSysPerfilesFunciones = null;
				beSysPerfilesFunciones obeSysPerfilesFunciones=new beSysPerfilesFunciones();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdPerfilFuncion", SqlDbType.Int).Value = IdPerfilFuncion;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeSysPerfilesFunciones = new List<beSysPerfilesFunciones>();
				while (datard.Read())
					{
					 obeSysPerfilesFunciones = new beSysPerfilesFunciones();
						obeSysPerfilesFunciones.IdPerfilFuncion =  datard.GetInt32(0);
						obeSysPerfilesFunciones.IdPerfil =  datard.GetInt32(1);
						obeSysPerfilesFunciones.IdFuncion =  datard.GetInt32(2);
						obeSysPerfilesFunciones.btnNuevo =  datard.GetBoolean(3);
						obeSysPerfilesFunciones.btnEditar =  datard.GetBoolean(4);
						obeSysPerfilesFunciones.btnEliminar =  datard.GetBoolean(5);
						obeSysPerfilesFunciones.btnConsultar =  datard.GetBoolean(6);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeSysPerfilesFunciones;
			}
	}
	public List< beSysPerfilesFunciones> listarTodos_SysPerfilesFunciones(SqlConnection Conexion)
	 {
		string sp = "SysProc_SysPerfilesFunciones_Traer_Todos";
		List<beSysPerfilesFunciones> lbeSysPerfilesFunciones = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeSysPerfilesFunciones = new List<beSysPerfilesFunciones>();
				beSysPerfilesFunciones obeSysPerfilesFunciones;
				while (datard.Read())
				{
					 obeSysPerfilesFunciones = new beSysPerfilesFunciones();
					obeSysPerfilesFunciones.IdPerfilFuncion =  datard.GetInt32(0);
					obeSysPerfilesFunciones.IdPerfil =  datard.GetInt32(1);
					obeSysPerfilesFunciones.IdFuncion =  datard.GetInt32(2);
					obeSysPerfilesFunciones.btnNuevo =  datard.GetBoolean(3);
					obeSysPerfilesFunciones.btnEditar =  datard.GetBoolean(4);
					obeSysPerfilesFunciones.btnEliminar =  datard.GetBoolean(5);
					obeSysPerfilesFunciones.btnConsultar =  datard.GetBoolean(6);
					lbeSysPerfilesFunciones.Add(obeSysPerfilesFunciones);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeSysPerfilesFunciones;
		}
	}
        public List<beSysPerfilesFunciones> traerSysPerfilesFunciones_x_IdPerfil(SqlConnection Conexion, int IdPerfil)
        {
            string sp = "SysProc_SysPerfilesFunciones_x_IdPerfil";
            List<beSysPerfilesFunciones> lbeSysPerfilesFunciones = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = IdPerfil;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        lbeSysPerfilesFunciones = new List<beSysPerfilesFunciones>();
                        beSysPerfilesFunciones obeSysPerfilesFunciones;
                        while (datard.Read())
                        {
                            obeSysPerfilesFunciones = new beSysPerfilesFunciones();
                            obeSysPerfilesFunciones.IdPerfilFuncion = datard.GetInt32(0);
                            obeSysPerfilesFunciones.IdPerfil = datard.GetInt32(1);
                            obeSysPerfilesFunciones.IdFuncion = datard.GetInt32(2);
                            obeSysPerfilesFunciones.btnNuevo = datard.GetBoolean(3);
                            obeSysPerfilesFunciones.btnEditar = datard.GetBoolean(4);
                            obeSysPerfilesFunciones.btnEliminar = datard.GetBoolean(5);
                            obeSysPerfilesFunciones.btnConsultar = datard.GetBoolean(6);
                            lbeSysPerfilesFunciones.Add(obeSysPerfilesFunciones);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeSysPerfilesFunciones;
            }
        }
        public DataTable listarSysPerfilesFunciones_GetAll(SqlConnection Conexion)
	 {
		string sp = "SysProc_SysPerfilesFunciones_Traer_Todos_GetAll";
		DataTable dtSysPerfilesFunciones = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtSysPerfilesFunciones = new DataTable();
				dtSysPerfilesFunciones.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtSysPerfilesFunciones;
		}
	}
}
}
