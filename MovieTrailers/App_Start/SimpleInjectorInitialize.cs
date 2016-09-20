using MovieTrailers.BLL;
using MovieTrailers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleInjector;
using System.Web.Http;
using SimpleInjector.Integration.WebApi;

namespace MovieTrailers
{
    public class SimpleInjectorInitialize
    {
        public static Container _container;

        public static void Start()
        {
            _container = new Container();
            _container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            // Register types
            _container.Register<ISearchBLL, SearchBLL>(Lifestyle.Scoped);
            _container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            _container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(_container);
        }
    }
}