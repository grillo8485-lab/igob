using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daProveedoresActaConstitutiva
 {
	public int guardarProveedoresActaConstitutiva(SqlConnection Conexion, beProveedoresActaConstitutiva obeProveedoresActaConstitutiva)
	{
		int Id=0;
		string sp = "Proc_ProveedoresActaConstitutivaInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdActaConstitutiva", SqlDbType.Int).Value = obeProveedoresActaConstitutiva.IdActaConstitutiva;
				cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obeProveedoresActaConstitutiva.IdProveedor;
				cmd.Parameters.Add("@NoEscritura", SqlDbType.VarChar).Value = obeProveedoresActaConstitutiva.NoEscritura;
				cmd.Parameters.Add("@NoNotaria", SqlDbType.NChar).Value = obeProveedoresActaConstitutiva.NoNotaria;
				cmd.Parameters.Add("@Lugar", SqlDbType.NVarChar).Value = obeProveedoresActaConstitutiva.Lugar;
				cmd.Parameters.Add("@FechaEscritura", SqlDbType.DateTime).Value = obeProveedoresActaConstitutiva.FechaEscritura;
				cmd.Parameters.Add("@FechaRegistroPublico", SqlDbType.DateTime).Value = obeProveedoresActaConstitutiva.FechaRegistroPublico;
				cmd.Parameters.Add("@NoFolioRegistro", SqlDbType.NVarChar).Value = obeProveedoresActaConstitutiva.NoFolioRegistro;
				cmd.Parameters.Add("@Actualizacion", SqlDbType.Int).Value = obeProveedoresActaConstitutiva.Actualizacion;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarProveedoresActaConstitutiva(SqlConnection Conexion, beProveedoresActaConstitutiva obeProveedoresActaConstitutiva)
	{
		string sp = "Proc_ProveedoresActaConstitutivaActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdActaConstitutiva", SqlDbType.Int).Value = obeProveedoresActaConstitutiva.IdActaConstitutiva;
				cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obeProveedoresActaConstitutiva.IdProveedor;
				cmd.Parameters.Add("@NoEscritura", SqlDbType.VarChar).Value = obeProveedoresActaConstitutiva.NoEscritura;
				cmd.Parameters.Add("@NoNotaria", SqlDbType.NChar).Value = obeProveedoresActaConstitutiva.NoNotaria;
				cmd.Parameters.Add("@Lugar", SqlDbType.NVarChar).Value = obeProveedoresActaConstitutiva.Lugar;
				cmd.Parameters.Add("@FechaEscritura", SqlDbType.DateTime).Value = obeProveedoresActaConstitutiva.FechaEscritura;
				cmd.Parameters.Add("@FechaRegistroPublico", SqlDbType.DateTime).Value = obeProveedoresActaConstitutiva.FechaRegistroPublico;
				cmd.Parameters.Add("@NoFolioRegistro", SqlDbType.NVarChar).Value = obeProveedoresActaConstitutiva.NoFolioRegistro;
				cmd.Parameters.Add("@Actualizacion", SqlDbType.Int).Value = obeProveedoresActaConstitutiva.Actualizacion;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarProveedoresActaConstitutiva(SqlConnection Conexion,int pIdActaConstitutiva)
	{
		string sp = "Proc_ProveedoresActaConstitutivaEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdActaConstitutiva", SqlDbType.Int).Value = pIdActaConstitutiva;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beProveedoresActaConstitutiva traerProveedoresActaConstitutiva_x_IdActaConstitutiva(SqlConnection Conexion,int IdActaConstitutiva)
	{
		string sp = "Proc_ProveedoresActaConstitutiva_x_IdActaConstitutiva";
		List<beProveedoresActaConstitutiva> lbeProveedoresActaConstitutiva = null;
				beProveedoresActaConstitutiva obeProveedoresActaConstitutiva=new beProveedoresActaConstitutiva();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdActaConstitutiva", SqlDbType.Int).Value = IdActaConstitutiva;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeProveedoresActaConstitutiva = new List<beProveedoresActaConstitutiva>();
				while (datard.Read())
					{
					 obeProveedoresActaConstitutiva = new beProveedoresActaConstitutiva();
						obeProveedoresActaConstitutiva.IdActaConstitutiva =  datard.GetInt32(0);
						obeProveedoresActaConstitutiva.IdProveedor =  datard.GetInt32(1);
						obeProveedoresActaConstitutiva.NoEscritura =  datard.GetString(2);
						obeProveedoresActaConstitutiva.NoNotaria =  datard.GetString(3);
						obeProveedoresActaConstitutiva.Lugar =  datard.GetString(4);
						obeProveedoresActaConstitutiva.FechaEscritura =  datard.GetDateTime(5);
						obeProveedoresActaConstitutiva.FechaRegistroPublico =  datard.GetDateTime(6);
						obeProveedoresActaConstitutiva.NoFolioRegistro =  datard.GetString(7);
						obeProveedoresActaConstitutiva.Actualizacion =  datard.GetInt32(8);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeProveedoresActaConstitutiva;
			}
	}
	public List< beProveedoresActaConstitutiva> listarTodos_ProveedoresActaConstitutiva(SqlConnection Conexion)
	 {
		string sp = "Proc_ProveedoresActaConstitutiva_Traer_Todos";
		List<beProveedoresActaConstitutiva> lbeProveedoresActaConstitutiva = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeProveedoresActaConstitutiva = new List<beProveedoresActaConstitutiva>();
				beProveedoresActaConstitutiva obeProveedoresActaConstitutiva;
				while (datard.Read())
				{
					 obeProveedoresActaConstitutiva = new beProveedoresActaConstitutiva();
					obeProveedoresActaConstitutiva.IdActaConstitutiva =  datard.GetInt32(0);
					obeProveedoresActaConstitutiva.IdProveedor =  datard.GetInt32(1);
					obeProveedoresActaConstitutiva.NoEscritura =  datard.GetString(2);
					obeProveedoresActaConstitutiva.NoNotaria =  datard.GetString(3);
					obeProveedoresActaConstitutiva.Lugar =  datard.GetString(4);
					obeProveedoresActaConstitutiva.FechaEscritura =  datard.GetDateTime(5);
					obeProveedoresActaConstitutiva.FechaRegistroPublico =  datard.GetDateTime(6);
					obeProveedoresActaConstitutiva.NoFolioRegistro =  datard.GetString(7);
					obeProveedoresActaConstitutiva.Actualizacion =  datard.GetInt32(8);
					lbeProveedoresActaConstitutiva.Add(obeProveedoresActaConstitutiva);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeProveedoresActaConstitutiva;
		}
	}
	public DataTable listarProveedoresActaConstitutiva_x_(SqlConnection Conexion,int IdActaConstitutiva)
	 {
		string sp = "Proc_ProveedoresActaConstitutiva_Traer_Todos";
		DataTable dtProveedoresActaConstitutiva = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdActaConstitutiva", SqlDbType.Int).Value = IdActaConstitutiva;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtProveedoresActaConstitutiva = new DataTable();
				dtProveedoresActaConstitutiva.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtProveedoresActaConstitutiva;
		}
	}
    
    /* Get All 28/08/2018 */
    public List<beProveedoresActaConstitutiva> listarTodos_ProveedoresActaConstitutiva_GetAll(SqlConnection Conexion)
    {
        string sp = "Proc_ProveedoresActaConstitutiva_TraerTodos_GetAll";
        List<beProveedoresActaConstitutiva> lbeProveedoresActaConstitutiva = null;
        SqlCommand cmd = new SqlCommand(sp, Conexion);
        cmd.CommandType = CommandType.StoredProcedure;
        using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
        {
            try
            {
                if (datard != null)
                {
                    lbeProveedoresActaConstitutiva = new List<beProveedoresActaConstitutiva>();
                    beProveedoresActaConstitutiva obeProveedoresActaConstitutiva;
                    while (datard.Read())
                    {
                        obeProveedoresActaConstitutiva = new beProveedoresActaConstitutiva();
                        obeProveedoresActaConstitutiva.IdActaConstitutiva = datard.GetInt32(0);
                        obeProveedoresActaConstitutiva.IdProveedor = datard.GetInt32(1);
                        obeProveedoresActaConstitutiva.NoEscritura = datard.GetString(2);
                        obeProveedoresActaConstitutiva.NoNotaria = datard.GetString(3);
                        obeProveedoresActaConstitutiva.Lugar = datard.GetString(4);
                        obeProveedoresActaConstitutiva.FechaEscritura = datard.GetDateTime(5);
                        obeProveedoresActaConstitutiva.FechaRegistroPublico = datard.GetDateTime(6);
                        obeProveedoresActaConstitutiva.NoFolioRegistro = datard.GetString(7);
                        obeProveedoresActaConstitutiva.Actualizacion = datard.GetInt32(8);

                        obeProveedoresActaConstitutiva.RazonSocial = datard.GetString(9);
                        
                        lbeProveedoresActaConstitutiva.Add(obeProveedoresActaConstitutiva);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeProveedoresActaConstitutiva;
        }
    }
    }
}
