using iGob.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Models
{
    public class GenerarLicitacion 
    {
        public beLicitaciones oLicitacion = new beLicitaciones();
        public List<beLicitacionesRequisiciones> lstLicitacionRequisiciciones = new List<beLicitacionesRequisiciones>();
        public SelectList lstEjerccioFiscal;
        public SelectList lstNumeroUnidadLicitatotia;
        public SelectList lstTiempos;
        public string IdRequisisicones = string.Empty;
    }
}