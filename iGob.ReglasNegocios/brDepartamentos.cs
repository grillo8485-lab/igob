using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
	public class brDepartamentos:brConexion
	{
	    public int guardarDepartamentos(beDepartamentos obeDepartamentos)
	    {
		    int IdDepartamento;
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
		    daDepartamentos odaDepartamentos= new daDepartamentos();
			    IdDepartamento =  odaDepartamentos.guardarDepartamentos(con, obeDepartamentos);
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return IdDepartamento;
			    }
	    }

	    public int actualizarDepartamentos(beDepartamentos obeDepartamentos)
	    {
		    int IdDepartamento;
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daDepartamentos odaDepartamentos= new daDepartamentos();
				    IdDepartamento =  odaDepartamentos.actualizarDepartamentos(con, obeDepartamentos);
				    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return IdDepartamento;
			    }
	    }

	    public int eliminarDepartamentos(int IdDepartamento)
	    {
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daDepartamentos odaDepartamentos= new daDepartamentos();
				    IdDepartamento =  odaDepartamentos.eliminarDepartamentos(con, IdDepartamento);
				    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return IdDepartamento;
			    }
	    }

	    public beDepartamentos traerDepartamentos_x_IdDepartamento (int IdDepartamento)
	    {
		    beDepartamentos obeDepartamentos=new beDepartamentos();
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daDepartamentos odaDepartamentos= new daDepartamentos();
				     obeDepartamentos =  odaDepartamentos.traerDepartamentos_x_IdDepartamento(con, IdDepartamento);
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return obeDepartamentos;
			    }
	    }

	    public List<beDepartamentos> listarTodos_Departamentos()
	     {
		    List<beDepartamentos> lbeDepartamentos =new List<beDepartamentos>();
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daDepartamentos odaDepartamentos= new daDepartamentos();
				     lbeDepartamentos =  odaDepartamentos.listarTodos_Departamentos(con);
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbeDepartamentos;
		    }
	    }
	    public List<beDepartamentos> listarTodos_Departamentos_GetAll()
	     {
		    List<beDepartamentos> lbeDepartamentos =new List<beDepartamentos>();
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daDepartamentos odaDepartamentos= new daDepartamentos();
				     lbeDepartamentos =  odaDepartamentos.listar_Departamentos_GetAll(con);
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbeDepartamentos;
		    }
	    }

        public List<beDepartamentos> traerDepartamentos_x_IdDependencia(int IdDependencia)
        {
            List<beDepartamentos> lbeDepartamentos = new List<beDepartamentos>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDepartamentos odaDepartamentos = new daDepartamentos();
                    lbeDepartamentos = odaDepartamentos.traerDepartamentos_x_IdDependencia(con, IdDependencia);
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
