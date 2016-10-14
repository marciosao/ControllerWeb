[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ControllerWeb.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ControllerWeb.App_Start.NinjectWebCommon), "Stop")]

namespace ControllerWeb.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    using Domain.Services;
    using Infra.Data.Repositories;
    using Domain.Interfaces.Repositories;
    using Domain.Interfaces.Services;
    using Application.Interfaces;
    using Application;
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));

            kernel.Bind<IProdutoAppService>().To<ProdutoAppService>();
            kernel.Bind<IFabricanteAppService>().To<FabricanteAppService>();
            kernel.Bind<IModeloAppService>().To<ModeloAppService>();
            kernel.Bind<IDevolucaoAppService>().To<DevolucaoAppService>();
            kernel.Bind<IDevolucaoProdutoAppService>().To<DevolucaoProdutoAppService>();
            kernel.Bind<IMenuAppService>().To<MenuAppService>();
            kernel.Bind<IModeloFabricanteAppService>().To<ModeloFabricanteAppService>();
            kernel.Bind<IOcorrenciaAppService>().To<OcorrenciaAppService>();
            kernel.Bind<IPerfilAppService>().To<PerfilAppService>();
            kernel.Bind<IPerfilMenuAppService>().To<PerfilMenuAppService>();
            kernel.Bind<IVendaAppService>().To<VendaAppService>();
            kernel.Bind<IVendaProdutoAppService>().To<VendaProdutoAppService>();
            kernel.Bind<IVendedorAppService>().To<VendedorAppService>();
            kernel.Bind<ILogSistemaAppService>().To<LogSistemaAppService>();


            ////////kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));

            kernel.Bind<IProdutoService>().To<ProdutoService>();
            kernel.Bind<IFabricanteService>().To<FabricanteService>();
            kernel.Bind<IModeloService>().To<ModeloService>();
            kernel.Bind<IDevolucaoService>().To<DevolucaoService>();
            kernel.Bind<IDevolucaoProdutoService>().To<DevolucaoProdutoService>();
            kernel.Bind<IMenuService>().To<MenuService>();
            kernel.Bind<IModeloFabricanteService>().To<ModeloFabricanteService>();
            kernel.Bind<IOcorrenciaService>().To<OcorrenciaService>();
            kernel.Bind<IPerfilService>().To<PerfilService>();
            kernel.Bind<IPerfilMenuService>().To<PerfilMenuService>();
            kernel.Bind<IVendaService>().To<VendaService>();
            kernel.Bind<IVendaProdutoService>().To<VendaProdutoService>();
            kernel.Bind<IVendedorService>().To<VendedorService>();
            kernel.Bind<ILogSistemaService>().To<LogSistemaService>();


            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));

            kernel.Bind<IProdutoRepository>().To<ProdutoRepository>();
            kernel.Bind<IFabricanteRepository>().To<FabricanteRepository>();
            kernel.Bind<IModeloRepository>().To<ModeloRepository>();
            kernel.Bind<IDevolucaoRepository>().To<DevolucaoRepository>();
            kernel.Bind<IDevolucaoProdutoRepository>().To<DevolucaoProdutoRepository>();
            kernel.Bind<IMenuRepository>().To<MenuRepository>();
            kernel.Bind<IModeloFabricanteRepository>().To<ModeloFabricanteRepository>();
            kernel.Bind<IOcorrenciaRepository>().To<OcorrenciaRepository>();
            kernel.Bind<IPerfilRepository>().To<PerfilRepository>();
            kernel.Bind<IPerfilMenuRepository>().To<PerfilMenuRepository>();
            kernel.Bind<IVendaRepository>().To<VendaRepository>();
            kernel.Bind<IVendaProdutoRepository>().To<VendaProdutoRepository>();
            kernel.Bind<IVendedorRepository>().To<VendedorRepository>();
            kernel.Bind<ILogSistemaRepository>().To<LogSistemaRepository>();
        }        
    }
}
