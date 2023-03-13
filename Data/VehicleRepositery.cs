using CarSales.Core;
using CarSales.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSales.Data
{
    public class VehicleRepositery : IVehicleRepositery
    {
        private readonly CarsDbContext context;

        public VehicleRepositery(CarsDbContext context)
        {
            this.context = context;
        }
        public async Task<Vehicle> GetVehicle(int id)
        {
            return await context.Vehicles
               .Include(v => v.Features)
               .ThenInclude(vf => vf.Feature)
               .Include(v => v.Model)
               .ThenInclude(m => m.Make)
               .SingleOrDefaultAsync(v => v.Id == id);
        }

        public void Add(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
        }

        public void Remove(Vehicle vehicle)
        {
            context.Vehicles.Remove(vehicle);
        }
    }
}
