using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovies;
using EFCoreMovies.Entities;
using ESCoreMovies.Utilities;
using EFCoreMovies.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ESCoreMoviesDb.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public ActorsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ActorDTO>> Get()
        {
            //return await context.Genres.ToListAsync();
            return await context.Actors
                //.Select(a => new ActorDTO { Id = a.Id, Name = a.Name, DateOfBirth = a.DateOfBirth })
                .ProjectTo<ActorDTO>(mapper.ConfigurationProvider) // using imapper provider (aternate select, mist download automapper)
                .OrderBy(a => a.Name)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(ActorCreationDTO actorCreationDto)
        {
            var actor = mapper.Map<Actor>(actorCreationDto);
            context.Add(actor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(ActorCreationDTO actorCreationDto, int id)
        {
            var actorDB = await context.Actors.FirstOrDefaultAsync(p => p.Id == id);

            if (actorDB == null) return NotFound();

            actorDB = mapper.Map(actorCreationDto, actorDB);
            await context.SaveChangesAsync();
            return Ok();
        }


        //updates every column
        [HttpPut("disconnected/{id:int}")]
        public async Task<ActionResult> PutDisconnected(ActorCreationDTO actorCreationDto, int id)
        {
            var existsActor = await context.Actors.AnyAsync(p => p.Id == id);

            if (!existsActor) return NotFound();

            var actor = mapper.Map<Actor>(actorCreationDto);
            actor.Id = id;

            context.Update(actor);
            await context.SaveChangesAsync();
            return Ok();

        }
 
    }
}
