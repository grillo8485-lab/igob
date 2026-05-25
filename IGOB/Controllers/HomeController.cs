using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Text;
using iGob.Entidades;
using System.Configuration;

namespace IGOB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ClsLogin acceso = new ClsLogin();
            var fechaFormatInicio = "01/04/2019";
            var fechaFormatFin = "31/12/2025";

            var fechaInicial = acceso.getKeyAcceso(fechaFormatInicio);
            var fechaFinal = acceso.getKeyAcceso(fechaFormatFin);
            var sistema = new beAcceso();
            sistema.FechaAcceso = fechaInicial;
            sistema.FechaAccesoTotal = fechaFinal;
            // seccion de lectura de archivo de configuración
            var validarAcceso = Convert.ToBoolean(ConfigurationManager.AppSettings["validarAcceso"].ToString());
            var acceso_ = new beAcceso();
            var resultArchivo = acceso.leerArchivo(Server.MapPath("~/Files"));
            if (validarAcceso)
            {
                
                switch (resultArchivo.result)
                {
                    case 0:
                        ViewBag.Error = null;
                        break;
                    case 1:
                        ViewBag.Error = "Archivo de configuración no esta completo, favor de verificar.";
                        break;
                    case 2:
                        ViewBag.Error = "Archivo de configuración no existe, favor de verificar.";
                        break;

                }
                // fin seccion de lectura de archivo de configuración
                
                if (resultArchivo.result == 0)
                {
                    // seccion de lectura de tabla Acceso en la base de datos, para la configuración del acceso al sistema, compracion de cadenas(tabla acceso vs sistema)
                    acceso_ = acceso.leerAccesoDb();
                    switch (acceso_.result)
                    {
                        case 0:
                            ViewBag.Error = null;
                            break;
                        case 1:
                        case 3:
                            ViewBag.Error = "Tiempo de prueba ha expirado.";
                            break;
                        case 2:
                            ViewBag.Error = "Archivo de configuración no existe, favor de verificar.";
                            break;

                    }
                    // Fin seccion de lectura de tabla Acceso en la base de datos, para la configuración del acceso al sistema
                }

                if (acceso_.result == 0)
                {
                    // seccion de lectura de tabla Acceso en la base de datos, para la configuración del acceso al sistema, compracion de cadenas(tabla acceso vs sistema)
                    switch (acceso.comprarCadenas(resultArchivo, acceso_, sistema))
                    {
                        case 0:
                            ViewBag.Error = null;
                            break;
                        case 1:
                        case 3:
                            ViewBag.Error = "Tiempo de prueba ha expirado.";
                            break;
                        case 2:
                            ViewBag.Error = "Archivo de configuración no existe, favor de verificar.";
                            break;

                    }
                    // Fin seccion de lectura de tabla Acceso en la base de datos, para la configuración del acceso al sistema
                }


            }
            else
            {
                acceso_.result = 0;
                ViewBag.Error = null;
            }
          
           

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Login(string Usuario, string password)
        {
           
            ClsLogin acceso = new ClsLogin(Usuario, password);
            ClsGenerica a = acceso.getAcceso();
            if (a.bool2)
            {
                System.Web.HttpContext.Current.Session["session"] = a.id2;
                System.Web.HttpContext.Current.Session["ClsGenerico"] = a;
                System.Web.HttpContext.Current.Session["Usuario"] = a.string1;
                System.Web.HttpContext.Current.Session["Perfil"] = a.string2;
                System.Web.HttpContext.Current.Session["Gobierno"] = a.string3;
                System.Web.HttpContext.Current.Session["Dependencia"] = a.string4;
                System.Web.HttpContext.Current.Session["IdModulo"] = 0;
                System.Web.HttpContext.Current.Session["formulario"] = "";
                System.Web.HttpContext.Current.Session["nombreVista"] = "Principal";
                System.Web.HttpContext.Current.Session["IdFuncion"] = 0;
                getCookie(a.string9);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (a.id7 == 4)
                {
                    System.Web.HttpContext.Current.Session["ClsGenerico"] = a;
                    CerrarSecision();
                    a.string1 = TempData["ErrorMSG"].ToString();
                }
                else
                {
                    TempData["ErrorMSG"] = a.string1;
                }
                
                return Json(new { success = false, mensaje = a.string1,idError= a.id7 }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult validarToken(string tokenValido, string attemptResponseCode)
        {

            try
            {

                var result = 1;
                var ErrorMSG_ = "";
                var attemptResponseCode_ = "";
                var authnAttemptId_ = "";
                
                if (Session["ClsGenerico"] != null)
                {
                    var f = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                    var Usuario = f.string5;

                    ClsLogin acceso = new ClsLogin();
                    var modoDebug = Convert.ToBoolean(ConfigurationManager.AppSettings["ModoDebug"].ToString());
                    if (!modoDebug)
                    {
                        var token = acceso.getToken(tokenValido);
                        if (token.Token != string.Empty)
                        {
                            return Json(new { success = 100, mensaje = "<h6><span class='fa fa-exclamation-triangle fa-1x'></span><strong>Token ya fue utilizado, favor de esperar el siguiente token.</h6>", attemptResponseCode = attemptResponseCode_, authnAttemptId = authnAttemptId_ }, JsonRequestBehavior.AllowGet);
                        }
                        switch (attemptResponseCode)
                        {
                            case "":
                            case "FAIL":
                                result = accesoAPIRSA(tokenValido, Usuario);
                                break;
                            case "CHALLENGE":
                                result = iniciarVerificacion(tokenValido, Usuario);
                                break;

                        }

                        ErrorMSG_ = TempData["ErrorMSG"] == null ? "" : TempData["ErrorMSG"].ToString().ToString();
                        attemptResponseCode_ = TempData["attemptResponseCode"] == null ? "" : TempData["attemptResponseCode"].ToString().ToString();
                        authnAttemptId_ = TempData["authnAttemptId"] == null ? "" : TempData["authnAttemptId"].ToString().ToString();


                    }
                    TempData["ErrorMSG"] = ErrorMSG_;
                    TempData["attemptResponseCode"] = attemptResponseCode_;
                    TempData["authnAttemptId"] = authnAttemptId_;

                    var pToken = new beTokenHistorial();
                    pToken.IdTokenHistorial = 0;
                    pToken.IdUsuario = (int)f.id2;
                    pToken.IdPerfil = (int)f.id;
                    pToken.Usuario = f.string5;
                    pToken.NoToken = f.string7;
                    pToken.LlaveAcceso = f.string9;
                    pToken.Token = tokenValido;
                    pToken.FechaRegistro = DateTime.Now;
                    acceso.saveToken(pToken);
                    // seccion para entrar en modo debug
                    if (modoDebug)
                    {
                        TempData["keyAcceso"] = acceso.getKeyAcceso(f.string7.Trim());
                    }

                    if (result == 1)
                    {
                        var usuario = acceso.getUsuario_x_IdUsuario((int)f.id2);
                        usuario.LlaveAcceso = f.string9;
                        if (!modoDebug)
                        {
                            acceso.saveEditUsuarioLlave(usuario);
                        }
                        acceso.bitacoraAcceso((int)f.id2, true, f.string9);
                    }
                }
                else
                {
                    result = 99;
                    ErrorMSG_ = "Sesión ha expirado.";
                }
                return Json(new { success = result, mensaje = "<h6>" + ErrorMSG_ + "</h6>", attemptResponseCode = attemptResponseCode_, authnAttemptId = authnAttemptId_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
               
                return Json(new { success = 0, mensaje = string.Format("Error: {0}", ex.Message) }, JsonRequestBehavior.AllowGet);
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult validarNumeroToken(string numeroToken)
        {

            try
            {

                var result = false;
                var ErrorMSG_ = "";
                var attemptResponseCode_ = "";
                var authnAttemptId_ = "";
                var f = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                var Usuario = f.string5;

                ClsLogin acceso = new ClsLogin(Usuario, "");
                var ususario_ = acceso.getUsuario_x_Usuario();
                if (ususario_.Usuario != "")
                {
                    if (ususario_.NoToken.Trim() == numeroToken.Trim())
                    {
                        ususario_.LlaveAcceso = f.string9;
                        acceso.saveEditUsuarioLlave(ususario_);
                        result = true;
                    }
                    else
                    {
                        ErrorMSG_ = "<h6><span class='fa fa-exclamation-triangle fa-1x'></span>Serial: <strong>"+numeroToken+ "</strong>, no es valido favor de verificar.</h6>";
                    }
                }
                return Json(new { success = result, mensaje = "<h6>" + ErrorMSG_ + "</h6>", attemptResponseCode = attemptResponseCode_, authnAttemptId = authnAttemptId_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = 0, mensaje = string.Format("Error: {0}", ex.Message) }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult CerrarSecision()
        {
            var llaveAcceso = "";
            TempData["ErrorMSG"] = null;
            if (System.Web.HttpContext.Current.Session["session"] == null)
            {
                if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("key"))
                {
                    HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["key"];
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    llaveAcceso = cookie.Value;
                    this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                }
                cerrarAcceso(llaveAcceso);
                return RedirectToAction("Index", "Home");
            }

            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("key"))
            {
                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["key"];
                cookie.Expires = DateTime.Now.AddDays(-1);
                llaveAcceso = cookie.Value;

                this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            }
            
            cerrarAcceso(llaveAcceso);
            System.Web.HttpContext.Current.Session.RemoveAll();
            
            
            return RedirectToAction("Index", "Home");
        }
        private void cerrarAcceso(string llaveAcceso)
        {
            ClsLogin acceso = new ClsLogin("", "");
            var a = new ClsGenerica();
            var BitacoraAcceso = acceso.getBitacora_x_LlaveAcceso(llaveAcceso);
            if (llaveAcceso != "")
            {
                if (llaveAcceso == BitacoraAcceso.LlaveAcceso)
                {
                    acceso.cerrarSecision(BitacoraAcceso.IdUsuario, false, llaveAcceso);
                    var usuario = acceso.getUsuario_x_IdUsuario(BitacoraAcceso.IdUsuario);
                    usuario.LlaveAcceso = "";
                    acceso.saveEditUsuarioLlave(usuario);
                    TempData["ErrorMSG"] = "<span class='fa fa-exclamation-triangle fa-1x'></span>Usuario <strong>" + a.string5 + "</strong> ha sido desbloqueado, intente lo nuevamente";
                    a.id7 = 100;
                    System.Web.HttpContext.Current.Session["ClsGenerico"] = a;
                }
                else
                {
                    TempData["ErrorMSG"] = "<span class='fa fa-exclamation-triangle fa-1x'></span>Usuario <strong>" + a.string5 + "</strong> no se ha podido desbloquear";
                }
            }
            else
            {
                TempData["ErrorMSG"] = "<span class='fa fa-exclamation-triangle fa-1x'></span>Usuario <strong>" + a.string5 + "</strong> no se ha podido desbloquear";

            }
        }

        private int accesoAPIRSA(string token, string Usuario)
        {
            try
            {
                var resultApi = procesarApi(procesarPosData(token, Usuario,1), "initialize");
                var accesoValido = 1;
                var attemptResponseCode = resultApi["attemptResponseCode"];
                var attemptReasonCode = resultApi["attemptReasonCode"];
                TempData["methodId"] = "";
                switch (attemptResponseCode)
                {
                    case "FAIL":
                        TempData["ErrorMSG"] = "<span class='fa fa-exclamation-triangle fa-1x'></span>Favor de solicitar al administrador, el desbloqueo de su cuenta.";
                        accesoValido = 100;
                        TempData["token"] = token;
                        TempData["keyAcceso"] = null;
                        break;
                    case "SUCCESS":
                        ClsLogin acceso = new ClsLogin("", "");
                        var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                        TempData["ErrorMSG"] = null;
                        accesoValido = 1;
                        TempData["token"] = null;
                        TempData["keyAcceso"] = acceso.getKeyAcceso(a.string7.Trim());
                        break;
                    case "CHALLENGE":
                        switch (attemptReasonCode)
                        {
                            case "AUTHENTICATION_REQUIRED":
                                TempData["ErrorMSG"] = "Introduce token(1), para continuar(esperar nuevo token)";
                                accesoValido = 3;
                                TempData["methodId"] = "SECURID";
                                TempData["token"] = token;
                                TempData["keyAcceso"] = null;
                                break;
                        }
                        break;
                    case "IN_PROCESS":
                        TempData["ErrorMSG"] = "El servidor inició el solicitud de autenticación, pero La solicitud no se ha completado. Para tales métodos, servir.";
                        accesoValido = 3;
                        TempData["token"] = token;
                        TempData["keyAcceso"] = null;
                        break;
                }
                TempData["attemptResponseCode"] = attemptResponseCode;
                TempData["attemptReasonCode"] = attemptReasonCode;
                return accesoValido;
            }
            catch (Exception ex)
            {
                TempData["ErrorMSG"] = string.Format("Error: {0}", ex.Message);
                return 0;
            }
        }
        public ActionResult accesoValido()
        {
            var session = System.Web.HttpContext.Current.Session["ClsGenerico"];
            if (session == null)
                RedirectToAction("Index", "Home");

            return View("_Principal");

        }
        private dynamic procesarPosData(string token, string Usuario, int tipoProceso, string authnAttemptId = "", string messageId = "")
        {
            var guid = Guid.NewGuid();
            dynamic posData = new System.Dynamic.ExpandoObject();
            dynamic context = new System.Dynamic.ExpandoObject();
            List<dynamic> subjectCredentials = new List<dynamic>();
            List<dynamic> collectedInputs = new List<dynamic>();
            List<string> sessionAttributes = new List<string>();
            dynamic objeto_ = new System.Dynamic.ExpandoObject();
            dynamic collectedInput = new System.Dynamic.ExpandoObject();
            switch (tipoProceso)
            {
                case 1:
                    posData.authnAttemptTimeout = 180;
                    posData.clientId = "192.168.100.8";
                    posData.subjectName = Usuario;
                    posData.lang = "en_US";
                    posData.assurancePolicyId = guid;
                    posData.sessionAttributes = sessionAttributes;
                    collectedInput.name = "SECURID";
                    collectedInput.value = token;
                    collectedInput.dataType = "STRING";
                    objeto_.methodId = "SECURID";
                    collectedInputs.Add(collectedInput);
                    objeto_.collectedInputs = collectedInputs;
                    subjectCredentials.Add(objeto_);
                    posData.subjectCredentials = subjectCredentials;
                    guid = Guid.NewGuid();
                    context = new System.Dynamic.ExpandoObject();
                    context.messageId = guid;
                    posData.context = context;
                    posData.keepAttempt = false;
                    break;
                case 2:
                    posData.authnAttemptTimeout = 180;
                    posData.clientId = "192.168.100.8";
                    posData.subjectName = Usuario;
                    posData.lang = "en_US";
                    posData.assurancePolicyId = guid;
                    posData.sessionAttributes = sessionAttributes;
                    posData.subjectCredentials = subjectCredentials;
                    guid = Guid.NewGuid();
                    context.messageId = guid;
                    posData.context = context;
                    posData.keepAttempt = false;
                    break;
                case 3:
                    collectedInput.name = "SECURID";
                    collectedInput.value = token;
                    collectedInput.dataType = "STRING";
                    objeto_.methodId = "SECURID";
                    objeto_.versionId = "1.0.0";
                    collectedInputs.Add(collectedInput);
                    objeto_.collectedInputs = collectedInputs;
                    subjectCredentials.Add(objeto_);

                    posData.subjectCredentials = subjectCredentials;
                    context.authnAttemptId = authnAttemptId;
                    context.messageId = Guid.NewGuid();
                    context.inResponseTo = messageId;
                    posData.context = context;
                    break;
                case 4:
                    collectedInput.name = "SECURID_NEXT_TOKENCODE";
                    collectedInput.value = token;
                    collectedInput.dataType = "STRING";
                    objeto_.methodId = "SECURID_NEXT_TOKENCODE";
                    objeto_.versionId = "1.0.0";
                    collectedInputs.Add(collectedInput);
                    objeto_.collectedInputs = collectedInputs;
                    subjectCredentials.Add(objeto_);

                    posData.subjectCredentials = subjectCredentials;
                    context.authnAttemptId = authnAttemptId;
                    context.messageId = Guid.NewGuid();
                    context.inResponseTo = messageId;
                    posData.context = context;
                    break;
            }

            return posData;

        }

        private int iniciarVerificacion(string token, string Usuario)
        {
            try
            {
                var methodId = TempData["methodId"];
                var accesoValido = 1;
                if (TempData["token"] == null)
                {
                    TempData["token"] = token;
                }
                else
                {
                    if (TempData["token"].ToString() == token)
                    {
                        switch (methodId)
                        {
                            case "SECURID_NEXT_TOKENCODE":
                                TempData["ErrorMSG"] = "Introduce token(2), token [" + token + "] ya fue enviado con anterioridad, favor de esperar nuevo token.";
                                accesoValido = 4;
                                break;
                            case "SECURID":
                                TempData["ErrorMSG"] = "Introduce token(1), token [" + token + "] ya fue enviado con anterioridad, favor de esperar nuevo token.";
                                accesoValido = 3;
                                break;
                        }
                        TempData["token"] = token;
                        
                        TempData["methodId"] = methodId;
                        return accesoValido;
                    }
                }
                
                dynamic resultApi = new System.Dynamic.ExpandoObject();
                var authnAttemptId = "";
                var attemptResponseCode = "";
                var messageId = "";
                switch (methodId)
                {
                    case "SECURID_NEXT_TOKENCODE":
                        authnAttemptId = TempData["authnAttemptId"].ToString();
                        messageId=TempData["messageId"].ToString();
                        resultApi = procesarApi(procesarPosData(token, Usuario, 4, authnAttemptId.ToString(), messageId), "verify");
                        break;
                    case "SECURID":
                        resultApi = procesarApi(procesarPosData(token, Usuario, 2), "initialize");
                        var context = resultApi["context"];
                        authnAttemptId = context["authnAttemptId"].ToString();
                        messageId = context["messageId"].ToString();
                        resultApi = procesarApi(procesarPosData(token, Usuario, 3, authnAttemptId.ToString(), messageId.ToString()), "verify");
                        
                        var challengeMethods = resultApi["challengeMethods"];
                        if (challengeMethods != null)
                        {
                            var challenges = challengeMethods["challenges"][0];
                            var requiredMethods = challenges["requiredMethods"][0];
                            context = resultApi["context"];
                            messageId = context["messageId"].ToString();
                            TempData["authnAttemptId"] = authnAttemptId;
                            TempData["messageId"] = messageId;
                            TempData["methodId"] = methodId = requiredMethods["methodId"];
                            TempData["ErrorMSG"] = "Introduce token(2), para continuar(esperar nuevo token)";
                        }
                        break;
                }
                //var accesoValido = 1;
                attemptResponseCode = resultApi["attemptResponseCode"].ToString();
                var attemptReasonCode = resultApi["attemptReasonCode"];
                
                switch (attemptResponseCode)
                {
                    case "FAIL":
                        TempData["ErrorMSG"] = "Favor de solicitar al administrador, el desbloqueo de su cuenta o datos incorrectos.";
                        accesoValido = 100;
                        TempData["token"] = token;
                        break;
                    case "SUCCESS":
                        TempData["ErrorMSG"] = null;
                        accesoValido = 1;
                        TempData["token"] = null;
                        ClsLogin acceso = new ClsLogin("", "");
                        var a = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                        TempData["keyAcceso"] = acceso.getKeyAcceso(a.string7);
                        break;
                    case "CHALLENGE":
                        accesoValido = 4;
                        TempData["token"] = token;
                        break;
                    
                }
                TempData["attemptResponseCode"] = attemptResponseCode;
                TempData["attemptReasonCode"] = attemptReasonCode;
                TempData["authnAttemptId"] = authnAttemptId;
                TempData["methodId"] = methodId;
                return accesoValido;
            }
            catch (Exception ex)
            {
                TempData["attemptResponseCode"] = "FAIL";
                TempData["ErrorMSG"] = "Introduce token(1), para continuar(esperar nuevo token)";
                TempData["methodId"] = "SECURID";
                TempData["ErrorMSG"] = string.Format("Error: {0}", ex.Message);
                return 0;
            }
        }
       
        private dynamic procesarApi(dynamic posData, string procesar)
        {
            try
            {

                var guid = Guid.NewGuid();
                var url = "https://servidor01.igob.org.mx:5555/mfa/v1_1/authn/" + procesar;
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/json; charset=utf-8";
                request.Accept = "application/json";
                request.Headers.Add("client-key", "igq4yd09kcysb3oqr1178q7r4t6e8bsmxc96df56d7zm9a3ih4na5zav9nj33hn9");
                request.Headers.Add("X-Access-ID", "w542n23sh035rm8833t018l1a2r5853yv84hju44g1s4r9p6lw7711ne38n0h387");
                
                var posDataSerializado = JsonConvert.SerializeObject(posData);
                ServicePointManager.ServerCertificateValidationCallback = ((remitente, certificado, cadena, sslPolicyErrors) => true);
                request.ContentLength = Encoding.UTF8.GetByteCount(posDataSerializado);
                using (Stream requestStream = request.GetRequestStream())
                {
                    byte[] parametersBuffer = Encoding.UTF8.GetBytes(posDataSerializado);
                    requestStream.Write(parametersBuffer, 0, parametersBuffer.Length);
                }
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string resp = reader.ReadToEnd();

                dynamic resultApi = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<dynamic>(resp);
                return resultApi;
            }
            catch (Exception ex)
            {
                TempData["ErrorMSG"] = string.Format("Error: {0}", ex.Message);
                return null;
            }
        }
        private void getCookie(string value)
        {
            HttpCookie cookie = new HttpCookie("key", value);
            // set the cookie's expiration date
            cookie.Expires = DateTime.Now.AddDays(1);
            // set the cookie on client's browser
            Response.Cookies.Add(cookie);
        }
    }
}