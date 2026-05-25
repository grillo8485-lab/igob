using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iGob.Entidades;

namespace IGOB.Models
{
    public class ClsEstudioMercado
    {
        public beBienServicioEstudioMercado ObeBienServicioEstudioMercado = new beBienServicioEstudioMercado();
        public beBienesServicios ObeBienesServicios = new beBienesServicios();
        public beCategoriasScian ObeCategoriasScian = new beCategoriasScian();
        public List<beEF_EntidadesFederativas> ObeEF_EntidadesFederativas = new List<beEF_EntidadesFederativas>();
        public List<beEF_Municipios> ObeEF_Municipios = new List<beEF_Municipios>();
        public List<beEF_Colonias> ObeEF_Colonias = new List<beEF_Colonias>();

    }
}