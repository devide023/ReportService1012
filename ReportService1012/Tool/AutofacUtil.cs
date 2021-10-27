using Autofac;
using Autofac.Extras.DynamicProxy;
using Autofac.Extras.Quartz;
using ReportService1012.Interceptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReportService1012.Tool
{
    public class AutofacUtil
    {
        /// <summary>
        /// Autofac容器对象
        /// </summary>
        private static IContainer _container;

        /// <summary>
        /// 初始化autofac
        /// </summary>
        public static void InitAutofac()
        {
            var builder = new ContainerBuilder();
            //注册拦截器
            builder.Register(c => new TestCeptor());
            //注册类型
            builder.RegisterTypes(Assembly.GetExecutingAssembly().GetTypes())
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors();
            //配置quartz.net依赖注入
            builder.RegisterModule(new QuartzAutofacFactoryModule());
            builder.RegisterModule(new QuartzAutofacJobsModule(Assembly.GetExecutingAssembly()));
            _container = builder.Build();
        }

        /// <summary>
        /// 从Autofac容器获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetFromFac<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
