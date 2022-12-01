using GraphQLAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLAPI
{

    public class SuperPowerMutation
    {

        //CRUD ***********ADD operaion
        [GraphQLName("AddSuperPower")]
        [UseDbContext(typeof(SuperHeroDbContext))]
        public async Task<Superpower> AddSuperPower(AddSuperPower input,
            [ScopedService] SuperHeroDbContext context, CancellationToken token)
        {
            var superPower = new Superpower
            {
                SuperheroId = Guid.NewGuid(),
                SuperPower = input.SuperPower,
                Description = input.Description,
                Superhero = input.Superhero

            };
            await context.Superpowers.AddAsync(superPower, token);
            await context.SaveChangesAsync(token);
            return superPower;
        }

      

        //CRUD ***********Update operaion
        [GraphQLName("UpdateSuperPower")]
        [UseDbContext(typeof(SuperHeroDbContext))]

        public async Task<Superpower> UpdateSuperPower(Superpower input,
            [ScopedService] SuperHeroDbContext context, CancellationToken token)
        {
            var superPower = await context.Superpowers.FindAsync(input.SuperheroId);
            if (superPower is not null)
            {
                superPower.SuperPower = input.SuperPower;
                superPower.Description = input.Description;
                superPower.Superhero = input.Superhero;
            }
            else
            {
                return null;
            }
            context.Superpowers.Update(superPower);
            await context.SaveChangesAsync(token);
            return superPower;
        }

        //CRUD ***********Delete operaion
        [GraphQLName("DeleteSuperPower")]
        [UseDbContext(typeof(SuperHeroDbContext))]

        public async Task<Superhero> DeleteSuperPower(SuperPower input,
            [ScopedService] SuperHeroDbContext context, CancellationToken token)
        {
            var superPower = await context.Superpowers.FindAsync(input.SuperheroId);
            if (superPower != null)
            {
                context.Superpowers.Remove(superPower);
                await context.SaveChangesAsync(token);
               
            }
            else
            {
                return null;
            }
            return null;

        }
        //CRUD ***********Get operaion
        [GraphQLName("GetSuperPower")]
        [UseDbContext(typeof(SuperHeroDbContext))]

        public async Task<SuperPower> GetSuperPower(SuperHeroDbContext context)
        {
            return Ok(await context.Superheroes.ToListAsync());
            

        }

    }
}
