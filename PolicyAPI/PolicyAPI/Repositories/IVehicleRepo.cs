using PolicyAPI.Models;

namespace PolicyAPI.Repositories
{
    public interface IVehicleRepo
    {

        Task<Vehicle> AddVehicle(Vehicle Vehicle);
        Task<bool> DeleteVehicle(string registrationNo);
        Task<Vehicle> GetVehicle(string registrationNo);
        Task<IEnumerable<Vehicle>> GetAllVehicles();

    }
}
