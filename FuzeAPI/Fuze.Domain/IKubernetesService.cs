using FuzeAPI.Models;

namespace Fuze.Domain
{
    public interface IKubernetesService
    {
        public Task<List<Pod>> GetAllPodsAsync();
    }
}
