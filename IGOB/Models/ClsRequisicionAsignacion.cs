using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Models
{
    public class ClsRequisicionAsignacion
    {
        public List<beTiposRequisiciones> tiposRequisicionAbierta()
        {
            brTiposRequisiciones b = new brTiposRequisiciones();

            return b.listar_TiposRequisiciones_Abiertas();
        }
        public List<beFormaAbastecimiento> getAllAbastecimiento()
        {
            brFormaAbastecimiento b = new brFormaAbastecimiento();
            return b.listarTodos_FormaAbastecimiento();
        }
        public List<beTiposSolicitud> getAllTiposSolicitud()
        {
            brTiposSolicitud b = new brTiposSolicitud();
            return b.listarTodos_TiposSolicitud();
        }
        public List<beCapitulos> getAllCapitulos()
        {
            brCapitulos b = new brCapitulos();
            var c = b.listarTodos_Capitulos();
            foreach (var item in c)
            {
                item.Capitulo = item.ClaveCapitulo + " " + item.Capitulo.Trim();
            }
            return c;
        }
        public List<bePartidas> getAllPartidas()
        {
            brPartidas b = new brPartidas();
            var c = b.listarTodos_Partidas();
            foreach (var item in c)
            {
                item.Descripcion = item.ClavePartida.Trim() + " " + item.Descripcion.Trim();
            }
            return c;
        }
        public List<bePartidas> getAllPartidas_x_IdCapitulo(int pIdCapitulo)
        {
            brPartidas b = new brPartidas();
            var c = b.listarPartidas_x_IdCapitulo(pIdCapitulo);
            foreach (var item in c)
            {
                item.Descripcion = item.ClavePartida.Trim() + " " + item.Partida.Trim();
            }
            return c;
        }
        public List<beTiempos> getAllTiempos()
        {
            brTiempos b = new brTiempos();
            return b.listarTodos_Tiempos();
        }
        public bePresupuestosPartidas getPresupuestosPartidas(int pIdPartida)
        {
            brPresupuestosPartidas b = new brPresupuestosPartidas();
            var c = b.traerPresupuestosPartidas_x_IdPartida(pIdPartida);
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
        public beEjerciciosFiscales getEjercicioFiscal_x_IdEjercicioFiscal(int pIdEjercicioFiscal)
        {

            brEjerciciosFiscales b = new brEjerciciosFiscales();
            return b.traerEjerciciosFiscales_x_IdEjercicioFiscal(pIdEjercicioFiscal);
        }
        public int saveRequisicion(beRequisiciones requisiciones)
        {

            brRequisiciones b = new brRequisiciones();
            return b.guardarRequisiciones(requisiciones);

        }
        public List<beRequisicionConsulta> consultaRequisicion(int pIdLista, int pIdPerfil, int pIdDependencia)
        {
            beGenerica oGenerico = new beGenerica();
            oGenerico.entero3 = pIdLista;
            oGenerico.entero2 = pIdPerfil;
            oGenerico.entero = pIdDependencia;
            brRequisicionConsulta b = new brRequisicionConsulta();
            return b.listarRequisicionConsulta(oGenerico);

        }
        public beRequisiciones getRequisicion(int pIdRequisicion)
        {

            brRequisiciones b = new brRequisiciones();
            return b.traerRequisiciones_x_IdRequisicion(pIdRequisicion);

        }
        public bePartidas getPartidad(int pIdPartida)
        {

            brPartidas b = new brPartidas();
            return b.traerPartidas_x_IdPartida(pIdPartida);

        }
        public PresupuestoLiquidez getPresupuestoLiquidez(int pIdpArtida, int pIdOrigenRecurso, int pIdDependencia, beRequisiciones pRequisicion)
        {
            var partida = getPartidad(pIdpArtida);
            var lstPresupuestoPartida = (new brPresupuestosPartidas()).listarTodos_PresupuestosPartidas_GetAll();
            PresupuestoLiquidez a = new PresupuestoLiquidez();
            if (lstPresupuestoPartida.Count() > 0)
            {
                var s = lstPresupuestoPartida.Where(c => c.IdPartida == pIdpArtida && c.IdDependencia == pIdDependencia).ToList().First();
                var p = (new brOrigenRecurso()).traerOrigenRecurso_x_IdOrigenRecurso(pIdOrigenRecurso);
                var t = (new brClavesPresupuestalesDetalles()).listar_ClavesPresupuestalesDetalles_IdPresupuestoPartida(s.IdPresupuestoPartida);

                a.Partida = partida.ClavePartida.Trim() + " " + partida.Partida.Trim();
                a.SaldoPatida = s.MontoSaldo;
                a.MontoSolicitado = pRequisicion.MontoAproximado;
                a.MontoPresupuestoAutorizado = pRequisicion.MontoAproximadoAutorizado;
                a.SaldoPresupuestoAutorizado = (a.SaldoPatida - a.MontoPresupuestoAutorizado);
                a.OrigenRecurso = p.OrigenRecurso;
                foreach (var item in t)
                {
                    p = (new brOrigenRecurso()).traerOrigenRecurso_x_IdOrigenRecurso(item.IdOrigenRecurso);
                    a.ClavesPresupuestalesDetalles.Add(new ClavesPresupuestales()
                    {
                        NumeroMinistracion = s.NumeroMinistracion,
                        ClavesPresupuestal = item.ClavePresupuestal,
                        MontoPresupuestado = item.MontoPresupuestado,
                        OrigenRecurso = p.OrigenRecurso,
                        De = (new brMeses()).traerMeses_x_IdMes(item.IdMesInicio).Mes,
                        Al = (new brMeses()).traerMeses_x_IdMes(item.IdMesFinal).Mes
                    });

                }
            }
            return a;

        }
        public List<Carta> getAllCartas_x_IdTipoSolicitud(int pIdTipoSolicitud)
        {
            List<Carta> cartas = new List<Carta>();

            var lstCartas = getAllCartas().Where(s => s.IdTipoSolicitud == pIdTipoSolicitud);
            foreach (var item in lstCartas)
            {
                Carta a = new Carta();
                a.IdCarta = item.IdCarta;
                a.IdEstatus = item.IdEstatus;
                a.Numero = item.Numero;
                a.NombreCarta = item.Nombre;
                a.Descripcion = item.Solicitada;
                a.Inciso = item.Inciso;
                a.CartaTexto = item.Carta;
                cartas.Add(a);
            }
            return cartas;
        }
        protected List<beCartas> getAllCartas()
        {
            List<beCartas> lstCartas = (new brCartas()).listarTodos_Cartas_GetAll().ToList();
            return lstCartas;
        }
        public int saveCarta(beCartas pCarta)
        {
            var i = (new brCartas()).guardarCartas(pCarta);
            return i;
        }
        public List<beRequisicionesLiquidez> getAllLiquidez_x_IdRequisicion(int pIdRequisicion)
        {
            List<Carta> cartas = new List<Carta>();

            return (new brRequisicionesLiquidez()).RequisicionesLiquidez_Traer_IdRequisicion(pIdRequisicion);

        }
        public decimal sumLiquidez(List<beRequisicionesLiquidez> liquidez)
        {
            return liquidez.Select(c => c.MontoComprometido).Sum();

        }
        public decimal sumRequisicionLote(List<beRequisicionLotesIdRequisicion> requisicionLote)
        {
            return requisicionLote.Select(c => c.Total).Sum();

        }
        public List<beGenerica> getProductos(beGenerica oGenerica)
        {
            return (new brRequisicionesLotes()).listarTodos_RequisicionesLotes_x_IdPartida_BienServicio(oGenerica);
        }
        public beGenerica getProducto(int IdBienServicio)
        {
            return (new brRequisicionesLotes()).traerRequisicionesLotes_x_IdBienServicio(IdBienServicio);
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
        public int saveRequisionLote(beRequisicionesLotes pRequisicionLote)
        {
            var lote = (new brRequisicionesLotes()).guardarRequisicionesLotes(pRequisicionLote);

            return lote;
        }
        public List<beMuestras> getAllRequerimientos()
        {
            var Muestras = (new brMuestras()).listarTodos_Muestras();

            return Muestras.Where(s => s.Activo == true).ToList();
        }
        public List<beRequisicionLotesIdRequisicion> getAllRequisicionLotes_x_IdRequisicion(int pIdRequisicion)
        {
            var lstRequisicionLotes = (new brRequisicionesLotes()).traerRequisicionesLotes_x_IdRequisicion(pIdRequisicion);

            return lstRequisicionLotes;
        }

        public int deleteLote(int pIdLote)
        {
            var lote = (new brRequisicionesLotes()).eliminarRequisicionesLotes(pIdLote);

            return lote;
        }
        public beRequisicionesLotes getRequisicionLote_x_IdLote(int pIdLote)
        {
            var objeto = (new brRequisicionesLotes()).traerRequisicionesLotes_x_IdLote(pIdLote);

            return objeto;
        }
        public int saveEditRequisionLote(beRequisicionesLotes pRequisicionLote)
        {
            var lote = (new brRequisicionesLotes()).actualizarRequisicionesLotes(pRequisicionLote);

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
        public beRequisicionesCondicionesEntregas getAllRequisicionCondiconesDeEntrega_x_IdRequisicion(int pIdRequisicion)
        {
            var RequisicionCondiconesDeEntrega = (new brRequisicionesCondicionesEntregas()).traerRequisicionesCondicionesEntregas_x_IdRequisicion(pIdRequisicion);

            return RequisicionCondiconesDeEntrega;
        }
        public int saveCondcionesDeEntrega(beRequisicionesCondicionesEntregas oCondcionesDeEntrega)
        {
            var condcionesDeEntrega = (new brRequisicionesCondicionesEntregas()).guardarRequisicionesCondicionesEntregas(oCondcionesDeEntrega);

            return condcionesDeEntrega;
        }
        public beRequisicionesCondicionesEntregas getRequisicionCondicionEntrega_x_IdRequisicionCondicionEntrega(int pIdRequisicionCondicionEntrega)
        {
            var objeto = (new brRequisicionesCondicionesEntregas()).traerRequisicionesCondicionesEntregas_x_IdRequisicionCondicionEntrega(pIdRequisicionCondicionEntrega);

            return objeto;
        }
        public int updateCondcionesDeEntrega(beRequisicionesCondicionesEntregas oCondcionesDeEntrega)
        {
            var condcionesDeEntrega = (new brRequisicionesCondicionesEntregas()).actualizarRequisicionesCondicionesEntregas(oCondcionesDeEntrega);

            return condcionesDeEntrega;
        }
        public List<beLugaresEntregaFirma> getAllLugaresEntregaFirma(int IdTipoLugar)
        {
            var LugaresEntregaFirma = (new brLugaresEntregaFirma()).listarTodos_LugaresEntregaFirma().Where(s => s.IdTipoLugar == IdTipoLugar).ToList();

            return LugaresEntregaFirma;
        }
        public beLugaresEntregaFirma getLugaresEntregaFirma_x_IdLugarEntrega(int IdLugarEntrega)
        {
            var LugarEntregaFirma = (new brLugaresEntregaFirma()).traerLugaresEntregaFirma_x_IdLugarEntregaFirma(IdLugarEntrega);

            return LugarEntregaFirma;
        }

        public List<beRequisiciconesCondicionesDetallesIdRequisicion> getRequisicionesCondicionesEntregasDetalles_x_IdRequisicion(int IdRequisicion)
        {
            var list = (new brRequisicionesCondicionesEntregasDetalles()).listar_RequisicionesCondicionesEntregasDetalles_x_IdRequisicion(IdRequisicion);
            return list;
        }
        public int saveRequisicionesCondicionesEntregasDetalles(beRequisicionesCondicionesEntregasDetalles oRequisicionesCondicionesEntregasDetalles)
        {
            return (new brRequisicionesCondicionesEntregasDetalles()).guardarRequisicionesCondicionesEntregasDetalles(oRequisicionesCondicionesEntregasDetalles);

        }
        public List<beRequisicionCondicionesEntregaDetalleConsulta> getAllCondicionesEntregasDetalles_x_IdRequisicionCondicionEntrega(int IdRequisicionCondicionEntrega)
        {
            var lst = (new brRequisicionesCondicionesEntregasDetalles()).listar_RequisicionesCondicionesEntregasDetalles_x_IdRequisicionCondicionEntrega(IdRequisicionCondicionEntrega);
            var s = 1;
            foreach (var item in lst)
            {
                item.i = s;
                s++;
            }
            return lst;
        }
        public beRequisicionesCondicionesEntregasDetalles getCondicionEntregaDetalle_x_IdCondicionEntregaDetalle(int IdCondicionEntregaDetalle)
        {
            var objeto = (new brRequisicionesCondicionesEntregasDetalles()).traerRequisicionesCondicionesEntregasDetalles_x_IdCondicionEntregaDetalle(IdCondicionEntregaDetalle);


            return objeto;
        }
        public int saveEditRequisicionesCondicionesEntregasDetalles(beRequisicionesCondicionesEntregasDetalles oRequisicionesCondicionesEntregasDetalles)
        {
            return (new brRequisicionesCondicionesEntregasDetalles()).actualizarRequisicionesCondicionesEntregasDetalles(oRequisicionesCondicionesEntregasDetalles);

        }
        public int eliminartRequisicionesCondicionesEntregasDetalles(int IdCondicionEntregaDetalle)
        {
            return (new brRequisicionesCondicionesEntregasDetalles()).eliminarRequisicionesCondicionesEntregasDetalles(IdCondicionEntregaDetalle);

        }
        public List<beCondicionesPagosEntrega> getCondicionesPagosEntrega(int IdTipoCondicion)
        {
            var list = (new brCondicionesPagosEntrega()).listarTodos_CondicionesPagosEntrega().Where(s => s.IdTipoCondicion == IdTipoCondicion).ToList();
            return list;
        }
        public beDependencias getDatosFacturacion(int IdDependencia)
        {
            var dependencia = (new brDependencias()).traerDependencias_x_IdDependencia(IdDependencia);

            return dependencia;
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

            if (cantidadPagos > 1)
                cantidadPagos = cantidadPagos - 1;

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
        protected string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }
        public int saveCondicionPago(beRequisicionesCondicionesPagos condcionPago)
        {
            return (new brRequisicionesCondicionesPagos()).guardarRequisicionesCondicionesPagos(condcionPago);
        }
        public int saveEditCondicionPago(beRequisicionesCondicionesPagos condcionPago)
        {
            return (new brRequisicionesCondicionesPagos()).actualizarRequisicionesCondicionesPagos(condcionPago);
        }
        public beRequisicionesCondicionesPagos getCondicionPago_x_IdCondcionPago(int IdCondcionPago)
        {
            return (new brRequisicionesCondicionesPagos()).traerRequisicionesCondicionesPagos_x_IdRequisicionCondicionPago(IdCondcionPago);
        }
        public beRequisicionesCondicionesPagos getCondiconPago_x_IdRequisicion(int IdRequisicion)
        {
            var b = new beRequisicionesCondicionesPagos();
            var lstRequisicionesCondicionesPagos = (new brRequisicionesCondicionesPagos()).listarTodos_RequisicionesCondicionesPagos();
            var a = lstRequisicionesCondicionesPagos.Where(s => s.IdRequisicion == IdRequisicion).ToList();
            if (a.Count > 0)
            {
                b = a.First();
            }
            return b;
        }
        public List<ClsGenerica> getAllCondicionesPagoDetalle_x_IdCondicionPago(int IdCondicionPago)
        {

            List<ClsGenerica> resultado = new List<ClsGenerica>();

            var t = (new brRequisicionesCondicionesPagosDetalles()).listarTodos_RequisicionesCondicionesPagosDetalles();
            var sf = t.Where(s => s.IdRequiscionCondicionPago == IdCondicionPago).ToList();

            foreach (var item in sf)
            {
                var a = new ClsGenerica();
                a.id2 = item.IdRqCondicionPagoDetalle;
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
        public beRequisicionesCondicionesPagosDetalles getCondicionPagoDetalle_x_IdCondcionPagoDetalle(int IdCondcionPagoDetalle)
        {
            return (new brRequisicionesCondicionesPagosDetalles()).traerRequisicionesCondicionesPagosDetalles_x_IdRqCondicionPagoDetalle(IdCondcionPagoDetalle);
        }
        public int saveEditCondiconPagoDetalle(beRequisicionesCondicionesPagosDetalles condcionPagoDetalle)
        {
            return (new brRequisicionesCondicionesPagosDetalles()).actualizarRequisicionesCondicionesPagosDetalles(condcionPagoDetalle);
        }
        public beRequisicionesFirmantes getFirmante(int IdRequisicion)
        {
            brRequisicionesFirmantes ObrRequisicionesFirmantes = new brRequisicionesFirmantes();
            var reqFirm = ObrRequisicionesFirmantes.listarTodos_RequisicionesFirmantes().Where(x => x.IdRequisicion == IdRequisicion).FirstOrDefault();
            return reqFirm;
        }
        public int saveEditRequisicion(beRequisiciones oRequisicion)
        {
            return (new brRequisiciones()).actualizarRequisiciones(oRequisicion);
        }
    }
}