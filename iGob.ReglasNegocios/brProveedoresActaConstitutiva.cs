using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brProveedoresActaConstitutiva : brConexion
    {
        public int guardarProveedoresActaConstitutiva(beProveedoresActaConstitutiva obeProveedoresActaConstitutiva)
        {
            int IdActaConstitutiva;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProveedoresActaConstitutiva odaProveedoresActaConstitutiva = new daProveedoresActaConstitutiva();
                    IdActaConstitutiva = odaProveedoresActaConstitutiva.guardarProveedoresActaConstitutiva(con, obeProveedoresActaConstitutiva);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdActaConstitutiva;
            }
        }

        public int actualizarProveedoresActaConstitutiva(beProveedoresActaConstitutiva obeProveedoresActaConstitutiva)
        {
            int IdActaConstitutiva;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProveedoresActaConstitutiva odaProveedoresActaConstitutiva = new daProveedoresActaConstitutiva();
                    IdActaConstitutiva = odaProveedoresActaConstitutiva.actualizarProveedoresActaConstitutiva(con, obeProveedoresActaConstitutiva);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdActaConstitutiva;
            }
        }

        public int eliminarProveedoresActaConstitutiva(int IdActaConstitutiva)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProveedoresActaConstitutiva odaProveedoresActaConstitutiva = new daProveedoresActaConstitutiva();
                    IdActaConstitutiva = odaProveedoresActaConstitutiva.eliminarProveedoresActaConstitutiva(con, IdActaConstitutiva);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdActaConstitutiva;
            }
        }

        public beProveedoresActaConstitutiva traerProveedoresActaConstitutiva_x_IdActaConstitutiva(int IdActaConstitutiva)
        {
            beProveedoresActaConstitutiva obeProveedoresActaConstitutiva = new beProveedoresActaConstitutiva();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProveedoresActaConstitutiva odaProveedoresActaConstitutiva = new daProveedoresActaConstitutiva();
                    obeProveedoresActaConstitutiva = odaProveedoresActaConstitutiva.traerProveedoresActaConstitutiva_x_IdActaConstitutiva(con, IdActaConstitutiva);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeProveedoresActaConstitutiva;
            }
        }

        public List<beProveedoresActaConstitutiva> listarTodos_ProveedoresActaConstitutiva()
        {
            List<beProveedoresActaConstitutiva> lbeProveedoresActaConstitutiva = new List<beProveedoresActaConstitutiva>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProveedoresActaConstitutiva odaProveedoresActaConstitutiva = new daProveedoresActaConstitutiva();
                    lbeProveedoresActaConstitutiva = odaProveedoresActaConstitutiva.listarTodos_ProveedoresActaConstitutiva(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeProveedoresActaConstitutiva;
            }
        }

        public List<beProveedoresActaConstitutiva> listarTodos_ProveedoresActaConstitutivaGetAll()
        {
            List<beProveedoresActaConstitutiva> lbeProveedoresActaConstitutiva = new List<beProveedoresActaConstitutiva>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProveedoresActaConstitutiva odaProveedoresActaConstitutiva = new daProveedoresActaConstitutiva();
                    lbeProveedoresActaConstitutiva = odaProveedoresActaConstitutiva.listarTodos_ProveedoresActaConstitutiva_GetAll(con);
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
