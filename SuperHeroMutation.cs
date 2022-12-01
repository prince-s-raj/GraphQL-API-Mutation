using GraphQLAPI;
using GraphQL;
using GraphQLAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLAPI
{
    public class SuperHeroMutation
    {
        //CRUD ***********ADD operaion
        [GraphQLName("AddSuperHero")]
        [UseDbContext(typeof(SuperHeroDbContext))]
        public async Task<Superhero> AddSuperHero(AddSuperHero input,
            [ScopedService] SuperHeroDbContext context, CancellationToken token)
        {
            var superHero = new Superhero
            {
                Id = Guid.NewGuid(),
                Name = input.Name,
                Description = input.Description,
                Height = input.Height,
                Superpowers = input.Superpowers,
                Movies = input.Movies
            };
            await context.Superheroes.AddAsync(superHero,token);
            await context.SaveChangesAsync(token);
            return superHero;
        }

       

        //CRUD ***********Update operaion
        [GraphQLName("UpdateSuperHero")]
        [UseDbContext(typeof(SuperHeroDbContext))]

        public async Task<Superhero> UpdateSuperHero(Superhero input,
            [ScopedService] SuperHeroDbContext context, CancellationToken token)
        {
            var superHero = await context.Superheroes.FindAsync(input.Id);
            if(superHero is not null)
            {
                superHero.Name = input.Name;
                superHero.Description = input.Description;
                superHero.Height = input.Height;
                superHero.Superpowers = input.Superpowers;
                superHero.Movies = input.Movies;
            }
            else
            {
                return null;
            }
            context.Superheroes.Update(superHero);
            await context.SaveChangesAsync(token);
            return superHero;
        }

        //CRUD ***********Delete operaion
        [GraphQLName("DeleteSuperHero")]
        [UseDbContext(typeof(SuperHeroDbContext))]

        public async Task<Superhero> DeleteSuperHero(Superhero input,
            [ScopedService] SuperHeroDbContext context, CancellationToken token)
        {
            var superHero = await context.Superheroes.FindAsync(input.Id);
            if(superHero!= null)
            {
                context.Superheroes.Remove(superHero);
            }
            else
            {
                return null;
            }
            await context.SaveChangesAsync(token);
            return superHero;

        }
        //CRUD ***********Get operaion
        [GraphQLName("GetSuperHero")]
        [UseDbContext(typeof(SuperHeroDbContext))]

        public async Task<Superhero> GetSuperHero(SuperHeroDbContext context)
        {
            return Ok(await context.Superheroes.ToListAsync());
            

        }


    }
}
