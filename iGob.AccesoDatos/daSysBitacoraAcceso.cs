using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daSysBitacoraAcceso
 {
	public int guardarSysBitacoraAcceso(SqlConnection Conexion, beSysBitacoraAcceso obeSysBitacoraAcceso)
	{
		int Id=0;
		string sp = "Proc_SysBitacoraAccesoInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAcceso", SqlDbType.Int).Value = obeSysBitacoraAcceso.IdAcceso;
				cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = obeSysBitacoraAcceso.IdUsuario;
				cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = obeSysBitacoraAcceso.Fecha;
				cmd.Parameters.Add("@Acceso", SqlDbType.Bit).Value = obeSysBitacoraAcceso.Acceso;
				cmd.Parameters.Add("@llaveAcceso", SqlDbType.NVarChar).Value = obeSysBitacoraAcceso.LlaveAcceso;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarSysBitacoraAcceso(SqlConnection Conexion, beSysBitacoraAcceso obeSysBitacoraAcceso)
	{
		string sp = "Proc_SysBitacoraAccesoActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAcceso", SqlDbType.Int).Value = obeSysBitacoraAcceso.IdAcceso;
				cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = obeSysBitacoraAcceso.IdUsuario;
				cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = obeSysBitacoraAcceso.Fecha;
				cmd.Parameters.Add("@Acceso", SqlDbType.Bit).Value = obeSysBitacoraAcceso.Acceso;
				cmd.Parameters.Add("@llaveAcceso", SqlDbType.NVarChar).Value = obeSysBitacoraAcceso.LlaveAcceso;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarSysBitacoraAcceso(SqlConnection Conexion,int pIdAcceso)
	{
		string sp = "Proc_SysBitacoraAccesoEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAcceso", SqlDbType.Int).Value = pIdAcceso;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beSysBitacoraAcceso traerSysBitacoraAcceso_x_IdAcceso(SqlConnection Conexion,int IdAcceso)
	{
		string sp = "Proc_SysBitacoraAcceso_x_IdAcceso";
				beSysBitacoraAcceso obeSysBitacoraAcceso=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdAcceso", SqlDbType.Int).Value = IdAcceso;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdAcceso = datard.GetOrdinal("IdAcceso");
						int posIdUsuario = datard.GetOrdinal("IdUsuario");
						int posFecha = datard.GetOrdinal("Fecha");
						int posAcceso = datard.GetOrdinal("Acceso");
						int posllaveAcceso = datard.GetOrdinal("llaveAcceso");
					 obeSysBitacoraAcceso = new beSysBitacoraAcceso();
				while (datard.Read())
					{
						obeSysBitacoraAcceso.IdAcceso =  datard.GetInt32(posIdAcceso);
						obeSysBitacoraAcceso.IdUsuario =  datard.GetInt32(posIdUsuario);
						obeSysBitacoraAcceso.Fecha =  datard.GetDateTime(posFecha);
						obeSysBitacoraAcceso.Acceso =  datard.GetBoolean(posAcceso);
						obeSysBitacoraAcceso.LlaveAcceso =  datard.GetString(posllaveAcceso);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeSysBitacoraAcceso;
			}
	}
	public List< beSysBitacoraAcceso> listarTodos_SysBitacoraAcceso(SqlConnection Conexion)
	 {
		string sp = "Proc_SysBitacoraAcceso_Traer_Todos";
		List<beSysBitacoraAcceso> lbeSysBitacoraAcceso = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAcceso = datard.GetOrdinal("IdAcceso");
						int posIdUsuario = datard.GetOrdinal("IdUsuario");
						int posFecha = datard.GetOrdinal("Fecha");
						int posAcceso = datard.GetOrdinal("Acceso");
						int posllaveAcceso = datard.GetOrdinal("llaveAcceso");
				lbeSysBitacoraAcceso = new List<beSysBitacoraAcceso>();
				beSysBitacoraAcceso obeSysBitacoraAcceso;
				while (datard.Read())
				{
					 obeSysBitacoraAcceso = new beSysBitacoraAcceso();
					obeSysBitacoraAcceso.IdAcceso =  datard.GetInt32(posIdAcceso);
					obeSysBitacoraAcceso.IdUsuario =  datard.GetInt32(posIdUsuario);
					obeSysBitacoraAcceso.Fecha =  datard.GetDateTime(posFecha);
					obeSysBitacoraAcceso.Acceso =  datard.GetBoolean(posAcceso);
					obeSysBitacoraAcceso.LlaveAcceso =  datard.GetString(posllaveAcceso);
					lbeSysBitacoraAcceso.Add(obeSysBitacoraAcceso);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeSysBitacoraAcceso;
		}
	}
	public List< beSysBitacoraAcceso> listar_SysBitacoraAcceso_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_SysBitacoraAcceso_TraerTodos_GetAll";
		List<beSysBitacoraAcceso> lbeSysBitacoraAcceso = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAcceso = datard.GetOrdinal("IdAcceso");
						int posIdUsuario = datard.GetOrdinal("IdUsuario");
						int posFecha = datard.GetOrdinal("Fecha");
						int posAcceso = datard.GetOrdinal("Acceso");
						int posllaveAcceso = datard.GetOrdinal("llaveAcceso");
				lbeSysBitacoraAcceso = new List<beSysBitacoraAcceso>();
				beSysBitacoraAcceso obeSysBitacoraAcceso;
				while (datard.Read())
				{
					 obeSysBitacoraAcceso = new beSysBitacoraAcceso();
					obeSysBitacoraAcceso.IdAcceso =  datard.GetInt32(posIdAcceso);
					obeSysBitacoraAcceso.IdUsuario =  datard.GetInt32(posIdUsuario);
					obeSysBitacoraAcceso.Fecha =  datard.GetDateTime(posFecha);
					obeSysBitacoraAcceso.Acceso =  datard.GetBoolean(posAcceso);
					obeSysBitacoraAcceso.LlaveAcceso =  datard.GetString(posllaveAcceso);
			// debe agregar campos de la Vista
					lbeSysBitacoraAcceso.Add(obeSysBitacoraAcceso);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeSysBitacoraAcceso;
		}
	}
        public beSysBitacoraAcceso traerSysBitacoraAcceso_x_LlaveAcceso(SqlConnection Conexion, string pLlaveAcceso)
        {
            string sp = "Proc_SysBitacoraAcceso_x_llaveAcceso";
            beSysBitacoraAcceso obeSysBitacoraAcceso = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LlaveAcceso", SqlDbType.NVarChar).Value = pLlaveAcceso;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdAcceso = datard.GetOrdinal("IdAcceso");
                        int posIdUsuario = datard.GetOrdinal("IdUsuario");
                        int posFecha = datard.GetOrdinal("Fecha");
                        int posAcceso = datard.GetOrdinal("Acceso");
                        int posllaveAcceso = datard.GetOrdinal("llaveAcceso");
                        obeSysBitacoraAcceso = new beSysBitacoraAcceso();
                        while (datard.Read())
                        {
                            obeSysBitacoraAcceso.IdAcceso = datard.GetInt32(posIdAcceso);
                            obeSysBitacoraAcceso.IdUsuario = datard.GetInt32(posIdUsuario);
                            obeSysBitacoraAcceso.Fecha = datard.GetDateTime(posFecha);
                            obeSysBitacoraAcceso.Acceso = datard.GetBoolean(posAcceso);
                            obeSysBitacoraAcceso.LlaveAcceso = datard.GetString(posllaveAcceso);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeSysBitacoraAcceso;
            }
        }
    }
}
