using Fuze.Domain.Interfaces;
using Fuze.Kube.Adapter.ConfigMap;
using FuzeAPI.Models;
using k8s;
using k8s.Models;
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

        public async Task<List<Pod>> GetAllPodsAsync()
        {
            List<Pod> allPods = new List<Pod>();
            var pods = await _kube.CoreV1.ListPodForAllNamespacesAsync();
            var bob = _kube.ListDeploymentForAllNamespaces();
            foreach (var pod in pods.Items)
            {
                var steve = pod.Labels().Values;
                Pod newPod = new()
                {
                    Name = pod.Metadata.Name,
                    Namespace = pod.Metadata.NamespaceProperty,
                    Status = pod.Status.Phase,
                    Selector = pod.Labels().Values.ToList()
                };

                allPods.Add(newPod);
            }

            return allPods;
        }
    }
}