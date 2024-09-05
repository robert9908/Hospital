using Hospital.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TestTask.Models.Domain;

namespace Hospital.API.Repositories
{
    public class SQLDoctorRepository : IDoctorRepository
    {
        private readonly HospitalDbContext dbContext;

        public SQLDoctorRepository(HospitalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Doctor> CreateAsync(Doctor doctor)
        {
            await dbContext.Doctors.AddAsync(doctor);
            await dbContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<List<Doctor>> GetAllAsync(string? sortBy = null, bool isAscending = true,
        int pageNumber = 1, int pageSize = 1000)
        {
            var doctors = dbContext.Doctors.Include("Cabinet").Include("Specialization").Include("Area").AsQueryable();


            //Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if(sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    doctors = isAscending ? doctors.OrderBy(x => x.Name): doctors.OrderByDescending(x => x.Name);
                }
                else if(sortBy.Equals("Surname", StringComparison.OrdinalIgnoreCase))
                {
                    doctors = isAscending ? doctors.OrderBy(x => x.Surname) : doctors.OrderByDescending(x => x.Surname);
                }
            }

            var skipResults = (pageNumber - 1) * pageSize;

            return await doctors.Skip(skipResults).Take(pageSize).ToListAsync();

        }
        public async Task<Doctor?> DeleteAsync(int id)
        {
            var existingDoctor = await dbContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);
            if(existingDoctor == null) { return null; }

            dbContext.Doctors.Remove(existingDoctor);
            await dbContext.SaveChangesAsync();
            return existingDoctor;
        }

        public async Task<Doctor?> UpdateAsync(int id, Doctor doctor)
        {
            var existingDoctor = await dbContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);

            if(existingDoctor == null) { return null; }

            existingDoctor.Name = doctor.Name;
            existingDoctor.Surname = doctor.Surname;
            existingDoctor.Patronymic = doctor.Patronymic;
            existingDoctor.AreaId = doctor.AreaId;
            existingDoctor.CabinetId = doctor.CabinetId;
            existingDoctor.SpecializationId = doctor.SpecializationId;

            await dbContext.SaveChangesAsync();

            return existingDoctor;


        }
    }
}
