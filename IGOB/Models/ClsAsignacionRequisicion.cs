using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iGob.Entidades;
using iGob.ReglasNegocios;

namespace IGOB.Models
{
    public class ClsAsignacionRequisicion
    {
        public beRequisiciones requisicion(int id)
        {
            brRequisiciones r = new brRequisiciones();

            return r.traerRequisiciones_x_IdRequisicion(id);
        }

        public string GetPartida_x_Id(int idPartida)
        {
            brPartidas b = new brPartidas();
            var c = b.traerPartidas_x_IdPartida(idPartida);
            var d = c.Partida = c.ClavePartida.Replace(" ", string.Empty) + " " + c.Partida;

            return d;
        }

        public decimal Monto_Solicitado(int id)
        {
            brRequisiciones r = new brRequisiciones();
            var s = r.traerRequisiciones_x_IdRequisicion(id);

            return s.MontoAproximado;
        }

        public decimal Saldo_Presupuestado_Autorizado(int idPartida, int idDependencia)
        {
            brPresupuestosPartidas p = new brPresupuestosPartidas();
            var q = p.PresupuestosPartidas_Traer_IdDependencia_IdPartida(idDependencia, idPartida);

            return q.MontoSaldo;
        }

        public decimal Monto_Aproximado_Autorizado(int id)
        {
            brRequisiciones r = new brRequisiciones();
            var s = r.traerRequisiciones_x_IdRequisicion(id);

            return s.MontoAproximadoAutorizado;
        }

        public string GetOrigenRecurso_x_Id(int idOrigen)
        {
            brOrigenRecurso o = new brOrigenRecurso();
            var p = o.traerOrigenRecurso_x_IdOrigenRecurso(idOrigen);

            return p.OrigenRecurso;
        }

        public int GetIdPartida_x_idRequisicion(int idRequisicion)
        {
            brRequisiciones a = new brRequisiciones();
            var b = a.traerRequisiciones_x_IdRequisicion(idRequisicion);

            return b.IdPartida;
        }

        public bePresupuestosPartidas GetPresupuestoPartida_x_idPartida_IdDependencia_IdEjercicioFiscal(int idPartida, int IdDependencia, int IdEjercicioFiscal)
        {
            brPresupuestosPartidas a = new brPresupuestosPartidas();
            var o = new bePresupuestosPartidas();
            var f = a.listarTodos_PresupuestosPartidas().Where(x => x.IdPartida == idPartida && x.IdDependencia == IdDependencia && x.IdEjercicioFiscal == IdEjercicioFiscal);
            if (f.Count() > 0)
            {
                o = a.listarTodos_PresupuestosPartidas().Where(x => x.IdPartida == idPartida && x.IdDependencia == IdDependencia && x.IdEjercicioFiscal == IdEjercicioFiscal).First();
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

        public List<beCuentasBancariasDependencias> GetCuentas_x_IdOrigenRecurso(int idOrigenRecurso)
        {
            brCuentasBancariasDependencias b = new brCuentasBancariasDependencias();
            var c = b.listarTodos_CuentasBancariasDependencias().Where(x => x.IdOrigenRecurso == idOrigenRecurso).ToList();

            foreach (var item in c)
            {
                item.NumeroCuenta = item.NumeroCuenta.ToString() + " / $" + item.MontoDisponible;
            }
            return c;
        }

        public beCuentasBancariasDependencias GetNombreCuenta_x_IdCuenta(int idCuenta)
        {
            brCuentasBancariasDependencias b = new brCuentasBancariasDependencias();

            return b.traerCuentasBancariasDependencias_x_IdCuentaBancaria(idCuenta);
        }

        public beBancos GetNombreBanco_x_IdBanco(int idBanco)
        {
            brBancos b = new brBancos();

            return b.traerBancos_x_IdBanco(idBanco);
        }

        public int saveLiquidez(beRequisicionesLiquidez requisicionesLiquidez)
        {
            brRequisicionesLiquidez r = new brRequisicionesLiquidez();

            return r.guardarRequisicionesLiquidez(requisicionesLiquidez);
        }

        public List<beRequisicionesLiquidez> TraerLiquidez_x_IdRequisicion(int idRequisicion)
        {

            brRequisicionesLiquidez r = new brRequisicionesLiquidez();

            return r.RequisicionesLiquidez_Traer_IdRequisicion(idRequisicion);
        }

        public int Autorizar(beRequisiciones requisiciones)
        {
            brRequisiciones r = new brRequisiciones();

            return r.actualizarRequisiciones(requisiciones);
        }

        public beRequisiciones GetRequisiciones_x_IdRequisicion(int idRequisicion)
        {

            brRequisiciones r = new brRequisiciones();

            return r.traerRequisiciones_x_IdRequisicion(idRequisicion);
        }

        public decimal Sum_MontoComprometido_x_IdRequisicion(int idRequisicion)
        {

            brRequisicionesLiquidez r = new brRequisicionesLiquidez();

            var c = r.Listar_RequisicionLiquidez_x_IdRequisicion(idRequisicion).Select(x => x.MontoComprometido).ToList();
            decimal d = 0;
            foreach (var item in c)
            {
                d += item;
            }
            return d;
        }

        public int DeleteRequisicionLiquidez(int idRequisicionLiquidez)
        {
            brRequisicionesLiquidez r = new brRequisicionesLiquidez();

            return r.eliminarRequisicionesLiquidez(idRequisicionLiquidez);
        }

        public beRequisicionesLiquidez GetRequisicionesLiquidez_x_IdRequisicionLiquidez(int idRequisicionesLiquidez)
        {
            brRequisicionesLiquidez r = new brRequisicionesLiquidez();

            return r.traerRequisicionesLiquidez_x_IdRequisicionLiquidez(idRequisicionesLiquidez);
        }

        public int UpdateRequisicionLiquidez(beRequisicionesLiquidez requisicionesLiquidez)
        {
            brRequisicionesLiquidez r = new brRequisicionesLiquidez();

            return r.actualizarRequisicionesLiquidez(requisicionesLiquidez);
        }

        public beRequisicionesLiquidez CheckNumeroOperacion(string NumeroOperacion)
        {
            brRequisicionesLiquidez r = new brRequisicionesLiquidez();

            return r.listarTodos_RequisicionesLiquidez().Where(x => x.NumeroOperacion == NumeroOperacion).FirstOrDefault();
        }

        public string GetDependencia_x_IdDependencia(int idDependencia)
        {
            brDependencias d = new brDependencias();

            return d.traerDependencias_x_IdDependencia(idDependencia).Dependencia;
        }

        public decimal GetMontoPresupuestadoAutorizado_x_IdRequisicion(int idRequisicion)
        {
            brRequisiciones r = new brRequisiciones();

            return r.traerRequisiciones_x_IdRequisicion(idRequisicion).MontoAproximadoAutorizado;
        }

        public string GetNombreBanco_x_IdCuentaBancaria(int IdCuentaBancaria)
        {
            brCuentasBancariasDependencias c = new brCuentasBancariasDependencias();
            brBancos b = new brBancos();

            var d = c.traerCuentasBancariasDependencias_x_IdCuentaBancaria(IdCuentaBancaria).IdBanco;

            var e = b.traerBancos_x_IdBanco(d);

            return e.NombreCorto;

        }
    }
}