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
        public ActionResult PrincipalEMBALAGEM()
        {
            ViewBag.Message = "PrincipalEMBALAGEM";

            return View();
        }

        public ActionResult PrincipalENTREGADOR()
        {
            ViewBag.Message = "PrincipalENTREGADOR";

            return View();
        }

        public ActionResult PrincipalERRO()
        {
            ViewBag.Message = "PrincipalERRO";

            return View();
        }

        public ActionResult PrincipalUSUARIO()
        {
            ViewBag.Message = "PrincipalUSUARIO";

            return View();
        }

        public ActionResult EmbalagemAlterar()
        {
            ViewBag.Message = "EmbalagemAlterar";

            return View();
        }

        public ActionResult EntregadorAlterar()
        {
            ViewBag.Message = "EntregadorAlterar";

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
                    var resultado = servico.RetornaRole(Usuario);

                    if (resultado == "EMBALAGEM")
                    {
                        return RedirectToAction("PrincipalEMBALAGEM");
                    }
                    else if (resultado == "USUARIO")
                    {
                        return RedirectToAction("PrincipalUSUARIO");
                    }
                    else if (resultado == "ENTREGADOR")
                    {
                        return RedirectToAction("PrincipalENTREGADOR");
                    }
                    else
                    {
                        return RedirectToAction("PrincipalERRO");
                    }
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