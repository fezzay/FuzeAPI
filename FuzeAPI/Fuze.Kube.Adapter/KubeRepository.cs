using Fuze.Domain.Interfaces;
using Fuze.Kube.Adapter.ConfigMap;
using FuzeAPI.Models;
using k8s;
using Microsoft.Extensions.Options;

namespace Fuze.Kube.Adapter
{
    public class KubeRepository : IKubeRepository
    {
        private KubernetesClientConfiguration _kubeClientConfig;
        private Kubernetes _kube;
        private readonly IOptions<KubeHost> _kubeHostSettings;
        public KubeRepository(IOptions<KubeHost> kubeHostSettings)
        {
            _kubeHostSettings = kubeHostSettings;
            _kubeClientConfig = new KubernetesClientConfiguration { Host = $"http://{_kubeHostSettings.Value.IP}:{_kubeHostSettings.Value.Port}"};
            _kube = new Kubernetes(_kubeClientConfig);
        }

        public Pods GetAllPods()
        {
            var list = _kube.CoreV1.ListNamespacedPod("default");
            foreach (var item in list.Items)
            {
                Console.WriteLine(item.Metadata.Name);
            }
            return new Pods()
            {
                Date = DateTime.Now.AddDays(1),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = list.Items.First().Metadata.Name
            };
        }
    }
}