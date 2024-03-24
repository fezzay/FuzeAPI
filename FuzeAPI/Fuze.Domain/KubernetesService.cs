﻿using Fuze.Domain.Interfaces;
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

        public async Task<List<Pod>> GetAllPodsAsync()
        {
            return await _kubeRepository.GetAllPodsAsync();
        }
    }
}