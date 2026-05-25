using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class ClsPerfil
    {
        public List<ClsGenerica> getPerfiles()
        {
            try
            {
                List<ClsGenerica> a = new List<ClsGenerica>();
                List<beSysPerfiles> b = new List<beSysPerfiles>();
                brSysPerfiles c = new brSysPerfiles();
                b = c.listarTodos_SysPerfiles();
                foreach (var item in b)
                {
                    ClsGenerica cls = new ClsGenerica();
                    cls.id = item.IdPerfil;
                    cls.string1 = item.Perfil;
                    cls.string2 = item.Descripcion;
                    cls.string3 = item.CodigoPerfil;
                    cls.string4 = item.Activo ? "Activo" : "Inactivo";
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
        public beSysPerfiles getPerfil(int pIdPerfil)
        {
            brSysPerfiles c = new brSysPerfiles();
            return c.traerSysPerfiles_x_IdPerfil(pIdPerfil);
        }
        public int savePerfil(beSysPerfiles pSysPerfil)
        {
            brSysPerfiles a = new brSysPerfiles();
            return a.guardarSysPerfiles(pSysPerfil);
        }
        public int saveEditPerfil(beSysPerfiles pSysPerfil)
        {
            brSysPerfiles a = new brSysPerfiles();
            return a.actualizarSysPerfiles(pSysPerfil);
        }
        public List<beSysPerfiles> getAllModulo()
        {
            try
            {
                List<beSysPerfiles> b = new List<beSysPerfiles>();
                brSysPerfiles c = new brSysPerfiles();
                return c.listarTodos_SysPerfiles();
            }
            catch (Exception ex)
            {
                return new List<beSysPerfiles>();
            }

        }
    }
}