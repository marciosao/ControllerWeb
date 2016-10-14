using Application.Interfaces;
using ControllerWeb.AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ControllerWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly ILogSistemaAppService _logSistemaApp;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.RegisterMappings();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            LogSistema lLog = new LogSistema();
            lLog.Erro = "StackTrace: " + ex.StackTrace.ToString() + " | InnerException: " + ex.InnerException.ToString() + " | Message: " + ex.Message;
            lLog.Tela = "Global.asax";
            lLog.Acao = "Application_Error";
            lLog.DataOcorrencia = DateTime.Now;

            _logSistemaApp.Add(lLog);
        }
    }
}
