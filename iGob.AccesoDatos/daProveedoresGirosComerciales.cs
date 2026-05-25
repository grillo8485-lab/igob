using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daProveedoresGirosComerciales
 {
	public int guardarProveedoresGirosComerciales(SqlConnection Conexion, beProveedoresGirosComerciales obeProveedoresGirosComerciales)
	{
		int Id=0;
		string sp = "Proc_ProveedoresGirosComercialesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdProveedorGiroComercial", SqlDbType.Int).Value = obeProveedoresGirosComerciales.IdProveedorGiroComercial;
				cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obeProveedoresGirosComerciales.IdProveedor;
				cmd.Parameters.Add("@IdActividadEconomica", SqlDbType.Int).Value = obeProveedoresGirosComerciales.IdActividadEconomica;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarProveedoresGirosComerciales(SqlConnection Conexion, beProveedoresGirosComerciales obeProveedoresGirosComerciales)
	{
		string sp = "Proc_ProveedoresGirosComercialesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdProveedorGiroComercial", SqlDbType.Int).Value = obeProveedoresGirosComerciales.IdProveedorGiroComercial;
				cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obeProveedoresGirosComerciales.IdProveedor;
				cmd.Parameters.Add("@IdActividadEconomica", SqlDbType.Int).Value = obeProveedoresGirosComerciales.IdActividadEconomica;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarProveedoresGirosComerciales(SqlConnection Conexion,int pIdProveedorGiroComercial)
	{
		string sp = "Proc_ProveedoresGirosComercialesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdProveedorGiroComercial", SqlDbType.Int).Value = pIdProveedorGiroComercial;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beProveedoresGirosComerciales traerProveedoresGirosComerciales_x_IdProveedorGiroComercial(SqlConnection Conexion,int IdProveedorGiroComercial)
	{
		string sp = "Proc_ProveedoresGirosComerciales_x_IdProveedorGiroComercial";
		List<beProveedoresGirosComerciales> lbeProveedoresGirosComerciales = null;
				beProveedoresGirosComerciales obeProveedoresGirosComerciales=new beProveedoresGirosComerciales();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdProveedorGiroComercial", SqlDbType.Int).Value = IdProveedorGiroComercial;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeProveedoresGirosComerciales = new List<beProveedoresGirosComerciales>();
				while (datard.Read())
					{
					 obeProveedoresGirosComerciales = new beProveedoresGirosComerciales();
						obeProveedoresGirosComerciales.IdProveedorGiroComercial =  datard.GetInt32(0);
						obeProveedoresGirosComerciales.IdProveedor =  datard.GetInt32(1);
						obeProveedoresGirosComerciales.IdActividadEconomica =  datard.GetInt32(2);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeProveedoresGirosComerciales;
			}
	}
	public List< beProveedoresGirosComerciales> listarTodos_ProveedoresGirosComerciales(SqlConnection Conexion)
	 {
		string sp = "Proc_ProveedoresGirosComerciales_Traer_Todos";
		List<beProveedoresGirosComerciales> lbeProveedoresGirosComerciales = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeProveedoresGirosComerciales = new List<beProveedoresGirosComerciales>();
				beProveedoresGirosComerciales obeProveedoresGirosComerciales;
				while (datard.Read())
				{
					 obeProveedoresGirosComerciales = new beProveedoresGirosComerciales();
					obeProveedoresGirosComerciales.IdProveedorGiroComercial =  datard.GetInt32(0);
					obeProveedoresGirosComerciales.IdProveedor =  datard.GetInt32(1);
					obeProveedoresGirosComerciales.IdActividadEconomica =  datard.GetInt32(2);
					lbeProveedoresGirosComerciales.Add(obeProveedoresGirosComerciales);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeProveedoresGirosComerciales;
		}
	}
	public DataTable listarProveedoresGirosComerciales_x_(SqlConnection Conexion,int IdProveedorGiroComercial)
	 {
		string sp = "Proc_ProveedoresGirosComerciales_Traer_Todos";
		DataTable dtProveedoresGirosComerciales = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdProveedorGiroComercial", SqlDbType.Int).Value = IdProveedorGiroComercial;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtProveedoresGirosComerciales = new DataTable();
				dtProveedoresGirosComerciales.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtProveedoresGirosComerciales;
		}
	}
    
    /* Get All 28/08/2018 */
    public List<beProveedoresGirosComerciales> listarTodos_ProveedoresGirosComerciales_GetAll(SqlConnection Conexion)
    {
        string sp = "Proc_ProveedoresGirosComerciales_TraerTodos_GetAll";
        List<beProveedoresGirosComerciales> lbeProveedoresGirosComerciales = null;
        SqlCommand cmd = new SqlCommand(sp, Conexion);
        cmd.CommandType = CommandType.StoredProcedure;
        using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
        {
            try
            {
                if (datard != null)
                {
                    lbeProveedoresGirosComerciales = new List<beProveedoresGirosComerciales>();
                    beProveedoresGirosComerciales obeProveedoresGirosComerciales;
                    while (datard.Read())
                    {
                        obeProveedoresGirosComerciales = new beProveedoresGirosComerciales();
                        obeProveedoresGirosComerciales.IdProveedorGiroComercial = datard.GetInt32(0);
                        obeProveedoresGirosComerciales.IdProveedor = datard.GetInt32(1);
                        obeProveedoresGirosComerciales.IdActividadEconomica = datard.GetInt32(2);
                        
                        obeProveedoresGirosComerciales.RazonSocial = datard.GetString(3);
                        obeProveedoresGirosComerciales.Descripcion = datard.GetString(4);

                        lbeProveedoresGirosComerciales.Add(obeProveedoresGirosComerciales);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeProveedoresGirosComerciales;
        }
    }
    }
}
