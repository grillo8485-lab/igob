using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class PerfilUsuarioController : ValidaSession
    {
        // GET: PerfilUsuario
        public ActionResult Index()
        {
            //obtenemos los datos del usuario
            var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            int IdPerfil = usuario.id.GetValueOrDefault();
            int IdUsuario = usuario.id2.GetValueOrDefault();
            int IdPersona = usuario.id3.GetValueOrDefault();
            int IdDependencia = usuario.id4;            
            int IdGobierno = usuario.id5;
            int IdProveedor = usuario.id6;

            

            //obtenemos los datos de persona            
            brDatosPersonas obrDatosPersonas = new brDatosPersonas();
            beDatosPersonas obeDatosPersonas = obrDatosPersonas.traerDatosPersonas_x_IdPersona(IdPersona);

            string Nombre = obeDatosPersonas.Nombres + ' ' + obeDatosPersonas.Apellidos;
            string Correo = obeDatosPersonas.CorreoElectronico;
            string Telefono = obeDatosPersonas.Telefono;
            //string puesto = ???

            //obtenemos el perfil
            brSysPerfiles obrSysPerfiles = new brSysPerfiles();
            beSysPerfiles obeSysPerfiles = obrSysPerfiles.traerSysPerfiles_x_IdPerfil(IdPerfil);

            string Perfil = obeSysPerfiles.Perfil;

            //datos para conseguir información de localidad
            brEF_Municipios obrmun = new brEF_Municipios();
            beEF_Municipios obemun = new beEF_Municipios();
            brEF_EntidadesFederativas obrent = new brEF_EntidadesFederativas();
            beEF_EntidadesFederativas obeent = new beEF_EntidadesFederativas();
            brEF_Paises obrpais = new brEF_Paises();
            beEF_Paises obepais = new beEF_Paises();
            string Empresa = "";
            string IdMunicipio = "";
            
            if (IdDependencia > 0)
            {
                //es dependencia
                brDependencias obrdep = new brDependencias();
                beDependencias obedep = obrdep.traerDependencias_x_IdDependencia(IdDependencia);

                IdMunicipio = obedep.IdMunicipio;
                Empresa = obedep.Dependencia;
            }
            else
            {
                //es proveedor
                brProveedores obrpro = new brProveedores();
                beProveedores obepro = obrpro.traerProveedores_x_IdProveedor(IdProveedor);

                IdMunicipio = obepro.IdMunicipio;
                Empresa = obepro.RazonSocial;
            }

            //obtenemos los datos de localidad
            obemun = obrmun.traerEF_Municipios_x_IdMunicipio(IdMunicipio);
            string Municipio = obemun.Municipio;
            string ClaveEstado = obemun.ClaveEstado;
            obeent = obrent.traerEF_EntidadesFederativas_x_ClaveEstado(ClaveEstado);
            string Estado = obeent.Estado;
            int IdPais = obeent.IdPais;
            obepais = obrpais.traerEF_Paises_x_IdPais(IdPais);
            string Pais = obepais.Pais;

            //preparamos las variables para enviarlas a la vista
            ViewBag.Nombre = Nombre;
            ViewBag.Correo = Correo;
            ViewBag.Telefono = Telefono;
            ViewBag.Perfil = Perfil;
            ViewBag.Empresa = Empresa;
            ViewBag.Municipio = Municipio;
            ViewBag.Estado = Estado;
            ViewBag.Pais = Pais;

            return View();
        }

        public ActionResult ChangePassword()
        {
            var data = new ClsGenerica();
            if (TempData.ContainsKey("generica"))
            {
                data = ((ClsGenerica)TempData["generica"]);
            }
            var c = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            data.string1 = c.string1;//nombre
            data.string5 = c.string5;//perfil
            
            return View(data);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult validationPassUserInSession(string pass1,string pass2,string pass3)
        //{
        //    var g = new ClsGenerica();
        //    try {
        //        var c = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
        //        var l = new ClsLogin(g.string5, pass3);
        //        var u = new brSysUsuarios();
        //        var usuariolog = u.traerSysUsuario_x_Usuario_X_Password(c.string5);
        //        if (usuariolog != null)
        //        {
        //            if (pass1 == pass2 && usuariolog.Password == l.getKeyAcceso(pass3).ToUpper())
        //            {
        //                var user = u.traerSysUsuarios_x_IdUsuario((int)c.id2);
        //                if (user != null)
        //                {
        //                    user.Password = l.getKeyAcceso(pass1).ToUpper();
        //                    u.actualizarSysUsuarios(user);
        //                    g.id = 1;
        //                }
        //                else
        //                {
        //                    g.id = 0;
        //                }
        //            }
        //            else
        //            {
        //                g.id = 2;
        //            }
        //        }
        //        else
        //        {
        //            g.id = 0;
        //        }
        //        TempData["generica"] = g;
        //        return RedirectToAction("ChangePassword", "PerfilUsuario");
        //    } catch(Exception e) {
        //        g.id = 0;
        //        g.string10 = e.Message;//error
        //        return RedirectToAction("ChangePassword", "PerfilUsuario");
        //    }

        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult validationPassUserInSession(string pass1, string pass2, string pass3)
        {
            var g = new ClsGenerica();
            try
            {
                var c = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                var l = new ClsLogin(g.string5, pass3);
                var u = new brSysUsuarios();
                var usuariolog = u.traerSysUsuario_x_Usuario_X_Password(c.string5);
                if (usuariolog != null)
                {
                    if (pass1 == pass2)
                    {
                        if(usuariolog.Password == l.getKeyAcceso(pass3))
                        {
                            var user = u.traerSysUsuarios_x_IdUsuario((int)c.id2);
                            g.bool1 = false;
                            if (user != null)
                            {
                                user.Password = l.getKeyAcceso(pass1);
                                u.actualizarSysUsuarios(user);
                                g.bool1 = true;
                                g.string1 = "Se cambio la contraseña! favor de cerrar la sesión.";
                                g.string2 = "string3";
                            }
                            else
                            {
                                
                                g.string1 = "Favor de contactar con el administrador del sistema!";
                                g.string2 = "string2";
                            }
                        }
                        else
                        {
                            g.string1 = "Favor de contactar con el administrador del sistema!";
                            g.string2 = "string2";
                        }
                        
                    }
                    else
                    {
                        g.string1 = "Las contraseña son incorrectas! favor de verificar.";
                        g.string2 = "string2";
                    }
                }
                else
                {
                    g.string1 = "Favor de contactar con el administrador del sistema!";
                    g.string2 = "string3";

                }
                TempData["generica"] = g;
                return Json(new { success = g.bool1,message = g.string1,focus = g.string2  },JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                g.bool1 = false;
                g.string1 = e.Message;//error
                g.string2 = "string3";
                return Json(new { success = g.bool1, message = g.string1, focus = g.string2 }, JsonRequestBehavior.AllowGet);
            }

        }

    }
}