namespace Fuze.Domain.Models
{
    public class Deployment
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Namespace { get; set; } = "";
        public List<string> Selectors { get; set; } = new();
    }
}
