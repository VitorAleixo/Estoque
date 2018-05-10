using Logistica.DAL;
using Logistica.Models;
using Logistica.WebService;
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

                ServicoWeb servico = new ServicoWeb();
                

                if (servico.Autenticar(Usuario, SenhaCriptografada) == true)
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
               throw ex;
            }
        }

    }
}