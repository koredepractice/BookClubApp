using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Bookclub.Models;
using BookClubApp.Services;

namespace BookClubApp.Controllers
{
    [ApiController]
    [Route("[controller]")]//URL: https://localhost:7167
    public class MembersController : ControllerBase
    {
        private readonly ICrudService<Member, int> _membersService;
        public MembersController(ICrudService<Member, int> membersService)
        {
            _membersService = membersService;
        }

        // GET all action
        [HttpGet] // auto returns data with a Content-Type of application/json
        public ActionResult<List<Member>> GetAll() => _membersService.GetAll().ToList();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Member> Get(int id)
        {
            var member = _membersService.Get(id);
            if (member is null) return NotFound();
            else return member;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Member member)
        {
            // Runs validation against model using data validation attributes
            if (ModelState.IsValid)
            {
                _membersService.Add(member);
                return CreatedAtAction(nameof(Create), new { id = member.MemberId }, member);
            }
            return BadRequest();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Member member)
        {
            var existingMembers = _membersService.Get(id);
            if (existingMembers is null || existingMembers.MemberId != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _membersService.Update(existingMembers, member);
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var member = _membersService.Get(id);
            if (member is null) return NotFound();
            _membersService.Delete(id);
            return NoContent();
        }
    }
}
