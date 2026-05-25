using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brDependencias:brConexion
		 {
	        public int guardarDependencias(beDependencias obeDependencias)
	        {
		        int IdDependencia;
		        using (SqlConnection con = new SqlConnection(CadenaConexion))
		        {
		        try {
			        con.Open();
	                daDependencias odaDependencias= new daDependencias();
	                IdDependencia =  odaDependencias.guardarDependencias(con, obeDependencias);
		        }
		        catch (Exception ex) {
			        throw ex;
		        }
		        return IdDependencia;
		        }
	        }

	        public int actualizarDependencias(beDependencias obeDependencias)
	        {
		        int IdDependencia;
		        using (SqlConnection con = new SqlConnection(CadenaConexion))
		        {
		        try {
			        con.Open();
			        daDependencias odaDependencias= new daDependencias();
			        IdDependencia =  odaDependencias.actualizarDependencias(con, obeDependencias);
			        }
		        catch (Exception ex) {
			        throw ex;
		        }
		        return IdDependencia;
		        }
	        }

	        public int eliminarDependencias(int IdDependencia)
	        {
		        using (SqlConnection con = new SqlConnection(CadenaConexion))
		        {
		        try {
			        con.Open();
			        daDependencias odaDependencias= new daDependencias();
			        IdDependencia =  odaDependencias.eliminarDependencias(con, IdDependencia);
			        }
		        catch (Exception ex) {
			        throw ex;
		        }
		        return IdDependencia;
		        }
	        }

	        public beDependencias traerDependencias_x_IdDependencia (int IdDependencia)
	        {
		        beDependencias obeDependencias=new beDependencias();
		        using (SqlConnection con = new SqlConnection(CadenaConexion))
		        {
		        try {
			        con.Open();
			        daDependencias odaDependencias= new daDependencias();
				        obeDependencias =  odaDependencias.traerDependencias_x_IdDependencia(con, IdDependencia);
		        }
		        catch (Exception ex) {
			        throw ex;
		        }
		        return obeDependencias;
		        }
	        }

	        public List<beDependencias> listarTodos_Dependencias()
	         {
		        List<beDependencias> lbeDependencias =new List<beDependencias>();
		        using (SqlConnection con = new SqlConnection(CadenaConexion))
			        {
			        try {
				        con.Open();
				        daDependencias odaDependencias= new daDependencias();
				         lbeDependencias =  odaDependencias.listarTodos_Dependencias(con);
			        }
			        catch (Exception ex) {
			        throw ex;
			        }
			        return lbeDependencias;
		        }
	        }

            public List<beDependencias> Listar_Dependencias_GetAll()
            {
                List<beDependencias> lbeDependencias = new List<beDependencias>();
                using (SqlConnection con = new SqlConnection(CadenaConexion))
                {
                    try
                    {
                        con.Open();
                        daDependencias odaDependencias = new daDependencias();
                        lbeDependencias = odaDependencias.Listar_Dependencias_GetAll(con);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    return lbeDependencias;
                }
            }
        }
}
