using Fuze.Domain.Interfaces;
using FuzeAPI.Models;

namespace Fuze.Domain
{
    public class KubernetesService : IKubernetesService
    {
        private IKubeRepository _kubeRepository;

        public KubernetesService(IKubeRepository kubeRepository) 
        {
            _kubeRepository = kubeRepository;
        }

        public Pods GetAllPods()
        {
            return _kubeRepository.GetAllPods();
        }
    }
}