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

        public async Task<List<Pod>> GetAllPodsAsync()
        {
            List<Pod> allPods = new List<Pod>();
            var pods = await _kube.CoreV1.ListPodForAllNamespacesAsync();

            foreach (var pod in pods.Items)
            {
                Pod newPod = new()
                {
                    Name = pod.Metadata.Name,
                    Namespace = pod.Metadata.NamespaceProperty,
                    Status = pod.Status.Phase
                };

                allPods.Add(newPod);
            }

            return allPods;
        }
    }
}