using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iGob.Entidades;
using iGob.ReglasNegocios;

namespace IGOB.Models
{
    public class ClsClavesPresupuestales
    {
        public List < bePresupuestosPartidas > GetPresupuestosPartidas_x_IdDependencia(int IdDependencia)
        {
            brPresupuestosPartidas p = new brPresupuestosPartidas();

            return p.listarTodos_PresupuestosPartidas().Where(x => x.IdDependencia == IdDependencia).ToList();
        }

        public List<beCapitulos> GetCapitulos()
        {
            brCapitulos b = new brCapitulos();

            var c = b.listarTodos_Capitulos();

            foreach (var item in c)
            {
                item.Capitulo = item.ClaveCapitulo + " " + item.Capitulo.Trim();
            }
            return c;
        }

        public List<beDependencias> GetDependencias()
        {
            brDependencias d = new brDependencias();

            return d.Listar_Dependencias_GetAll().ToList();

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

        public List<beOrigenRecurso> GetOrigenRecurso()
        {
            brOrigenRecurso o = new brOrigenRecurso();

            return o.listarTodos_OrigenRecurso().ToList();
        }

        public List<beClavesPresupuestalesDetalles> GetClavesPresupuestalesDetalles_x_IdPresupuestoPartida(int IdPresupuestoPartida)
        {
            brClavesPresupuestalesDetalles c = new brClavesPresupuestalesDetalles();

            return c.listar_ClavesPresupuestalesDetalles_IdPresupuestoPartida(IdPresupuestoPartida);
        }

        public beCapitulos GetCapitulo_x_IdPartida(int IdPartida)
        {
            brCapitulos c = new brCapitulos();
            brPartidas p = new brPartidas();

            var q = p.traerPartidas_x_IdPartida(IdPartida).IdCapitulo;
            var t = c.traerCapitulos_x_IdCapitulo(q);

            t.Capitulo = t.ClaveCapitulo + " " + t.Capitulo.Trim();

            return t;
        }

        public bePartidas getPartida_x_IdPartida(int IdPartida) {

            brPartidas p = new brPartidas();

            var q = p.traerPartidas_x_IdPartida(IdPartida);

            q.Partida = q.ClavePartida.Trim() + " " + q.Partida;

            return q;

        }


        public int DeletePresupuestosPartidas_w_ClavesPresupuestalesDetalles(int IdPresupuestoPartida)
        {
            brPresupuestosPartidas p = new brPresupuestosPartidas();
            brClavesPresupuestalesDetalles c = new brClavesPresupuestalesDetalles();
            var Result = 0;

            bePresupuestosPartidas PresupuestoPartida = p.traerPresupuestosPartidas_x_IdPresupuestoPartida(IdPresupuestoPartida);
            var clavesPresupuestalesDetalles = c.listar_ClavesPresupuestalesDetalles_IdPresupuestoPartida(IdPresupuestoPartida);

            if (PresupuestoPartida != null)
            {
                if (clavesPresupuestalesDetalles != null)
                {                    
                    c.eliminarClavesPresupuestalesDetalles_x_IdPresupuestoPartida(IdPresupuestoPartida);
                }
                p.eliminarPresupuestosPartidas(IdPresupuestoPartida);

                Result = 1;
            }

            return Result;
        }

        public decimal getMontoSaldo(int IdPresuestoPartida) {
            brPresupuestosPartidas p = new brPresupuestosPartidas();

            return p.traerPresupuestosPartidas_x_IdPresupuestoPartida(IdPresuestoPartida).MontoSaldo;
        }
    }
}