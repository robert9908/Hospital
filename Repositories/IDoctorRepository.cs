using TestTask.Models.Domain;

namespace Hospital.API.Repositories
{
    public interface IDoctorRepository
    {
        Task<Doctor> CreateAsync(Doctor doctor);
        Task<List<Doctor>> GetAllAsync(string? sortBy = null, bool isAscending = true, 
        int pageNumber = 1, int pageSize = 1000);
        Task<Doctor?> DeleteAsync(int id);
        Task<Doctor?>UpdateAsync(int id, Doctor doctor);
    }
}
