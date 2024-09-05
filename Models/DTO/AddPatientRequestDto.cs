namespace Hospital.API.Models.DTO
{
    public class AddPatientRequestDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public int AreaId { get; set; }
    }
}
