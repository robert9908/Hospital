namespace Hospital.API.Models.DTO
{
    public class AddDoctorRequestDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int CabinetId { get; set; }
        public int SpecializationId { get; set; }
        public int AreaId { get; set; }
    }
}
