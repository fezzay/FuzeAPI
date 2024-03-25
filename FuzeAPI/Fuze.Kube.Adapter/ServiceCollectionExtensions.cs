using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Fuze.Kube.Adapter.ConfigMap;
using Fuze.Domain.Interfaces;

namespace Fuze.Kube.Adapter
{
    public static class ServiceCollectionExtensions
    {
        public static void AddKube(this IServiceCollection services)
        {
            services.AddSingleton<IKubeRepository, KubeRepository>();
        }
    }
}
