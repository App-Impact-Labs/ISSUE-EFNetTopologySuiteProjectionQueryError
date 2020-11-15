using System.Collections.Generic;

namespace EfProjectionWithTopologyError.Dto
{
    public class HealthInstitutionGetDetailsRes
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public GeolocationDto Coordinates { get; set; }

        public IEnumerable<int> MedicalServiceIds { get; set; }

        public class GeolocationDto

        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }
    }
}
