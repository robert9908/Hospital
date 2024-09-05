using Hospital.API.Data;
using Microsoft.EntityFrameworkCore;
using TestTask.Models.Domain;

namespace Hospital.API.Repositories
{
    public class SQLPatientRepository: IPatientRepository
    {
        private readonly HospitalDbContext dbContext;

        public SQLPatientRepository(HospitalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Patient> CreateAsync(Patient patient)
        {
            await dbContext.Patients.AddAsync(patient);
            await dbContext.SaveChangesAsync();
            return patient;
        }

        public async Task<List<Patient>> GetAllAsync(string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000)
        {
            var patients = dbContext.Patients.Include("Area").AsQueryable();

            // Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase)) // Используйте свойства модели Patient
                {
                    patients = isAscending ? patients.OrderBy(x => x.Name) : patients.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("LastName", StringComparison.OrdinalIgnoreCase)) // Используйте свойства модели Patient
                {
                    patients = isAscending ? patients.OrderBy(x => x.Surname) : patients.OrderByDescending(x => x.Surname);
                }
            }

            var skipResults = (pageNumber - 1) * pageSize;

            return await patients.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<Patient?> DeleteAsync(int id)
        {
            var existingPatient = await dbContext.Patients.FirstOrDefaultAsync(x => x.Id == id);
            if (existingPatient == null) { return null; }

            dbContext.Patients.Remove(existingPatient);
            await dbContext.SaveChangesAsync();
            return existingPatient;
        }

        public async Task<Patient?> UpdateAsync(int id, Patient patient)
        {
            var existingPatient = await dbContext.Patients.FirstOrDefaultAsync(x => x.Id==id);

            if (existingPatient == null) { return null; }

            existingPatient.Name = patient.Name;
            existingPatient.Surname = patient.Surname;
            existingPatient.Patronymic = patient.Patronymic;
            existingPatient.Address = patient.Address;
            existingPatient.BirthDate = patient.BirthDate;
            existingPatient.Gender = patient.Gender;
            existingPatient.AreaId = patient.AreaId;

            await dbContext.SaveChangesAsync();

            return existingPatient;
        }
    }
}
