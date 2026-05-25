using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class ClsModulo
    {
        public List<ClsGenerica> getModulos()
        {
            try
            {
                List<ClsGenerica> a = new List<ClsGenerica>();
                List<beSysModulos> b = new List<beSysModulos>();
                brSysModulos c = new brSysModulos();
                b = c.listarTodos_SysModulos();
                foreach (var item in b)
                {
                    ClsGenerica cls = new ClsGenerica();
                    cls.id = item.IdModulo;
                    cls.string1 = item.Modulo;
                    cls.string2 = item.Descripcion;
                    cls.string3 = item.Clave;
                    cls.id2 = item.Orden;
                    cls.string4 = item.Icono;
                    cls.string5 = item.Activo ? "Activo" : "Inactivo";
                    a.Add(cls);
                }
                return a;
            }
            catch (Exception ex)
            {
                List<ClsGenerica> a = new List<ClsGenerica>();
                return a;
            }
            
        }
        public beSysModulos getModulo(int pIdModlulo)
        {
            brSysModulos c = new brSysModulos();
            return c.traerSysModulos_x_IdModulo(pIdModlulo);
        }
        public int saveModulo(beSysModulos pSysModulo)
        {
            brSysModulos a = new brSysModulos();
            return a.guardarSysModulos(pSysModulo);
        }
        public int saveEditModulo(beSysModulos pSysModulo)
        {
            brSysModulos a = new brSysModulos();
            return a.actualizarSysModulos(pSysModulo);
        }
        public List<beSysModulos> getAllModulo()
        {
            try
            {
                List<beSysModulos> b = new List<beSysModulos>();
                brSysModulos c = new brSysModulos();
                return c.listarTodos_SysModulos().Where(s=> s.Activo == true).ToList();
            }
            catch (Exception ex)
            {
                return new List<beSysModulos>();
            }

        }
    }
   
}