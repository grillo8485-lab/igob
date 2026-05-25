using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using iGob.AccesoDatos;
using iGob.Entidades;
using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using iGob.ReglasNegocios;
using System.Security.Cryptography;
using System.Text;

namespace IGOB.Controllers
{
    public class RecuperacionContraseniaController : Controller
    {
        private brSysUsuarios ObrSysUsuarios = new brSysUsuarios();

        // GET: RecuperacionContrasenia
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RecuperacionPassword(string correo)
        {
            var mess = "";
            var suc = false;
            try
            {
                var usuariolog = ObrSysUsuarios.listarTodos_SysUsuarios().FirstOrDefault(x=>x.Usuario.ToUpper().Trim()==correo.ToUpper().Trim());
                if (usuariolog!=null)
                {
                    //mess = DecryptMD5(usuariolog.Password);
                    //suc = false;
                    if (EnviarEmail(usuariolog))//correo usuariolog.Usuario
                    {
                        mess = "Se enviaron los datos al correo";
                        suc = true;
                    }
                    else
                    {
                        mess = "No se pudo enviar datos al correo";
                        suc = false;
                    }
                }
                else
                {
                    mess = "se encontrarón algunos problemas con la cuenta contacte con el administrador";
                    suc = false;
                }
            }
            catch(Exception e)
            {
                mess = "Se encontrarón algunos problemas con la cuenta contacte con el administrador";//e.Message;
                suc = false;
            }
            return Json(new { success = suc,message = mess }, JsonRequestBehavior.AllowGet);
        }

        private bool EnviarEmail(beSysUsuarios us)
        {
            MailMessage correo = new MailMessage();
            try
            {
                if (us != null)
                {
                    var guid = Guid.NewGuid().ToString();
                    us.LlaveAcceso = guid;
                    var newpassword = this.CrearPassword(10);
                    us.Password = this.EncodeMd5(newpassword);
                    ObrSysUsuarios.actualizarSysUsuarios(us);

                    string path = "http://192.168.100.4/RecuperacionContrasenia/LinkRecuperacionPassword?str1=" + guid + "&str2=" + us.IdUsuario + "&str3=1mb3h";

                    var msgbody = "<strong style='color: #fff'>Usuario " + us.Nombres + " " + us.Apellidos + " su nueva contraseña del sistema iGob es: " + newpassword + "</strong><br/><strong style='color: #fff'>Aviso!</strong><br/><a href='" + path + "' style='color: #fff'>Da click para verificar cuenta</a><br/><strong style='color: #fff'>o pega este LINK:  " + path + "</strong><br/>iGob"; ;
                    var htmlbody = "<div align='center' style='background-color: #383838'><img width='20%'  draggable='false' src='http://igob.mx/temas/iGob/images/iGob_logotipo.png' /><div style='color: #fff'>" + msgbody + ".</div><hr></div>";

                    beConfiguracionMailSalida emailadmin = new brConfiguracionMailSalida().listarTodos_ConfiguracionMailSalida().FirstOrDefault(x=>x.Activo==true);

                    correo.From = new MailAddress(emailadmin.Correo);//usuario real admin
                    correo.To.Add(us.Usuario);
                    correo.Subject = ("Recuperación de clave del sistema iGob");
                    correo.IsBodyHtml = true;
                    correo.Body = htmlbody;
                    correo.Priority = MailPriority.Normal;

                    SmtpClient serverMail = new SmtpClient();
                    serverMail.Credentials = new NetworkCredential(emailadmin.Correo,emailadmin.Contrasena);
                    serverMail.Host = emailadmin.Servidor;//"smtp.gmail.com";//"smtp.live.com";
                    serverMail.EnableSsl = true;
                    serverMail.Timeout = 300000;
                    serverMail.Port = emailadmin.Puerto;

                    serverMail.Send(correo);

                    correo.Dispose();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                us.LlaveAcceso = "";
                ObrSysUsuarios.actualizarSysUsuarios(us);
                var ec = e.Message;
                correo.Dispose();
                return false;
            }

        }

        private string DecryptMD5(string message)
        {
            string passphrase = "A!9HHhi%XjjYY4YP2@Nob009X";
            byte[] results;
            UTF8Encoding utf8 = new UTF8Encoding();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] deskey = md5.ComputeHash(utf8.GetBytes(passphrase));
            TripleDESCryptoServiceProvider desalg = new TripleDESCryptoServiceProvider();
            desalg.Key = deskey;
            desalg.Mode = CipherMode.ECB;
            desalg.Padding = PaddingMode.PKCS7;
            byte[] decrypt_data = Convert.FromBase64String(message);
            try
            {
                //To transform the utf binary code to md5 decrypt
                ICryptoTransform decryptor = desalg.CreateDecryptor();
                results = decryptor.TransformFinalBlock(decrypt_data, 0, decrypt_data.Length);
            }
            finally
            {
                desalg.Clear();
                md5.Clear();

            }
            //TO convert decrypted binery code to string
            return utf8.GetString(results);
        }

        public ActionResult LinkRecuperacionPassword(string str1,int str2)
        {
            try
            {
                var usuariolog = ObrSysUsuarios.traerSysUsuarios_x_IdUsuario(str2);
                //var usuariolog = ObrSysUsuarios.listarTodos_SysUsuarios().FirstOrDefault(x => x.LlaveAcceso.Trim() == str1.Trim());
                if (usuariolog != null)
                {
                    if(usuariolog.LlaveAcceso.Trim() == str1.Trim())
                    {
                        usuariolog.LlaveAcceso = "";
                        if (ObrSysUsuarios.actualizarSysUsuarios(usuariolog) == 0)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ViewBag.mess = "Se encontrarón algunos problemas con la cuenta contacte con el administrador";
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.mess = "Se encontrarón algunos problemas con la cuenta contacte con el administrador";
                        return View();
                    }
                }
                else
                {
                    ViewBag.mess = "Se encontrarón algunos problemas con la cuenta contacte con el administrador";
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.mess = "Se encontrarón algunos problemas con la cuenta contacte con el administrador <div class='d-none'>" + e.Message + "</div>";
                return View();
            }
        }

        private string CrearPassword(int longitud)
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < longitud--)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            return res.ToString();
        }

        private string EncodeMd5(string message)
        {
            string passphrase = "A!9HHhi%XjjYY4YP2@Nob009X";
            byte[] results;
            UTF8Encoding utf8 = new UTF8Encoding();
            //to create the object for UTF8Encoding  class
            //TO create the object for MD5CryptoServiceProvider 
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] deskey = md5.ComputeHash(utf8.GetBytes(passphrase));
            //to convert to binary passkey
            //TO create the object for  TripleDESCryptoServiceProvider 
            TripleDESCryptoServiceProvider desalg = new TripleDESCryptoServiceProvider();
            desalg.Key = deskey;//to  pass encode key
            desalg.Mode = CipherMode.ECB;
            desalg.Padding = PaddingMode.PKCS7;
            byte[] encrypt_data = utf8.GetBytes(message);
            //to convert the string to utf encoding binary 

            try
            {


                //To transform the utf binary code to md5 encrypt    
                ICryptoTransform encryptor = desalg.CreateEncryptor();
                results = encryptor.TransformFinalBlock(encrypt_data, 0, encrypt_data.Length);

            }
            finally
            {
                //to clear the allocated memory
                desalg.Clear();
                md5.Clear();
            }
            //to convert to 64 bit string from converted md5 algorithm binary code
            return Convert.ToBase64String(results);

        }

    }
}