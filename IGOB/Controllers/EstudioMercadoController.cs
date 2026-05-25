using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IGOB.Models;
using iGob.Entidades;
using iGob.ReglasNegocios;

namespace IGOB.Controllers
{
    public class EstudioMercadoController : Controller
    {
        // GET: EstudioMercado
        public ActionResult Index(int id=0)
        {
            if (id == 0)
            {
                ViewBag.comboEstados = new SelectList(new brEF_EntidadesFederativas().listarTodos_EF_EntidadesFederativas(), "ClaveEstado", "Estado");
                ViewBag.comboUE = new SelectList(new brTamannoUE().listarTodos_TamannoUE(), "IdTamannoUE", "TamanoUE");
                var nivelconfianza = new brNivelesConfianza().listarTodos_NivelesConfianza();
                ViewBag.NivelConfianza = new SelectList(nivelconfianza, "IdNivelConfianza", "NivelConfianza");
                ViewBag.ValorConfianza = new SelectList(nivelconfianza, "IdNivelConfianza", "ValorConfianza");
                ViewBag.conclusiones = new brReactivosConclusionEM().listarTodos_ReactivosConclusionEM();
            }
            else
            {
                var studioM = new brBienServicioEstudioMercado().traerBienServicioEstudioMercado_x_IdDatoEstudioMercado(id);
                if (studioM != null)
                {
                    ViewBag.BSEM = studioM;
                    ViewBag.bienservicio = new brBienesServicios().traerBienesServicios_x_IdBienServicio(studioM.IdBienServicio);
                    ViewBag.categorscian = new brCategoriasScian().traerCategoriasScian_x_CodigoScian(ViewBag.bienservicio.CodigoScian);
                    ViewBag.comboEstados = new SelectList(new brEF_EntidadesFederativas().listarTodos_EF_EntidadesFederativasEstMer(), "ClaveEstado2", "Estado", studioM.Estado);
                    var municipios = new brEF_Municipios().listarTodos_EF_MunicipiosEstMerc().Where(x => x.ClaveEstado2 == studioM.Estado).ToList();
                    ViewBag.comboMunicip = new SelectList(municipios, "IdMunicipio2", "Municipio", studioM.Municipio);
                    var colonias = new brEF_Colonias().listarTodos_EF_ColoniasEstMerc().Where(x => x.IdMunicipio2 == studioM.Municipio).ToList();
                    ViewBag.comboLocalid = new SelectList(colonias, "IdColonia2", "Colonia", studioM.Localidad);
                    ViewBag.comboUE = new SelectList(new brTamannoUE().listarTodos_TamannoUE(), "IdTamannoUE", "TamanoUE",studioM.TamannoUnidades);

                    var determinacionP = new brDeterminacionPrecios().listarTodos_DeterminacionPrecios().FirstOrDefault(x => x.IdDatoEstudioMercado == studioM.IdDatoEstudioMercado);
                    if (determinacionP!=null)
                    {
                        ViewBag.determinacionP = determinacionP;
                        if (studioM.TipoDeterminacion == 1 || studioM.UEVieneCatalogo)
                        {
                            var listadoMuestraPrecio = new brDispercionMuestraPrecios().listarTodos_DispercionMuestraPrecios().Where(x => x.IdDeterminaPrecioBienServicio == ViewBag.determinacionP.IdDeterminaPrecioBienServicio);
                            if (listadoMuestraPrecio.Count() > 0)
                            {
                                ViewBag.DispMP = listadoMuestraPrecio;
                            }
                        }
                        else
                        {
                            var listadoMuestraUE = new brDispercionMuestraUE().listarTodos_DispercionMuestraUE().Where(x => x.IdDeterminaPrecioBienServicio == ViewBag.determinacionP.IdDeterminaPrecioBienServicio);
                            if (listadoMuestraUE.Count() > 0)
                            {
                                ViewBag.DispMUE = listadoMuestraUE;
                            }
                        }
                        ViewBag.ConslusionResp = false;
                        var sc = new brConclusionesEstudioMercado().listarTodos_ConclusionesEstudioMercado().Where(x => x.IdDatoEstudioMercado == studioM.IdDatoEstudioMercado).ToList().Count();
                        if (sc > 0)
                        {
                            ViewBag.ConslusionResp = true;
                            ViewBag.conclusiones = new brConclusionesEstudioMercado().listarTodos_ConclusionesEstudioMercadoEstMerc(studioM.IdDatoEstudioMercado);
                        }
                        else
                        {
                            ViewBag.conclusiones = new brReactivosConclusionEM().listarTodos_ReactivosConclusionEM();
                        }
                    }
                }
                else
                {
                    ViewBag.comboEstados = new SelectList(new brEF_EntidadesFederativas().listarTodos_EF_EntidadesFederativas(), "ClaveEstado", "Estado");
                    ViewBag.comboUE = new SelectList(new brTamannoUE().listarTodos_TamannoUE(), "IdTamannoUE", "TamanoUE");
                    var nivelconfianza = new brNivelesConfianza().listarTodos_NivelesConfianza();
                    ViewBag.NivelConfianza = new SelectList(nivelconfianza, "IdNivelConfianza", "NivelConfianza");
                    ViewBag.ValorConfianza = new SelectList(nivelconfianza, "IdNivelConfianza", "ValorConfianza");
                    ViewBag.conclusiones = new brReactivosConclusionEM().listarTodos_ReactivosConclusionEM();
                    ViewBag.Misconclusiones = new brConclusionesEstudioMercado().listarTodos_ConclusionesEstudioMercado().Where(x => x.IdDatoEstudioMercado == studioM.IdDatoEstudioMercado);
                }
            }
            return View();
        }

        public ActionResult Historial()
        {
            var listadohistorial = new brBienServicioEstudioMercado().listarTodos_BienServicioEstudioMercadoHistorial();
            return View("Historial",listadohistorial);
        }

        public JsonResult bienesservicios(string str)
        {
            try
            {
                var listbienesservicios = new brBienesServicios().listarTodos_BienesServicios().Where(x => x.BienServicio.Contains(str)).Take(20);//.Select(x => new { BienServicio = x.BienServicio, IdBienServicio = x.IdBienServicio })
                return Json(new { success = true, data = listbienesservicios }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { success = false, data = e.Message }, JsonRequestBehavior.AllowGet);
            }
            
        }

        public JsonResult getscian(int str)
        {
            try
            {
                var scian = new brCategoriasScian().traerCategoriasScian_x_CodigoScian(str);
                return Json(new { success = true, data = scian }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, data = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetMunicipios(string claveestado)
        {
            try
            {
                var municipios = new brEF_Municipios().listarTodos_EF_Municipios().Where(x => x.ClaveEstado == claveestado).ToList();
                return Json(new { success = true, data = municipios }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, data = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetColonias(string IdMunicipio)
        {
            try
            {
                var colonias = new brEF_Colonias().listarTodos_EF_Colonias().Where(x => x.IdMunicipio.Trim() == IdMunicipio.Trim()).ToList();
                return Json(new { success = true, data = colonias }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, data = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetUEIdentificadas(int num, string str)
        {
            try
            {
                var uei = new brUnidadesEconomicas().UnidadesEconomicas_NumeroUnidades(num, str);
                return Json(new { success = true, data = uei.Id }, JsonRequestBehavior.AllowGet);
            }catch(Exception e)
            {
                return Json(new { success = false, data = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult addBienServEstudioMercado(beBienServicioEstudioMercado obj)
        {
            try
            {
                var insEstMer = new brBienServicioEstudioMercado().guardarBienServicioEstudioMercado(obj);
                if (insEstMer!=0)
                {
                    return Json(new { success = true, data = new { message = "Se agrego correctamente" , scalar = insEstMer} }, JsonRequestBehavior.AllowGet);
                }
                else {
                    return Json(new { success = false, data = new { message = "No se pudo agregar", scalar = 0 } }, JsonRequestBehavior.AllowGet);
                }
            }catch(Exception e)
            {
                return Json(new { success = false, data = new { message = "No se pudo agregar"+e.Message, scalar = 0 } }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetUE(string texto, int cve_ent)/*, int cve_mun*/
        {
            try
            {
                var listaunidades = new brUnidadesEconomicas().UnidadesEconomicas_x_nom_estab(texto, cve_ent);/*, cve_mun*/
                return Json(new { success = true, data = listaunidades }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = true, data = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult GetCalculoMuestra(beDeterminacionPrecios determinacionPrecios)
        {
            try
            {
                ClsInvesticacionPrecio investicacionPrecio = new ClsInvesticacionPrecio();
                //determinacionPrecios
                var nivelConfianza = investicacionPrecio.getNivelesConfianza((int)determinacionPrecios.NivelConfianza);
                var confianzaVarianza = Math.Pow(Double.Parse(nivelConfianza.ValorConfianza.ToString()), 2) * Math.Pow(Double.Parse(determinacionPrecios.Varianza.ToString()), 2);
                var divisor = confianzaVarianza * determinacionPrecios.Poblacion;
                var dividendo = confianzaVarianza + (Math.Pow(Double.Parse(determinacionPrecios.MargenError.ToString()), 2) * (determinacionPrecios.Poblacion - 1));
                var resultado = divisor / dividendo;
                determinacionPrecios.Muestra = decimal.Parse(resultado.ToString());
                determinacionPrecios.MuestraRedondeada = (int)Math.Ceiling(resultado);
                return Json(new { success = true, data = determinacionPrecios }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveDeterminacionPrecio(beDeterminacionPrecios obj)
        {
            try
            {
                obj.FechaCalculoMuestra = DateTime.Now;
                obj.FechaCalculoPrecio = DateTime.Now;
                var nivelconfianza = new brNivelesConfianza().traerNivelesConfianza_x_IdNivelConfianza((Int32)obj.NivelConfianza);
                obj.ConstanteNivelConfianza = nivelconfianza.ValorConfianza;
                obj.NivelConfianza = nivelconfianza.NivelConfianza;
                var save = new brDeterminacionPrecios().guardarDeterminacionPrecios(obj);
                if (save != 0)
                {
                    return Json(new { success = true, data = new { message = "Se agrego correctamente" , scalar = save} }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, data = new { message = "no se pudo agregar correctamente", scalar = 0 } }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(new { success = false, data = new { message = e.Message , scalar = 0 } }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveUpDeterminacionPrecio(beDeterminacionPrecios obj)
        {
            var BS = new brBienesServicios();
            try
            {
                var a = new brDeterminacionPrecios();
                var nobj = a.traerDeterminacionPrecios_x_IdDeterminaPrecioBienServicio(obj.IdDeterminaPrecioBienServicio);
                if (nobj != null)
                {
                    nobj.FechaCalculoPrecio = DateTime.Now;
                    nobj.Promedio = obj.Promedio;
                    nobj.Maximo = obj.Maximo;
                    nobj.Minimo = obj.Minimo;
                    nobj.Moda = obj.Moda;
                    nobj.Mediana = obj.Mediana;
                    nobj.PrecioAplicado = obj.PrecioAplicado;
                    var save = a.actualizarDeterminacionPrecios(nobj);
                    bool s = save == 0;
                    var bienservicioupdate = BS.traerBienesServicios_x_IdBienServicio(nobj.IdBienServicio);
                    if (bienservicioupdate != null)
                    {
                        //insertar historialpreciobienservicio
                        var objHPBS = new beHistotialPreciosBienServicio();
                        objHPBS.IdHistorialPrecioBienServicio = 0;
                        objHPBS.IdBienServicio = nobj.IdBienServicio;
                        objHPBS.PrecioUnitarioActual = nobj.PrecioAplicado;
                        objHPBS.PrecioUnitarioAnterior = bienservicioupdate.PrecioUnitario;
                        objHPBS.FechaActualizacion = DateTime.Now;
                        objHPBS.IdDatoEstudioMercado = nobj.IdDatoEstudioMercado;
                        var HBS = new brHistotialPreciosBienServicio().guardarHistotialPreciosBienServicio(objHPBS);
                        //BienServicio actualizacion precio
                        bienservicioupdate.PrecioUnitario = obj.PrecioAplicado;
                        bienservicioupdate.FechaActualizacionPrecio = DateTime.Now;
                        var BSUP = BS.actualizarBienesServicios(bienservicioupdate);
                    }
                    return Json(new { success = s ? true : false, data = new { message = s ? "Se agrego correctamente" : "No se pudo agregar" } }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, data = new { message = "No se pudo agregar" } }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(new { success = false, data = new { message = e.Message } }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveConclusionesEstudio(IEnumerable<beConclusionesEstudioMercado> obj)
        {
            try
            {
                foreach(var item in obj)
                {
                    var conclusionEst = new brConclusionesEstudioMercado().guardarConclusionesEstudioMercado(item);
                }
                return Json(new { success = true, data = new { message = "Se agrego correctamente", scalar = 0 } }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, data = new { message = "No se pudo agregar", scalar = 0 } }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetProviderSample(string TamanoEU, int Codigo, int CveEstado, int NoUnidadesEconomicas, int TamanoMuestra)
        {
            try
            {
                var providers = new brUnidadesEconomicas().UnidadesEconomicasMuestra(TamanoEU,Codigo,CveEstado,NoUnidadesEconomicas,TamanoMuestra);
                if (providers != null && providers.Count>0)
                {
                    return Json(new { success = true, data = new { message = "", body = providers} }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, data = new { message = "Datos no encontrados" } }, JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception e)
            {
                return Json(new { success = false, data = new { message = e.Message } }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveUENoCatalogo(beDispercionMuestraUE obj)
        {
            try
            {
                var saveDispM = new brDispercionMuestraUE().guardarDispercionMuestraUE(obj);
                return Json(new { success = true, data = new { message = saveDispM != 0 ? "Se guardo la cotización" : "No se pudo agregar la cotización", body = saveDispM != 0 ? saveDispM : 0 } }, JsonRequestBehavior.AllowGet);
            }catch(Exception e)
            {
                return Json(new { success = false, data = new { message = e.Message, body = 0 } }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveDispMP(beDispercionMuestraPrecios obj)
        {
            try
            {
                var saveDP = new brDispercionMuestraPrecios().guardarDispercionMuestraPrecios(obj);
                return Json(new { success = true, data = new { message = saveDP != 0 ? "Se guardo la cotización" : "No se pudo agregar la cotización", body = saveDP != 0 ? saveDP : 0 } }, JsonRequestBehavior.AllowGet);
            }catch(Exception e)
            {
                return Json(new { success = false, data = new { message = e.Message, body = 0 } }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveDispMuePrec(beDispercionMuestraPrecios obj)
        {
            try
            {
                var a = new brDispercionMuestraPrecios();
                var nobj = a.traerDispercionMuestraPrecios_x_IdDispercionMuestraPrecio(obj.IdDispercionMuestraPrecio);
                if (nobj != null)
                {
                    nobj.PrecioSinImpuesto = obj.PrecioSinImpuesto;
                    nobj.Precio = obj.PrecioSinImpuesto + (obj.PrecioSinImpuesto * (decimal)(0.16));
                    var save = a.actualizarDispercionMuestraPrecios(nobj);
                    bool s = save == 0;
                    return Json(new { success = s ? true : false, message = s ? "Se agrego cotización" : "No se pudo agregegar la cotización" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "No se pudo agregegar la cotización" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveDispMueUE(beDispercionMuestraUE obj)
        {
            try
            {
                var a = new brDispercionMuestraUE();
                var nobj = a.traerDispercionMuestraUE_x_IdDispercionMuestraUE(obj.IdDispercionMuestraUE);
                if (nobj != null)
                {
                    nobj.PrecioSinImpuesto = obj.PrecioSinImpuesto;
                    nobj.Precio = obj.PrecioSinImpuesto + (obj.PrecioSinImpuesto * (decimal)(0.16));
                    nobj.Direccion = obj.Direccion;
                    nobj.UnidadEconomica = obj.UnidadEconomica;
                    var save = a.actualizarDispercionMuestraUE(nobj);
                    bool s = save == 0;
                    return Json(new { success = s ? true : false, message = s ? "Se agrego cotización" : "No se pudo agregegar la cotización" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "No se pudo agregegar la cotización" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult addDispeM(IEnumerable<DispercionMuestraPreciosUE> obj, int tipo, int iddetpbs)
        {
            try
            {
                if (tipo == 1)
                {
                    var dipersionMuestraPrecio = new List<beDispercionMuestraPrecios>();
                    foreach (var item in obj)
                    {
                        var objMP = new beDispercionMuestraPrecios();
                        objMP.IdDispercionMuestraPrecio = 0;
                        objMP.IdDeterminaPrecioBienServicio = iddetpbs;
                        objMP.IdUnidadEconomica = item.Id;
                        objMP.PrecioSinImpuesto = 0;
                        objMP.Precio = 0;
                        var save = new brDispercionMuestraPrecios().guardarDispercionMuestraPrecios(objMP);
                        item.IdRegisted = save;
                    }
                }
                else
                {
                    var dispersionMuestraUE = new List<beDispercionMuestraUE>();
                    foreach (var item in obj)
                    {
                        var objUE = new beDispercionMuestraUE();
                        objUE.IdDispercionMuestraUE = 0;
                        objUE.IdDeterminaPrecioBienServicio = iddetpbs;
                        objUE.UnidadEconomica = "";
                        objUE.Direccion = "";
                        objUE.PrecioSinImpuesto = 0;
                        objUE.Precio = 0;
                        var save = new brDispercionMuestraUE().guardarDispercionMuestraUE(objUE);
                        item.IdRegisted = save;
                    }
                }
                return Json(new { success = true, data = obj }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, data = obj }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
