using Application.Interfaces;
using ControllerWeb.ViewModels;
using Domain.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ControllerWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVendedorAppService _vendedorApp;
        public HomeController(IVendedorAppService vendedorApp)
        {
            this._vendedorApp = vendedorApp;
        }
        public ActionResult Index()
        {
			if(Session["UsuarioLogado"] != null)
			{
				return View();
			}
			else
			{
				return View("Login");
			}
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Vendedor pVendedor)
        {
            //Inicia a autorização .NET
            FormsAuthentication.Initialize();

            if (string.IsNullOrEmpty(pVendedor.Matricula) || string.IsNullOrEmpty(pVendedor.Senha))
            {
                // *43396 [Segurança] Usuário - Autenticação - MSG Campo Obriga
                if (string.IsNullOrEmpty(pVendedor.Matricula) && string.IsNullOrEmpty(pVendedor.Senha))
                {
                    Session["sModalMsgm"] = "* Usuário e Senha são campos obrigatórios";
                }
                else if (string.IsNullOrEmpty(pVendedor.Matricula))
                {
                    Session["sModalMsgm"] = "* Usuário é campo obrigatório.";
                }
                else if (string.IsNullOrEmpty(pVendedor.Senha))
                {
                    Session["sModalMsgm"] = "* Senha é campo obrigatório.";
                }

                ViewBag.MsgErro = 1;
                Session["sModalTit"] = "Mensagem do Sistema";
                Session["Usuario"] = null;

                return View();
            }

            var login = _vendedorApp.Login(pVendedor);
            //********************************************************************
            if (login!= null)
            {
                if (Permissoes(login))
                {
                    Autenticar(login);
					Session.Add("UsuarioLogado",login); 
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.MsgErro = 1;
                Session["sModalMsgm"] = "* Usuário e/ou Senha inválido(a)!";
                Session["sModalTit"] = "Mensagem do Sistema";

                //bool validar = true;

                Session["UsuarioLogado"] = null;
                ModelState.AddModelError("", "");
            }

            //********************************************************************

            ////////if (login != null)
            ////////{
            ////////    Session.Add("UsuarioLogado", login);

            ////////    return RedirectToAction("Index", "Home");
            ////////}
            ////////else {
            ////////    return RedirectToAction("Login", "Home");
            ////////}

            return View();
        }

        [ChildActionOnly]
        public ActionResult PartialModalConfirmLogin()
        {
            string caminho = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
            ViewBag.Caminho = caminho;
            ViewBag.MensagemModal = Session["sModalMsgm"].ToString();
            ViewBag.TituloModal = Session["sModalTit"].ToString();
            ViewBag.MsgErro = Session["sMsgErro"];

            Session["sModalMsgm"] = null;
            Session["sModalTit"] = null;
            Session["sMsgErro"] = null;
            Session["FlagBotoesTela"] = null;

            return PartialView();
        }

        private bool Permissoes(Vendedor usuario)
        {
            // Preenche o usuario
            Session["UsuarioAlterar"] = usuario;

            ViewBag.MsgErro = 0;

            if (!usuario.Ativo)
            {
                ViewBag.MsgErro = 1;
                Session["sModalMsgm"] = "* Usuário Desabilitado! Para maiores informações entre em contato com o Gerente.";
                Session["sModalTit"] = "Mensagem do Sistema";

                return false;
            }
            else
            {
                return true;
            }

        }

        public void Autenticar(Vendedor usuario, string senhaCrip = "")
        {
            FormsAuthenticationTicket autentic = new FormsAuthenticationTicket(usuario.Matricula, false, 120);

            // Criptografa o ticket por questão de segurança
            string encryptedTicket = FormsAuthentication.Encrypt(autentic);

            // Cria um cookie(será usado para validação do asp.net)
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            // Seta expiração
            if (autentic.IsPersistent) authCookie.Expires = autentic.Expiration;

            //Adiciona o cookie na aplicação
            Response.Cookies.Add(authCookie);
        }
    }
}