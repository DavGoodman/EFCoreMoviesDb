using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreMovies;
using EFCoreMovies.DTOs;
using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace ESCoreMoviesDb.Controllers
{
    [ApiController]
    [Route("api/cinema")]
    public class CinemasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
   
        public CinemasController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CinemaDTO>> Get()
        {
            return await context.Cinemas.ProjectTo<CinemaDTO>(mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpGet("closeToMe")]
        public async Task<ActionResult> Get(double latitude, double longitude)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            
            var myLocation = geometryFactory.CreatePoint(new Coordinate(longitude, latitude));
            
            //var maxDistanceInMeters = 2000;

            var cinemas = await context.Cinemas
                .OrderBy(c=> c.Location.Distance(myLocation))
                //.Where(c => c.Location.IsWithinDistance(myLocation, maxDistanceInMeters))
                .Select(c => new
                {
                    Name = c.Name,
                    Distance = Math.Round(c.Location.Distance(myLocation))
                })
                .ToListAsync();

             return Ok(cinemas);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetByID(int id)
        {

            var CinemaDB = await context.Cinemas
                .Include(c => c.CinemaHalls)
                .Include(c => c.CinemaOffer)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (CinemaDB == null) return NotFound();

            CinemaDB.Location = null;
            
            return Ok(CinemaDB);

        }

        [HttpPost]
        public async Task<ActionResult> Post()
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var cinemaLocation = geometryFactory.CreatePoint(new Coordinate(-69.912539, 18.476256));

            var cinema = new Cinema()
            {
                Name = "My cinema",
                Location = cinemaLocation,
                CinemaOffer = new CinemaOffer()
                {
                    DiscountPercentage = 5,
                    Begin = DateTime.Today,
                    End = DateTime.Today.AddDays(7)
                },
                CinemaHalls = new List<CinemaHall>()
                {
                    new CinemaHall()
                    {
                        Cost = 200,
                        CinemaHallType = CinemaHallType.TwoDimensions
                    },
                    new CinemaHall()
                    {
                        Cost = 250,
                        CinemaHallType = CinemaHallType.ThreeDimensions
                    }
                }
            };

            context.Add(cinema);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("withDTO")]
        public async Task<ActionResult> Post(CinemaCreationDTO cinemaCreationDto)
        {
            var cinema = mapper.Map<Cinema>(cinemaCreationDto);
            context.Add(cinema);
            await context.SaveChangesAsync();
            return Ok();
        }


        // update with related data
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(CinemaCreationDTO cinemaCreationDto, int id)
        {
            var CinemaDB = await context.Cinemas
                .Include(c => c.CinemaHalls)
                .Include(c => c.CinemaOffer)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (CinemaDB == null) return NotFound();

            CinemaDB = mapper.Map(cinemaCreationDto, CinemaDB);
            await context.SaveChangesAsync();
            return Ok();

        }

    }
}
