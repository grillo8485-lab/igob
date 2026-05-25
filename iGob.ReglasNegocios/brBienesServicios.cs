using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
	public class brBienesServicios:brConexion
	{
	    public int guardarBienesServicios(beBienesServicios obeBienesServicios)
	    {
		    int IdBienServicio;
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
		    daBienesServicios odaBienesServicios= new daBienesServicios();
			    IdBienServicio =  odaBienesServicios.guardarBienesServicios(con, obeBienesServicios);
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return IdBienServicio;
			    }
	    }

	    public int actualizarBienesServicios(beBienesServicios obeBienesServicios)
	    {
		    int IdBienServicio;
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daBienesServicios odaBienesServicios= new daBienesServicios();
				    IdBienServicio =  odaBienesServicios.actualizarBienesServicios(con, obeBienesServicios);
				    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return IdBienServicio;
			    }
	    }

	    public int eliminarBienesServicios(int IdBienServicio)
	    {
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daBienesServicios odaBienesServicios= new daBienesServicios();
				    IdBienServicio =  odaBienesServicios.eliminarBienesServicios(con, IdBienServicio);
				    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return IdBienServicio;
			    }
	    }

	    public beBienesServicios traerBienesServicios_x_IdBienServicio (int IdBienServicio)
	    {
		    beBienesServicios obeBienesServicios=new beBienesServicios();
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daBienesServicios odaBienesServicios= new daBienesServicios();
				     obeBienesServicios =  odaBienesServicios.traerBienesServicios_x_IdBienServicio(con, IdBienServicio);
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return obeBienesServicios;
			    }
	    }

	    public List<beBienesServicios> listarTodos_BienesServicios()
	     {
		    List<beBienesServicios> lbeBienesServicios =new List<beBienesServicios>();
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daBienesServicios odaBienesServicios= new daBienesServicios();
				     lbeBienesServicios =  odaBienesServicios.listarTodos_BienesServicios(con);
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbeBienesServicios;
		    }
	    }

        public List<beBienesServicios> listarTodos_GetAllBienesServicios()
        {
            List<beBienesServicios> lbeBienesServicios = new List<beBienesServicios>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daBienesServicios odaBienesServicios = new daBienesServicios();
                    lbeBienesServicios = odaBienesServicios.listarBienesServicios_x_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeBienesServicios;
            }
        }
        public List<beBienesServicios> listarTodos_GetAllBienesServicios_x_IdCapitulo(int pIdCapitulo/*,string cadena*/)
        {
            List<beBienesServicios> lbeBienesServicios = new List<beBienesServicios>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daBienesServicios odaBienesServicios = new daBienesServicios();
                    lbeBienesServicios = odaBienesServicios.listarTodos_GetAllBienesServicios_x_IdCapitulo(con, pIdCapitulo /*,cadena*/);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeBienesServicios;
            }
        }
    }
}

