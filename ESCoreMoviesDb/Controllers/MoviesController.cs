using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovies.DTOs;
using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public MoviesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }



        // return movie by id
        [HttpGet("automapper/{id:int}")]
        public async Task<ActionResult<MovieDTO>> Get(int id)
        {
            var movieDTO = await context.Movies
                .ProjectTo<MovieDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movieDTO == null)  return NotFound(); 

            movieDTO.Cinemas = movieDTO.Cinemas.DistinctBy(x => x.Id).ToList();

            return movieDTO;
        }


        [HttpPost]
        public async Task<ActionResult> Post(MovieCreationDTO movieCreationDto)
        {
            var movie = mapper.Map<Movie>(movieCreationDto);

            // we dont want to create new genres/cinema halls
            movie.Genres.ForEach(g => context.Entry(g).State = EntityState.Unchanged);
            movie.CinemaHalls.ForEach(ch => context.Entry(ch).State = EntityState.Unchanged);

            if (movie.MoviesActors is not null)
            {
                for (int i = 0; i < movie.MoviesActors.Count; i++)
                {
                    movie.MoviesActors[i].Order = i + 1;
                }
            }
            
            context.Add(movie);
            await context.SaveChangesAsync();
            return Ok(movie);
        }





















        //prints genres with only the names
        [HttpGet("selectLoading")]
        public async Task<ActionResult> GetSelectedLoading(int id)
        {
            var movieDTO = await context.Movies.Select(m => new
            {
                Id = m.Id,
                Title = m.Title,
                Genres = m.Genres
                    .Select(g => g.Name)
                    .OrderByDescending(n => n)
                    .ToList()

            }).FirstOrDefaultAsync(m => m.Id == id);

            if (movieDTO is null) return NotFound();

            return Ok(movieDTO);
        }


        //[HttpGet("explicitLoading/{id:int}")]
        //public async Task<ActionResult<MovieDTO>> GetExplicit(int id)
        //{
        //    var movie = await context.Movies.FirstOrDefaultAsync(m=>m.Id == id);

        //    if(movie == null) return NotFound();

        //    var genresCount = await context.Entry(movie).Collection(p => p.Genres).Query().CountAsync();

        //    var movieDTO = mapper.Map<MovieDTO>(movie);

        //    return Ok(new
        //    {
        //        Id = movieDTO.Id,
        //        Title = movieDTO.Title,
        //        GenresCount = genresCount
        //    });
        //}


        //[HttpGet("lazyLoading/{id:int}")] //not recommended, performance issues
        //public async Task<ActionResult<MovieDTO>> GetLazyLoading(int id)
        //{
        //    var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);

        //    if(movie == null) return NotFound();

        //    var movieDTO = mapper.Map<MovieDTO>(movie);
        //    movieDTO.Cinemas = movieDTO.Cinemas.DistinctBy(x=>x.Id).ToList();

        //    return movieDTO;
        //}


        //[HttpGet("groupedByCinema")]
        //public async Task<ActionResult> GetGroupedByCinema()
        //{
        //    var groupedMovies = await context.Movies.GroupBy(m => m.InCinemas).Select(g => new
        //    {
        //        InCinemas = g.Key,
        //        Count = g.Count(),
        //        Movies = g.ToList()

        //    }).ToListAsync();

        //    return Ok(groupedMovies);
        //} 


        //[HttpGet("groupedByGenresCount")]
        //public async Task<ActionResult> GetGroupedByGenresCount()
        //{
        //    var groupedMovies = await context.Movies.GroupBy(m => m.Genres.Count()).Select(g => new
        //    {
        //        Count = g.Key,
        //        Titles = g.Select(m=>m.Title),
        //        Genres = g.Select(m=>m.Genres).SelectMany(a=>a).Select(ge=>ge.Name).Distinct()

        //    }).ToListAsync();

        //    return Ok(groupedMovies);
        //}

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> Filter([FromQuery] MovieFilterDTO movieFilterDto)
        {
            var moviesQueryable = context.Movies.AsQueryable();

            if (!string.IsNullOrEmpty(movieFilterDto.Title))
            {
                moviesQueryable = moviesQueryable.Where(m => m.Title.Contains(movieFilterDto.Title));
            }

            if (movieFilterDto.GenreId != 0)
            {
                moviesQueryable = moviesQueryable
                    .Where(m => m.Genres
                        .Select(g => g.Id)
                        .Contains(movieFilterDto.GenreId));
            }

            if (movieFilterDto.InCinemas)
            {
                moviesQueryable = moviesQueryable.Where(m => m.InCinemas);
            }

            if (movieFilterDto.UpcomingReleases)
            {
                var today = DateTime.Today;
                moviesQueryable = moviesQueryable.Where(m => m.ReleaseDate > today);
            }

            var movies = await moviesQueryable.Include(m => m.Genres).ToListAsync();
            return mapper.Map<List<MovieDTO>>(movies);
        }
    }
}
