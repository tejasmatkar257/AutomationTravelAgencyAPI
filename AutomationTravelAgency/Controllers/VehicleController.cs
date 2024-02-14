using AutomationTravelAgency.Data;
using AutomationTravelAgency.Models.Domain;
using AutomationTravelAgency.Models.DTO;
using AutomationTravelAgency.Repositories.Implementation;
using AutomationTravelAgency.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AutomationTravelAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }
        /* public async Task<ActionResult<IEnumerable<Vehicle>>> GetAllVehicles()
         {
             var vehicles = await vehicleRepository.GetAllAsync();
             return Ok(vehicles);
         }
        */
        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            var vehicles = await vehicleRepository.GetAllAsync();

            // Map Domain model to DTO

            var response = new List<VehicleDto>();
            foreach (var vehicle in vehicles)
            {
                response.Add(new VehicleDto
                {
                    VehicleId = vehicle.VehicleId,
                    VehicleName = vehicle.VehicleName,
                    VehicleNumber = vehicle.VehicleNumber,
                    VehicleType = vehicle.VehicleType,
                    SeatingCapacity = vehicle.SeatingCapacity,
                    FarePerKm = vehicle.FarePerKm
                });
            }

            return Ok(response);
        }
        //
        [HttpPost]
        public async Task<IActionResult> CreateVehicle(CreateVehicleRequestDto request)
        {
            //Map DTO to Domain Model
            var vehicle = new Vehicle
            {
                VehicleName = request.VehicleName,
                VehicleNumber = request.VehicleNumber,
                VehicleType = request.VehicleType,
                SeatingCapacity = request.SeatingCapacity,
                FarePerKm = request.FarePerKm
            };

            await vehicleRepository.CreateAsync(vehicle);

            //Domain model to DTO
            var response = new VehicleDto
            {
                VehicleId = vehicle.VehicleId,
                VehicleName = vehicle.VehicleName,
                VehicleNumber = vehicle.VehicleNumber,
                VehicleType = vehicle.VehicleType,
                SeatingCapacity = vehicle.SeatingCapacity,
                FarePerKm = vehicle.FarePerKm

            };

            return Ok(vehicle);
        }

        //
        [HttpGet("{VehicleId}")]
        public async Task<ActionResult<Vehicle>> GetVehicleById(int VehicleId)
        {
            var vehicle = await vehicleRepository.GetById(VehicleId);
            if (vehicle == null)
            {
                return NotFound();
            }
            return vehicle;
        }

        [HttpPut("{VehicleId}")]
        public async Task<IActionResult> UpdateVehicle(int VehicleId, CreateVehicleRequestDto request)
        {
            var vehicle = new Vehicle
            {
                VehicleId=VehicleId,
                VehicleName = request.VehicleName,
                VehicleNumber = request.VehicleNumber,
                VehicleType = request.VehicleType,
                SeatingCapacity = request.SeatingCapacity,
                FarePerKm = request.FarePerKm
            };

            await vehicleRepository.UpdateAsync(vehicle);

            if (vehicle == null)
            {
                return NotFound();
            }

            //Domain model to DTO
            var response = new VehicleDto
            {
                VehicleId = vehicle.VehicleId,
                VehicleName = vehicle.VehicleName,
                VehicleNumber = vehicle.VehicleNumber,
                VehicleType = vehicle.VehicleType,
                SeatingCapacity = vehicle.SeatingCapacity,
                FarePerKm = vehicle.FarePerKm

            };

            return Ok(response);

        }

        [HttpDelete("{VehicleId}")]
        public async Task<ActionResult<Vehicle>> DeleteVehicle(int VehicleId)
        {
            var deletedVehicle = await vehicleRepository.DeleteAsync(VehicleId);
            if (deletedVehicle == null)
            {
                return NotFound();
            }

            return deletedVehicle;
        }


    }
}
