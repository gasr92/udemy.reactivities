using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;

        public ActivitiesController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IList<Activity>>> GetActivitities()
        {
            var result = await _context.Activities.ToListAsync();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivitityById(Guid id)
        {
            var result = await _context.Activities.FindAsync(id);
            return result;
        }
    }
}