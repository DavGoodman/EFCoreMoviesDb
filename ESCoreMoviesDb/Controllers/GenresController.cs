using AutoMapper;
using EFCoreMovies;
using EFCoreMovies.DTOs;
using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ESCoreMovies.Utilities;

namespace ESCoreMoviesDb.Controllers
{

    [ApiController]
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public GenresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Genre>> Get(/*int page = 1, int recordsToTake = 2*/)
        {
            context.Logs.Add(new Log { Message = "Executing Get from GenresController" });
            await context.SaveChangesAsync();

            //return await context.Genres.ToListAsync();
            return await context.Genres/*.AsNoTracking()*/
                .OrderByDescending(g => EF.Property<DateTime>(g, "CreatedDate"))
                //.Paginate(page, recordsToTake)
                .ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genre>> Get(int id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(p => p.Id == id);
            if (genre is null) return NotFound();

            var createdDate = context.Entry(genre).Property<DateTime>("CreatedDate").CurrentValue;
            return Ok(new
            {
                Id = genre.Id,
                Name = genre.Name,
                CreatedDate = createdDate
            });
        }

        [HttpPost]
        public async Task<ActionResult> Post(GenreCreationDTO genreCreationDto)
        {
            var genreExists = await context.Genres.AnyAsync(g => g.Name == genreCreationDto.Name);
            if (genreExists)
            {
                return BadRequest($"The genre with the name {genreCreationDto.Name} already exists");
            } 

            var genre = mapper.Map<Genre>(genreCreationDto);

            context.Add(genre); // marking genre as added
            await context.SaveChangesAsync();

            return Ok(genre);
        }
        
        [HttpPost("several")]
        public async Task<ActionResult> PostMany(GenreCreationDTO[] genresDTO)
        {
            var genres = mapper.Map<Genre[]>(genresDTO);
            context.AddRange(genres);
            await context.SaveChangesAsync();

            return Ok();
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(p=>p.Id == id);

            if (genre is null) return NotFound();

            context.Remove(genre);
            await context.SaveChangesAsync();
            return Ok();
        }

        // must apply config to GenresConfig to work
        [HttpDelete("softDelete/{id:int}")]
        public async Task<ActionResult> SoftDelete(int id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(p => p.Id == id);

            if (genre is null) return NotFound();

            genre.IsDeleted = true;
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpPost("restore/{id:int}")]
        public async Task<ActionResult> Restore(int id)
        {
            var genre = await context.Genres.IgnoreQueryFilters().FirstOrDefaultAsync(p => p.Id == id);

            if (genre is null) return NotFound();

            genre.IsDeleted = false;
            await context.SaveChangesAsync();
            return Ok();
        }







        //[HttpGet("filter")]
        //public async Task<IEnumerable<Genre>> Filter(string name)
        //{
        //    return await context.Genres.Where(g => g.Name.Contains(name)).ToListAsync();
        //}
    } 

}
