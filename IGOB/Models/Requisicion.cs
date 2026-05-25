using iGob.Entidades;
using IGOB.Areas.Catalogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class Requisicion
    {
        public string Titulo = "REQUISICIONES";
        public bool Activar = false;
        
        public beRequisiciones oRequisicones= new beRequisiciones();
        public PresupuestoLiquidez presupuestoLiquidez = new PresupuestoLiquidez();
        public List<Carta> lstCartas = new List<Carta>();
        public List<beRequisicionesLiquidez> lstLiquidez = new List<beRequisicionesLiquidez>();
        public decimal sumLiquidez = decimal.MinValue;
        public List<beRequisicionLotesIdRequisicion> lstRequisicionLotesIdRequisicion = new List<beRequisicionLotesIdRequisicion>();
        public decimal sumRequisicionLote = decimal.MinValue;
        public beRequisicionesCondicionesEntregas condicionesDeEntrega = new beRequisicionesCondicionesEntregas();
        public List<beRequisicionCondicionesEntregaDetalleConsulta> lstRequisicionCondicionesEntregaDetalleConsulta = new List<beRequisicionCondicionesEntregaDetalleConsulta>();
        public beDependencias datosFacturacion = new beDependencias();
        public ClsGenerica datos = new ClsGenerica();
        public beRequisicionesCondicionesPagos condicionPago = new beRequisicionesCondicionesPagos();
        public List<ClsGenerica> condicionPagoDetalle = new List<ClsGenerica>();
        public beManifiestosProveedores oManifiestosProveedores = new beManifiestosProveedores();
        public List<beManifiestoProveedoresClientes> lstManifiestoProveedoresClientes = new List<beManifiestoProveedoresClientes>();
        public List<beManifiestoProveedoresDeclaratorias> lstManifiestoProveedoresDeclaratorias = new List<beManifiestoProveedoresDeclaratorias>();
        public beRequisicionLotesIdRequisicion oLotePropuestaTecnicaEconomica = new beRequisicionLotesIdRequisicion();
        public beManifiestoProveedoresClientes oManifiestoProveedoresClientes = new beManifiestoProveedoresClientes();
        public string extencionArchivoCatalogo = string.Empty;
        public string extencionArchivoCertificacicon = string.Empty;
        public beManifiestoProveedoresDeclaratorias oManifiestoProveedoresDeclaratorias = new beManifiestoProveedoresDeclaratorias();
        public beProveedoresRequisicionesInvitacion oProveedoresRequisicionesInvitacion = new beProveedoresRequisicionesInvitacion();
        public List<beProveedores> lstProveedoresxAsignar = new List<beProveedores>();
        public int IdTipoPropuesta = 0;
        public int IdTipoProceso = 0;
        public string activar = string.Empty;
        public string activarLotes = string.Empty;
        public string visibleEconimica = string.Empty;
        public string visibleTecnica = string.Empty;
        public string visibleTecnicaSolicitante = string.Empty;
        public string visibleTecnicaRevisor = string.Empty;
        public string activarTecnicaSolicitante = string.Empty;
        public string activarTecnicaRevisor = string.Empty;
        public int IdPerfil = 0;
        public Requisicion()
        {
            if(oRequisicones.IdRequisicion == 0)
                oRequisicones.NumeroLicitacion = 1;
        }
    }
}