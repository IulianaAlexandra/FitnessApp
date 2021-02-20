using FitnessAppWebAPI.Models;
using FitnessAppWebAPI.Services;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace FitnessAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuscleGroupController : ControllerBase
    {
        private MuscleGroupService MuscleGroupService { get; }

        public MuscleGroupController(MuscleGroupService muscleGroupService)
        {
            MuscleGroupService = muscleGroupService;
        }

        [HttpGet]
        [Route("")]
        [EnableQuery]
        public IQueryable<MuscleGroups> Get()
        {
            return MuscleGroupService.ListMuscleGroups();
        }


        [HttpPost]
        [Route("add")]
        public async Task<string> Add([FromBody] MuscleGroups muscleGroup)
        {
            try
            {
                if (MuscleGroupService.MuscleGroupItemExists(muscleGroup.IdGroup))
                {
                    return "An item with the same id already exists.";
                }
                else
                {
                    await MuscleGroupService.Add(muscleGroup);
                    return "Success";
                }
            }
            catch
            {
                return "Error";
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<string> Update([FromBody] MuscleGroups muscleGroup)
        {
            var group = await MuscleGroupService.Update(muscleGroup);

            if (group == null)
            {
                return "Invalid muscle group";
            }

            return "Success";

        }
        [HttpPost]
        [Route("delete/{id}")]
        public async Task<string> Delete(int id)
        {
            try
            {
                await MuscleGroupService.Delete(id);
                return "Success";
            }
            catch
            {
                return "Invalid muscle group id";
            }

        }
    }
}
