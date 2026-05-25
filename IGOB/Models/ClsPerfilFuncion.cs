using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class ClsPerfilFuncion
    {
        public List<ClsGenerica> getPerfilesFuciones()
        {
            try
            {
                List<ClsGenerica> a = new List<ClsGenerica>();
                return a;
            }
            catch (Exception ex)
            {
                
                return new List<ClsGenerica>();
            }

        }
        public beSysPerfilesFunciones getPerfilFunciones(int pIdPerfilFunciones)
        {
            brSysPerfilesFunciones c = new brSysPerfilesFunciones();
            return c.traerSysPerfilesFunciones_x_IdPerfilFuncion(pIdPerfilFunciones);
        }
        public int eliminarPerfilFuciones(int pIdPerfilFunciones)
        {
            brSysPerfilesFunciones a = new brSysPerfilesFunciones();
            return a.eliminarSysPerfilesFunciones(pIdPerfilFunciones);
        }
        public int savePerfilFuciones(beSysPerfilesFunciones pSysPerfilFunciones)
        {
            brSysPerfilesFunciones a = new brSysPerfilesFunciones();
            return a.guardarSysPerfilesFunciones(pSysPerfilFunciones);
        }
        public int saveEditPerfilFUnciones(beSysPerfilesFunciones pSysPerfilFunciones)
        {
            brSysPerfilesFunciones a = new brSysPerfilesFunciones();
            return a.actualizarSysPerfilesFunciones(pSysPerfilFunciones);
        }
        public List<beSysPerfilesFunciones> getAllPerfilFunciones_x_IdPerfil(int pIdPerfil)
        {
            try
            {
                List<beSysPerfilesFunciones> b = new List<beSysPerfilesFunciones>();
                brSysPerfilesFunciones c = new brSysPerfilesFunciones();
                return c.listarTodos_SysPerfilesFunciones().Where(s=> s.IdPerfil == pIdPerfil).ToList();
            }
            catch (Exception ex)
            {
                return new List<beSysPerfilesFunciones>();
            }

        }
        public List<PerfilesFunciones> procesarMenuPerfilFunciones(List<PerfilesFunciones> lstMenu, List<beSysPerfilesFunciones> lstPerfilFunciones)
        {
            foreach(var item in lstPerfilFunciones)
            {
                foreach(var itemModulo in lstMenu)
                {
                    var a = itemModulo.Funciones.Where(s => s.IdFuncion == item.IdFuncion).ToList();
                    if(a.Count > 0)
                    {
                        var b = a.First();
                        b.ActivoMenu = true;
                        b.btnNuevo = item.btnNuevo;
                        b.btnEliminar = item.btnEliminar;
                        b.btnEditar = item.btnEditar;
                        b.btnConsultar = item.btnConsultar;
                        itemModulo.Modulos.ActivoPerfil = true;
                        break;
                    }
                    
                }
                    
            }
            return lstMenu;
        }
        public List<PerfilesFunciones> getAllMenu()
        {
            List<PerfilesFunciones> lstPerfilesFunciones = new List<PerfilesFunciones>();
            ClsModulo modulo = new ClsModulo();
            ClsFuncion funcion = new ClsFuncion();
            var modulos = modulo.getAllModulo();
            var funciones = funcion.getAllFunciones();
            foreach (var itemModulo in modulos)
            {
                var x = funciones.Where(s => s.IdModulo == itemModulo.IdModulo).ToList();
                if (x.Count > 0)
                {
                    PerfilesFunciones objeto = new PerfilesFunciones();
                    objeto.Modulos = new Modulo();
                    objeto.Modulos.IdModulo = itemModulo.IdModulo;
                    objeto.Modulos.Descripcion = itemModulo.Descripcion;
                    objeto.Modulos.Clave = itemModulo.Clave;
                    objeto.Modulos.ActivoPerfil = false;
                    objeto.Funciones = new List<Funcion>();
                    foreach (var itemFunciones in x)
                    {
                        Funcion f = new Funcion();
                        f.IdFuncion = itemFunciones.IdFuncion;
                        f.IdModulo = itemFunciones.IdModulo;
                        f.Descripcion = itemFunciones.Descripcion;
                        f.btnNuevo = false;
                        f.btnEliminar = false;
                        f.btnEditar = false;
                        f.btnConsultar = false;
                        f.ActivoMenu = false;
                        objeto.Funciones.Add(f);
                    }
                    
                    lstPerfilesFunciones.Add(objeto);
                }
                
            }

            return lstPerfilesFunciones;
        }
        public List<beSysPerfilesFunciones> getPerfilFuncionesEliminar(List<beSysPerfilesFunciones> pLstPerfilFuncionesBase, List<beSysPerfilesFunciones> pLstPerfilFuncionesVista)
        {
            try
            {
                List<beSysPerfilesFunciones> listaEliminar = new List<beSysPerfilesFunciones>();
                foreach (var itemBase in pLstPerfilFuncionesBase)
                {
                    bool encontrado = false;
                    foreach(var itemVista in pLstPerfilFuncionesVista)
                    {
                        if(itemBase.IdFuncion == itemVista.IdFuncion)
                        {
                            encontrado = true;
                        }
                    }
                    if (!encontrado)
                    {
                        listaEliminar.Add(itemBase);
                    } 
                }
                return listaEliminar;
            }
            catch (Exception ex)
            {
                return new List<beSysPerfilesFunciones>();
            }

        }
        public List<beSysPerfilesFunciones> getPerfilFuncionesAgregar(List<beSysPerfilesFunciones> pLstPerfilFuncionesBase, List<beSysPerfilesFunciones> pLstPerfilFuncionesVista)
        {
            try
            {
                List<beSysPerfilesFunciones> listaAgregar = new List<beSysPerfilesFunciones>();
                foreach (var itemVista in pLstPerfilFuncionesVista)  
                {
                    bool encontrado = false;
                    foreach (var itemBase in pLstPerfilFuncionesBase)
                    {
                        if (itemBase.IdFuncion == itemVista.IdFuncion)
                        {
                            encontrado = true;
                        }
                    }
                    if (!encontrado)
                    {
                        listaAgregar.Add(itemVista);
                    }
                }
                return listaAgregar;
            }
            catch (Exception ex)
            {
                return new List<beSysPerfilesFunciones>();
            }

        }
        public List<beSysPerfilesFunciones> getPerfilFuncionesActualizar(List<beSysPerfilesFunciones> pLstPerfilFuncionesBase, List<beSysPerfilesFunciones> pLstPerfilFuncionesVista)
        {
            try
            {
                List<beSysPerfilesFunciones> listaActualizar = new List<beSysPerfilesFunciones>();
                foreach (var itemVista in pLstPerfilFuncionesVista)
                {
                    bool encontrado = false;
                    foreach (var itemBase in pLstPerfilFuncionesBase)
                    {
                        if (itemBase.IdFuncion == itemVista.IdFuncion)
                        {
                            itemVista.IdPerfilFuncion = itemBase.IdPerfilFuncion;
                            encontrado = true;
                        }
                    }
                    if (encontrado)
                    {

                        listaActualizar.Add(itemVista);
                    }
                }
                return listaActualizar;
            }
            catch (Exception ex)
            {
                return new List<beSysPerfilesFunciones>();
            }

        }
    }
}