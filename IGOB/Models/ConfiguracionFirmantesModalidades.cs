using iGob.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Models
{
    public class ConfiguracionFirmantesModalidades
    {
        public List<beConfiguracionFirmatesPedidos> lst = new List<beConfiguracionFirmatesPedidos>();
        public SelectList lstModalidades ;
    }
}