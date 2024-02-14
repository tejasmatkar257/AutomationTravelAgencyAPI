using AutomationTravelAgency.Data;
using AutomationTravelAgency.Models.Domain;
using AutomationTravelAgency.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace AutomationTravelAgency.Repositories.Implementation
{
    public class DriverRepository:IDriverRepository
    {
        private readonly ApplicationDbContext dbContext;

        public DriverRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Driver> CreateAsync(Driver driver)
        {
            await dbContext.Driver.AddAsync(driver);
            await dbContext.SaveChangesAsync();

            return driver;
        }

        public async Task<IEnumerable<Driver>> GetAllAsync()
        {
            return await dbContext.Driver.ToListAsync();
        }
        public async Task<Driver?> GetById(int id)
        {
            return await dbContext.Driver.FirstOrDefaultAsync(d => d.DriverId == id);
        }

        public async Task<Driver?> UpdateAsync(Driver driver)
        {
            dbContext.Entry(driver).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
                return driver;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DriverExists(driver.DriverId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Driver?> DeleteAsync(int id)
        {
            var driver = await dbContext.Driver.FindAsync(id);
            if (driver == null)
            {
                return null;
            }

            dbContext.Driver.Remove(driver);
            await dbContext.SaveChangesAsync();

            return driver;
        }

        private async Task<bool> DriverExists(int id)
        {
            return await dbContext.Driver.AnyAsync(d => d.DriverId == id);
        }
    }
}

