using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.API.Models.DTO
{
    public class UpdateDoctorRequestDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int CabinetId { get; set; }
        public int SpecializationId { get; set; }
        public int AreaId { get; set; }
    }
}
