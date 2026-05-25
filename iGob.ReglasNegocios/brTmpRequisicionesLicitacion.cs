using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brTmpRequisicionesLicitacion : brConexion
    {
        public int guardarTmpRequisicionesLicitacion(beTmpRequisicionesLicitacion obeTmpRequisicionesLicitacion)
        {
            int IdRequisicion;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTmpRequisicionesLicitacion odaTmpRequisicionesLicitacion = new daTmpRequisicionesLicitacion();
                    IdRequisicion = odaTmpRequisicionesLicitacion.guardarTmpRequisicionesLicitacion(con, obeTmpRequisicionesLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdRequisicion;
            }
        }

        public int actualizarTmpRequisicionesLicitacion(beTmpRequisicionesLicitacion obeTmpRequisicionesLicitacion)
        {
            int IdRequisicion;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTmpRequisicionesLicitacion odaTmpRequisicionesLicitacion = new daTmpRequisicionesLicitacion();
                    IdRequisicion = odaTmpRequisicionesLicitacion.actualizarTmpRequisicionesLicitacion(con, obeTmpRequisicionesLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdRequisicion;
            }
        }

        public int eliminarTmpRequisicionesLicitacion(int IdRequisicion)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTmpRequisicionesLicitacion odaTmpRequisicionesLicitacion = new daTmpRequisicionesLicitacion();
                    IdRequisicion = odaTmpRequisicionesLicitacion.eliminarTmpRequisicionesLicitacion(con, IdRequisicion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdRequisicion;
            }
        }

        public beTmpRequisicionesLicitacion traerTmpRequisicionesLicitacion_x_IdRequisicion(int IdRequisicion)
        {
            beTmpRequisicionesLicitacion obeTmpRequisicionesLicitacion = new beTmpRequisicionesLicitacion();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTmpRequisicionesLicitacion odaTmpRequisicionesLicitacion = new daTmpRequisicionesLicitacion();
                    obeTmpRequisicionesLicitacion = odaTmpRequisicionesLicitacion.traerTmpRequisicionesLicitacion_x_IdRequisicion(con, IdRequisicion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeTmpRequisicionesLicitacion;
            }
        }

        public List<beTmpRequisicionesLicitacion> listarTodos_TmpRequisicionesLicitacion()
        {
            List<beTmpRequisicionesLicitacion> lbeTmpRequisicionesLicitacion = new List<beTmpRequisicionesLicitacion>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTmpRequisicionesLicitacion odaTmpRequisicionesLicitacion = new daTmpRequisicionesLicitacion();
                    lbeTmpRequisicionesLicitacion = odaTmpRequisicionesLicitacion.listarTodos_TmpRequisicionesLicitacion(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeTmpRequisicionesLicitacion;
            }
        }
        public List<beTmpRequisicionesLicitacion> listarTodos_TmpRequisicionesLicitacion_GetAll()
        {
            List<beTmpRequisicionesLicitacion> lbeTmpRequisicionesLicitacion = new List<beTmpRequisicionesLicitacion>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTmpRequisicionesLicitacion odaTmpRequisicionesLicitacion = new daTmpRequisicionesLicitacion();
                    lbeTmpRequisicionesLicitacion = odaTmpRequisicionesLicitacion.listar_TmpRequisicionesLicitacion_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeTmpRequisicionesLicitacion;
            }
        }
        public beTmpRequisicionesLicitacion getTmpRequisicionesLicitacion_x_Guid(string pGuid)
        {
            beTmpRequisicionesLicitacion obeTmpRequisicionesLicitacion = new beTmpRequisicionesLicitacion();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTmpRequisicionesLicitacion odaTmpRequisicionesLicitacion = new daTmpRequisicionesLicitacion();
                    obeTmpRequisicionesLicitacion = odaTmpRequisicionesLicitacion.getTmpRequisicionesLicitacion_x_Guid(con, pGuid);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeTmpRequisicionesLicitacion;
            }
        }
    }
}
