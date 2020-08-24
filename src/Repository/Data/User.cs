using System.Collections.Generic;

namespace Repository.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location CurrentLocation { get; set; }
        public IList<UserLocation> LocationHistory { get; set; } = new List<UserLocation>();
    }
}