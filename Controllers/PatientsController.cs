using AutoMapper;
using Hospital.API.Models.DTO;
using Hospital.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTask.Models.Domain;

namespace Hospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPatientRepository patientRepository;

        public PatientsController(IMapper mapper, IPatientRepository patientRepository)
        {
            this.mapper = mapper;
            this.patientRepository = patientRepository;
        }

        //Create Patient
        //POST: /api/patients
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddPatientRequestDto addPatientRequestDto)
        {
            var patientDomainModel = mapper.Map<Patient>(addPatientRequestDto);

            await patientRepository.CreateAsync(patientDomainModel);
            return Ok(mapper.Map<PatientDto>(patientDomainModel));
        }

        //GET Patients
        //GET: /api/patietns?sortBy=Name&Ascending=true&pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? sortBy, [FromQuery] bool? isAscending,
        [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var patientsDomainModel = await patientRepository.GetAllAsync(sortBy,
                isAscending ?? true, pageNumber, pageSize);

            return Ok(mapper.Map<List<PatientDto>>(patientsDomainModel));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deletedPatientDomainModel = await patientRepository.DeleteAsync(id);
            if (deletedPatientDomainModel == null) { return NotFound(); }

            return Ok(mapper.Map<PatientDto>(deletedPatientDomainModel));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdatePatientRequestDto updatePatientRequestDto)
        {
            //Map DTO to Domain Model 
            var patientDomainModel = mapper.Map<Patient>(updatePatientRequestDto);

            await patientRepository.UpdateAsync(id, patientDomainModel);

            if (patientDomainModel == null) { return NotFound(); }

            return Ok(mapper.Map<PatientDto>(patientDomainModel));
        }
    }
}
