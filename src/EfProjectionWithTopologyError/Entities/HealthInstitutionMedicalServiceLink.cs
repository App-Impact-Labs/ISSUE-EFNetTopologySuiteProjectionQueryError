namespace EfProjectionWithTopologyError.Entities
{
    public class HealthInstitutionMedicalServiceLink
    {
        public int Id { get; set; }

        public int HealthInstitutionId { get; set; }
        public virtual HealthInstitution HealthInstitution { get; set; }

        public int MedicalServiceId { get; set; }
        public virtual MedicalService MedicalService { get; set; }
    }
}
