namespace Repository.Code
{
    public interface IDatabaseSettings
    {
        string CurrentLocationsCollection { get; set; }
        string HistoricalLocationsCollection { get; set; }
        string ConnectionString { get; set; }
        string Database { get; set; }
    }
}