using NetTopologySuite.Geometries;
using System.Collections.Generic;

namespace EfProjectionWithTopologyError.Entities
{
    public class HealthInstitution
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Point Coordinates { get; set; }

        public virtual IList<HealthInstitutionMedicalServiceLink> MedicalServiceLinks { get; set; }
    }
}
