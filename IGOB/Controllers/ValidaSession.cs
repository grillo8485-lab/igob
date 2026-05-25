using IGOB.Areas.Catalogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Runtime.CompilerServices;
using IGOB.Models;

namespace System.Web.Mvc
{
    public abstract class ValidaSession : Controller
    {
        public ValidaSession()
        {
            var session = System.Web.HttpContext.Current.Session["ClsGenerico"];
            if (session == null)
                RedirectToAction("Index", "Home");
        }
        protected override void OnActionExecuting(ActionExecutingContext ctx)
        {
            var session = System.Web.HttpContext.Current.Session["ClsGenerico"];
            if (session == null)
                ctx.Result = RedirectToAction("Index", "Home");

            var IdModulo = System.Web.HttpContext.Current.Session["IdModulo"];
            var formulario = System.Web.HttpContext.Current.Session["formulario"];
            var nombreVista = System.Web.HttpContext.Current.Session["nombreVista"];
            var IdFuncion = System.Web.HttpContext.Current.Session["IdFuncion"];
            var nombreModulo = System.Web.HttpContext.Current.Session["nombreModulo"];

            var capa = ctx.RouteData.GetRequiredString("controller");
            switch (capa)
            {
                case "Menu":
                case "Principal":
                    break;
                default:
                    //ctx = procesarMenu(ctx, capa);
                    break;
            }
        }

        protected ActionExecutingContext procesarMenu(ActionExecutingContext ctx,string capa)
        {
            var menu = (IEnumerable<ClsMenuPropiedades>)Session["Menu"];
            var boolAcceso = false;
            foreach (var item in menu)
            {
                foreach (var itemFunciones in item.Funciones)
                {
                    var array = itemFunciones.Formulario.Split('?').ToList();
                    if (array.Count == 1)
                    {
                        array = itemFunciones.Formulario.Split('/').ToList();
                        if (array.Count == 1)
                        {
                            if (capa == array.First())
                            {

                                
                                boolAcceso = true;
                                break;
                            }
                        }
                        else
                        {
                            if (capa == array.First())
                            {
                                
                                boolAcceso = true;
                                break;
                            }

                        }

                        break;
                    }
                    else
                    {
                        if (capa == array.First())
                        {
                           
                            boolAcceso = true;
                            break;
                        }
                    }


                }
            }
            Session["Menu"] = menu;
            if (!boolAcceso)
            {
                ctx.Result = RedirectToAction("Index", "Home");
                return ctx;
            }
               
            return ctx;
        }

    }

}