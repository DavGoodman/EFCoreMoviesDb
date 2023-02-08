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
            //return await context.Genres.ToListAsync();
            return await context.Genres/*.AsNoTracking()*/
                .OrderBy(g => g.Name)
                //.Paginate(page, recordsToTake)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(GenreCreationDTO genreCreationDto)
        {
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
