using AutoMapper;
using Crayon.TechExercise.CloudSales.Api.Responses;
using Crayon.TechExercise.CloudSales.Application.CloudServiceProvider.Commands;
using Crayon.TechExercise.CloudSales.Application.CloudServiceProvider.Queries;
using Crayon.TechExercise.CloudSales.Application.PurchasedSoftware.Commands;
using Crayon.TechExercise.CloudSales.Application.PurchasedSoftware.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Crayon.TechExercise.CloudSales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwaresController(IMediator mediator, IMapper mapper, ILogger<SoftwaresController> logger) : ControllerBase
    {
        [HttpGet]
        [Route("available")]
        public async Task<IActionResult> GetAvailableSoftwaresService()
        {
            var result = await mediator.Send(new GetAvailableSoftwareServicesQuery());

            if (!result.Any())
            {
                return NotFound();
            }

            return Ok(mapper.Map<IEnumerable<SoftwareServiceResponse>>(result));
        }

        [HttpPost]
        [Route("available/order")]
        public async Task<IActionResult> OrderSoftwaresService(int accountId, int softwareServiceId, int quantity)
        {
            try
            {
                await mediator.Send(new OrderSoftwareServiceCommand(accountId, softwareServiceId, quantity));
            }
            catch (Exception ex)
            {
                logger.LogError("Order software service failed for {accountId}, {softwareServiceId} and {quantity}", accountId, softwareServiceId, quantity);
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpGet]
        [Route("purchased")]
        public async Task<IActionResult> GetPurchasedSoftware(int accountId)
        {
            var result = await mediator.Send(new GetPurchasedSoftwaresByAccountQuery(accountId));
            
            if(!result.Any())
            {
                return NotFound();
            }

            return Ok(mapper.Map<IEnumerable<PurchasedSoftwareResponse>>(result));
        }

        [HttpPost("purchased/change-quantity")]
        public async Task<IActionResult> ChangeQuantity(int id, int newQuantity)
        {
            try
            {
                await mediator.Send(new ChangePurchasedSoftwareQuantityCommand(id, newQuantity));
            }
            catch (Exception ex)
            {
                logger.LogError("Change quantity for purchased software {id} failed for setting {newQuantity}", id, newQuantity);
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost("purchased/cancel")]
        public async Task<IActionResult> Cancel(int id)
        {
            try
            {
                await mediator.Send(new CancelPurchasedSoftwareCommand(id));
            }
            catch (Exception ex)
            {
                logger.LogError("Cancel purchased software failed for {id}", id);
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost("purchased/extend")]
        public async Task<IActionResult> Extend(int id, DateTime newLicenseDate)
        {
            try
            {
                await mediator.Send(new ExtendPurchasedSoftwareValidityCommand(id, newLicenseDate));
            }
            catch (Exception ex)
            {
                logger.LogError("Extend purchased software failed for {id} with {newLicenseDate}", id, newLicenseDate);
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
