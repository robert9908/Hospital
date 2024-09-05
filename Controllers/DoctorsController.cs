using AutoMapper;
using Hospital.API.Models.DTO;
using Hospital.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using TestTask.Models.Domain;


namespace Hospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IDoctorRepository doctorRepository;

        public DoctorsController(IMapper mapper, IDoctorRepository doctorRepository)
        {
            this.mapper = mapper;
            this.doctorRepository = doctorRepository;
        }
        //Create Doctor
        //POST: /api/doctors
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddDoctorRequestDto addDoctorRequestDto)
        {
            var doctorDomainModel = mapper.Map<Doctor>(addDoctorRequestDto);

            await doctorRepository.CreateAsync(doctorDomainModel);
            return Ok(mapper.Map<DoctorDto>(doctorDomainModel));
        }

        //GET Doctors
        //GET: /api/doctors?sortBy=Name&Ascending=true&pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? sortBy, [FromQuery] bool? isAscending,
        [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000 )
        {
            var doctorsDomainModel = await doctorRepository.GetAllAsync(sortBy, isAscending?? true,pageNumber, pageSize);

            return Ok(mapper.Map<List<DoctorDto>>(doctorsDomainModel));
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deletedDoctorDomainModel = await doctorRepository.DeleteAsync(id);
            if(deletedDoctorDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<DoctorDto>(deletedDoctorDomainModel));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateDoctorRequestDto updatedoctorRequestDto)
        {
            //Map DTO to Domain Model 
            var doctorDomainModel = mapper.Map<Doctor>(updatedoctorRequestDto);

            await doctorRepository.UpdateAsync(id, doctorDomainModel);

            if (doctorDomainModel == null) { return NotFound(); }

            return Ok(mapper.Map<DoctorDto>(doctorDomainModel));
        }

    }
}
