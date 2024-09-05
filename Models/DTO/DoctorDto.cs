using TestTask.Models.Domain;

namespace Hospital.API.Models.DTO
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public CabinetDto Cabinet { get; set; }
        public SpecializationDto Specialization { get; set; }
        public AreaDto Area { get; set; }

    }
}
