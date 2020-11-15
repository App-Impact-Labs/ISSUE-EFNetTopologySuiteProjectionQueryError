using System.Collections.Generic;

namespace EfProjectionWithTopologyError.Entities
{
    public class MedicalService
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IList<HealthInstitutionMedicalServiceLink> HealthInstitutionLinks { get; set; }
    }
}
