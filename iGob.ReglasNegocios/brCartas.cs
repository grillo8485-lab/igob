using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brCartas : brConexion
    {
        public int guardarCartas(beCartas obeCartas)
        {
            int IdCarta;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCartas odaCartas = new daCartas();
                    IdCarta = odaCartas.guardarCartas(con, obeCartas);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdCarta;
            }
        }

        public int actualizarCartas(beCartas obeCartas)
        {
            int IdCarta;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCartas odaCartas = new daCartas();
                    IdCarta = odaCartas.actualizarCartas(con, obeCartas);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdCarta;
            }
        }

        public int eliminarCartas(int IdCarta)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCartas odaCartas = new daCartas();
                    IdCarta = odaCartas.eliminarCartas(con, IdCarta);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdCarta;
            }
        }

        public beCartas traerCartas_x_IdCarta(int IdCarta)
        {
            beCartas obeCartas = new beCartas();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCartas odaCartas = new daCartas();
                    obeCartas = odaCartas.traerCartas_x_IdCarta(con, IdCarta);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeCartas;
            }
        }

        public List<beCartas> listarTodos_Cartas()
        {
            List<beCartas> lbeCartas = new List<beCartas>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCartas odaCartas = new daCartas();
                    lbeCartas = odaCartas.listarTodos_Cartas(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCartas;
            }
        }
        public List<beCartas> listarTodos_Cartas_GetAll()
        {
            List<beCartas> lbeCartas = new List<beCartas>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCartas odaCartas = new daCartas();
                    lbeCartas = odaCartas.listar_Cartas_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCartas;
            }
        }

        public List<beCartas> listar_Cartas_x_IdRequisicion(int pIdrequisicion)
        {
            List<beCartas> lbeCartas = new List<beCartas>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCartas odaCartas = new daCartas();
                    lbeCartas = odaCartas.listar_Cartas_x_IdRequisicion(con, pIdrequisicion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCartas;
            }
        }

        public List<beCartas> listar_Cartas_x_IdProveedorRqInvitacion(int pIdProveedorRqInvitacion)
        {
            List<beCartas> lbeCartas = new List<beCartas>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCartas odaCartas = new daCartas();
                    lbeCartas = odaCartas.listar_Cartas_x_IdProveedorRqInvitacion(con, pIdProveedorRqInvitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCartas;
            }
        }
    }
}
