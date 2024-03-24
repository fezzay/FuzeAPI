using Fuze.Domain.Interfaces;
using Fuze.Domain.Models;
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
            List<Pod> allPods = new();
            var pods = await _kube.CoreV1.ListPodForAllNamespacesAsync();
            foreach (var pod in pods.Items)
            {
                Pod newPod = new()
                {
                    Name = pod.Metadata.Name,
                    Namespace = pod.Metadata.NamespaceProperty,
                    Status = pod.Status.Phase,
                    Selectors = pod.Labels().Values.ToList()
                };

                allPods.Add(newPod);
            }

            return allPods;
        }

        public async Task<List<Deployment>> GetAllDeploymentsAsync()
        {
            List<Deployment> allDeployments = new();
            var deployments = await _kube.ListDeploymentForAllNamespacesAsync();
            foreach (var deployment in deployments.Items)
            {
                Deployment newDeployment = new()
                {
                    Name = deployment.Metadata.Name,
                    Namespace = deployment.Metadata.NamespaceProperty,
                    Selectors = deployment.Labels().Values.ToList()
                };

                allDeployments.Add(newDeployment);
            }
            return allDeployments;
        }
    }
}