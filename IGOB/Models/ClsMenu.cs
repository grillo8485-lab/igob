
using iGob.Entidades;
using iGob.ReglasNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    
    public class ClsMenu
    {
        protected int _idUsuario = 0;
        public ClsMenu(int idUsuario)
        {
            _idUsuario = idUsuario;
        }
        public ClsMenu()
        {
            
        }
        public List<ClsMenuPropiedades> getMenu()
        {
            List<ClsMenuPropiedades> clsMenuPropiedaes = new List<ClsMenuPropiedades>();
            
            var usuario = getUsuario();
            var perfil = getPerfilUsuario(usuario.IdPerfil);
            if (perfil.Activo)
            {
                List<beSysPerfilesFunciones> lstPerfilFunciones = getPerfilesFunciones(usuario.IdPerfil);
                var lstFunciones = getFunciones(lstPerfilFunciones).OrderBy(s=> s.Orden).ToList();
                List<beSysModulos> lstModulos = null;
                if (lstFunciones.Count > 0)
                {
                    lstFunciones = lstFunciones.Where(s => s.Activo == true).ToList();
                    lstModulos = getModulos(lstFunciones).OrderBy(s => s.Orden).ToList();
                    if (lstModulos.Count > 0)
                    {
                        lstModulos = lstModulos.Where(s => s.Activo == true).ToList();
                        clsMenuPropiedaes = getMenuFInal(lstModulos, lstFunciones);
                        return clsMenuPropiedaes;
                    }
                    else
                    {
                        return clsMenuPropiedaes;
                    }
                }
                else
                {
                    return clsMenuPropiedaes;
                }
                
            }
            else
            {
                return clsMenuPropiedaes;
            }

        }
        protected beSysUsuarios getUsuario()
        {
            beSysUsuarios usuario = new beSysUsuarios();
            brSysUsuarios brUsuario = new brSysUsuarios();
            usuario = brUsuario.traerSysUsuarios_x_IdUsuario(_idUsuario);
            return usuario;
        }
        protected beSysPerfiles getPerfilUsuario(int IdPerfil)
        {
            beSysPerfiles perfil = new beSysPerfiles();
            brSysPerfiles brPerfiles = new brSysPerfiles();
            perfil = brPerfiles.traerSysPerfiles_x_IdPerfil(IdPerfil );
            return perfil;
        }
        protected List<beSysPerfilesFunciones> getPerfilesFunciones(int IdPerfil)
        {
            List<beSysPerfilesFunciones> lstPerfilFunciones = new List<beSysPerfilesFunciones>();
            brSysPerfilesFunciones brPerfileFunciones = new brSysPerfilesFunciones();
            lstPerfilFunciones = brPerfileFunciones.traerSysPerfilesFunciones_x_IdPerfil(IdPerfil);
            return lstPerfilFunciones;
        }
        protected List<beSysFunciones> getFunciones(List<beSysPerfilesFunciones> lstPerfilFunciones)
        {
            var lstFunciones = new List<beSysFunciones>();
            brSysFunciones brFunciones = new brSysFunciones();
            foreach (beSysPerfilesFunciones item in lstPerfilFunciones)
            {
                beSysFunciones a = new beSysFunciones();
                a = brFunciones.traerSysFunciones_x_IdFuncion(item.IdFuncion);
                lstFunciones.Add(a);
            }
            return lstFunciones.OrderBy(x => x.Orden).ToList();
        }
        public List<beSysFunciones> getAllFunciones()
        {
            var lstFunciones = new List<beSysFunciones>();
            var lst = (new brSysFunciones()).listarTodos_SysFunciones();
            
            return lst;
        }
        protected List<beSysModulos> getModulos(List<beSysFunciones> lstFunciones)
        {
            List<beSysModulos> lstModulos = new List<beSysModulos>();
               var groupedCustomerList = lstFunciones.GroupBy(u => u.IdModulo).ToList();
            brSysModulos brModulos = new brSysModulos();
            foreach (var item in groupedCustomerList)
            {
                beSysModulos a = new beSysModulos();
                a = brModulos.traerSysModulos_x_IdModulo(item.Key);
                lstModulos.Add(a);
            }

                
            return lstModulos;
        }
        protected List<ClsMenuPropiedades> getMenuFInal(List<beSysModulos> lstModulo, List<beSysFunciones> lstFunciones)
        {
            List<ClsMenuPropiedades> menuPropiedades = new List<ClsMenuPropiedades>();

            foreach (var item in lstModulo)
            {
                ClsMenuPropiedades a = new ClsMenuPropiedades();
                a.Modulo = item;
                a.Funciones = lstFunciones
                                    .Where(m => m.IdModulo == item.IdModulo)
                                    .ToList();
                menuPropiedades.Add(a);
            }


            return menuPropiedades;
        }
    }
}