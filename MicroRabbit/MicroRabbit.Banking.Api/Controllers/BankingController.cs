using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Api.Controllers
{
    /*    [ApiController]
        [Route("api/[controller]")]*/

    /// <summary>
    /// A controller responsible for banking operations.
    /// </summary>
    [Route("api/banking")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class BankingController : ControllerBase
    {

        private readonly ILogger<BankingController> _logger;
        private readonly IAccountService _accountService;

        /// <summary>
        /// Creates a new instance of <see cref="BankingController"/>.
        /// </summary>
        /// <param name="accountService">A service that performs operations in bank accounts.</param>
        public BankingController(ILogger<BankingController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        //GET api/banking
        /*[HttpGet]*/

        /// <summary>
        /// Retrieves a list of all the available accounts.
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet("accounts")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(IEnumerable<Account>))]
        public ActionResult<IEnumerable<Account>> Get()
        {
            return Ok(_accountService.GetAccounts());
        }

        /*[HttpPost]*/
        /// <summary>
        /// Transfers funds between two specified accounts.
        /// </summary>
        /// <param name="request">A model that contains information about the transfer of funds.</param>
        /// <response code="200">OK</response>
        [HttpPost("accounts/transfer-funds")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(void))]
        public IActionResult Post([FromBody] AccountTransfer accountTransfer)
        {
            _accountService.Transfer(accountTransfer);
            return Ok(accountTransfer);
        }
    }
}
