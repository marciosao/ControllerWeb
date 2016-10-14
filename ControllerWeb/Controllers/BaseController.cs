using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ControllerWeb.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILogSistemaAppService _logSistemaApp;
        protected const string SESSAO_USUARIO = "UsuarioLogado";
        protected Vendedor gUsuario { get; set; }
        
        protected void ObtemUsuarioLogado()
        {
            try
            {
                if (Session != null && Session[SESSAO_USUARIO] != null)
                {
                    if (gUsuario == null)
                    {
                        gUsuario = new Vendedor();
                    }

                    gUsuario = (Vendedor)Session[SESSAO_USUARIO];
                }
                else
                {
                    RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                LogSistema lLog = new LogSistema();
                lLog.Erro = "StackTrace: " + ex.StackTrace.ToString() + " | InnerException: " + ex.InnerException.ToString() + " | Message: " + ex.Message;
                lLog.Tela = "BaseController";
                lLog.Acao = "ObtemUsuarioLogado";
                lLog.DataOcorrencia = DateTime.Now;
                if (GetUsuarioLogado() != null)
                {
                    lLog.Usuario = GetUsuarioLogado().IdVendedor;
                }

                _logSistemaApp.Add(lLog);
            }
        }

        ////////public BaseController()
        ////////{
        ////////    //this.ObtemUsuarioLogado();
        ////////}

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Se usuário não é válido, a requisição é redirecionada 
            // para a página de login configurada.
            if (!IsUsuarioValido())
            {
                filterContext.Result = new RedirectResult(FormsAuthentication.LoginUrl, true);
                filterContext.Result = new RedirectResult("~/Home/Login", true);
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }

        /// <summary>
        /// Verifica se há usuário válido e ativo na sessão
        /// </summary>
        private bool IsUsuarioValido()
        {
            return (Session != null) && (Session[SESSAO_USUARIO] != null);
        }

        /// <summary>
        /// Recupera o usuário logado, caso haja algum
        /// </summary>
        /// <returns></returns>
        protected Vendedor GetUsuarioLogado()
        {
            Vendedor usuario = null;
            try
            {
                if (Session != null)
                {
                    usuario = Session[SESSAO_USUARIO] as Vendedor;
                }
            }
            catch (Exception ex)
            {
                LogSistema lLog = new LogSistema();
                lLog.Erro = "StackTrace: " + ex.StackTrace.ToString() + " | InnerException: " + ex.InnerException.ToString() + " | Message: " + ex.Message;
                lLog.Tela = "BaseController";
                lLog.Acao = "GetUsuarioLogado";
                lLog.DataOcorrencia = DateTime.Now;
                if (GetUsuarioLogado() != null)
                {
                    lLog.Usuario = GetUsuarioLogado().IdVendedor;
                }

                _logSistemaApp.Add(lLog);
            }
            return usuario;
        }


    }
}