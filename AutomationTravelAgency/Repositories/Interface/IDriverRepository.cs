using AutomationTravelAgency.Models.Domain;

namespace AutomationTravelAgency.Repositories.Interface
{
    public interface IDriverRepository
    {
        Task<Driver > CreateAsync(Driver driver);
        Task<IEnumerable<Driver>> GetAllAsync();

        Task<Driver?> GetById(int id);

        Task<Driver?> UpdateAsync(Driver driver);

        Task<Driver?> DeleteAsync(int id);
    }
}
