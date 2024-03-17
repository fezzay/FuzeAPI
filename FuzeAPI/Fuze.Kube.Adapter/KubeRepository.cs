using Fuze.Domain.Interfaces;
using FuzeAPI.Models;

namespace Fuze.Kube.Adapter
{
    public class KubeRepository : IKubeRepository
    {
        public KubeRepository() 
        {

        }

        public Pods GetAllPods()
        {
            return new Pods()
            {
                Date = DateTime.Now.AddDays(1),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = "hi"
            };
        }
    }
}