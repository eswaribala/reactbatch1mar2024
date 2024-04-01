using Microsoft.EntityFrameworkCore;
using PolicyAPI.Contexts;
using PolicyAPI.Models;

namespace PolicyAPI.Repositories
{
    public class VehicleRepo:IVehicleRepo
    {
        private PolicyContext _dbContext;

        public VehicleRepo(PolicyContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Vehicle> AddVehicle(Vehicle Vehicle)
        {
            var result = await this._dbContext.Vehicles.AddAsync(Vehicle);
            await this._dbContext.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<bool> DeleteVehicle(string registrationNo)
        {
            bool Status = false;
            var result = await IsVehicleExists(registrationNo);
            if (result != null)
            {
                this._dbContext.Vehicles.Remove(result);
                await this._dbContext.SaveChangesAsync();
                Status = true;
            }

            return Status;

        }


        private async Task<Vehicle> IsVehicleExists(string registrationNo)
        {

            return await this._dbContext.Vehicles.FirstOrDefaultAsync(v => v.RegistrationNo == registrationNo);

        }


        public async Task<IEnumerable<Vehicle>> GetAllVehicles()
        {
            return await this._dbContext.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> GetVehicle(string registrationNo)
        {
            return await IsVehicleExists(registrationNo);
        }

    }
}
