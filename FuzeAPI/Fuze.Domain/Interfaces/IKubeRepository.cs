using FuzeAPI.Models;

namespace Fuze.Domain.Interfaces
{
    public interface IKubeRepository
    {
        public Pods GetAllPods();
    }
}
