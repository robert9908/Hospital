using AutoMapper;
using Hospital.API.Models.DTO;
using TestTask.Models.Domain;

namespace Hospital.API.Mapping
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AddDoctorRequestDto, Doctor>().ReverseMap();
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Cabinet, CabinetDto>().ReverseMap();
            CreateMap<Specialization, SpecializationDto>().ReverseMap();
            CreateMap<Area, AreaDto>().ReverseMap();
            CreateMap<UpdateDoctorRequestDto, Doctor>().ReverseMap();

            CreateMap<AddPatientRequestDto, Patient>().ReverseMap();
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<UpdatePatientRequestDto,Patient>().ReverseMap();
        }
    }
}
