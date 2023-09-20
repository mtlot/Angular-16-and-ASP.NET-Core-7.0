using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransactionAPI.Models;

namespace TransactionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  // This attribute helps with automatic model state validation
    public class GroupController : Controller
    {
        private readonly IGroupRepository groupRepository;

        public Group updatedGroup { get; private set; }

        public GroupController(IGroupRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(groupRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetGroupWithEvents(int id)
        {

            var group = groupRepository.GetGroupWithEvents(id);

            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);

        }
        [HttpPost]
        public IActionResult Post([FromBody] Group group)
        {
            if (group == null)
            {
                return BadRequest("Group cannot be null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Optional: Check for duplicates
                var existingGroup = groupRepository.GetByName(group.Name); // Assuming GetByName is a method in your repository
                if (existingGroup != null)
                {
                    return BadRequest("Group with the same name already exists.");
                }

                var createdGroup = groupRepository.Add(group);
                return CreatedAtAction(nameof(GetById), new { id = createdGroup.Id }, createdGroup);
            }
            catch (Exception ex)  // Catch exceptions for logging or additional processing
            {
                // Log exception (if needed)
                return StatusCode(500, "Internal server error");
            }
        }

        private object GetById()
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Group group)
        {
            if (id == group.Id)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var Group = groupRepository.Update(updatedGroup);
                if (Group == null) return NotFound();  // If the group doesn't exist in the database
                return Ok(Group);
            }

            return BadRequest();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (groupRepository.GetById(id) == null)
            {
                return NotFound();
            }

            groupRepository.Delete(id);
            return NoContent();
        }
    }
}
