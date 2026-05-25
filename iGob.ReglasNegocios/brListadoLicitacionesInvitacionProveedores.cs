using iGob.AccesoDatos;
using iGob.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGob.ReglasNegocios
{
    public class brListadoLicitacionesInvitacionProveedores : brConexion
    {
        public List<beListadoLicitacionesInvitacionProveedores> ListadoLicitacionesInvitacionProveedores(int IdProveedor)
        {
            List<beListadoLicitacionesInvitacionProveedores> listadoInvitacionesProveedores = new List<beListadoLicitacionesInvitacionProveedores>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daListadoLicitacionesInvitacionProveedores a = new daListadoLicitacionesInvitacionProveedores();
                    listadoInvitacionesProveedores = a.ListadoGenerarLicitacion(con, IdProveedor);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listadoInvitacionesProveedores;
            }
        }
        public List<beListadoLicitacionesInvitacionProveedores> ListadoLicitacionesAceptadasProveedor(int IdProveedor)
        {
            List<beListadoLicitacionesInvitacionProveedores> listadoInvitacionesProveedores = new List<beListadoLicitacionesInvitacionProveedores>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daListadoLicitacionesInvitacionProveedores a = new daListadoLicitacionesInvitacionProveedores();
                    listadoInvitacionesProveedores = a.ListadoLicitacionesAceptadasProveedor(con, IdProveedor);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listadoInvitacionesProveedores;
            }
        }
        public List<beListadoLicitacionesInvitacionProveedores> Licitaciones_x_Revisor(int pIdUsuario)
        {
            List<beListadoLicitacionesInvitacionProveedores> listadoInvitacionesProveedores = new List<beListadoLicitacionesInvitacionProveedores>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daListadoLicitacionesInvitacionProveedores a = new daListadoLicitacionesInvitacionProveedores();
                    listadoInvitacionesProveedores = a.Licitaciones_x_Revisor(con, pIdUsuario);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listadoInvitacionesProveedores;
            }
        }
        public List<beListadoLicitacionesInvitacionProveedores> Licitacion_Requisiciones_Revisor(int pLisitacion)
        {
            List<beListadoLicitacionesInvitacionProveedores> listadoInvitacionesProveedores = new List<beListadoLicitacionesInvitacionProveedores>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daListadoLicitacionesInvitacionProveedores a = new daListadoLicitacionesInvitacionProveedores();
                    listadoInvitacionesProveedores = a.Licitacion_Requisiciones_Revisor(con, pLisitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listadoInvitacionesProveedores;
            }
        }

        public List<beListadoRequisicionLicitacion> ListadoRequisicionLicitacion(int IdInvitacion)
        {
            List<beListadoRequisicionLicitacion> ListadoRequisicionLicitacion = new List<beListadoRequisicionLicitacion>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daListadoLicitacionesInvitacionProveedores a = new daListadoLicitacionesInvitacionProveedores();
                    ListadoRequisicionLicitacion = a.ListadoRequisicionLicitacion(con, IdInvitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ListadoRequisicionLicitacion;
            }
        }
        public List<beListadoLicitacionesInvitacionProveedores> Licitaciones_x_SolictanteDependencia(int pIdDependencia)
        {
            List<beListadoLicitacionesInvitacionProveedores> listadoInvitacionesProveedores = new List<beListadoLicitacionesInvitacionProveedores>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daListadoLicitacionesInvitacionProveedores a = new daListadoLicitacionesInvitacionProveedores();
                    listadoInvitacionesProveedores = a.Licitaciones_x_SolictanteDependencia(con, pIdDependencia);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listadoInvitacionesProveedores;
            }
        }
        public List<beListadoRequisicionLicitacion> ListadoRequisicionLicitacionSolictanteDependencia(int pIdLicitacion,int pIdDependencia)
        {
            List<beListadoRequisicionLicitacion> ListadoRequisicionLicitacion = new List<beListadoRequisicionLicitacion>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daListadoLicitacionesInvitacionProveedores a = new daListadoLicitacionesInvitacionProveedores();
                    ListadoRequisicionLicitacion = a.ListadoRequisicionLicitacionSolictanteDependencia(con, pIdLicitacion, pIdDependencia);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ListadoRequisicionLicitacion;
            }
        }
        public List<beListadoRequisicionLicitacion> ListadoRequisicionLicitacionRevisor_x_IdLicitacion(int pIdLicitacion)
        {
            List<beListadoRequisicionLicitacion> ListadoRequisicionLicitacion = new List<beListadoRequisicionLicitacion>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daListadoLicitacionesInvitacionProveedores a = new daListadoLicitacionesInvitacionProveedores();
                    ListadoRequisicionLicitacion = a.ListadoRequisicionLicitacionRevisor_x_IdLicitacion(con, pIdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ListadoRequisicionLicitacion;
            }
        }

        //Revisor
        public List<beListadoRequisicionLicitacion> PropuestasTecnicasRevisor_IdLicitacion(int pIdLicitacion)
        {
            List<beListadoRequisicionLicitacion> ListadoRequisicionLicitacion = new List<beListadoRequisicionLicitacion>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daListadoLicitacionesInvitacionProveedores a = new daListadoLicitacionesInvitacionProveedores();
                    ListadoRequisicionLicitacion = a.PropuestasTecnicasRevisor_IdLicitacion(con, pIdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ListadoRequisicionLicitacion;
            }
        }

        //Solicitante
        public List<beListadoRequisicionLicitacion> PropuestasTecnicasSolicitante_IdRequisicion(int pIdLicitacion)
        {
            List<beListadoRequisicionLicitacion> ListadoRequisicionLicitacion = new List<beListadoRequisicionLicitacion>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daListadoLicitacionesInvitacionProveedores a = new daListadoLicitacionesInvitacionProveedores();
                    ListadoRequisicionLicitacion = a.PropuestasTecnicasSolicitante_IdRequisicion(con, pIdLicitacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ListadoRequisicionLicitacion;
            }
        }
        public List<beListadoRequisicionLicitacion> ListadoRequisicionLicitacionSolictanteDependenciaDictamenTecnico(int pIdLicitacion, int pIdDependencia)
        {
            List<beListadoRequisicionLicitacion> ListadoRequisicionLicitacion = new List<beListadoRequisicionLicitacion>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daListadoLicitacionesInvitacionProveedores a = new daListadoLicitacionesInvitacionProveedores();
                    ListadoRequisicionLicitacion = a.ListadoRequisicionLicitacionSolictanteDependenciaDictamenTecnico(con, pIdLicitacion, pIdDependencia);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ListadoRequisicionLicitacion;
            }
        }
        //Revisor
        public List<beListadoRequisicionLicitacion> DictamenPropuestasTecnicasRevisor_IdLicitacion_IdEstatus(int pIdLicitacion,int pIdEstatus)
        {
            List<beListadoRequisicionLicitacion> ListadoRequisicionLicitacion = new List<beListadoRequisicionLicitacion>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daListadoLicitacionesInvitacionProveedores a = new daListadoLicitacionesInvitacionProveedores();
                    ListadoRequisicionLicitacion = a.DictamenPropuestasTecnicasRevisor_IdLicitacion_IdEstatus(con, pIdLicitacion, pIdEstatus);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ListadoRequisicionLicitacion;
            }
        }
        //Revisor
        public List<bePedidosLicitaciones> LiberarPedido_IdLicitacion(int pIdLicitacion,int pIdPerfil)
        {
            List<bePedidosLicitaciones> ListadoRequisicionLicitacion = new List<bePedidosLicitaciones>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daListadoLicitacionesInvitacionProveedores a = new daListadoLicitacionesInvitacionProveedores();
                    ListadoRequisicionLicitacion = a.LiberarPedido_IdLicitacion(con, pIdLicitacion, pIdPerfil);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ListadoRequisicionLicitacion;
            }
        }
        //Revisor
        public List<bePedidosFirmantesLiberar> getAllPedidosFirmantes_IdPedido(int pIdPedido)
        {
            List<bePedidosFirmantesLiberar> ListadoRequisicionLicitacion = new List<bePedidosFirmantesLiberar>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daListadoLicitacionesInvitacionProveedores a = new daListadoLicitacionesInvitacionProveedores();
                    ListadoRequisicionLicitacion = a.getAllPedidosFirmantes_IdPedido(con, pIdPedido);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ListadoRequisicionLicitacion;
            }
        }
        //Solicitante
        public List<bePedidosLicitaciones> LiberarPedido_IdLicitacion_IdDependencia(int pIdLicitacion,int pIdDependencia,int pIdPerfil)
        {
            List<bePedidosLicitaciones> ListadoRequisicionLicitacion = new List<bePedidosLicitaciones>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daListadoLicitacionesInvitacionProveedores a = new daListadoLicitacionesInvitacionProveedores();
                    ListadoRequisicionLicitacion = a.LiberarPedido_IdLicitacion_IdDependencia(con, pIdLicitacion, pIdDependencia, pIdPerfil);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ListadoRequisicionLicitacion;
            }
        }
        //4.	Director adquisiciones
        public List<beListadoLicitacionesInvitacionProveedores> getAllDirectorAdquisiciones()
        {
            List<beListadoLicitacionesInvitacionProveedores> listadoInvitacionesProveedores = new List<beListadoLicitacionesInvitacionProveedores>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daListadoLicitacionesInvitacionProveedores a = new daListadoLicitacionesInvitacionProveedores();
                    listadoInvitacionesProveedores = a.getAllDirectorAdquisiciones(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listadoInvitacionesProveedores;
            }
        }
        //Proveedor
        public List<bePedidosLicitaciones> LiberarPedido_Proveedor(int pIdLicitacion, int pIdProveedor,int IdPerfil)
        {
            List<bePedidosLicitaciones> ListadoRequisicionLicitacion = new List<bePedidosLicitaciones>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daListadoLicitacionesInvitacionProveedores a = new daListadoLicitacionesInvitacionProveedores();
                    ListadoRequisicionLicitacion = a.LiberarPedido_Proveedor(con, pIdLicitacion, pIdProveedor, IdPerfil);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ListadoRequisicionLicitacion;
            }
        }
    }
}
