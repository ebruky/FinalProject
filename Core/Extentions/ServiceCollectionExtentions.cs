using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection,ICoreModule[] coreModules)
        {
            //parametre olarak verdiğimiz this neyi genişletmek istediğimi belirtmek içindir yani parametre değildir.

            foreach (var coreModule in coreModules)
            {
                coreModule.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
