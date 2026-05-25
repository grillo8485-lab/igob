using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iGob.ReglasNegocios;
using iGob.Entidades;
using IGOB.Areas.Catalogos.Models;

namespace IGOB.Models
{
    public class ClsDatosPersonas
    {
        public List<beEF_EntidadesFederativas> ListEntFed()
        {
            return new brEF_EntidadesFederativas().listarTodos_EF_EntidadesFederativas().ToList();
        }
        public string GetMunicipio_idColonia(string idColonia)
        {
            beEF_Colonias colonia = new brEF_Colonias().listarTodos_EF_Colonias().FirstOrDefault(x => x.IdColonia.Trim() == idColonia.Trim());
            return colonia.IdMunicipio = (colonia.IdMunicipio != null ? colonia.IdMunicipio : "");
        }
        public List<beEF_Municipios> ListMunxClaveEst(String id)
        {
            return new brEF_Municipios().listarTodos_EF_Municipios().Where(x => x.ClaveEstado == id).ToList();
        }
        public List<beEF_Colonias> ListColonias(string idmun)
        {
            return new brEF_Colonias().listarTodos_EF_Colonias().Where(x => x.IdMunicipio.Trim() == idmun.Trim()).ToList();
        }
        public List<beDependencias> ListDependencias()
        {
            return new brDependencias().listarTodos_Dependencias().ToList();
        }
        public List<beProveedores> ListProv()
        {
            return new brProveedores().listarTodos_Proveedores().ToList();
        }
        public List<beGobierno> ListGobierno()
        {
            return new brGobierno().listarTodos_Gobierno().ToList();
        }
        public List<beTiposPersonas> ListTipoPersonas()
        {
            return new brTiposPersonas().listarTodos_TiposPersonas().ToList();
        }
        public List<beEstatusPersonas> ListEstatus()
        {
            return new brEstatusPersonas().listarTodos_EstatusPersonas().ToList();
        }
    }
}