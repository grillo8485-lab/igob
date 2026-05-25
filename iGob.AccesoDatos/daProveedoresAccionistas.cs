using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daProveedoresAccionistas
 {
	public int guardarProveedoresAccionistas(SqlConnection Conexion, beProveedoresAccionistas obeProveedoresAccionistas)
	{
		int Id=0;
		string sp = "Proc_ProveedoresAccionistasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdProveedorAccionista", SqlDbType.Int).Value = obeProveedoresAccionistas.IdProveedorAccionista;
				cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = obeProveedoresAccionistas.IdPersona;
				cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obeProveedoresAccionistas.IdProveedor;
				cmd.Parameters.Add("@IdTipoRepresentacion", SqlDbType.Int).Value = obeProveedoresAccionistas.IdTipoRepresentacion;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarProveedoresAccionistas(SqlConnection Conexion, beProveedoresAccionistas obeProveedoresAccionistas)
	{
		string sp = "Proc_ProveedoresAccionistasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdProveedorAccionista", SqlDbType.Int).Value = obeProveedoresAccionistas.IdProveedorAccionista;
				cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = obeProveedoresAccionistas.IdPersona;
				cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obeProveedoresAccionistas.IdProveedor;
				cmd.Parameters.Add("@IdTipoRepresentacion", SqlDbType.Int).Value = obeProveedoresAccionistas.IdTipoRepresentacion;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarProveedoresAccionistas(SqlConnection Conexion,int pIdProveedorAccionista)
	{
		string sp = "Proc_ProveedoresAccionistasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdProveedorAccionista", SqlDbType.Int).Value = pIdProveedorAccionista;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beProveedoresAccionistas traerProveedoresAccionistas_x_IdProveedorAccionista(SqlConnection Conexion,int IdProveedorAccionista)
	{
		string sp = "Proc_ProveedoresAccionistas_x_IdProveedorAccionista";
		List<beProveedoresAccionistas> lbeProveedoresAccionistas = null;
				beProveedoresAccionistas obeProveedoresAccionistas=new beProveedoresAccionistas();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdProveedorAccionista", SqlDbType.Int).Value = IdProveedorAccionista;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeProveedoresAccionistas = new List<beProveedoresAccionistas>();
				while (datard.Read())
					{
					 obeProveedoresAccionistas = new beProveedoresAccionistas();
						obeProveedoresAccionistas.IdProveedorAccionista =  datard.GetInt32(0);
						obeProveedoresAccionistas.IdPersona =  datard.GetInt32(1);
						obeProveedoresAccionistas.IdProveedor =  datard.GetInt32(2);
						obeProveedoresAccionistas.IdTipoRepresentacion =  datard.GetInt32(3);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeProveedoresAccionistas;
			}
	}
	public List< beProveedoresAccionistas> listarTodos_ProveedoresAccionistas(SqlConnection Conexion)
	 {
		string sp = "Proc_ProveedoresAccionistas_Traer_Todos";
		List<beProveedoresAccionistas> lbeProveedoresAccionistas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeProveedoresAccionistas = new List<beProveedoresAccionistas>();
				beProveedoresAccionistas obeProveedoresAccionistas;
				while (datard.Read())
				{
					 obeProveedoresAccionistas = new beProveedoresAccionistas();
					obeProveedoresAccionistas.IdProveedorAccionista =  datard.GetInt32(0);
					obeProveedoresAccionistas.IdPersona =  datard.GetInt32(1);
					obeProveedoresAccionistas.IdProveedor =  datard.GetInt32(2);
					obeProveedoresAccionistas.IdTipoRepresentacion =  datard.GetInt32(3);
					lbeProveedoresAccionistas.Add(obeProveedoresAccionistas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeProveedoresAccionistas;
		}
	}
	public DataTable listarProveedoresAccionistas_x_(SqlConnection Conexion,int IdProveedorAccionista)
	 {
		string sp = "Proc_ProveedoresAccionistas_Traer_Todos";
		DataTable dtProveedoresAccionistas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdProveedorAccionista", SqlDbType.Int).Value = IdProveedorAccionista;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtProveedoresAccionistas = new DataTable();
				dtProveedoresAccionistas.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtProveedoresAccionistas;
		}
	}
    /* Get All 28/08/2018 */
    public List<beProveedoresAccionistas> listarTodos_ProveedoresAccionistas_GetAll(SqlConnection Conexion)
    {
        string sp = "Proc_ProveedoresAccionistas_TraerTodos_GetAll";
        List<beProveedoresAccionistas> lbeProveedoresAccionistas = null;
        SqlCommand cmd = new SqlCommand(sp, Conexion);
        cmd.CommandType = CommandType.StoredProcedure;
        using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
        {
            try
            {
                if (datard != null)
                {
                    lbeProveedoresAccionistas = new List<beProveedoresAccionistas>();
                    beProveedoresAccionistas obeProveedoresAccionistas;
                    while (datard.Read())
                    {
                        obeProveedoresAccionistas = new beProveedoresAccionistas();
                        obeProveedoresAccionistas.IdProveedorAccionista = datard.GetInt32(0);
                        obeProveedoresAccionistas.IdPersona = datard.GetInt32(1);
                        obeProveedoresAccionistas.IdProveedor = datard.GetInt32(2);
                        obeProveedoresAccionistas.IdTipoRepresentacion = datard.GetInt32(3);

                        obeProveedoresAccionistas.Nombre = datard.GetString(4);
                        obeProveedoresAccionistas.RazonSocial = datard.GetString(5);
                        obeProveedoresAccionistas.TipoRepresentacion = datard.GetString(6);
                        lbeProveedoresAccionistas.Add(obeProveedoresAccionistas);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeProveedoresAccionistas;
        }
    }
    }
}
