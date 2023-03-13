using CarSales.Core.Models;

namespace CarSales.Core
{
    public interface IVehicleRepositery
    {
        Task<Vehicle> GetVehicle(int id);
        public void Add(Vehicle vehicle);
        public void Remove(Vehicle vehicle);
    }

}