using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IList<Activity>>> GetActivitities()
        {
            var result = await Mediator.Send(new List.Query());
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivitityById(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id } );
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity([FromBody] Activity activity)
        {
            var result = await Mediator.Send(new Create.Command { Activity = activity });
            return Ok(result);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> EditActivity(Guid id, [FromBody] Activity activity)
        {
            activity.Id = id;
            var result = await Mediator.Send(new Edit.Command { Activity = activity });
            return Ok(result);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            var result = await Mediator.Send(new Delete.Command { Id = id });
            return Ok(result);
        }

    }
}