using CarSales.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CarSales.Controllers.Resources;
using CarSales.Core.Models;

namespace CarSales.Controllers
{
    public class HomeController : Controller
    {
        private readonly CarsDbContext context;
        private readonly IMapper mapper;

        public HomeController(CarsDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return Content("index");
        }
        [Route("/api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes = await context.Makes.Include(m => m.Models).ToListAsync();
            return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }
    }
}
