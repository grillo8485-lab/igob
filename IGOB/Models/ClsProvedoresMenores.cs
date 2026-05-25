using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iGob.Entidades;
using iGob.ReglasNegocios;

namespace IGOB.Models
{
    public class ClsProvedoresMenores
    {
        private brProveedores ObrProveedores = new brProveedores();
        public List<beProveedores> ListProvMen(int idGob){
            return ObrProveedores.listarTodos_Proveedores_CM().Where(x=>x.IdGobierno == idGob).ToList();
        }
        public List<beProveedores> ListProvGen(int idGob)
        {
            return ObrProveedores.listarTodos_Proveedores_GetAll().Where(x => x.IdGobierno == idGob).ToList();
        }
        public List<beEF_EntidadesFederativas> ListEF(){
            return new brEF_EntidadesFederativas().listarTodos_EF_EntidadesFederativas().ToList();
        }
        public List<beActividadesEconomicas> ListActE(){
            return new brActividadesEconomicas().listarTodos_ActividadesEconomicas().ToList();
        }
        public List<beTiposRepresentacion> ListTipRep(){
            return new brTiposRepresentacion().listarTodos_TiposRepresentacion().ToList();
        }
        public List<beProveedoresAccionistas> ListProvAc(){
            return new brProveedoresAccionistas().listarTodos_ProveedoresAccionistas().ToList();
        }
        public List<beGobierno> ListGob(){
            return new brGobierno().listarTodos_Gobierno().ToList();
        }
        public List<beBancos> ListBanc(){
            return new brBancos().listarTodos_Bancos().ToList();
        }
        public List<beEF_Municipios> ListMunxId(String id){
            return new brEF_Municipios().listarTodos_EF_Municipios().Where(x => x.ClaveEstado == id).ToList();
        }
        public List<beEF_EntidadesFederativas> ListEntxId(String id){
            return new brEF_EntidadesFederativas().listarTodos_EF_EntidadesFederativas().Where(x => x.ClaveEstado == id).ToList();
        }

    }
}