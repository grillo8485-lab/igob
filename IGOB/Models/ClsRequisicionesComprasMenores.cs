using iGob.Entidades;
using iGob.ReglasNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class ClsRequisicionesComprasMenores
    {
        public List<beTiposSolicitud> GetAllTiposSolicitud()
        {
            brTiposSolicitud obrTiposSolicitud = new brTiposSolicitud();
            return obrTiposSolicitud.listarTodos_TiposSolicitud();
        }

        public List<beCapitulos> GetAllCapitulos()
        {
            brCapitulos obrCapitulos = new brCapitulos();
            var ListaCapitulos = obrCapitulos.listarTodos_Capitulos();
            foreach (var item in ListaCapitulos)
            {
                item.Capitulo = item.ClaveCapitulo + " " + item.Capitulo;
            }
            return ListaCapitulos;
        }

        public List<bePartidas> GetAllPartidas()
        {
            brPartidas obrPartidas = new brPartidas();
            var ListaPartidas = obrPartidas.listarTodos_Partidas();
            foreach (var item in ListaPartidas)
            {
                item.Partida = item.ClavePartida + " " + item.Partida;
            }
            return ListaPartidas;
        }



        public List<bePartidas> GetAllPartidas_x_IdCapitulo(int pIdCapitulo)
        {
            brPartidas obrPartidas = new brPartidas();
            var ListaPartidas = obrPartidas.listarPartidas_x_IdCapitulo(pIdCapitulo);
            foreach (var item in ListaPartidas)
            {
                item.Partida = item.ClavePartida + " " + item.Partida;
            }            
            return ListaPartidas;
        }

        public List<beDepartamentos> GetDepartamentos_x_IdDependencia(int pIdDependencia)
        {
            brDepartamentos obrDepartamentos = new brDepartamentos();
            var ListaDepartamentos = obrDepartamentos.traerDepartamentos_x_IdDependencia(pIdDependencia);
            
            return ListaDepartamentos;
        }

        public List<beLugaresEntregasPagosCM> GetLugaresEntregasCM_x_IdDependencia(int pIdDependencia)
        {
            brLugaresEntregasPagosCM obrLugaresEntregasPagosCM = new brLugaresEntregasPagosCM();
            var ListaLugaresEntregasPagosCM = obrLugaresEntregasPagosCM.traerLugaresEntregasCM_x_IdDependencia(pIdDependencia);

            return ListaLugaresEntregasPagosCM;
        }

        public List<beLugaresEntregasPagosCM> GetLugaresPagosCM_x_IdDependencia(int pIdDependencia)
        {
            brLugaresEntregasPagosCM obrLugaresEntregasPagosCM = new brLugaresEntregasPagosCM();
            var ListaLugaresEntregasPagosCM = obrLugaresEntregasPagosCM.traerLugaresPagosCM_x_IdDependencia(pIdDependencia);
            
            return ListaLugaresEntregasPagosCM;
        }

        public beEjerciciosFiscales GetEjercicioFiscal()
        {
            beEjerciciosFiscales obeEjerciciosFiscales = new beEjerciciosFiscales();
            brEjerciciosFiscales obrEjerciciosFiscales = new brEjerciciosFiscales();
            List<beEjerciciosFiscales> ListaEjerciciosFiscales = obrEjerciciosFiscales.listarTodos_EjerciciosFiscales().Where(EjerciciosFiscales => EjerciciosFiscales.Activo == true).ToList();
            if (ListaEjerciciosFiscales.Count > 0)
            {
                obeEjerciciosFiscales = ListaEjerciciosFiscales.First();
            }
            return obeEjerciciosFiscales;
        }

        public beOrigenRecurso GetOrigenRecurso()
        {
            beOrigenRecurso obeOrigenRecurso = new beOrigenRecurso();
            brOrigenRecurso obrOrigenRecurso = new brOrigenRecurso();
            List<beOrigenRecurso> ListaOrigenRecurso = obrOrigenRecurso.listarTodos_OrigenRecurso().Where(item => item.OrigenRecurso == "Estatal").ToList();
            if (ListaOrigenRecurso.Count > 0)
            {
                obeOrigenRecurso = ListaOrigenRecurso.First();
            }
            return obeOrigenRecurso;
        }

        public List<beProveedores> GetAllProveedores(int IdGobierno)
        {
            brProveedores obrProveedores = new brProveedores();
            var ListaProveedores = obrProveedores.listarTodos_Proveedores_CM();
            ListaProveedores = ListaProveedores.Where(x => x.IdGobierno == IdGobierno).ToList();
            return ListaProveedores;
        }

        public int GuardaRequisicionCM(beRequisicionesComprasMenores requisicionescm)
        {
            brRequisicionesComprasMenores obrRequisicionesComprasMenores = new brRequisicionesComprasMenores();
            return obrRequisicionesComprasMenores.guardarRequisicionesComprasMenores(requisicionescm);
        }

        public int ActualizarRequisicionCM(beRequisicionesComprasMenores requisicionescm)
        {
            brRequisicionesComprasMenores obrRequisicionesComprasMenores = new brRequisicionesComprasMenores();
            return obrRequisicionesComprasMenores.actualizarRequisicionesComprasMenores(requisicionescm);
        }

        public beRequisicionesComprasMenores TraerRequisicionCM(int pIdReqCM)
        {
            beRequisicionesComprasMenores obeReqCM = new beRequisicionesComprasMenores();

            //obtenemos los valores guardados con esa Id
            brRequisicionesComprasMenores obrReqCM = new brRequisicionesComprasMenores();
            var ListaReqCM = obrReqCM.traerRequisicionesComprasMenores_x_IdRequisicionCompraMenor(pIdReqCM);

            obeReqCM.IdRequisicionCompraMenor = ListaReqCM.IdRequisicionCompraMenor;
            obeReqCM.IdDependencia = ListaReqCM.IdDependencia;
            obeReqCM.IdDepartamento = ListaReqCM.IdDepartamento;
            obeReqCM.IdOrigenRecurso = ListaReqCM.IdOrigenRecurso;
            obeReqCM.IdEstatusCM = ListaReqCM.IdEstatusCM;
            obeReqCM.IdPartida = ListaReqCM.IdPartida;
            obeReqCM.IdEjercicioFiscal = ListaReqCM.IdEjercicioFiscal;
            obeReqCM.IdTipoSolicitud = ListaReqCM.IdTipoSolicitud;
            obeReqCM.IdPresupuesto = ListaReqCM.IdPresupuesto;
            obeReqCM.FechaRequisicion = ListaReqCM.FechaRequisicion;
            obeReqCM.RequisicionFolio = ListaReqCM.RequisicionFolio;
            obeReqCM.ConsecutivoRequisicion = ListaReqCM.ConsecutivoRequisicion;
            obeReqCM.MontoAproximado = ListaReqCM.MontoAproximado;
            obeReqCM.CantidadLotes = ListaReqCM.CantidadLotes;
            obeReqCM.ImporteTotalLotes = ListaReqCM.ImporteTotalLotes;
            obeReqCM.Observaciones = ListaReqCM.Observaciones;
            obeReqCM.Justificacion = ListaReqCM.Justificacion;
            obeReqCM.FechaEntrega = ListaReqCM.FechaEntrega;
            obeReqCM.IdLugarEntrega = ListaReqCM.IdLugarEntrega;
            obeReqCM.FechaPago = ListaReqCM.FechaPago;
            obeReqCM.IdLugarPago = ListaReqCM.IdLugarPago;
            obeReqCM.SaldoPartida = ListaReqCM.SaldoPartida;
            obeReqCM.MontoPresupuestado = ListaReqCM.MontoPresupuestado;
            obeReqCM.IdUsuarioAutoriza = ListaReqCM.IdUsuarioAutoriza;
            obeReqCM.IdProveedor = ListaReqCM.IdProveedor;
            obeReqCM.Economia = ListaReqCM.Economia;
            obeReqCM.Ejercido = ListaReqCM.Ejercido;
            obeReqCM.IdUsuarioRegistro = ListaReqCM.IdUsuarioRegistro;
            obeReqCM.FechaRegistro = ListaReqCM.FechaRegistro;

            //obtenemos los datos de tablas externas
            brOrigenRecurso obrOriReq = new brOrigenRecurso();
            var ListaOriReq = obrOriReq.traerOrigenRecurso_x_IdOrigenRecurso(ListaReqCM.IdOrigenRecurso);

            obeReqCM.OrigenRecurso = ListaOriReq.OrigenRecurso;

            brPartidas obrPartida = new brPartidas();
            var ListaPartida = obrPartida.traerPartidas_x_IdPartida(ListaReqCM.IdPartida);

            obeReqCM.Partida = ListaPartida.Partida;

            brCapitulos obrCapitulos = new brCapitulos();
            var ListaCapitulos = obrCapitulos.traerCapitulos_x_IdCapitulo(ListaPartida.IdCapitulo);

            obeReqCM.IdCapitulo = ListaCapitulos.IdCapitulo;
            obeReqCM.Capitulo = ListaCapitulos.Capitulo;

            brEjerciciosFiscales obrEjerFis = new brEjerciciosFiscales();
            var ListaEjerFis = obrEjerFis.traerEjerciciosFiscales_x_IdEjercicioFiscal(ListaReqCM.IdEjercicioFiscal);

            obeReqCM.Ejercicio = ListaEjerFis.Ejercicio;

            return obeReqCM;
        }


        /* lotes */

        public int GetLastLote(int IdRequisicionCompraMenor)
        {
            var NoLote = 0;

            brRequisicionesComprasMenoresLotes obReqCMLotes = new brRequisicionesComprasMenoresLotes();
            List<beRequisicionesComprasMenoresLotes> ListaReqCMLotes = obReqCMLotes.traerRequisicionesComprasMenoresLotes_x_IdRequisicionCompraMenor(IdRequisicionCompraMenor).ToList();
            foreach (var item in ListaReqCMLotes)
            {
                if (NoLote < item.NoLote)
                {
                    NoLote = item.NoLote;
                }
            }
            NoLote++;

            return NoLote;
        }

        public int GuardaReqCMLote(beRequisicionesComprasMenoresLotes reqcmlote)
        {
            brRequisicionesComprasMenoresLotes obrReqCMLote = new brRequisicionesComprasMenoresLotes();
            return obrReqCMLote.guardarRequisicionesComprasMenoresLotes(reqcmlote);
        }

        public int ActualizaReqCMLote(beRequisicionesComprasMenoresLotes reqcmlote)
        {
            brRequisicionesComprasMenoresLotes obrReqCMLote = new brRequisicionesComprasMenoresLotes();
            return obrReqCMLote.actualizarRequisicionesComprasMenoresLotes(reqcmlote);
        }

        public List<beRequisicionesComprasMenoresLotes> GetAllLotes_x_IdReqCM(int IdReqCM)
        {
            brRequisicionesComprasMenoresLotes obrReqCMLotes = new brRequisicionesComprasMenoresLotes();
            var ListaLotes = obrReqCMLotes.traerRequisicionesComprasMenoresLotes_x_IdRequisicionCompraMenor(IdReqCM);

            return ListaLotes;
        }

        public beRequisicionesComprasMenoresLotes TraerReqCMLote(int pIdReqCMLote)
        {
            beRequisicionesComprasMenoresLotes obeReqCMLote = new beRequisicionesComprasMenoresLotes();

            //obtenemos los valores con esa id
            brRequisicionesComprasMenoresLotes obrReqCMLote = new brRequisicionesComprasMenoresLotes();
            var ListaReqCMLote = obrReqCMLote.traerRequisicionesComprasMenoresLotes_x_IdLoteCompraMenor(pIdReqCMLote);

            obeReqCMLote.IdLoteCompraMenor = ListaReqCMLote.IdLoteCompraMenor;
            obeReqCMLote.IdRequisicionCompraMenor = ListaReqCMLote.IdRequisicionCompraMenor;
            obeReqCMLote.NoLote = ListaReqCMLote.NoLote;
            obeReqCMLote.IdBienServicio = ListaReqCMLote.IdBienServicio;
            obeReqCMLote.Concepto = ListaReqCMLote.Concepto;
            obeReqCMLote.IdTipoBienServicio = ListaReqCMLote.IdTipoBienServicio;
            obeReqCMLote.Cantidad = ListaReqCMLote.Cantidad;
            obeReqCMLote.PrecioUnitario = ListaReqCMLote.PrecioUnitario;
            obeReqCMLote.Importe = ListaReqCMLote.Importe;
            obeReqCMLote.PorcentajeImpuesto = ListaReqCMLote.PorcentajeImpuesto;
            obeReqCMLote.ImporteImpuesto = ListaReqCMLote.ImporteImpuesto;
            obeReqCMLote.Total = ListaReqCMLote.Total;
            obeReqCMLote.FechaRegistro = ListaReqCMLote.FechaRegistro;
            obeReqCMLote.IdUsuarioRegistro = ListaReqCMLote.IdUsuarioRegistro;

            return obeReqCMLote;
        }

        public int BorraReqCMLote(int pIdReqCMLote)
        {
            brRequisicionesComprasMenoresLotes obrReqCMLotes = new brRequisicionesComprasMenoresLotes();
            return obrReqCMLotes.eliminarRequisicionesComprasMenoresLotes(pIdReqCMLote);
        }

        public List<beRequisicionesComprasMenores> consultaRequisicionCM(int pIdLista, int pIdPerfil, int pIdDependencia)
        {
            beGenerica oGenerico = new beGenerica();
            oGenerico.entero3 = pIdLista;
            oGenerico.entero2 = pIdPerfil;
            oGenerico.entero = pIdDependencia;
            brRequisicionesComprasMenores b = new brRequisicionesComprasMenores();
            return b.listarTodos_RequisicionesComprasMenores_Listado(oGenerico);

        }


    }
}