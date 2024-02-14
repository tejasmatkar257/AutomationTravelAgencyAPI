using AutomationTravelAgency.Models.Domain;
using AutomationTravelAgency.Models.DTO;
using AutomationTravelAgency.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutomationTravelAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverRepository driverRepository;

        public DriverController(IDriverRepository driverRepository)
        {
            this.driverRepository = driverRepository;
        }
        /* public async Task<ActionResult<IEnumerable<Driver>>> GetAllDrivers()
         {
             var drivers = await driverRepository.GetAllAsync();
             return Ok(drivers);
         }
        */
        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            var drivers = await driverRepository.GetAllAsync();

            // Map Domain model to DTO

            var response = new List<DriverDto>();
            foreach (var driver in drivers)
            {
                response.Add(new DriverDto
                {
                    DriverId = driver.DriverId,
                    DriverName = driver.DriverName,
                    DriverAddress = driver.DriverAddress,
                    DriverContact = driver.DriverContact,
                    DriverLicenseNumber = driver.DriverLicenseNumber
                });
            }

            return Ok(response);
        }
        //
        [HttpPost]
        public async Task<IActionResult> CreateDriver(CreateDriverRequestDto request)
        {
            //Map DTO to Domain Model
            var driver = new Driver
            {
                DriverName = request.DriverName,
                DriverAddress = request.DriverAddress,
                DriverContact = request.DriverContact,
                DriverLicenseNumber = request.DriverLicenseNumber
            };

            await driverRepository.CreateAsync(driver);

            //Domain model to DTO
            var response = new DriverDto
            {
                DriverId = driver.DriverId,
                DriverName = driver.DriverName,
                DriverAddress = driver.DriverAddress,
                DriverContact = driver.DriverContact,
                DriverLicenseNumber = driver.DriverLicenseNumber

            };

            return Ok(driver);
        }

        //
        [HttpGet("{DriverId}")]
        public async Task<ActionResult<Driver>> GetDriverById(int DriverId)
        {
            var driver = await driverRepository.GetById(DriverId);
            if (driver == null)
            {
                return NotFound();
            }
            return driver;
        }

        [HttpPut("{DriverId}")]
        public async Task<IActionResult> UpdateDriver(int DriverId, CreateDriverRequestDto request)
        {
            var driver = new Driver
            {
                DriverId = DriverId,
                DriverName = request.DriverName,
                DriverAddress = request.DriverAddress,
                DriverContact = request.DriverContact,
                DriverLicenseNumber = request.DriverLicenseNumber
            };

            await driverRepository.UpdateAsync(driver);

            if (driver == null)
            {
                return NotFound();
            }

            //Domain model to DTO
            var response = new DriverDto
            {
                DriverId = driver.DriverId,
                DriverName = driver.DriverName,
                DriverAddress = driver.DriverAddress,
                DriverContact = driver.DriverContact,
                DriverLicenseNumber = driver.DriverLicenseNumber

            };

            return Ok(response);

        }

        [HttpDelete("{DriverId}")]
        public async Task<ActionResult<Driver>> DeleteDriver(int DriverId)
        {
            var deletedDriver = await driverRepository.DeleteAsync(DriverId);
            if (deletedDriver == null)
            {
                return NotFound();
            }

            return deletedDriver;
        }
    }
}
