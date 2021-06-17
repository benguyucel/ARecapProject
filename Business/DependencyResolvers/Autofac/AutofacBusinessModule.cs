using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Services
            builder.RegisterType<CarMenager>().As<ICarService>();
            builder.RegisterType<BrandMenager>().As<IBrandService>();
            builder.RegisterType<ColorMenager>().As<IColorService>();
            builder.RegisterType<RentalMenager>().As<IRentalService>();
            builder.RegisterType<CustomerMenager>().As<ICustomerService>();
            builder.RegisterType<UserMenager>().As<IUserService>();
            builder.RegisterType<CarImageMenager>().As<ICarImageService>();
            builder.RegisterType<AuthMenager>().As<IAuthService>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            //Dals

            builder.RegisterType<EfCarDal>().As<ICarDal>();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>();
            builder.RegisterType<EfColorDal>().As<IColorDal>();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
