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
    [Route ("api/")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private IAccountRepo repo;
        public AccountsController(IAccountRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet("accounts")]
        
        public ActionResult<IEnumerable<AccountDTO>> GetAllAccounts()
        {
            var allAccounts = repo.GetAllAccounts();
            {
                if (allAccounts == null) { return StatusCode(StatusCodes.Status500InternalServerError, new { status = false, message = "No Record Found." }); }
            }
            return Ok(new { status = true, data = allAccounts });
        }

        [HttpGet("accounts/{Id}")]
        
        public ActionResult <AccountDTO> GetAllAccountById( int Id)
        {
            var account = repo.GetAccountById(Id);
            {
                if (account == null) { return StatusCode(StatusCodes.Status500InternalServerError, new { status = false, message = "No Record Found." }); }
            }
            return Ok(new { status = true, data = account });
        }

        [HttpPut("accounts/{id}")]
        public IActionResult UpdateAccount(int accountId, [FromBody] AccountDTO model)
        {

           var response = repo.UpdateAccount(accountId, model);
            if (response) return Ok(new { status = true,  data = response });
            return StatusCode(StatusCodes.Status500InternalServerError, new { status = false, message = "Error updating record." });
        }

        [HttpPost("accounts")]
        public IActionResult CreateAccount([FromBody] AccountDTO model)
        {
            
            var accountCreated = repo.CreateAccount(model);

            //check if not null and return success message
            if (accountCreated)
                return Ok(new { status = true, message = "Account created successfully."});

            return StatusCode(StatusCodes.Status500InternalServerError, new { status = false, message = "Error creating record." });
        }

        [HttpDelete("accounts/{accountId}")]
        public ActionResult DeleteAccount(int accountId)
        {
            var User = repo.DeleteAccount(accountId);
            {
                if (User == false) { return StatusCode(StatusCodes.Status500InternalServerError, new { status = false, message = "Error deleting Record." }); }
            }
            return Ok(new { status = true, data = User });
        }
    }
}
