using Fuze.Domain.Models;
using FuzeAPI.Models;

namespace Fuze.Domain.Interfaces
{
    public interface IKubeRepository
    {
        public Task<List<Pod>> GetAllPodsAsync();
        public Task<List<Deployment>> GetAllDeploymentsAsync();
    }
}
