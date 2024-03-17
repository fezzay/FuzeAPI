using FuzeAPI.Models;

namespace Fuze.Domain
{
    public interface IKubernetesService
    {
        public Pods GetAllPods();
    }
}
