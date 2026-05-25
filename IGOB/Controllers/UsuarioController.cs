using iGob.Entidades;
using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class UsuarioController : ValidaSession
    {
        // GET: Usuario
        public ActionResult Index()
        {
            ClsUsuario a = new ClsUsuario();
            var UsuriosTexto = a.getAllUsuariosText();
            ViewBag.TPListPerfiles = new SelectList(a.getPerfiles(), "IdPerfil", "Descripcion"); 
           
            return View(UsuriosTexto);
        }

        [HttpPost]
        public JsonResult createUsuario(beSysUsuarios pSysUsuario)
        {
            
            ClsLogin lg = new ClsLogin(pSysUsuario.Usuario, pSysUsuario.Password);
            if (lg.searchUsuario_x_Usuario().Usuario == null)
            {
                pSysUsuario.Password = lg.getPassword();
                ClsUsuario a = new ClsUsuario();
                pSysUsuario.FechaRegistro = DateTime.Now;
                beDatosPersonas b = a.getPersona(pSysUsuario.IdPersona);
                if (b.IdPersona == 0)
                {
                    return Json(new { success = false, mensaje = "Error':'Datos de la persona no encontrado." }, JsonRequestBehavior.AllowGet);
                }
                pSysUsuario.IdDependencia = b.IdDependencia;
                pSysUsuario.IdProveedor = b.IdProveedor;
                pSysUsuario.Nombres = b.Nombres;
                pSysUsuario.Apellidos = b.Apellidos;
                pSysUsuario.LlaveAcceso = "";
                pSysUsuario.NoToken = "0";
                a.addSysUsuario(pSysUsuario);
                return Json(new { success = true, mensaje = "" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, mensaje = "Error Usuario repetido, Favor de verificar" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult buscarUsuario(string pTexto)
        {
            ClsUsuario a = new ClsUsuario();
            List<beDatosPersonas>  s = a.getPersonas(pTexto);
            List<ClsGenerica> b = new List<ClsGenerica>();
            foreach (var item in s)
            {
                ClsGenerica t = new ClsGenerica();
                t.id = item.IdPersona;
                t.string1 = item.Nombres;
                t.string2 = item.Rfc;
                t.string3 = a.getDependencias(item.IdDependencia).Dependencia;
                t.string4 = a.getProveedores(item.IdProveedor).RazonSocial;
                b.Add(t);
            }
            return Json(new { success = true, objeto = b }, JsonRequestBehavior.AllowGet); ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Eliminar(int Id)
        {
            if(Id == 0)
            {
                return Json(new { success = false, mensaje = "Error dato inconsistente" }, JsonRequestBehavior.AllowGet); ;
            }
            ClsUsuario a = new ClsUsuario();
            var b = a.getUsuario_x_IdUsuario(Id);
            b.Activo = false;
            a.deleteUsuario(b);
            return Json(new { success = true}, JsonRequestBehavior.AllowGet); ;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getUsuario_x_IdUsuario(int pIdUsuario)
        {
            ClsUsuario a = new ClsUsuario();
            var item = a.getUsuario_x_IdUsuario(pIdUsuario);
            ClsGenerica t = new ClsGenerica();
            t.id = item.IdPersona;
            t.string1 = item.Nombres + " " + item.Apellidos;
            t.string2 = item.CorreoElectronico;
            t.id2 = item.IdPerfil;
            t.bool1 = item.Activo;

            return Json(new { success = true, objeto = t }, JsonRequestBehavior.AllowGet); ;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Editar(beSysUsuarios pSysUsuario)
        {
            try
            {
                ClsUsuario a = new ClsUsuario();
                beSysUsuarios b = new beSysUsuarios();
                b = a.getUsuario_x_IdUsuario(pSysUsuario.IdUsuario);
                b.CorreoElectronico = pSysUsuario.CorreoElectronico;
                b.IdPerfil = pSysUsuario.IdPerfil;
                b.Activo = pSysUsuario.Activo;
                b.FechaRegistro = DateTime.Now;

                a.deleteUsuario(b);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { success = false,mensaje=ex.Message }, JsonRequestBehavior.AllowGet); ;
            }
            
        }
        
    }
}