using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daDepartamentos
    {
	    public int guardarDepartamentos(SqlConnection Conexion, beDepartamentos obeDepartamentos)
	    {
		    int Id=0;
		    string sp = "Proc_DepartamentosInsertar";
		    using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			    {
			    try {
				    cmd.CommandType = CommandType.StoredProcedure;
				    cmd.Parameters.Add("@IdDepartamento", SqlDbType.Int).Value = obeDepartamentos.IdDepartamento;
				    cmd.Parameters.Add("@Departamento", SqlDbType.NVarChar).Value = obeDepartamentos.Departamento;
				    cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obeDepartamentos.IdDependencia;
				    cmd.Parameters.Add("@Responsable", SqlDbType.NVarChar).Value = obeDepartamentos.Responsable;
				    cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeDepartamentos.Activo;
			
				    Id =(int)cmd.ExecuteScalar();
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return Id;
			    }
	    }

	    public int actualizarDepartamentos(SqlConnection Conexion, beDepartamentos obeDepartamentos)
	    {
		    string sp = "Proc_DepartamentosActualizar";
		    using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		    {
			    try {
				    cmd.CommandType = CommandType.StoredProcedure;
				    cmd.Parameters.Add("@IdDepartamento", SqlDbType.Int).Value = obeDepartamentos.IdDepartamento;
				    cmd.Parameters.Add("@Departamento", SqlDbType.NVarChar).Value = obeDepartamentos.Departamento;
				    cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obeDepartamentos.IdDependencia;
				    cmd.Parameters.Add("@Responsable", SqlDbType.NVarChar).Value = obeDepartamentos.Responsable;
				    cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeDepartamentos.Activo;
			
				    cmd.ExecuteNonQuery();
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return 0;
			    }
	    }

	    public int eliminarDepartamentos(SqlConnection Conexion,int pIdDepartamento)
	    {
		    string sp = "Proc_DepartamentosEliminar";
		    using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		    {
			    try {
				    cmd.CommandType = CommandType.StoredProcedure;
				    cmd.Parameters.Add("@IdDepartamento", SqlDbType.Int).Value = pIdDepartamento;
				    cmd.ExecuteNonQuery();
				    }
				    catch (Exception ex) {
					    throw ex;
				    }
			    return 0;
			    }
	    }
	    public beDepartamentos traerDepartamentos_x_IdDepartamento(SqlConnection Conexion,int IdDepartamento)
	    {
		    string sp = "Proc_Departamentos_x_IdDepartamento";
				    beDepartamentos obeDepartamentos=null;
		    SqlCommand cmd = new SqlCommand(sp,Conexion);
		    cmd.CommandType = CommandType.StoredProcedure;
		    cmd.Parameters.Add("@IdDepartamento", SqlDbType.Int).Value = IdDepartamento;
		    using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		    {
			    try {
				    if (datard != null)
				    {
						    int posIdDepartamento = datard.GetOrdinal("IdDepartamento");
						    int posDepartamento = datard.GetOrdinal("Departamento");
						    int posIdDependencia = datard.GetOrdinal("IdDependencia");
						    int posResponsable = datard.GetOrdinal("Responsable");
						    int posActivo = datard.GetOrdinal("Activo");
					     obeDepartamentos = new beDepartamentos();
				    while (datard.Read())
					    {
						    obeDepartamentos.IdDepartamento =  datard.GetInt32(posIdDepartamento);
						    obeDepartamentos.Departamento =  datard.GetString(posDepartamento);
						    obeDepartamentos.IdDependencia =  datard.GetInt32(posIdDependencia);
						    obeDepartamentos.Responsable =  datard.GetString(posResponsable);
						    obeDepartamentos.Activo =  datard.GetBoolean(posActivo);
					    }
				    }
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return obeDepartamentos;
			    }
	    }
	    public List< beDepartamentos> listarTodos_Departamentos(SqlConnection Conexion)
	     {
		    string sp = "Proc_Departamentos_Traer_Todos";
		    List<beDepartamentos> lbeDepartamentos = null;
		    SqlCommand cmd = new SqlCommand(sp,Conexion);
		    cmd.CommandType = CommandType.StoredProcedure;
		    using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		    {
		    try {
			    if (datard != null)
			    {
						    int posIdDepartamento = datard.GetOrdinal("IdDepartamento");
						    int posDepartamento = datard.GetOrdinal("Departamento");
						    int posIdDependencia = datard.GetOrdinal("IdDependencia");
						    int posResponsable = datard.GetOrdinal("Responsable");
						    int posActivo = datard.GetOrdinal("Activo");
				    lbeDepartamentos = new List<beDepartamentos>();
				    beDepartamentos obeDepartamentos;
				    while (datard.Read())
				    {
					     obeDepartamentos = new beDepartamentos();
					    obeDepartamentos.IdDepartamento =  datard.GetInt32(posIdDepartamento);
					    obeDepartamentos.Departamento =  datard.GetString(posDepartamento);
					    obeDepartamentos.IdDependencia =  datard.GetInt32(posIdDependencia);
					    obeDepartamentos.Responsable =  datard.GetString(posResponsable);
					    obeDepartamentos.Activo =  datard.GetBoolean(posActivo);
					    lbeDepartamentos.Add(obeDepartamentos);
				    }
			    }
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbeDepartamentos;
		    }
	    }
	    public List< beDepartamentos> listar_Departamentos_GetAll(SqlConnection Conexion)
	     {
		    string sp = "Proc_Departamentos_TraerTodos_GetAll";
		    List<beDepartamentos> lbeDepartamentos = null;
		    SqlCommand cmd = new SqlCommand(sp,Conexion);
		    cmd.CommandType = CommandType.StoredProcedure;
		    using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		    {
		    try {
			    if (datard != null)
			    {
						    int posIdDepartamento = datard.GetOrdinal("IdDepartamento");
						    int posDepartamento = datard.GetOrdinal("Departamento");
						    int posIdDependencia = datard.GetOrdinal("IdDependencia");
						    int posResponsable = datard.GetOrdinal("Responsable");
						    int posActivo = datard.GetOrdinal("Activo");
				    lbeDepartamentos = new List<beDepartamentos>();
				    beDepartamentos obeDepartamentos;
				    while (datard.Read())
				    {
					     obeDepartamentos = new beDepartamentos();
					    obeDepartamentos.IdDepartamento =  datard.GetInt32(posIdDepartamento);
					    obeDepartamentos.Departamento =  datard.GetString(posDepartamento);
					    obeDepartamentos.IdDependencia =  datard.GetInt32(posIdDependencia);
					    obeDepartamentos.Responsable =  datard.GetString(posResponsable);
					    obeDepartamentos.Activo =  datard.GetBoolean(posActivo);
			    // debe agregar campos de la Vista
					    lbeDepartamentos.Add(obeDepartamentos);
				    }
			    }
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbeDepartamentos;
		    }
	    }

        public List<beDepartamentos> traerDepartamentos_x_IdDependencia(SqlConnection Conexion, int IdDependencia)
        {
            string sp = "Proc_Departamentos_x_IdDependencia";
            List<beDepartamentos> lbeDepartamentos = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = IdDependencia;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdDepartamento = datard.GetOrdinal("IdDepartamento");
                        int posDepartamento = datard.GetOrdinal("Departamento");
                        int posIdDependencia = datard.GetOrdinal("IdDependencia");
                        int posResponsable = datard.GetOrdinal("Responsable");
                        lbeDepartamentos = new List<beDepartamentos>();
                        beDepartamentos obeDepartamentos;
                        while (datard.Read())
                        {
                            obeDepartamentos = new beDepartamentos();
                            obeDepartamentos.IdDepartamento = datard.GetInt32(posIdDepartamento);
                            obeDepartamentos.Departamento = datard.GetString(posDepartamento);
                            obeDepartamentos.IdDependencia = datard.GetInt32(posIdDependencia);
                            obeDepartamentos.Responsable = datard.GetString(posResponsable);
                            lbeDepartamentos.Add(obeDepartamentos);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeDepartamentos;
            }
        }
    }
}
