using AutoMapper;
using Crayon.TechExercise.CloudSales.Api.Responses;
using Crayon.TechExercise.CloudSales.Application.Customer.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Crayon.TechExercise.CloudSales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [Route("accounts/{customerId}")]
        public async Task<IActionResult> GetAccountsByCustomer(int customerId)
        {
            try
            {
                var result = await mediator.Send(new AccountsByCustomerQuery(customerId));
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
