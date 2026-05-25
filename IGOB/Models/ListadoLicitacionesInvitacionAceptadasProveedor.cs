using iGob.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Models
{
    public class ListadoLicitacionesInvitacionAceptadasProveedor
    {
        public List<beListadoLicitacionesInvitacionProveedores> lstInvitacionesAcptadasProveedor = new List<beListadoLicitacionesInvitacionProveedores>();
        public beLicitacionesInvitacionProveedores oLicitacionesInvitacionProveedores = new beLicitacionesInvitacionProveedores();
        public SelectList lstEstatusPagos;
        public SelectList lstMotivoRechazo;
        public string extencionArvhico = string.Empty;
        public int IdPerfil = 0;
        public string Titulo = "";
    }
}