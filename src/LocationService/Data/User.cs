using System.Collections.Generic;

namespace LocationService.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location LastKnownLocation { get; set; }
    }

    public class UserHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Location> LocationHistory { get; set; }
    }
}