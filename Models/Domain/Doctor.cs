using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Models.Domain
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        [ForeignKey("Cabinet")]
        public int CabinetId {  get; set; }
        [ForeignKey("Specialization")]
        public int SpecializationId { get; set; }
        [ForeignKey("Area")]
        public int AreaId { get; set; }
        public Cabinet Cabinet { get; set; }
        public Specialization Specialization { get; set; }
        public Area Area { get; set; }

    }
}
