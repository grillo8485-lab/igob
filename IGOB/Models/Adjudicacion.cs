using iGob.Entidades;
using IGOB.Areas.Catalogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class Adjudicacion
    {

        public string Titulo = "REQUISICIONES";
        public bool Activar = false;
        public int isCheckTec = 0;
        public int isCheckEco = 0;

        public beAdjudicaciones oAdjudicaciones = new beAdjudicaciones();
        public beAdjudicacionesLiquidez presupuestoLiquidez = new beAdjudicacionesLiquidez();    
        public List<beAdjudicacionesLotes> lstAdjudicacionLotes_x_IdAdjudicacion = new List<beAdjudicacionesLotes>();
        public List<Carta> lstCartas = new List<Carta>();
        public List<beAdjudicacionesLiquidez> lstLiquidez = new List<beAdjudicacionesLiquidez>();
        public decimal sumLiquidez = decimal.MinValue;
        public decimal sumAdjudicacionLote = decimal.MinValue;
        public beAdjudicacionesCondicionesEntregas condicionesDeEntrega = new beAdjudicacionesCondicionesEntregas();

        public List<beAdjudicacionesCondicionesEntregasDetalles> lstAdjudicacionCondicionesEntregaDetalleConsulta = new List<beAdjudicacionesCondicionesEntregasDetalles>();

        public beDependencias datosFacturacion = new beDependencias();
        public ClsGenerica datos = new ClsGenerica();
        public beAdjudicacionesCondicionesPagos condicionPago = new beAdjudicacionesCondicionesPagos();
        public List<ClsGenerica> condicionPagoDetalle = new List<ClsGenerica>();

        public List<beProveedores> lstProveedoresxAsignar = new List<beProveedores>();



    }
}