namespace Repository.Code
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CurrentLocationsCollection { get; set; }
        public string HistoricalLocationsCollection { get; set; }
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}