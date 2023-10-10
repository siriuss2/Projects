namespace MovieApp.App.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MovieApp.DTOs.MovieDTOs;
    using MovieApp.Services.Interfaces;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService _movieService)
        {
            this._movieService = _movieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieDTO>>> GetAll()
        {
            try
            {
                return Ok(await _movieService.GetAllMoviesAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetMovie(int id)
        {
            try
            {
                if (id < 0)
                    return BadRequest("Invalid input for id");

                MovieDTO movieDTO = await _movieService.GetMovieByIdAsync(id);

                if (movieDTO == null)
                    return NotFound($"Movie with id:{id} not found");

                return Ok(movieDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateMovie([FromBody] CreateMovieDTO createMovieDTO)
        {
            try
            {
                if(createMovieDTO == null)
                    return BadRequest("The movie can not be null");

                if(string.IsNullOrEmpty(createMovieDTO.Description) || createMovieDTO.Genre <= 0 ||
                    string.IsNullOrEmpty(createMovieDTO.Year) || string.IsNullOrEmpty(createMovieDTO.Title))
                    return BadRequest("You need to enter all of the params");

                await _movieService.CreateMovieAsync(createMovieDTO);

                return StatusCode(StatusCodes.Status201Created, "Movie created!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team");
            }
        }

        [HttpPatch]
        public async Task<IActionResult> EditMovie([FromBody] EditMovieDTO editMovieDTO)
        {
            try
            {
                if(editMovieDTO == null)
                    return BadRequest("Invalid input");

                if (editMovieDTO.Id <= 0)
                    return BadRequest("Invalid Id.Please try again");

                await _movieService.EditMovieAsync(editMovieDTO);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid input for id");

                MovieDTO movieDTO = await _movieService.GetMovieByIdAsync(id);

                if (movieDTO == null)
                    return NotFound("Movie not found!");

                await _movieService.DeleteMovieAsync(movieDTO.Id);

                return Ok("Deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team");
            }
        }
    }
}
