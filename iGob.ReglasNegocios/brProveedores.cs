using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brProveedores:brConexion
		 {
	public int guardarProveedores(beProveedores obeProveedores)
	{
		int IdProveedor;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daProveedores odaProveedores= new daProveedores();
			IdProveedor =  odaProveedores.guardarProveedores(con, obeProveedores);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdProveedor;
			}
	}

	public int actualizarProveedores(beProveedores obeProveedores)
	{
		int IdProveedor;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedores odaProveedores= new daProveedores();
				IdProveedor =  odaProveedores.actualizarProveedores(con, obeProveedores);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdProveedor;
			}
	}

	public int eliminarProveedores(int IdProveedor)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedores odaProveedores= new daProveedores();
				IdProveedor =  odaProveedores.eliminarProveedores(con, IdProveedor);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdProveedor;
			}
	}

	public beProveedores traerProveedores_x_IdProveedor (int IdProveedor)
	{
		beProveedores obeProveedores=new beProveedores();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedores odaProveedores= new daProveedores();
				 obeProveedores =  odaProveedores.traerProveedores_x_IdProveedor(con, IdProveedor);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeProveedores;
			}
	}

	public List<beProveedores> listarTodos_Proveedores()
	 {
		List<beProveedores> lbeProveedores =new List<beProveedores>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daProveedores odaProveedores= new daProveedores();
				 lbeProveedores =  odaProveedores.listarTodos_Proveedores(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeProveedores;
		}
	}
    /* Get All 28/08/2018 */
    public List<beProveedores> listarTodos_Proveedores_GetAll()
    {
        List<beProveedores> lbeProveedores = new List<beProveedores>();
        using (SqlConnection con = new SqlConnection(CadenaConexion))
        {
            try
            {
                con.Open();
                daProveedores odaProveedores = new daProveedores();
                lbeProveedores = odaProveedores.listarTodos_Proveedores_GetAll(con);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeProveedores;
        }
    }
    /* Compras menores 28/08/2018 */
    public List<beProveedores> listarTodos_Proveedores_CM()
    {
        List<beProveedores> lbeProveedores = new List<beProveedores>();
        using (SqlConnection con = new SqlConnection(CadenaConexion))
        {
            try
            {
                con.Open();
                daProveedores odaProveedores = new daProveedores();
                lbeProveedores = odaProveedores.listarTodos_Proveedores_CM(con);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lbeProveedores;
        }
    }

        public List< beProveedores> getAllProveedores_x_IdAdjudicacion(int IdAdjudicacion)
        {

            List<beProveedores> lbeProveedores = new List<beProveedores>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProveedores odaProveedores = new daProveedores();
                    lbeProveedores = odaProveedores.getAllProveedores_x_IdAdjudicacion(con, IdAdjudicacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeProveedores;
            }
        }

        public List<beProveedores> getAllProveedores_x_IdPartida(int IdPartida)
        {

            List<beProveedores> lbeProveedores = new List<beProveedores>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProveedores odaProveedores = new daProveedores();
                    lbeProveedores = odaProveedores.getAllProveedores_x_IdPartida(con, IdPartida);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeProveedores;
            }
        }
        public List<beProveedores> getAllProveedores_x_IdRequisicion(int IdRequisicion)
        {

            List<beProveedores> lbeProveedores = new List<beProveedores>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProveedores odaProveedores = new daProveedores();
                    lbeProveedores = odaProveedores.getAllProveedores_x_IdRequisicion(con, IdRequisicion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeProveedores;
            }
        }
    }
}
