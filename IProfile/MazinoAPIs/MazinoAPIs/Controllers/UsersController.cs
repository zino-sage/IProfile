using MazinoAPIs.DTOs;
using MazinoAPIs.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MazinoAPIs.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRep repo;
        public UsersController(IUserRep repo)
        {
            this.repo = repo;
        }

        [HttpGet("users")]

        public ActionResult<IEnumerable<UserDTO>> GetAllUsers()
        {
            var allUsers = repo.GetAllUsers();
            {
                if (allUsers == null) { return StatusCode(StatusCodes.Status500InternalServerError, new { status = false, message = "No Record Found." }); }
            }
            return Ok(new { status = true, data = allUsers });
        }

        [HttpGet("accounts/{accountId}/users/{userId}")]
        public ActionResult<UserDTO> GetAllUserById(int accountId, int userId)
        {
            var User = repo.GetUserById(accountId, userId);
            {
                if (User == null) { return StatusCode(StatusCodes.Status500InternalServerError, new { status = false, message = "No Record Found." }); }
            }
            return Ok(new { status = true, data = User });
        }

        [HttpPut("accounts/{accountId}/users/{userId}")]
        public IActionResult UpdateUser(int accountId, int UserId, [FromBody] UserDTO model)
        {

            var response = repo.UpdateUser(accountId, UserId, model);
            if (response) return Ok(new { status = true, data = response });
            return StatusCode(StatusCodes.Status500InternalServerError, new { status = false, message = "Error updating record." });
        }

        [HttpPost("accounts/{id}/users")]
        public IActionResult CreateUser(int id, [FromBody] UserDTO model)
        {

            var UserCreated = repo.CreateUser(id, model);

            //check if not null and return success message
            if (UserCreated)
                return Ok(new { status = true, message = "User created successfully." });

            return StatusCode(StatusCodes.Status500InternalServerError, new { status = false, message = "Error creating record." });
        }

        [HttpGet("accounts/{id}/users")]
        public ActionResult<UserDTO> GetAllUserByAccountId(int Id)
        {
            var User = repo.GetUserByAccountId(Id);
            {
                if (User == null) { return StatusCode(StatusCodes.Status500InternalServerError, new { status = false, message = "No Record Found." }); }
            }
            return Ok(new { status = true, data = User });
        }

        [HttpDelete("accounts/{accountId}/users/{userId}")]
        public ActionResult DeleteUser(int accountId, int userId)
        {
            var User = repo.DeleteUser(accountId, userId);
            {
                if (User == false) { return StatusCode(StatusCodes.Status500InternalServerError, new { status = false, message = "Error deleting Record." }); }
            }
            return Ok(new { status = true, data = User });
        }
    }
}
