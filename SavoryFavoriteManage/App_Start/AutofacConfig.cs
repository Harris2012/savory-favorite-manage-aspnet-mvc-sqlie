using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

using SavoryFavoriteManage.Controllers;
using SavoryFavoriteManage.Convertor;
using SavoryFavoriteManage.Repository;
using SavoryFavoriteManage.Repository.Sqlite;
using SavoryFavoriteManage.Meta;

namespace SavoryFavoriteManage
{
    public class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //asp.net mvc
            {
                var builder = new ContainerBuilder();
                builder.RegisterControllers(typeof(MvcApplication).Assembly);

                DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
            }

            //asp.net webapi
            {
                var builder = new ContainerBuilder();
                builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
                builder.RegisterType<SqliteConnectionProvider>();

                builder.RegisterType<SqliteFavoriteRepository>().As<IFavoriteRepository>().SingleInstance();
                builder.RegisterType<SqliteCategoryRepository>().As<ICategoryRepository>().SingleInstance();

                builder.RegisterType<SqliteTheCategoryRepository>().As<ITheCategoryRepository>().SingleInstance();

                builder.RegisterType<FavoriteConvertor>().As<IFavoriteConvertor>().SingleInstance();
                builder.RegisterType<CategoryConvertor>().As<ICategoryConvertor>().SingleInstance();

                builder.RegisterType<TheCategoryConvertor>().As<ITheCategoryConvertor>().SingleInstance();

                builder.RegisterType<TheCategoryMeta>().As<ITheCategoryMeta>().SingleInstance();

                config.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());
            }
        }
    }
}