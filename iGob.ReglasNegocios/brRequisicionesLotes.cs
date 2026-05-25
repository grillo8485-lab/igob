using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brRequisicionesLotes : brConexion
    {
        public int guardarRequisicionesLotes(beRequisicionesLotes obeRequisicionesLotes)
        {
            int IdLote;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesLotes odaRequisicionesLotes = new daRequisicionesLotes();
                    IdLote = odaRequisicionesLotes.guardarRequisicionesLotes(con, obeRequisicionesLotes);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdLote;
            }
        }

        public int actualizarRequisicionesLotes(beRequisicionesLotes obeRequisicionesLotes)
        {
            int IdLote;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesLotes odaRequisicionesLotes = new daRequisicionesLotes();
                    IdLote = odaRequisicionesLotes.actualizarRequisicionesLotes(con, obeRequisicionesLotes);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdLote;
            }
        }

        public int eliminarRequisicionesLotes(int IdLote)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesLotes odaRequisicionesLotes = new daRequisicionesLotes();
                    IdLote = odaRequisicionesLotes.eliminarRequisicionesLotes(con, IdLote);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdLote;
            }
        }

        public beRequisicionesLotes traerRequisicionesLotes_x_IdLote(int IdLote)
        {
            beRequisicionesLotes obeRequisicionesLotes = new beRequisicionesLotes();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesLotes odaRequisicionesLotes = new daRequisicionesLotes();
                    obeRequisicionesLotes = odaRequisicionesLotes.traerRequisicionesLotes_x_IdLote(con, IdLote);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRequisicionesLotes;
            }
        }

        public List<beRequisicionesLotes> listarTodos_RequisicionesLotes()
        {
            List<beRequisicionesLotes> lbeRequisicionesLotes = new List<beRequisicionesLotes>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesLotes odaRequisicionesLotes = new daRequisicionesLotes();
                    lbeRequisicionesLotes = odaRequisicionesLotes.listarTodos_RequisicionesLotes(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesLotes;
            }
        }
        public List<beRequisicionesLotes> listarTodos_RequisicionesLotes_GetAll()
        {
            List<beRequisicionesLotes> lbeRequisicionesLotes = new List<beRequisicionesLotes>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesLotes odaRequisicionesLotes = new daRequisicionesLotes();
                    lbeRequisicionesLotes = odaRequisicionesLotes.listar_RequisicionesLotes_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesLotes;
            }
        }
        public List<beGenerica> listarTodos_RequisicionesLotes_x_IdPartida_BienServicio(beGenerica oGenerica)
        {
            List<beGenerica> lbeRequisicionesLotes = new List<beGenerica>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesLotes odaRequisicionesLotes = new daRequisicionesLotes();
                    lbeRequisicionesLotes = odaRequisicionesLotes.listarTodos_RequisicionesLotes_x_IdPartida_BienServicio(con, oGenerica);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesLotes;
            }
        }
        public beGenerica traerRequisicionesLotes_x_IdBienServicio(int IdBienServicio)
        {
            beGenerica oGenerica = new beGenerica();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesLotes odaRequisicionesLotes = new daRequisicionesLotes();
                    oGenerica = odaRequisicionesLotes.traerRequisicionesLotes_x_IdBienServicio(con, IdBienServicio);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return oGenerica;
            }
        }
        public List<beRequisicionLotesIdRequisicion> traerRequisicionesLotes_x_IdRequisicion(int IdRequisicion)
        {
            List<beRequisicionLotesIdRequisicion> lstbeRequisicionLotesIdRequisicion = new List<beRequisicionLotesIdRequisicion>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesLotes odaRequisicionesLotes = new daRequisicionesLotes();
                    lstbeRequisicionLotesIdRequisicion = odaRequisicionesLotes.traerRequisicionesLotes_x_IdRequisicion(con, IdRequisicion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lstbeRequisicionLotesIdRequisicion;
            }
        }

        public List<beRequisicionLotesIdRequisicion> traerRequisicionesLotes_x_IdProveedorRqInvitacion(int pIdProveedorRqInvitacion)
        {
            List<beRequisicionLotesIdRequisicion> lstbeRequisicionLotesIdRequisicion = new List<beRequisicionLotesIdRequisicion>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesLotes odaRequisicionesLotes = new daRequisicionesLotes();
                    lstbeRequisicionLotesIdRequisicion = odaRequisicionesLotes.traerRequisicionesLotes_x_IdProveedorRqInvitacion(con, pIdProveedorRqInvitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lstbeRequisicionLotesIdRequisicion;
            }
        }
        public List<beGenerica> listarTodos_BienServicio_x_Producto(beGenerica oGenerica)
        {
            List<beGenerica> lbeRequisicionesLotes = new List<beGenerica>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesLotes odaRequisicionesLotes = new daRequisicionesLotes();
                    lbeRequisicionesLotes = odaRequisicionesLotes.listarTodos_BienServicio_x_Producto(con, oGenerica);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesLotes;
            }
        }
    }
}
