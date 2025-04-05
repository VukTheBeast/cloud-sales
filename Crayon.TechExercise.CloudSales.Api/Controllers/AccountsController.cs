using AutoMapper;
using Crayon.TechExercise.CloudSales.Api.Responses;
using Crayon.TechExercise.CloudSales.Application.Account.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Crayon.TechExercise.CloudSales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            try
            {
                var result = await mediator.Send(new ListAllAccountsQuery());
                return Ok(mapper.Map<IEnumerable<AccountResponse>>(result));
            }
            catch (NullReferenceException ex)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
