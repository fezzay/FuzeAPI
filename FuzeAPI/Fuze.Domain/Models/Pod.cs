namespace FuzeAPI.Models
{
    public class Pod
    {
        public string Name { get; set; } = "";
        public string Namespace { get; set; } = "default";
        public string Status { get; set; } = "NOT FOUND";
    }
}