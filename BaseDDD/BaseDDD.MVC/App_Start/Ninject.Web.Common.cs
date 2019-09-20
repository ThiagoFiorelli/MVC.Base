[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BaseDDD.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(BaseDDD.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace BaseDDD.MVC.App_Start
{
    using System;
    using System.Reflection;
    using System.Web;
    using BaseDDD.Application;
    using BaseDDD.Application.Interface;
    using BaseDDD.Domain.Interfaces.Repositories;
    using BaseDDD.Domain.Interfaces.Services;
    using BaseDDD.Domain.Services;
    using BaseDDD.Infra.Data.Repositories;
    using BaseDDD.MVC.AutoMapper;
    using global::AutoMapper;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

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
                kernel.Load(Assembly.GetExecutingAssembly());
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
            kernel.Bind<IClienteAppService>().To<ClienteAppService>();
            kernel.Bind<IProdutoAppService>().To<ProdutoAppService>();
            kernel.Bind<IPedidoAppService>().To<PedidoAppService>();
            kernel.Bind<IPedidoItemAppService>().To<PedidoItemAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IClienteService>().To<ClienteService>();
            kernel.Bind<IProdutoService>().To<ProdutoService>();
            kernel.Bind<IPedidoService>().To<PedidoService>();
            kernel.Bind<IPedidoItemService>().To<PedidoItemService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IClienteRepository>().To<ClienteRepository>();
            kernel.Bind<IProdutoRepository>().To<ProdutoRepository>();
            kernel.Bind<IPedidoRepository>().To<PedidoRepository>();
            kernel.Bind<IPedidoItemRepository>().To<PedidoItemRepository>();

            kernel.Bind<IMapper>()
                .ToMethod(context =>
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                            cfg.AddProfile<DomainToViewModelMappingProfile>();
                            cfg.AddProfile<ViewModelToDomainMappingProfile>();
                            // tell automapper to use ninject when creating value converters and resolvers
                            cfg.ConstructServicesUsing(t => kernel.Get(t));
                    });
                    return config.CreateMapper();
                }).InSingletonScope();
        }        
    }
}