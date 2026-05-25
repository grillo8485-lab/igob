using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daCondicionesPagosEntrega
 {
	public int guardarCondicionesPagosEntrega(SqlConnection Conexion, beCondicionesPagosEntrega obeCondicionesPagosEntrega)
	{
		int Id=0;
		string sp = "Proc_CondicionesPagosEntregaInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdCondicion", SqlDbType.Int).Value = obeCondicionesPagosEntrega.IdCondicion;
				cmd.Parameters.Add("@Condicion", SqlDbType.NVarChar).Value = obeCondicionesPagosEntrega.Condicion;
				cmd.Parameters.Add("@IdTipoCondicion", SqlDbType.Int).Value = obeCondicionesPagosEntrega.IdTipoCondicion;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeCondicionesPagosEntrega.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarCondicionesPagosEntrega(SqlConnection Conexion, beCondicionesPagosEntrega obeCondicionesPagosEntrega)
	{
		string sp = "Proc_CondicionesPagosEntregaActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdCondicion", SqlDbType.Int).Value = obeCondicionesPagosEntrega.IdCondicion;
				cmd.Parameters.Add("@Condicion", SqlDbType.NVarChar).Value = obeCondicionesPagosEntrega.Condicion;
				cmd.Parameters.Add("@IdTipoCondicion", SqlDbType.Int).Value = obeCondicionesPagosEntrega.IdTipoCondicion;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeCondicionesPagosEntrega.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarCondicionesPagosEntrega(SqlConnection Conexion,int pIdCondicion)
	{
		string sp = "Proc_CondicionesPagosEntregaEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdCondicion", SqlDbType.Int).Value = pIdCondicion;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beCondicionesPagosEntrega traerCondicionesPagosEntrega_x_IdCondicion(SqlConnection Conexion,int IdCondicion)
	{
		string sp = "Proc_CondicionesPagosEntrega_x_IdCondicion";
		List<beCondicionesPagosEntrega> lbeCondicionesPagosEntrega = null;
				beCondicionesPagosEntrega obeCondicionesPagosEntrega=new beCondicionesPagosEntrega();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdCondicion", SqlDbType.Int).Value = IdCondicion;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeCondicionesPagosEntrega = new List<beCondicionesPagosEntrega>();
				while (datard.Read())
					{
					 obeCondicionesPagosEntrega = new beCondicionesPagosEntrega();
						obeCondicionesPagosEntrega.IdCondicion =  datard.GetInt32(0);
						obeCondicionesPagosEntrega.Condicion =  datard.GetString(1);
						obeCondicionesPagosEntrega.IdTipoCondicion =  datard.GetInt32(2);
						obeCondicionesPagosEntrega.Activo =  datard.GetBoolean(3);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeCondicionesPagosEntrega;
			}
	}
	public List< beCondicionesPagosEntrega> listarTodos_CondicionesPagosEntrega(SqlConnection Conexion)
	 {
		string sp = "Proc_CondicionesPagosEntrega_Traer_Todos";
		List<beCondicionesPagosEntrega> lbeCondicionesPagosEntrega = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeCondicionesPagosEntrega = new List<beCondicionesPagosEntrega>();
				beCondicionesPagosEntrega obeCondicionesPagosEntrega;
				while (datard.Read())
				{
					 obeCondicionesPagosEntrega = new beCondicionesPagosEntrega();
					obeCondicionesPagosEntrega.IdCondicion =  datard.GetInt32(0);
					obeCondicionesPagosEntrega.Condicion =  datard.GetString(1);
					obeCondicionesPagosEntrega.IdTipoCondicion =  datard.GetInt32(2);
					obeCondicionesPagosEntrega.Activo =  datard.GetBoolean(3);
					lbeCondicionesPagosEntrega.Add(obeCondicionesPagosEntrega);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeCondicionesPagosEntrega;
		}
	}
	public DataTable listarCondicionesPagosEntrega_x_(SqlConnection Conexion,int IdCondicion)
	 {
		string sp = "Proc_CondicionesPagosEntrega_Traer_Todos";
		DataTable dtCondicionesPagosEntrega = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdCondicion", SqlDbType.Int).Value = IdCondicion;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtCondicionesPagosEntrega = new DataTable();
				dtCondicionesPagosEntrega.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtCondicionesPagosEntrega;
		}
	}
    public List<beCondicionesPagosEntrega> listarTodos_CondicionesPagosEntrega_GetAll(SqlConnection Conexion)
    {
        string sp = "Proc_CondicionesPagosEntrega_TraerTodos_GetAll";
        List<beCondicionesPagosEntrega> lbeCondicionesPagosEntrega = null;
        SqlCommand cmd = new SqlCommand(sp, Conexion);
        cmd.CommandType = CommandType.StoredProcedure;
        using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
        {
            try
            {
                if (datard != null)
                {
                    lbeCondicionesPagosEntrega = new List<beCondicionesPagosEntrega>();
                    beCondicionesPagosEntrega obeCondicionesPagosEntrega;
                    while (datard.Read())
                    {
                        obeCondicionesPagosEntrega = new beCondicionesPagosEntrega();
                        obeCondicionesPagosEntrega.IdCondicion = datard.GetInt32(0);
                        obeCondicionesPagosEntrega.Condicion = datard.GetString(1);
                        obeCondicionesPagosEntrega.IdTipoCondicion = datard.GetInt32(2);
                        obeCondicionesPagosEntrega.Activo = datard.GetBoolean(3);

                        /* TiposCondiciones 24/08/2018 */
                        obeCondicionesPagosEntrega.TipoCondicion = datard.GetString(4);
                        /**/
                        lbeCondicionesPagosEntrega.Add(obeCondicionesPagosEntrega);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeCondicionesPagosEntrega;
        }
    }
    }
}
