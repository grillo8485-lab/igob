using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iGob.Entidades;
using iGob.ReglasNegocios;

namespace IGOB.Models
{
    public class ClsRequisicionFirmante
    {
        private brRequisiciones ObrRequisiciones = new brRequisiciones();
        public beRequisicionesFirmantes validarCamposStatus(beRequisicionesFirmantes ReqFirmantes)
        {
            if (ReqFirmantes.ValidaCondicionEntrega == true && ReqFirmantes.ValidaCondicionPago == true && ReqFirmantes.ValidaLotes == true)
            {
                ReqFirmantes.IdEstatusRequisicion = 70;
                
            }
            else
            {
                ReqFirmantes.IdEstatusRequisicion = 75;
                
            }
            ReqFirmantes.ObservacionLotes = ReqFirmantes.ObservacionLotes == null?"Sin Observaciones": ReqFirmantes.ObservacionLotes;
            ReqFirmantes.ObservacionCondicionPago = ReqFirmantes.ObservacionCondicionPago == null?"Sin Observaciones": ReqFirmantes.ObservacionCondicionPago;
            ReqFirmantes.OnservacionCondicionEntrega = ReqFirmantes.OnservacionCondicionEntrega == null?"Sin Observaciones":ReqFirmantes.OnservacionCondicionEntrega;

            var requisicionStatus = ObrRequisiciones.traerRequisiciones_x_IdRequisicion(ReqFirmantes.IdRequisicion);
            requisicionStatus.IdEstatusRequisicion = ReqFirmantes.IdEstatusRequisicion;
            ObrRequisiciones.actualizarRequisiciones(requisicionStatus);
            return ReqFirmantes;
        }
    }
}