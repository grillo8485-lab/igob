using iGob.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGob.AccesoDatos
{
    public class daAdjudicacionesPedidosConsulta
    {
        public List<beAdjudicacionesPedidosConsulta> listarAdjudicacionesPedidosConsulta(SqlConnection Conexion, beGenerica oGenerico)
        {
            List<beAdjudicacionesPedidosConsulta> lbeAdjudicacionesPedidosConsulta = new List<beAdjudicacionesPedidosConsulta>();
            string sp = "Proc_PedidosAdjudicacionesProveedores_x_IdDependenciaProveedorAdquiscion";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = oGenerico.entero;  
            cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = oGenerico.entero2;
            cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = oGenerico.entero3;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {

                        int IdAdjudicacionPedido = datard.GetOrdinal("IdAdjudicacionPedido");
                        int Folio = datard.GetOrdinal("Folio");
                        int FolioNumero = datard.GetOrdinal("FolioNumero");
                        int IdEstatusPedido = datard.GetOrdinal("IdEstatusPedido");
                        int IdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
                        int AdjudicacionFolio = datard.GetOrdinal("AdjudicacionFolio");
                        int Rfc = datard.GetOrdinal("Rfc");
                        int RazonSocial = datard.GetOrdinal("RazonSocial");
                        int IdAdjudicacionProveedor = datard.GetOrdinal("IdAdjudicacionProveedor");
                        int EstatusPedido = datard.GetOrdinal("EstatusPedido");
                        int IdProveedor = datard.GetOrdinal("IdProveedor"); ;
                        int EstatusFirmaPedido = datard.GetOrdinal("EstatusFirmaPedido");

                        while (datard.Read())
                        {
                            beAdjudicacionesPedidosConsulta obeAdjudicacionesPedidosConsulta = new beAdjudicacionesPedidosConsulta();
                            obeAdjudicacionesPedidosConsulta.IdAdjudicacionPedido = datard.GetInt32(IdAdjudicacionPedido);
                            obeAdjudicacionesPedidosConsulta.Folio = datard.GetString(Folio);
                            obeAdjudicacionesPedidosConsulta.FolioNumero = datard.GetInt32(FolioNumero);
                            obeAdjudicacionesPedidosConsulta.IdEstatusPedido = datard.GetInt32(IdEstatusPedido);
                            obeAdjudicacionesPedidosConsulta.IdAdjudicacion = datard.GetInt32(IdAdjudicacion);
                            obeAdjudicacionesPedidosConsulta.AdjudicacionFolio = datard.GetString(AdjudicacionFolio);
                            obeAdjudicacionesPedidosConsulta.Rfc = datard.GetString(Rfc);
                            obeAdjudicacionesPedidosConsulta.RazonSocial = datard.GetString(RazonSocial);
                            obeAdjudicacionesPedidosConsulta.IdAdjudicacionProveedor = datard.GetInt32(IdAdjudicacionProveedor);
                            obeAdjudicacionesPedidosConsulta.EstatusPedido = datard.GetString(EstatusPedido);
                            obeAdjudicacionesPedidosConsulta.IdProveedor = datard.GetInt32(IdProveedor);
                            obeAdjudicacionesPedidosConsulta.EstatusFirmaPedido = datard.GetString(EstatusFirmaPedido);

                            lbeAdjudicacionesPedidosConsulta.Add(obeAdjudicacionesPedidosConsulta);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAdjudicacionesPedidosConsulta;
            }
        }
    }
}
