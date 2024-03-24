using FuzeAPI.Models;

namespace Fuze.Domain.Interfaces
{
    public interface IKubeRepository
    {
        public List<Pod> GetAllPods();
    }
}
