using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class ClsGenerarLicitacion
    {
        public List<beEjerciciosFiscales> getAllEjercicioFiscal()
        {
            return (new brEjerciciosFiscales()).listarTodos_EjerciciosFiscales();
        }
        public List<beUnidadesLicitadoras> getAllUnidadesLicitadoras(int pIdDependencia)
        {
            return (new brUnidadesLicitadoras()).listarTodos_UnidadesLicitadoras().Where(s => s.Activo == true && s.IdDependencia == pIdDependencia).ToList();
        }
        public List<beTiempos> getAllTiempos()
        {
            return (new brTiempos()).listarTodos_Tiempos().Where(s => s.Activo == true).ToList();
        }
        public beLicitaciones getLicitacion(int pIdLicitacion, ClsGenerica s, int idEjerccioFiscal, int IdTipoLicitacion, int IdTiempo, int IdModalidadLicitacion)
        {
            if (pIdLicitacion == 0)
            {

                var a = (new brLicitaciones()).traerLicitaciones_x_Fecha_IdGobierno(DateTime.Now, s.id5, IdTipoLicitacion, IdTiempo, IdModalidadLicitacion);
                a.IdUsuarioRegistro = (int)s.id2;
                a.FechaRegistro = DateTime.Now;
                a.IdEjercicioFiscal = idEjerccioFiscal;
                var id = (new brLicitaciones()).guardarLicitaciones(a);
                var licitacion = (new brLicitaciones()).traerLicitaciones_x_IdLicitacion(id);
                licitacion.Modalidad = (new brModalidadesLicitaciones()).traerModalidadesLicitaciones_x_IdModalidadLicitacion(licitacion.IdModalidadLicitacion).ModalidadLicitacion;
                return licitacion;
                //return a;
            }
            else
            {
                var licitacion = (new brLicitaciones()).traerLicitaciones_x_IdLicitacion(pIdLicitacion);
                licitacion.Modalidad = (new brModalidadesLicitaciones()).traerModalidadesLicitaciones_x_IdModalidadLicitacion(licitacion.IdModalidadLicitacion).ModalidadLicitacion;
                return licitacion;
            }

        }
        public List<beLicitacionesRequisiciones> getLicitacionRequisiciones(int pIdLicitacion, List<int> id, int pIdUsuario)
        {
            var lst = new List<beLicitacionesRequisiciones>();
            if (id.Count() > 0)
            {
                lst = (new brLicitacionesRequisiciones()).listarTodos_LicitacionesRequisiciones().Where(s => s.IdLicitacion == pIdLicitacion).ToList();
                foreach (var item in lst)
                {
                    (new brLicitacionesRequisiciones()).eliminarLicitacionesRequisiciones(item.IdLicitacionRequisicion);
                }
                foreach (var item in id)
                {
                    var requisicion = (new brRequisiciones()).traerRequisiciones_x_IdRequisicion(item);
                    var partidad = (new brPartidas()).traerPartidas_x_IdPartida(requisicion.IdPartida);
                    var i = new beLicitacionesRequisiciones(
                        0,
                        pIdLicitacion,
                        item,
                        DateTime.Now,
                        requisicion.FechaAutorizacion,
                        1,
                        pIdUsuario,
                        DateTime.Now,
                        (new brDependencias()).traerDependencias_x_IdDependencia(requisicion.IdDependencia).Dependencia,
                        partidad.ClavePartida.Trim() + " " + partidad.Partida.Trim(),
                        requisicion.RequisicionFolio
                    );
                    (new brLicitacionesRequisiciones()).guardarLicitacionesRequisiciones(i);
                }

            }


            lst = (new brLicitacionesRequisiciones()).listarTodos_LicitacionesRequisiciones().Where(s => s.IdLicitacion == pIdLicitacion).ToList();
            foreach (var item in lst)
            {
                var requisicion = (new brRequisiciones()).traerRequisiciones_x_IdRequisicion(item.IdRequisicion);
                item.Dependencia = (new brDependencias()).traerDependencias_x_IdDependencia(requisicion.IdDependencia).Dependencia;
                var partidad = (new brPartidas()).traerPartidas_x_IdPartida(requisicion.IdPartida);
                item.Partida = partidad.ClavePartida.Trim() + " " + partidad.Partida.Trim();
                item.FolioRequisicion = requisicion.RequisicionFolio;
            }
            return lst;


        }
        public int updateDates(beLicitaciones data)
        {
            return (new brLicitaciones()).actualizarLicitaciones(data);
            //return (new brLicitaciones()).traerLicitaciones_x_IdLicitacion(id);
        }

        public beLicitaciones updateLicitacion(beLicitaciones data, int IdGobierno, int IdTipoLicitacion, int IdTiempo, int IdModalidadLicitacion)
        {

            var a = (new brLicitaciones()).traerLicitaciones_x_Fecha_IdGobierno(data.FechaAutorizacion, IdGobierno, IdTipoLicitacion, IdTiempo, IdModalidadLicitacion);
            a.IdEjercicioFiscal = data.IdEjercicioFiscal;
            a.IdLicitacion = data.IdLicitacion;
            a.IdUnidadLicitadora = data.IdUnidadLicitadora;
            a.HoraAutorizacion = TimeSpan.Parse(string.Format("{0:HH:mm:ss}", data.FechaAutorizacion));
            a.HoraFallo = TimeSpan.Parse(string.Format("{0:HH:mm:ss}", data.FechaFallo));
            a.FechaFallo = data.FechaFallo;
            a.FechaHoraAclaracionDudas = data.FechaHoraAclaracionDudas;

            var id = (new brLicitaciones()).actualizarLicitaciones(a);
            return (new brLicitaciones()).traerLicitaciones_x_IdLicitacion(data.IdLicitacion);

        }
        public int publicar(beLicitaciones data)
        {
            var a = (new brLicitaciones()).traerLicitaciones_x_IdLicitacion(data.IdLicitacion);
            a.IdEstatusLicitacion = 20;
            a.IdEtapaLicitacion = 1;
            var lst = (new brLicitacionesRequisiciones()).listarTodos_LicitacionesRequisiciones().Where(s => s.IdLicitacion == data.IdLicitacion).ToList();
            var requisicion_ = (new brRequisiciones()).traerRequisiciones_x_IdRequisicion(lst[0].IdRequisicion);
            switch (requisicion_.IdTipoRequisicion)
            {
                case 1:
                    a.IdModalidadLicitacion = 1;
                    break;
                case 2:
                    a.IdModalidadLicitacion = 4;
                    break;
                case 3:
                    a.IdModalidadLicitacion = 7;
                    break;
            }
            a.IdUsuarioRevisor = requisicion_.IdUsuarioRevisor;
            var id = (new brLicitaciones()).actualizarLicitaciones(a);
            return id;

        }
        public beLicitaciones getLicitacion_x_IdLicitacion(int IdLicitacion)
        {
            return (new brLicitaciones()).traerLicitaciones_x_IdLicitacion(IdLicitacion);
        }
        public int getCountLicitacionesPendientes()
        {
            return (new brLicitaciones()).listarTodos_Licitaciones().Where(s => s.IdEstatusLicitacion == 10).ToList().Count;
        }
        public beTmpRequisicionesLicitacion set_Get_TempLicitacionRequisiciones(List<int> id)
        {
            var guid = Guid.NewGuid();
            if (id.Count() > 0)
            {
                
                foreach (var item in id)
                {
                    var requisicion = (new brRequisiciones()).traerRequisiciones_x_IdRequisicion(item);
                    var i = new beTmpRequisicionesLicitacion(
                        pIdRequisicion: requisicion.IdRequisicion,
                        pIdGuid: guid.ToString(),
                        pIdTiempo: requisicion.IdTiempo,
                        pTotal: requisicion.MontoAproximadoAutorizado
                    );
                    (new brTmpRequisicionesLicitacion()).guardarTmpRequisicionesLicitacion(i);
                }
            }
            return (new brTmpRequisicionesLicitacion()).getTmpRequisicionesLicitacion_x_Guid(guid.ToString());
        }
        
    }
}