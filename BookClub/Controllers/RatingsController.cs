using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Bookclub.Models;
using BookClubApp.Services;

namespace BookClubApp.Controllers
{
    [ApiController]
    [Route("[controller]")]//URL: https://localhost:7167/
    public class RatingsController : ControllerBase
    {
        private readonly ICrudService<Rating, int> _ratingsService;
        public RatingsController(ICrudService<Rating, int> ratingsService)
        {
            _ratingsService = ratingsService;
        }

        // GET all action
        [HttpGet] // auto returns data with a Content-Type of application/json
        public ActionResult<List<Rating>> GetAll() => _ratingsService.GetAll().ToList();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Rating> Get(int id)
        {
            var rating = _ratingsService.Get(id);
            if (rating is null) return NotFound();
            else return rating;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Rating rating)
        {
            // Runs validation against model using data validation attributes
            if (ModelState.IsValid)
            {
                _ratingsService.Add(rating);
                return CreatedAtAction(nameof(Create), new { id = rating.Id }, rating);
            }
            return BadRequest();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Rating rating)
        {
            var existingRatings = _ratingsService.Get(id);
            if (existingRatings is null || existingRatings.Id != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _ratingsService.Update(existingRatings, rating);
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var rating = _ratingsService.Get(id);
            if (rating is null) return NotFound();
            _ratingsService.Delete(id);
            return NoContent();
        }

        //displaying the result of the joins function in RatinsRepository 

        //[HttpGet]
        //[Route ("info")]
        //public ActionResult<List<string>>GetInfo()
        //{
        //    return ((RatingsService)_ratingsService).GetJoinedData().ToList();
        //}
    }
}
