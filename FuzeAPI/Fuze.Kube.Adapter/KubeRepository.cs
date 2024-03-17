using Fuze.Domain.Interfaces;
using FuzeAPI.Models;
using k8s;

namespace Fuze.Kube.Adapter
{
    public class KubeRepository : IKubeRepository
    {
        private KubernetesClientConfiguration _kubeClientConfig;
        private Kubernetes _kube;
        public KubeRepository()
        {
            _kubeClientConfig = KubernetesClientConfiguration.BuildConfigFromConfigFile("/etc/rancher/k3s/k3s.yaml");
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
                Summary = "hi"
            };
        }
    }
}