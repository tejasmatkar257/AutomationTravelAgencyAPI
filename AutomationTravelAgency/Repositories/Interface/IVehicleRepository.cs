using AutomationTravelAgency.Models.Domain;

namespace AutomationTravelAgency.Repositories.Interface
{
    public interface IVehicleRepository
    {
        Task<Vehicle> CreateAsync(Vehicle vehicle);
        Task<IEnumerable<Vehicle>> GetAllAsync();

        Task<Vehicle?> GetById(int id);

        Task<Vehicle?> UpdateAsync(Vehicle vehicle);

        Task<Vehicle?> DeleteAsync(int id);
    }
}
