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
        public ActionResult PrincipalEntrega()
        {
            ViewBag.Message = "PrincipalEntrega";

            return View();
        }

        public ActionResult PrincipalStatusProduto()
        {
            ViewBag.Message = "PrincipalStatusProduto";

            return View();
        }

        public ActionResult Rastreio()
        {
            ViewBag.Message = "Rastreio";

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

                WebServiceXML UserLogin = new WebServiceXML();

                if (UserLogin.Autenticar(Usuario, SenhaCriptografada) == true)
                {
                    //ADICIONAR METODO PARA VER A FUNÇÂO DO USUARIO LOGADO E DEPENDENDO RETORNA A TELA
                    return RedirectToAction("PrincipalEntrega");
                }
                else
                {
                    ModelState.AddModelError("", "Usuário ou senha inválidos!");
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }
}