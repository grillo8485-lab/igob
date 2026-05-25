using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
	public class brClavesPresupuestalesDetalles:brConexion
    {
        public int guardarClavesPresupuestalesDetalles(beClavesPresupuestalesDetalles obeClavesPresupuestalesDetalles)
	    {
		    int IdClavePresupuestalDetalle;
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
		        daClavesPresupuestalesDetalles odaClavesPresupuestalesDetalles= new daClavesPresupuestalesDetalles();
			    IdClavePresupuestalDetalle =  odaClavesPresupuestalesDetalles.guardarClavesPresupuestalesDetalles(con, obeClavesPresupuestalesDetalles);
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return IdClavePresupuestalDetalle;
			    }
	    }

	    public int actualizarClavesPresupuestalesDetalles(beClavesPresupuestalesDetalles obeClavesPresupuestalesDetalles)
	    {
		    int IdClavePresupuestalDetalle;
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daClavesPresupuestalesDetalles odaClavesPresupuestalesDetalles= new daClavesPresupuestalesDetalles();
				    IdClavePresupuestalDetalle =  odaClavesPresupuestalesDetalles.actualizarClavesPresupuestalesDetalles(con, obeClavesPresupuestalesDetalles);
				    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return IdClavePresupuestalDetalle;
			    }
	    }

	    public int eliminarClavesPresupuestalesDetalles(int IdClavePresupuestalDetalle)
	    {
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daClavesPresupuestalesDetalles odaClavesPresupuestalesDetalles= new daClavesPresupuestalesDetalles();
				    IdClavePresupuestalDetalle =  odaClavesPresupuestalesDetalles.eliminarClavesPresupuestalesDetalles(con, IdClavePresupuestalDetalle);
				    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return IdClavePresupuestalDetalle;
			    }
	    }

	    public beClavesPresupuestalesDetalles traerClavesPresupuestalesDetalles_x_IdClavePresupuestalDetalle (int IdClavePresupuestalDetalle)
	    {
		    beClavesPresupuestalesDetalles obeClavesPresupuestalesDetalles=new beClavesPresupuestalesDetalles();
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daClavesPresupuestalesDetalles odaClavesPresupuestalesDetalles= new daClavesPresupuestalesDetalles();
				     obeClavesPresupuestalesDetalles =  odaClavesPresupuestalesDetalles.traerClavesPresupuestalesDetalles_x_IdClavePresupuestalDetalle(con, IdClavePresupuestalDetalle);
			    }
			    catch (Exception ex) {
				    throw ex;
			    }
			    return obeClavesPresupuestalesDetalles;
			    }
	    }

	    public List<beClavesPresupuestalesDetalles> listarTodos_ClavesPresupuestalesDetalles()
	    {
		    List<beClavesPresupuestalesDetalles> lbeClavesPresupuestalesDetalles =new List<beClavesPresupuestalesDetalles>();
		    using (SqlConnection con = new SqlConnection(CadenaConexion))
			    {
			    try {
				    con.Open();
				    daClavesPresupuestalesDetalles odaClavesPresupuestalesDetalles= new daClavesPresupuestalesDetalles();
				     lbeClavesPresupuestalesDetalles =  odaClavesPresupuestalesDetalles.listarTodos_ClavesPresupuestalesDetalles(con);
			    }
			    catch (Exception ex) {
			    throw ex;
			    }
			    return lbeClavesPresupuestalesDetalles;
		    }
	    }

        public List<beClavesPresupuestalesDetalles> listar_ClavesPresupuestalesDetalles_IdPresupuestoPartida(int IdPresupuestoPartida)
        {
            List<beClavesPresupuestalesDetalles> lbeClavesPresupuestalesDetalles = new List<beClavesPresupuestalesDetalles>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daClavesPresupuestalesDetalles odaClavesPresupuestalesDetalles = new daClavesPresupuestalesDetalles();
                    lbeClavesPresupuestalesDetalles = odaClavesPresupuestalesDetalles.traer_ClavesPresupuestalesDetalles_x_IdClavePresupuestalDetalle(con, IdPresupuestoPartida);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeClavesPresupuestalesDetalles;
            }
        }

        public int eliminarClavesPresupuestalesDetalles_x_IdPresupuestoPartida(int IdPresupuestoPartida)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daClavesPresupuestalesDetalles odaClavesPresupuestalesDetalles = new daClavesPresupuestalesDetalles();
                    IdPresupuestoPartida = odaClavesPresupuestalesDetalles.eliminarClavesPresupuestalesDetalles_x_IdPresupuestoPartida(con, IdPresupuestoPartida);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdPresupuestoPartida;
            }
        }
    }
}
