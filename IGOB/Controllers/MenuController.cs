using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Areas.Catalogos.Controllers
{
    public class MenuController : ValidaSession
    {
        // GET: Catalogos/Menu
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["session"] == null)
            {
                TempData["ErrorMSG"] = null;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                int idUsuario = (int)System.Web.HttpContext.Current.Session["session"];
                ClsMenu menu = new ClsMenu(idUsuario);
                var menuFinal = menu.getMenu();
                System.Web.HttpContext.Current.Session["Menu"] = menuFinal;
                return PartialView(menuFinal);
            }
        }
        [HttpPost]
        public ActionResult accesoVista(int Id,int IdModulo,string formulario,string nombreVista,int IdFuncion,string nombreModulo)
        {
            System.Web.HttpContext.Current.Session["IdModulo"] = IdModulo;
            System.Web.HttpContext.Current.Session["formulario"] = formulario;
            System.Web.HttpContext.Current.Session["nombreVista"] = nombreVista;
            System.Web.HttpContext.Current.Session["IdFuncion"] = IdFuncion;
            System.Web.HttpContext.Current.Session["nombreModulo"] = nombreModulo;

            if (Id==0)
                return RedirectToAction("Index", formulario);
            else
                return RedirectToAction("Index", formulario,new { @Id = Id });
        }
    }
}