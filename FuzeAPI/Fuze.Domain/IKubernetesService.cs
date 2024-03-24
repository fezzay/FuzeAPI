using FuzeAPI.Models;

namespace Fuze.Domain
{
    public interface IKubernetesService
    {
        public List<Pod> GetAllPods();
    }
}
