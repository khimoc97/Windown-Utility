namespace WindowUtility.Core.Models
{
    public class AppSettings
    {
        public List<GatewayInfo> ListGateway { get; set; }
    }

    public class GatewayInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bandwidth { get; set; }
        public string DefaultGateway { get; set; }
    }
}
