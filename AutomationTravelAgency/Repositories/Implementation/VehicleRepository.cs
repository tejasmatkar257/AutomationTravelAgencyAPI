using AutomationTravelAgency.Data;
using AutomationTravelAgency.Models.Domain;
using AutomationTravelAgency.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace AutomationTravelAgency.Repositories.Implementation
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext dbContext;

        public VehicleRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Vehicle> CreateAsync(Vehicle vehicle)
        {
            await dbContext.Vehicle.AddAsync(vehicle);
            await dbContext.SaveChangesAsync();

            return vehicle;
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return await dbContext.Vehicle.ToListAsync();
        }
        public async Task<Vehicle?> GetById(int id)
        {
            return await dbContext.Vehicle.FirstOrDefaultAsync(v => v.VehicleId == id);
        }

        public async Task<Vehicle?> UpdateAsync(Vehicle vehicle)
        {
            dbContext.Entry(vehicle).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
                return vehicle;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await VehicleExists(vehicle.VehicleId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Vehicle?> DeleteAsync(int id)
        {
            var vehicle = await dbContext.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return null;
            }

            dbContext.Vehicle.Remove(vehicle);
            await dbContext.SaveChangesAsync();

            return vehicle;
        }

        private async Task<bool> VehicleExists(int id)
        {
            return await dbContext.Vehicle.AnyAsync(v => v.VehicleId == id);
        }
    }
}
 