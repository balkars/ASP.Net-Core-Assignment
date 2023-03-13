﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarSales.Controllers.Resources;
using CarSales.Data;
using CarSales.Core.Models;

namespace CarSales.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly CarsDbContext context;
        private readonly IMapper mapper;
        public FeaturesController(CarsDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/features")]
        public async Task<IEnumerable<KeyValuePairResource>> GetFeatures()
        {
            var features = await context.Features.ToListAsync();

            return mapper.Map<List<Feature>, List<KeyValuePairResource>>(features);
        }
    }
}