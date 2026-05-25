using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;

namespace IGOB.Models
{
    public class ClsAdquisicion
    {
        public List<beCapitulos> Capitulos()
        {
            brCapitulos b = new brCapitulos();
            return b.listarTodos_Capitulos();
        }

        public List<beTiposAdjudicacion> getTiposAdjudicacion() {
            return (new brTiposAdjudicacion()).listarTodos_TiposAdjudicacion(); 
        }

        public List<beTiposSolicitud> TiposSolicitud()
        {
            brTiposSolicitud t = new brTiposSolicitud();
            return t.listarTodos_TiposSolicitud();
        }

        public List<bePartidas> getAllPartidas_x_IdCapitulo(int pIdCapitulo)
        {
            brPartidas b = new brPartidas();
            var c = b.listarPartidas_x_IdCapitulo(pIdCapitulo);
            foreach (var item in c)
            {
                item.Partida = item.ClavePartida + " " + item.Partida;
            }
            return c;
        }

        public List<beCapitulos> getAllCapitulos() {
            brCapitulos b = new brCapitulos();
            var c = b.listarTodos_Capitulos();
            foreach(var item in c)
            {
                item.Capitulo = item.ClaveCapitulo + " " + item.Capitulo; 
            }
            return c;
        }

        public beEjerciciosFiscales getEjercicioFiscal()
        {
            beEjerciciosFiscales a = new beEjerciciosFiscales();
            brEjerciciosFiscales b = new brEjerciciosFiscales();
            List<beEjerciciosFiscales> c = b.listarTodos_EjerciciosFiscales().Where(s => s.Activo == true).ToList();
            if (c.Count > 0)
            {
                a = c.First();
            }
            return a;
        }

        public bePresupuestosPartidas getPresupuestosPartidas(int pIdPartida, int pIdDependencia)
        {
            brPresupuestosPartidas b = new brPresupuestosPartidas();
            var c = b.listarTodos_PresupuestosPartidas().Where(x => x.IdPartida == pIdPartida && x.IdDependencia == pIdDependencia).FirstOrDefault();
            return c;
        }

        public int saveAdjudicacion(beAdjudicaciones beAdjudicaciones )
        {
            brAdjudicaciones r = new brAdjudicaciones();
            return r.guardarAdjudicaciones(beAdjudicaciones);
        }

        public beOrigenRecurso getAllOrigenRecurso_x_Id(int Id)
        {
            brOrigenRecurso O = new brOrigenRecurso();
            return O.traerOrigenRecurso_x_IdOrigenRecurso(Id);
        }

        public int getAllOrigenRecurso_x_IdAdjudicacion(int IdAdjudicacion)
        {
            brAdjudicacionesLiquidez O = new brAdjudicacionesLiquidez();
            List<int> lstOR = O.AdjudicacionLiquidez_Traer_IdAdjudicacion(IdAdjudicacion).Select( x => Convert.ToInt32(x.IdOrigenRecurso)).ToList();
            var r = 0;


            if (lstOR.Contains(2))
            {
                r = 2;
            }
            else if( lstOR.Contains(1) && lstOR.Contains(3) )
            {
                r = 4;
            }
            else if (lstOR.Contains(1))
            {
                r = 1;
            }
            else
            {
                r = 3;
            }

            return r;

        }

        public List<beAdjudicacionConsulta> consultaAdjudicacion(int pIdLista, int pIdPerfil, int pIdDependencia)
        {
            beGenerica oGenerico = new beGenerica();
            oGenerico.entero3 = pIdLista;
            oGenerico.entero2 = pIdPerfil;
            oGenerico.entero = pIdDependencia;
            brAdjudicacionConsulta b = new brAdjudicacionConsulta();
            return b.listarAdjudicacionConsulta(oGenerico);
        }

        public List<beAdjudicacionesPedidosConsulta> consultaAdjudicacionesPedidos(int IdDependencia, int IdProveedor, int IdPerfil)
        {
            beGenerica oGenerico = new beGenerica();
            oGenerico.entero3 = IdPerfil;
            oGenerico.entero2 = IdProveedor;
            oGenerico.entero = IdDependencia;
            brAdjudicacionesPedidosConsulta b = new brAdjudicacionesPedidosConsulta();
            return b.listarAdjudicacionesPedidosConsulta(oGenerico);
        }


        public List<beAdjudicacionConsulta> consultaAdjudicacionProveedor(int IdProveedor, int IdTipoAdjudicacion) {
            brAdjudicacionConsulta b = new brAdjudicacionConsulta();
            return b.listarAdjudicacionesConsultaProveedores(IdProveedor, IdTipoAdjudicacion);
        }

        public int GetEjercicioFiscal_x_IdAdjudicacion(int IdEjercicioFiscal)
        {
            brEjerciciosFiscales e = new brEjerciciosFiscales();

            return e.traerEjerciciosFiscales_x_IdEjercicioFiscal(IdEjercicioFiscal).Ejercicio;
        }

        public string GetOrigenRecurso_x_IdAdjudicacion(int IdOrigenRecurso)
        {
            brOrigenRecurso o = new brOrigenRecurso();

            return o.traerOrigenRecurso_x_IdOrigenRecurso(IdOrigenRecurso).OrigenRecurso;
        }

        public string GetDependencia_x_IdDependencia(int idDependencia)
        {
            brDependencias d = new brDependencias();

            return d.traerDependencias_x_IdDependencia(idDependencia).Dependencia;
        }

        public decimal GetMontoPresupuestadoAutorizado_x_IdAdjudicacion(int IdAdjudicacion)
        {
            brAdjudicaciones r = new brAdjudicaciones();

            return r.traerAdjudicaciones_x_IdAdjudicacion(IdAdjudicacion).MontoAproximadoAutorizado;
        }

        public string GetPartida_x_Id(int idPartida)
        {
            brPartidas b = new brPartidas();

            var c = b.traerPartidas_x_IdPartida(idPartida);
            var d = c.Partida = c.ClavePartida.Replace(" ", string.Empty) + " " + c.Partida;         

            return d;
        }

        public decimal Monto_Solicitado(int IdAdjudicacion)
        {
            brAdjudicaciones r = new brAdjudicaciones();
            var s = r.traerAdjudicaciones_x_IdAdjudicacion(IdAdjudicacion);

            return s.MontoAproximado;
        }

        public decimal Saldo_Presupuestado_Autorizado(int idPartida, int idDependencia)
        {
            var c = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            brPresupuestosPartidas p = new brPresupuestosPartidas();

            if (c.id == 8)
            {
                return 0;
            }else if( c.id != 3){

                 var q = p.listarTodos_PresupuestosPartidas().Where(x => x.IdPartida == idPartida && x.IdDependencia == idDependencia).FirstOrDefault();
                return q.MontoSaldo;
            }
            else{

                var q = p.listarTodos_PresupuestosPartidas().Where(x => x.IdPartida == idPartida && x.IdDependencia == c.id4).FirstOrDefault();
                return q.MontoSaldo;
            }

            //var q = p.traerPresupuestosPartidas_x_IdPartida(idPartida);


        }

        public decimal Monto_Aproximado_Autorizado(int IdAdjudicacion)
        {
            brAdjudicaciones r = new brAdjudicaciones();
            var s = r.traerAdjudicaciones_x_IdAdjudicacion(IdAdjudicacion);

            return s.MontoAproximadoAutorizado;
        }

        public int GetIdPartida_x_IdAdjudicacion(int IdAdjudicacion)
        {
            brAdjudicaciones a = new brAdjudicaciones();
            var b = a.traerAdjudicaciones_x_IdAdjudicacion(IdAdjudicacion);

            return b.IdPartida;
        }

        public bePresupuestosPartidas GetPresupuestoPartida_x_IdPartida_IdDependencia_IdEjercicioFiscal(int IdPartida, int IdDependencia, int IdEjercicioFiscal)
        {
            brPresupuestosPartidas a = new brPresupuestosPartidas();
            var o = new bePresupuestosPartidas();
            var f = a.listarTodos_PresupuestosPartidas().Where(x => x.IdPartida == IdPartida && x.IdDependencia == IdDependencia && x.IdEjercicioFiscal == IdEjercicioFiscal);
            if (f.Count() > 0)
            {
                o = a.listarTodos_PresupuestosPartidas().Where(x => x.IdPartida == IdPartida && x.IdDependencia == IdDependencia && x.IdEjercicioFiscal == IdEjercicioFiscal).First();
            }
            return o;
        }

        public List<beClavesPresupuestalesDetalles> OClavesPresupuestalesDetalles(int idPresupuestoPartida)
        {
            brClavesPresupuestalesDetalles a = new brClavesPresupuestalesDetalles();

            var b = a.listar_ClavesPresupuestalesDetalles_IdPresupuestoPartida(idPresupuestoPartida);

            return b;
        }

        public List<beOrigenRecurso> listarTodos_OrigenRecurso()
        {
            brOrigenRecurso o = new brOrigenRecurso();
            var p = o.listarTodos_OrigenRecurso();
            return p;
        }

        public List<beAdjudicacionesLiquidez> TraerLiquidez_x_IdAdjudicacion(int IdAdjudicacion)
        {

            brAdjudicacionesLiquidez r = new brAdjudicacionesLiquidez();

            return r.AdjudicacionLiquidez_Traer_IdAdjudicacion(IdAdjudicacion);
        }

        public List<beAdjudicacionesLotes> getAllAdjudicacionLotes_x_IdAdjudicacion(int IdAdjudicacion)
        {
            var lstAdjudicacionLotes = (new brAdjudicacionesLotes().listarTodos_AdjudicacionesLotes_x_IdAdjudicacion(IdAdjudicacion));

            return lstAdjudicacionLotes;
        }

        //public List<beAdjudicacionesPropuestasTecnicaEconomica> getAllAdjudicacionLotesProveedor_x_IdAdjudicacion(int IdAdjudicacion)
        //{
        //    var lstAdjudicacionesLotes = (new brAdjudicacionesPropuestasTecnicaEconomica().listarAdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicacion(IdAdjudicacion));

        //    return lstAdjudicacionesLotes;
        //}

        public List<beAdjudicacionesLotes> getAllAdjudicacionesProveedoresLotes_x_IdAdjudicacion(int IdAdjudicacion)
        {
            var lstRequisicionLotes = (new brAdjudicacionesLotes().listarTodos_AdjudicacionesProveedoresLotes_x_IdAdjudicacion(IdAdjudicacion));

            return lstRequisicionLotes;
        }

        public List<beMeses> getMeses()
        {
            int anio = DateTime.Now.Month;
            var meses = (new brMeses()).listarTodos_Meses();

            return meses.Where(s => s.IdMes >= anio).ToList();
        }

        public List<beFrecuencias> geteFrecuencias()
        {
            var Frecuencias = (new brFrecuencias()).listarTodos_Frecuencias();

            return Frecuencias.Where(s => s.Activo == true).ToList();
        }

        public List<beMuestras> getAllRequerimientos()
        {
            var Muestras = (new brMuestras()).listarTodos_Muestras();

            return Muestras.Where(s => s.Activo == true).ToList();
        }

        public List<beGenerica> getProductos(beGenerica oGenerica)
        {
            return (new brAdjudicacionesLotes()).listarTodos_AdjudicacionesLotes_x_IdPartida_BienServicio(oGenerica);
        }

        public beGenerica getProducto(int IdBienServicio)
        {
            return (new brAdjudicacionesLotes()).traerAdjudicacionesLotes_x_IdBienServicio(IdBienServicio);
        }

        public beAdjudicacionesLotes getAdjudicacionLote_x_IdLote(int IdLote)
        {
            brAdjudicacionesLotes adjudicacionesLotes = new brAdjudicacionesLotes();

            return adjudicacionesLotes.traerAdjudicacionesLotes_x_IdLote(IdLote);
        }

        public int saveEditAdjudicacionLote(beAdjudicacionesLotes AdjudicacionLote)
        {
            var lote = (new brAdjudicacionesLotes()).actualizarAdjudicacionesLotes(AdjudicacionLote);

            return lote;
        }

        public decimal sumLiquidez(List<beAdjudicacionesLiquidez> liquidez)
        {
            return liquidez.Select(c => c.MontoComprometido).Sum();
        }

        public decimal sumAdjudicacionLote(List<beAdjudicacionesLotes> requisicionLote)
        {
            return requisicionLote.Select(c => c.Total).Sum();

        }

        public beAdjudicaciones TraerAdjudicacion_x_IdAdjudicacion(int IdAdjudicacion) {
            brAdjudicaciones a = new brAdjudicaciones();

            return a.traerAdjudicaciones_x_IdAdjudicacion(IdAdjudicacion);
        }

        public int Autorizar(beAdjudicaciones adjudicaciones)
        {
            brAdjudicaciones r = new brAdjudicaciones();

            return r.actualizarAdjudicaciones(adjudicaciones);
        }

        public int saveLiquidez(beAdjudicacionesLiquidez adjudicacionesLiquidez)
        {
            brAdjudicacionesLiquidez r = new brAdjudicacionesLiquidez();

            return r.guardarAdjudicacionesLiquidez(adjudicacionesLiquidez);
        }

        public int DeleteAdjudicacionLiquidez(int idAdjudicacionLiquidez)
        {
            brAdjudicacionesLiquidez a = new brAdjudicacionesLiquidez();

            return a.eliminarAdjudicacionesLiquidez(idAdjudicacionLiquidez);
        }

        public beAdjudicacionesLiquidez GetAdjudicacionesLiquidez_x_IdAdjudicacionLiquidez(int idAdjudicacionesLiquidez)
        {
            brAdjudicacionesLiquidez r = new brAdjudicacionesLiquidez();

            return r.traerAdjudicacionesLiquidez_x_IdAdjudicacionLiquidez(idAdjudicacionesLiquidez);
        }

        public int UpdateAdjudicacionLiquidez(beAdjudicacionesLiquidez adjudicacionesLiquidez)
        {
            brAdjudicacionesLiquidez r = new brAdjudicacionesLiquidez();

            return r.actualizarAdjudicacionesLiquidez(adjudicacionesLiquidez);
        }

        public decimal Sum_MontoComprometido_x_IdAdjudicacion(int idAdjudicacion)
        {

            brAdjudicacionesLiquidez a = new brAdjudicacionesLiquidez();

            var c = a.AdjudicacionLiquidez_Traer_IdAdjudicacion(idAdjudicacion).Select(x => x.MontoComprometido).ToList();
            decimal d = 0;
            foreach (var item in c)
            {
                d += item;
            }
            return d;
        }

        public int saveAdjudicacionLote(beAdjudicacionesLotes adjudicacionesLotes)
        {
            var lote = (new brAdjudicacionesLotes()).guardarAdjudicacionesLotes(adjudicacionesLotes);

            return lote;
        }

        public beAdjudicacionesFirmantes getFirmante(int IdAdjudicacion)
        {
            brAdjudicacionesFirmantes O = new brAdjudicacionesFirmantes();
            var adjFirm = O.listarTodos_AdjudicacionesFirmantes().Where(x => x.IdAdjudicacion == IdAdjudicacion).FirstOrDefault();
            return adjFirm;
        }

        public List<beAdjudicacionesCondicionesDetallesIdAdjudicacion> getAdjudicacionesCondicionesEntregasDetalles_x_IdAdjudicacion(int IdAdjudicacion)
        {
            var list = (new brAdjudicacionesCondicionesEntregasDetalles()).listar_AdjudicacionesCondicionesEntregasDetalles_x_IdAdjudicacion(IdAdjudicacion);
            return list;
        }

        public int deleteLote(int pIdLote)
        {
            var lote = (new brAdjudicacionesLotes()).eliminarAdjudicacionesLotes(pIdLote);

            return lote;
        }

        public List<bePlazosEntregas> getAllPlazosEntrega()
        {
            var plazo = (new brPlazosEntregas()).listarTodos_PlazosEntregas();

            return plazo.Where(s => s.Activo == true).ToList();
        }

        public List<beTiposEntregas> getAllTiposEntrega()
        {
            var tiposEntrega = (new brTiposEntregas()).listarTodos_TiposEntregas();

            return tiposEntrega.Where(s => s.Activo == true).ToList();
        }

        public List<bePlazosTiempos> getAllPlazoTiempos()
        {
            var plazoTiempos = (new brPlazosTiempos()).listarTodos_PlazosTiempos();

            return plazoTiempos.Where(s => s.Activo == true).ToList();
        }

        public List<beTiposDias> getAllTiposDias()
        {
            var TiposDias = (new brTiposDias()).listarTodos_TiposDias();

            return TiposDias;
        }

        public List<beLugaresEntregaFirma> getAllLugaresEntregaFirma(int IdTipoLugar)
        {
            var LugaresEntregaFirma = (new brLugaresEntregaFirma()).listarTodos_LugaresEntregaFirma().Where(s => s.IdTipoLugar == IdTipoLugar).ToList();

            return LugaresEntregaFirma;
        }

        public beAdjudicacionesCondicionesEntregas getAdjudicacionCondicionEntrega_x_IdAdjudicacionCondicionEntrega(int pIdAdjudicacionCondicionEntrega)
        {
            var objeto = (new brAdjudicacionesCondicionesEntregas()).traerAdjudicacionesCondicionesEntregas_x_IdAdjudicacionCondicionEntrega(pIdAdjudicacionCondicionEntrega);

            return objeto;
        }

        public int updateCondcionesDeEntrega(beAdjudicacionesCondicionesEntregas oCondcionesDeEntrega)
        {
            var condcionesDeEntrega = (new brAdjudicacionesCondicionesEntregas()).actualizarAdjudicacionesCondicionesEntregas(oCondcionesDeEntrega);

            return condcionesDeEntrega;
        }

        public beAdjudicacionesCondicionesEntregas getAllAdjudicacionCondiconesDeEntrega_x_IdAdjudicacion(int IdAdjudicacion)
        {

            var AdjudicacionCondiconesDeEntrega = (new brAdjudicacionesCondicionesEntregas()).listarTodos_AdjudicacionesCondicionesEntregas().Where(x => x.IdAdjudicacion == IdAdjudicacion).FirstOrDefault();

            if (AdjudicacionCondiconesDeEntrega != null)
            {
                AdjudicacionCondiconesDeEntrega.IsNUll = false;
            }

            return AdjudicacionCondiconesDeEntrega;
        }

        public int saveAdjudicacionesCondicionesEntregasDetalles(beAdjudicacionesCondicionesEntregasDetalles oAdjudicacionesCondicionesEntregasDetalles)
        {
            return (new brAdjudicacionesCondicionesEntregasDetalles()).guardarAdjudicacionesCondicionesEntregasDetalles(oAdjudicacionesCondicionesEntregasDetalles);

        }

        public List<beAdjudicacionesCondicionesEntregasDetalles> getAllCondicionesEntregasDetalles_x_IdAdjudicacionCondicionEntrega(int IdAdjudicacionCondicionEntrega)
        {
            var lst = (new brAdjudicacionesCondicionesEntregasDetalles()).listar_AdjudicacionesCondicionesEntregasDetalles_x_IdAdjudicacionCondicionEntrega(IdAdjudicacionCondicionEntrega);
            var s = 1; 
            foreach (var item in lst)
            {
                item.i = s;
                s++;
            }
            return lst;
        }

        public beAdjudicacionesCondicionesEntregasDetalles getCondicionEntregaDetalle_x_IdCondicionEntregaDetalle(int IdCondicionEntregaDetalle)
        {
            var objeto = (new brAdjudicacionesCondicionesEntregasDetalles()).traerAdjudicacionesCondicionesEntregasDetalles_x_IdAdCondicionEntregaDetalle(IdCondicionEntregaDetalle);


            return objeto;
        }

        public int saveEditAdjudicacionesCondicionesEntregasDetalles(beAdjudicacionesCondicionesEntregasDetalles oAdjudicacionesCondicionesEntregasDetalles)
        {
            return (new brAdjudicacionesCondicionesEntregasDetalles()).actualizarAdjudicacionesCondicionesEntregasDetalles(oAdjudicacionesCondicionesEntregasDetalles);

        }

        public int eliminartAdjudicacionesCondicionesEntregasDetalles(int IdCondicionEntregaDetalle)
        {
            return (new brAdjudicacionesCondicionesEntregasDetalles()).eliminarAdjudicacionesCondicionesEntregasDetalles(IdCondicionEntregaDetalle);

        }

        public List<beCondicionesPagosEntrega> getCondicionesPagosEntrega(int IdTipoCondicion)
        {
            var list = (new brCondicionesPagosEntrega()).listarTodos_CondicionesPagosEntrega().Where(s => s.IdTipoCondicion == IdTipoCondicion).ToList();
            return list;
        }

        public beAdjudicacionesCondicionesPagosDetalles getCondicionPagoDetalle_x_IdCondcionPagoDetalle(int IdCondcionPagoDetalle)
        {
            return (new brAdjudicacionesCondicionesPagosDetalles()).traerAdjudicacionesCondicionesPagosDetalles_x_IdAdCondicionPagoDetalle(IdCondcionPagoDetalle);
        }
        public int saveEditCondicionPagoDetalle(beAdjudicacionesCondicionesPagosDetalles condcionPagoDetalle)
        {
            return (new brAdjudicacionesCondicionesPagosDetalles()).actualizarAdjudicacionesCondicionesPagosDetalles(condcionPagoDetalle);
        }

        public List<beEF_Paises> getAllPaises()
        {
            var paises = (new brEF_Paises()).listarTodos_EF_Paises();
            return paises;
        }

        public List<beEF_Municipios> getAllMunicipio(string claveEstado)
        {
            var municipios = (new brEF_Municipios()).listarTodos_EF_Municipios().Where(s => s.ClaveEstado == claveEstado).ToList();
            return municipios;
        }

        public List<beEF_EntidadesFederativas> getAllEstados(int IdPais)
        {
            var estados = (new brEF_EntidadesFederativas()).listarTodos_EF_EntidadesFederativas().Where(s => s.IdPais == IdPais).ToList();
            return estados;
        }

        public List<beAnticipos> getAllAnticipos()
        {
            var lstAnticipo = (new brAnticipos()).listarTodos_Anticipos();
            return lstAnticipo;
        }

        public List<bePeriodicidad> getAllPeriodicidad()
        {
            var lstPeriodicidad = (new brPeriodicidad()).listarTodos_Periodicidad();
            return lstPeriodicidad;
        }

        public beLugaresEntregaFirma getLugaresEntregaFirma_x_IdLugarEntrega(int IdLugarEntrega)
        {
            var LugarEntregaFirma = (new brLugaresEntregaFirma()).traerLugaresEntregaFirma_x_IdLugarEntregaFirma(IdLugarEntrega);

            return LugarEntregaFirma;
        }

        public int saveCondicionPago(beAdjudicacionesCondicionesPagos condcionPago)
        {
            return (new brAdjudicacionesCondicionesPagos()).guardarAdjudicacionesCondicionesPagos(condcionPago);
        }

        public int saveEditCondicionPago(beAdjudicacionesCondicionesPagos condcionPago)
        {
            return (new brAdjudicacionesCondicionesPagos()).actualizarAdjudicacionesCondicionesPagos(condcionPago);
        }

        protected string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }

        public List<ClsGenerica> getCalculoPartida(int IdPeriodicidad, int cantidadPagos, decimal importeRestante, decimal porcentajeAplicado, DateTime FechaInicioPago)
        {

            DateTime fechaInicial = FechaInicioPago;//Fecha Inicio
            DateTime fechaFinal = DateTime.Now;//Fecha Fin
            int tipoPeriodo = 0;
            List<ClsGenerica> resultado = new List<ClsGenerica>();
            switch (IdPeriodicidad)
            {

                case 1:
                    tipoPeriodo = 1;
                    break;
                case 2:
                    tipoPeriodo = 2;
                    break;
                case 3:
                    tipoPeriodo = 3;
                    break;
                case 4:
                    tipoPeriodo = 6;
                    break;
                case 5:
                    tipoPeriodo = 12;
                    break;

            }
            int i = 1;
            decimal porcentaje = (1 - porcentajeAplicado) / cantidadPagos * 100;
            decimal importePorPago = importeRestante / cantidadPagos;

            fechaFinal = fechaInicial.AddMonths(cantidadPagos * tipoPeriodo);
            for (DateTime d = fechaInicial; d < fechaFinal; d = d.AddMonths(tipoPeriodo))
            {
                //Hacer algo con la fecha

                var a = new ClsGenerica();
                a.id = i;
                a.id2 = d.Month;
                a.string1 = MonthName(d.Month) + " - " + d.Year.ToString();
                a.string2 = "";
                a.decimal1 = importePorPago;
                a.decimal2 = porcentaje;
                a.bool1 = false;
                a.DateTime1 = d;
                resultado.Add(a);
                i++;
            }
            return resultado;
        }

        public beAdjudicacionesCondicionesPagos getCondicionPago_x_IdCondcionPago(int IdCondcionPago)
        {
            return (new brAdjudicacionesCondicionesPagos()).traerAdjudicacionesCondicionesPagos_x_IdAdjudicacionCondicionPago(IdCondcionPago);
        }

        public List<beProveedores> getAllProveedores(int IdAdjudicacion, int IdPartida)
        {
            brProveedores p = new brProveedores();

            var prov = p.getAllProveedores_x_IdAdjudicacion(IdAdjudicacion).ToList();

            return  prov;
        }

        public int saveFirmantes(beAdjudicacionesFirmantes adjudicacionesFirmantes) {

            brAdjudicacionesFirmantes f = new brAdjudicacionesFirmantes();

            return  f.guardarAdjudicacionesFirmantes(adjudicacionesFirmantes);

        }
        
        public beAdjudicacionesFirmantes validarCamposStatus(beAdjudicacionesFirmantes AdjFirmantes)
        {
            brAdjudicaciones ObrAdjudicaciones = new brAdjudicaciones();
            if (AdjFirmantes.ValidaCondicionEntrega == true && AdjFirmantes.ValidaCondicionPago == true && AdjFirmantes.ValidaLotes == true)
            {
                AdjFirmantes.IdEstatusAdjudicacion = 70;
                AdjFirmantes.ObservacionLotes = "Sin observaciones";
                AdjFirmantes.ObservacionCondicionPago = "Sin observaciones";
                AdjFirmantes.OnservacionCondicionEntrega = "Sin observaciones";
            }
            else
            {
                AdjFirmantes.IdEstatusAdjudicacion = 60; // estatus rechazado
                if (AdjFirmantes.ObservacionLotes == null) { AdjFirmantes.ObservacionLotes = "Sin observaciones"; }
                if (AdjFirmantes.ObservacionCondicionPago == null) { AdjFirmantes.ObservacionCondicionPago = "Sin observaciones"; }
                if (AdjFirmantes.OnservacionCondicionEntrega == null) { AdjFirmantes.OnservacionCondicionEntrega = "Sin observaciones"; }
            }
            var AdjudicacionStatus = ObrAdjudicaciones.traerAdjudicaciones_x_IdAdjudicacion(AdjFirmantes.IdAdjudicacion);
            AdjudicacionStatus.IdEstatusAdjudicacion = AdjFirmantes.IdEstatusAdjudicacion;
            ObrAdjudicaciones.actualizarAdjudicaciones(AdjudicacionStatus);
            return AdjFirmantes;
        }

        public beDependencias getDatosFacturacion(int IdDependencia)
        {
            var dependencia = (new brDependencias()).traerDependencias_x_IdDependencia(IdDependencia);

            return dependencia;
        }

        public ClsGenerica getMunicipio_estado_pais(string IdMunicipio)
        {
            ClsGenerica a = new ClsGenerica();
            var municipios = (new brEF_Municipios()).traerEF_Municipios_x_IdMunicipio(IdMunicipio);
            var estados = (new brEF_EntidadesFederativas()).traerEF_EntidadesFederativas_x_ClaveEstado(municipios.ClaveEstado);

            a.string1 = IdMunicipio;
            a.string2 = municipios.ClaveEstado;
            a.id = estados.IdPais;
            return a;
        }

        public beAdjudicacionesCondicionesPagos getCondiconPago_x_IdAdjudicacion(int IdAdjudicacion)
        {
            var b = new beAdjudicacionesCondicionesPagos();
            var lstAdjudicacionesCondicionesPagos = (new brAdjudicacionesCondicionesPagos()).listarTodos_AdjudicacionesCondicionesPagos();
            var a = lstAdjudicacionesCondicionesPagos.Where(s => s.IdAdjudicacion == IdAdjudicacion).ToList();
            if (a.Count > 0)
            {
                b = a.First();
            }
            return b;
        }

        public List<ClsGenerica> getAllCondicionesPagoDetalle_x_IdCondicionPago(int IdCondicionPago)
        {

            List<ClsGenerica> resultado = new List<ClsGenerica>();

            var t = (new brAdjudicacionesCondicionesPagosDetalles()).listarTodos_AdjudicacionesCondicionesPagosDetalles();
            var sf = t.Where(s => s.IdAdjudicacionCondicionPago == IdCondicionPago).ToList();

            foreach (var item in sf)
            {
                var a = new ClsGenerica();
                a.id2 = item.IdAdCondicionPagoDetalle;
                a.id = item.NumeroPago;
                a.string1 = MonthName(item.FechaPago.Month) + " - " + item.FechaPago.Year.ToString();
                a.string2 = "";
                a.decimal1 = item.ImportePago;
                a.decimal2 = item.PorcentajePago;
                a.bool1 = true;
                resultado.Add(a);
            }


            return resultado;
        }

        public int getIdAdjudicacionProveedor_x_IdAdjudicacion_x_IdProveedor(int IdAdjudicacion, int IdProveedor)
        {
            brAdjudicacionesProveedores adjudicacionesProveedores = new brAdjudicacionesProveedores();

            var r = adjudicacionesProveedores.listarTodos_AdjudicacionesProveedores().FirstOrDefault(x=>x.IdAdjudicacion==IdAdjudicacion && x.IdProveedor==IdProveedor);

            return r.IdAdjudicacionProveedor;
        }



        public beAdjudicacionesPropuestasTecnicaEconomica getAdjudicacionPropuestaTecEco_x_IdAdjudicacionProveedor_x_IdLote(int IdAdjudicacionProveedor, int IdLote)
        {
            brAdjudicacionesPropuestasTecnicaEconomica tecnicaEconomica = new brAdjudicacionesPropuestasTecnicaEconomica();

            var r = tecnicaEconomica.listarTodos_AdjudicacionesPropuestasTecnicaEconomica().Where(x => x.IdAdjudicacionProveedor == IdAdjudicacionProveedor && x.IdLote == IdLote).FirstOrDefault();

            return r;
        }

        public beAdjudicacionesProveedores getAdjudicacionProveedor_x_IdAdjudicacion_x_IdProveedor(int IdAdjudicacion, int IdProveedor)
        {

            brAdjudicacionesProveedores adjudicacionesProveedores = new brAdjudicacionesProveedores();

            var r = adjudicacionesProveedores.listarTodos_AdjudicacionesProveedores().FirstOrDefault(x => x.IdAdjudicacion == IdAdjudicacion && x.IdProveedor == IdProveedor);

            return r;
        }

        public beAdjudicacionesProveedores getIdEstatusEnvioPropuesta(int IdAdjudicacionProveedor)
        {
            brAdjudicacionesProveedores adjudicacionesProveedores = new brAdjudicacionesProveedores();

            return adjudicacionesProveedores.traerAdjudicacionesProveedores_x_IdAdjudicacionProveedor(IdAdjudicacionProveedor);
        }

        public List<beAdjudicacionesProveedores> getAllProveedoresAdjudicacion_x_IdAdjudicacion(int IdAdjudicacion, int IdEstatusAdjudicacionProveedor)
        {

            brAdjudicacionesProveedores adjudicacionesProveedores = new brAdjudicacionesProveedores();

            return adjudicacionesProveedores.getAllProveedoresAdjudicacion_x_IdAdjudicacion(IdAdjudicacion, IdEstatusAdjudicacionProveedor);
        }

        public List<beAdjudicacionesLiquidez> getallLiquidez_x_IdAdjudicacion(int IdAdjudicacion)
        {
            List<Carta> cartas = new List<Carta>();

            return (new brAdjudicacionesLiquidez()).AdjudicacionLiquidez_Traer_IdAdjudicacion(IdAdjudicacion);
        }

        public List<beAdjudicacionesCondicionesDetallesIdAdjudicacion> getAdjudicacionesCondicionesEntregasDetallesFaltantes_x_IdAdjudicacion(int IdAdjudicacion)
        {
            var list = (new brAdjudicacionesCondicionesEntregasDetalles()).listar_AdjudicacionesCondicionesEntregasDetalles_x_IdAdjudicacion(IdAdjudicacion).Where(x => x.CantidadxAsignar != 0).ToList();

            return list;
        }

        public beAdjudicacionesPropuestasTecnicaEconomica getDataAdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicacion_x_IdProveedor(int IdAdjudicacion, int IdProveedor, int IdLote)
        {
            var IdAdjudicacionProveedor = (new brAdjudicacionesProveedores()).listarTodos_AdjudicacionesProveedores().Where(x => x.IdAdjudicacion == IdAdjudicacion && x.IdProveedor == IdProveedor).FirstOrDefault().IdAdjudicacionProveedor;

           // return (new brAdjudicacionesPropuestasTecnicaEconomica()).traerAdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicionProveedor(IdAdjudicacionProveedor).Where(x => x.IdLote == IdLote).Select(x => new { PrecioUnitarioOfertado = x.PrecioUnitarioOfertado, ImporteOfertado = x.ImporteOfertado, TotalOfertado = x.TotalOfertado, ImportePeriodo = x.ImportePeriodo, ImpuestoImporte = x.ImpuestoImporte, ImpuestoPeriodo = x.ImpuestoPeriodo, ImpuestoPorcentaje = x.ImpuestoPorcentaje, TotalPeriodo =  x.TotalPeriodo } ).FirstOrDefault();
            return (new brAdjudicacionesPropuestasTecnicaEconomica()).traerAdjudicacionesPropuestasTecnicaEconomica_x_IdAdjudicionProveedor(IdAdjudicacionProveedor).Where(x => x.IdLote == IdLote).FirstOrDefault();
        }

        public beConfiguracionModalidadTipoProceso getTipoAdjudicacion_x_IdTipoAdjudicacion(int IdTipoAdjudicacion)
        {
            var IdConfiguracionModalidadTipoProceso = IdTipoAdjudicacion == 1 ? 6 : 7;
            return (new brConfiguracionModalidadTipoProceso()).traerConfiguracionModalidadTipoProceso_x_IdConfiguracionModalidadTipoProceso(IdConfiguracionModalidadTipoProceso);
        }
        public string getCapitulo_x_IdPartida(int IdPartida)
        {
            var ncap = (new brCapitulos()).traerCapitulos_x_IdCapitulo((new brPartidas()).traerPartidas_x_IdPartida(IdPartida).IdCapitulo);
            return ncap.ClaveCapitulo + " " + ncap.Capitulo;
        }
    }
}