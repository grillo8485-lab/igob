using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Models;
using IGOB.Areas.Catalogos.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class SubirPlantillasController : ValidaSession
    {
        // GET: SubirPlantillas
        public ActionResult Index()
        {
            //obtenemos los datos nesarios
            brPlantillas Plan = new brPlantillas();

            //obtenemos la lista de plantillas
            List<bePlantillas> ListaPlantillas = Plan.listar_Plantillas_TipoUso();

            ViewBag.ListaPlantillas = ListaPlantillas;

            //obtenemos el gobierno
            var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            int IdGobierno = usuario.id5;

            //obtenemos la lista de TipoUso
            ViewBag.ListaTipoUso = new SelectList(Plan.listar_TipoUso(IdGobierno), "IdTipoUsoPlantilla", "TipoUso");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult TraerPlantilla(int pIdPlantilla)
        {
            try
            {
                //obtenemos los datos nesarios
                brPlantillas obrPlan = new brPlantillas();
                bePlantillas obePlantillas = obrPlan.traerPlantillas_x_IdPlantilla_GetAll(pIdPlantilla);


                return Json(new { success = true, objeto = obePlantillas }, JsonRequestBehavior.AllowGet); ;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult EliminarPlantilla(int pIdPlantilla)
        {
            try
            {
                brPlantillas obrPlan = new brPlantillas();
                
                //obtenemos la plantilla
                bePlantillas Plantilla = obrPlan.traerPlantillas_x_IdPlantilla(pIdPlantilla);
                
                //ruta donde se almacenan las plantillas
                string pathPlantillas = Server.MapPath("~/Files/Plantillas/");
                //borramos el archivo anterior                        
                ClsLibreriaArchivos.DeleteFile(Path.Combine(pathPlantillas, Plantilla.UrlPlantilla));

                //borramos los datos de la tabla
                var plantilla = obrPlan.eliminarPlantillas(pIdPlantilla);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet); ;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UploadFiles(int IdTipoUsoPlantilla, int IdPlantilla, string NombreArchivo, string Descripcion)
        {
            try
            {
                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    brPlantillas obrPlan = new brPlantillas();

                    //datos del archivo enviado
                    var pic = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
                    HttpPostedFileBase filebase = new HttpPostedFileWrapper(pic);
                    //nombre del archivo
                    var fileName = filebase.FileName;

                    //ruta donde se almacenan las plantillas
                    string pathPlantillas = Server.MapPath("~/Files/Plantillas/");

                    //subimos el archivo actual
                    var path = Path.Combine(pathPlantillas, fileName);
                    filebase.SaveAs(path);

                    //verificamos que la id de plantilla sea distinta a la default
                    if (IdPlantilla > 0)
                    {
                        //Es una plantilla existente, buscamos sus datos
                        

                        //obtenemos la plantilla
                        bePlantillas Plantilla = obrPlan.traerPlantillas_x_IdPlantilla(IdPlantilla);

                        //borramos el archivo anterior                        
                        //ClsLibreriaArchivos.DeleteFile(Path.Combine(pathPlantillas, Plantilla.UrlPlantilla));
                        
                        //modificamos los datos en la tabla
                        Plantilla.NombreArchivo = NombreArchivo;
                        Plantilla.UrlPlantilla = fileName;
                        Plantilla.Descripcion = Descripcion;

                        if (ModelState.IsValid)
                        {
                            var edit = obrPlan.actualizarPlantillas(Plantilla);
                            if (edit == 0)
                            {
                                //se edito correctamente
                                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                //ocurrió un fallo
                                return Json(new { success = false, Mensaje = "No se pudo editar la plantilla" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { success = false, Mensaje = "No se pudo editar la plantilla" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        //es una plantilla nueva, insertamos los datos

                        //generamos los datos a guardar
                        bePlantillas Plantilla = new bePlantillas();
                                                
                        Plantilla.IdPlantilla = 0;

                        //obtenemos el gobiern0
                        var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                        Plantilla.IdGobierno = usuario.id5;

                        Plantilla.IdTipoUsoPlantilla = IdTipoUsoPlantilla;
                        Plantilla.UrlPlantilla = fileName;
                        Plantilla.NombreArchivo = NombreArchivo;
                        Plantilla.Descripcion = Descripcion;

                        if (ModelState.IsValid)
                        {
                            var create = obrPlan.guardarPlantillas(Plantilla);
                            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { success = false, Mensaje = "No se pudieron actualizar los datos de la plantilla" }, JsonRequestBehavior.AllowGet);
                        }
                    }//fin else
                    
                }
                else
                {
                    return Json(new { success = false, Mensaje = "No se envió archivo para guardar" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, Mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}