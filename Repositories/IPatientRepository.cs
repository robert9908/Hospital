using TestTask.Models.Domain;

namespace Hospital.API.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient> CreateAsync(Patient patient);
        Task<List<Patient>> GetAllAsync(string? sortBy = null, bool isAscending = true,
        int pageNumber = 1, int pageSize = 1000);
        Task<Patient?> DeleteAsync(int id);
        Task<Patient?> UpdateAsync(int id, Patient patient);
    }
}
