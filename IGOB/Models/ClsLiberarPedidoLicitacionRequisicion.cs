using iGob.Entidades;
using iGob.ReglasNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class ClsLiberarPedidoLicitacionRequisicion
    {
       public bePedidosLicitaciones getPedido(int pIdPedido, int pIdLicitacion,int pIdperfil)
        {
            return (new brListadoLicitacionesInvitacionProveedores()).LiberarPedido_IdLicitacion(pIdLicitacion, pIdperfil).Where(s => s.IdPedido == pIdPedido).FirstOrDefault();
        }
        public beDependencias getDependencias(int IdDependencia)
        {
            return new brDependencias().traerDependencias_x_IdDependencia(IdDependencia);
        }
        public beProveedores getProveedores(int IdProveedor)
        {
            return new brProveedores().traerProveedores_x_IdProveedor(IdProveedor);
        }
        public beEF_Municipios getMunicipios(string IdMunicipio)
        {
            return new brEF_Municipios().traerEF_Municipios_x_IdMunicipio(IdMunicipio);
        }
        public beEF_EntidadesFederativas getEntidadesFederativas(string ClaveEstado)
        {
            return new brEF_EntidadesFederativas().traerEF_EntidadesFederativas_x_ClaveEstado(ClaveEstado);
        }
        public beEF_Paises getPais(int IdPais)
        {
            return new brEF_Paises().traerEF_Paises_x_IdPais(IdPais);
        }
        public beRequisicionesCondicionesEntregas getRequisicionesCondicionesEntregas(int IdRequisicion)
        {
            return (new brRequisicionesCondicionesEntregas()).traerRequisicionesCondicionesEntregas_x_IdRequisicion(IdRequisicion);
        }
        public beRequisicionesCondicionesPagos getRequisicionesCondicionesPagos(int IdRequisicion)
        {
            return (new brRequisicionesCondicionesPagos()).listarTodos_RequisicionesCondicionesPagos().FirstOrDefault(s => s.IdRequisicion == IdRequisicion);
        }
        public beCondicionesPagosEntrega getCondiconPago(int IdTipoCondicionPago)
        {
            return (new brCondicionesPagosEntrega()).traerCondicionesPagosEntrega_x_IdCondicion(IdTipoCondicionPago);
        }
        public beTiposEntregas getTipoEntrega(int IdTipoEntrega)
        {
            return (new brTiposEntregas()).traerTiposEntregas_x_IdTipoEntrega(IdTipoEntrega);
        }
        public bePlazosTiempos getPlazosTiempos(int IdPlazoTiempo)
        {
            return (new brPlazosTiempos()).traerPlazosTiempos_x_IdPlazoTiempo(IdPlazoTiempo);
        }
        public List<beManifiestoProveedoresDeclaratorias> getManifiestoProveedoresDeclaratorias(int IdPedido)
        {
            return (new brManifiestoProveedoresDeclaratorias()).getPedidoManifiestos_x_IdPedido(IdPedido);
        }
        public List<bePedidosFirmantesLiberar> getListadoLicitacionesInvitacionProveedores(int IdPedido,int IdPerfil,string usuario)
        {
            var lst = (new brListadoLicitacionesInvitacionProveedores()).getAllPedidosFirmantes_IdPedido(IdPedido);
            var maxObj = lst.Where(obj => obj.IdUsuarioFirmante != 0).ToList();
            if (maxObj.Count == 0)
            {
                
                lst.ForEach(x => {
                    if (x.IdPerfil == IdPerfil)
                    {
                        x.NombreCompleto = usuario;
                        x.check = x.IdUsuarioFirmante == 0 ? "" : "checked";
                        x.activo = x.IdUsuarioFirmante == 0 ?x.Ordenamiento==1? "" : "disabledClick" : "disabledClick";
                    }
                    if (x.IdPerfil != IdPerfil)
                    {
                        x.check = x.IdUsuarioFirmante == 0 ? "" : "checked";
                        x.activo = "disabledClick";
                    }
                });
            }
            else
            {
                var max = maxObj.Max(x => x.Ordenamiento);
                lst.ForEach(x => {
                    if (x.IdPerfil == IdPerfil)
                    {
                        x.NombreCompleto = usuario;
                        x.check = x.IdUsuarioFirmante == 0 ? "" : "checked";
                        x.activo = x.IdUsuarioFirmante == 0 ? (max==(x.Ordenamiento-1))? "" : "disabledClick" : "disabledClick";
                    }
                    if (x.IdPerfil != IdPerfil)
                    {
                        
                        x.check = x.IdUsuarioFirmante == 0 ? "" : "checked";
                        x.activo = "disabledClick";
                    }
                });
            }
            return lst;
        }
        public string GetPartida_x_Id(int idPartida)
        {
            brPartidas b = new brPartidas();

            var c = b.traerPartidas_x_IdPartida(idPartida);
            var d = c.Partida = c.ClavePartida.Replace(" ", string.Empty) + " " + c.Partida;

            return d;
        }
        public List<bePedidoDetallesLotesEntregas> getPedidoDetallesLotesEntregas_x_IdPedido(int IdPedido)
        {
            return (new brManifiestoProveedoresDeclaratorias()).getPedidoDetallesLotesEntregas_x_IdPedido(IdPedido);
        }
        public bePedidosFirmantes getPedidoFirmantes(int IdPedidoFirmante)
        {
            return (new brPedidosFirmantes()).traerPedidosFirmantes_x_IdPedidoFirmante(IdPedidoFirmante);
        }
        public int savePedidoFirmantes(bePedidosFirmantes PedidosFirmantes)
        {
            return (new brPedidosFirmantes()).actualizarPedidosFirmantes(PedidosFirmantes);
        }
        public bePlazosEntregas getAllPlazoEntrega(int pIdPlazoEntrega)
        {
            var plazo = (new brPlazosEntregas()).listarTodos_PlazosEntregas();

            return plazo.Where(s => s.Activo == true && s.IdPlazoEntrega== pIdPlazoEntrega).FirstOrDefault();
        }
        public beRequisicionesCondicionesEntregas getAllRequisicionCondiconesDeEntrega_x_IdRequisicion(int pIdRequisicion)
        {
            var RequisicionCondiconesDeEntrega = (new brRequisicionesCondicionesEntregas()).traerRequisicionesCondicionesEntregas_x_IdRequisicion(pIdRequisicion);

            return RequisicionCondiconesDeEntrega;
        }
        public bePedidos getPedido(int pIdPedido)
        {
            return (new brPedidos()).traerPedidos_x_IdPedido(pIdPedido);
        }
        public int savePedido(bePedidos oPedido)
        {
            return (new brPedidos()).actualizarPedidos(oPedido);
        }
    }
}