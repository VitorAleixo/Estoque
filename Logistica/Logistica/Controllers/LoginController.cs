using Logistica.DAL;
using Logistica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Logistica.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Principal()
        {
            ViewBag.Message = "Principal";

            return View();
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Usuario, string Senha)
        {
            try
            {

                Criptografacao encrypt = new Criptografacao();
                string SenhaCriptografada = encrypt.SHA256(Senha);

                UsuarioDAO UserLogin = new UsuarioDAO();
                UserLogin.Login(Usuario, SenhaCriptografada);


                if (UserLogin.Validar == true)
                {
                    return RedirectToAction("Principal");
                }
                else
                {
                    ModelState.AddModelError("", "Usuário ou senha inválidos!");
                    return View();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}