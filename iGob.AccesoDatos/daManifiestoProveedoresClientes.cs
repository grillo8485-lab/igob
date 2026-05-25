using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daManifiestoProveedoresClientes
 {
	public int guardarManifiestoProveedoresClientes(SqlConnection Conexion, beManifiestoProveedoresClientes obeManifiestoProveedoresClientes)
	{
		int Id=0;
		string sp = "Proc_ManifiestoProveedoresClientesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdManifiestoProveedorCliente", SqlDbType.Int).Value = obeManifiestoProveedoresClientes.IdManifiestoProveedorCliente;
				cmd.Parameters.Add("@IdManifiestoProveedor", SqlDbType.Int).Value = obeManifiestoProveedoresClientes.IdManifiestoProveedor;
				cmd.Parameters.Add("@NombreCliente", SqlDbType.VarChar).Value = obeManifiestoProveedoresClientes.NombreCliente;
				cmd.Parameters.Add("@DirecionCliente", SqlDbType.VarChar).Value = obeManifiestoProveedoresClientes.DirecionCliente;
				cmd.Parameters.Add("@TelefonoCliente", SqlDbType.VarChar).Value = obeManifiestoProveedoresClientes.TelefonoCliente;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarManifiestoProveedoresClientes(SqlConnection Conexion, beManifiestoProveedoresClientes obeManifiestoProveedoresClientes)
	{
		string sp = "Proc_ManifiestoProveedoresClientesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdManifiestoProveedorCliente", SqlDbType.Int).Value = obeManifiestoProveedoresClientes.IdManifiestoProveedorCliente;
				cmd.Parameters.Add("@IdManifiestoProveedor", SqlDbType.Int).Value = obeManifiestoProveedoresClientes.IdManifiestoProveedor;
				cmd.Parameters.Add("@NombreCliente", SqlDbType.VarChar).Value = obeManifiestoProveedoresClientes.NombreCliente;
				cmd.Parameters.Add("@DirecionCliente", SqlDbType.VarChar).Value = obeManifiestoProveedoresClientes.DirecionCliente;
				cmd.Parameters.Add("@TelefonoCliente", SqlDbType.VarChar).Value = obeManifiestoProveedoresClientes.TelefonoCliente;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarManifiestoProveedoresClientes(SqlConnection Conexion,int pIdManifiestoProveedorCliente)
	{
		string sp = "Proc_ManifiestoProveedoresClientesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdManifiestoProveedorCliente", SqlDbType.Int).Value = pIdManifiestoProveedorCliente;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beManifiestoProveedoresClientes traerManifiestoProveedoresClientes_x_IdManifiestoProveedorCliente(SqlConnection Conexion,int IdManifiestoProveedorCliente)
	{
		string sp = "Proc_ManifiestoProveedoresClientes_x_IdManifiestoProveedorCliente";
				beManifiestoProveedoresClientes obeManifiestoProveedoresClientes=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdManifiestoProveedorCliente", SqlDbType.Int).Value = IdManifiestoProveedorCliente;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdManifiestoProveedorCliente = datard.GetOrdinal("IdManifiestoProveedorCliente");
						int posIdManifiestoProveedor = datard.GetOrdinal("IdManifiestoProveedor");
						int posNombreCliente = datard.GetOrdinal("NombreCliente");
						int posDirecionCliente = datard.GetOrdinal("DirecionCliente");
						int posTelefonoCliente = datard.GetOrdinal("TelefonoCliente");
					 obeManifiestoProveedoresClientes = new beManifiestoProveedoresClientes();
				while (datard.Read())
					{
						obeManifiestoProveedoresClientes.IdManifiestoProveedorCliente =  datard.GetInt32(posIdManifiestoProveedorCliente);
						obeManifiestoProveedoresClientes.IdManifiestoProveedor =  datard.GetInt32(posIdManifiestoProveedor);
						obeManifiestoProveedoresClientes.NombreCliente =  datard.GetString(posNombreCliente);
						obeManifiestoProveedoresClientes.DirecionCliente =  datard.GetString(posDirecionCliente);
						obeManifiestoProveedoresClientes.TelefonoCliente =  datard.GetString(posTelefonoCliente);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeManifiestoProveedoresClientes;
			}
	}
	public List< beManifiestoProveedoresClientes> listarTodos_ManifiestoProveedoresClientes(SqlConnection Conexion)
	 {
		string sp = "Proc_ManifiestoProveedoresClientes_Traer_Todos";
		List<beManifiestoProveedoresClientes> lbeManifiestoProveedoresClientes = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdManifiestoProveedorCliente = datard.GetOrdinal("IdManifiestoProveedorCliente");
						int posIdManifiestoProveedor = datard.GetOrdinal("IdManifiestoProveedor");
						int posNombreCliente = datard.GetOrdinal("NombreCliente");
						int posDirecionCliente = datard.GetOrdinal("DirecionCliente");
						int posTelefonoCliente = datard.GetOrdinal("TelefonoCliente");
				lbeManifiestoProveedoresClientes = new List<beManifiestoProveedoresClientes>();
				beManifiestoProveedoresClientes obeManifiestoProveedoresClientes;
				while (datard.Read())
				{
					 obeManifiestoProveedoresClientes = new beManifiestoProveedoresClientes();
					obeManifiestoProveedoresClientes.IdManifiestoProveedorCliente =  datard.GetInt32(posIdManifiestoProveedorCliente);
					obeManifiestoProveedoresClientes.IdManifiestoProveedor =  datard.GetInt32(posIdManifiestoProveedor);
					obeManifiestoProveedoresClientes.NombreCliente =  datard.GetString(posNombreCliente);
					obeManifiestoProveedoresClientes.DirecionCliente =  datard.GetString(posDirecionCliente);
					obeManifiestoProveedoresClientes.TelefonoCliente =  datard.GetString(posTelefonoCliente);
					lbeManifiestoProveedoresClientes.Add(obeManifiestoProveedoresClientes);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeManifiestoProveedoresClientes;
		}
	}
	public List< beManifiestoProveedoresClientes> listar_ManifiestoProveedoresClientes_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_ManifiestoProveedoresClientes_TraerTodos_GetAll";
		List<beManifiestoProveedoresClientes> lbeManifiestoProveedoresClientes = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdManifiestoProveedorCliente = datard.GetOrdinal("IdManifiestoProveedorCliente");
						int posIdManifiestoProveedor = datard.GetOrdinal("IdManifiestoProveedor");
						int posNombreCliente = datard.GetOrdinal("NombreCliente");
						int posDirecionCliente = datard.GetOrdinal("DirecionCliente");
						int posTelefonoCliente = datard.GetOrdinal("TelefonoCliente");
				lbeManifiestoProveedoresClientes = new List<beManifiestoProveedoresClientes>();
				beManifiestoProveedoresClientes obeManifiestoProveedoresClientes;
				while (datard.Read())
				{
					 obeManifiestoProveedoresClientes = new beManifiestoProveedoresClientes();
					obeManifiestoProveedoresClientes.IdManifiestoProveedorCliente =  datard.GetInt32(posIdManifiestoProveedorCliente);
					obeManifiestoProveedoresClientes.IdManifiestoProveedor =  datard.GetInt32(posIdManifiestoProveedor);
					obeManifiestoProveedoresClientes.NombreCliente =  datard.GetString(posNombreCliente);
					obeManifiestoProveedoresClientes.DirecionCliente =  datard.GetString(posDirecionCliente);
					obeManifiestoProveedoresClientes.TelefonoCliente =  datard.GetString(posTelefonoCliente);
			// debe agregar campos de la Vista
					lbeManifiestoProveedoresClientes.Add(obeManifiestoProveedoresClientes);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeManifiestoProveedoresClientes;
		}
	}
        public List<beManifiestoProveedoresClientes> getAllManifiestosProveedores_x_IdManifiestoProveedor(SqlConnection Conexion,int pIdManifiestoProveedor)
        {
            string sp = "Proc_ManifiestoProveedoresClientes_IdManifiestoProveedor";
            List<beManifiestoProveedoresClientes> lbeManifiestoProveedoresClientes = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdManifiestoProveedor", SqlDbType.Int).Value = pIdManifiestoProveedor;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdManifiestoProveedorCliente = datard.GetOrdinal("IdManifiestoProveedorCliente");
                        int posIdManifiestoProveedor = datard.GetOrdinal("IdManifiestoProveedor");
                        int posNombreCliente = datard.GetOrdinal("NombreCliente");
                        int posDirecionCliente = datard.GetOrdinal("DirecionCliente");
                        int posTelefonoCliente = datard.GetOrdinal("TelefonoCliente");
                        lbeManifiestoProveedoresClientes = new List<beManifiestoProveedoresClientes>();
                        beManifiestoProveedoresClientes obeManifiestoProveedoresClientes;
                        while (datard.Read())
                        {
                            obeManifiestoProveedoresClientes = new beManifiestoProveedoresClientes();
                            obeManifiestoProveedoresClientes.IdManifiestoProveedorCliente = datard.GetInt32(posIdManifiestoProveedorCliente);
                            obeManifiestoProveedoresClientes.IdManifiestoProveedor = datard.GetInt32(posIdManifiestoProveedor);
                            obeManifiestoProveedoresClientes.NombreCliente = datard.GetString(posNombreCliente);
                            obeManifiestoProveedoresClientes.DirecionCliente = datard.GetString(posDirecionCliente);
                            obeManifiestoProveedoresClientes.TelefonoCliente = datard.GetString(posTelefonoCliente);
                            // debe agregar campos de la Vista
                            lbeManifiestoProveedoresClientes.Add(obeManifiestoProveedoresClientes);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeManifiestoProveedoresClientes;
            }
        }
    }
}
