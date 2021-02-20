using FitnessAppWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessAppWebAPI.Services
{
    public class MuscleGroupService
    {
        public bool MuscleGroupItemExists(int id) => Context.MuscleGroup.Any(e => e.IdGroup == id);
        private improvedfitnessappContext Context { get; }

        public MuscleGroupService(improvedfitnessappContext context)
        {
            Context = context;
        }

        public IQueryable<MuscleGroups> ListMuscleGroups()
        {
            return Context.MuscleGroup;
        }
        public async Task<MuscleGroups> GetGroupById(int id)
        {
            var muscleGroupItem = await Context.MuscleGroup.FindAsync(id);
            return muscleGroupItem;
        }
        public async Task Add(MuscleGroups group)
        {
            await Context.AddAsync(group);
            await Context.SaveChangesAsync();
        }

        public async Task<MuscleGroups> Update(MuscleGroups group)
        {
            var dbGroup = await Context.MuscleGroup.Where(dbG => dbG.IdGroup == group.IdGroup).SingleOrDefaultAsync();
            if (dbGroup == null) return null;

            Context.Entry(dbGroup).CurrentValues.SetValues(group);
            await Context.SaveChangesAsync();

            return dbGroup;
        }
        public async Task Delete(int id)
        {
            var muscleGroupItem = await Context.MuscleGroup.FindAsync(id);
            Context.MuscleGroup.Remove(muscleGroupItem);
            await Context.SaveChangesAsync();
        }

    }
}
