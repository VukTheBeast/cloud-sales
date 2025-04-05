using Crayon.TechExercise.CloudSales.Application.Account;
using Crayon.TechExercise.CloudSales.Application.PurchasedSoftware;
using FluentValidation;
using MediatR;

namespace Crayon.TechExercise.CloudSales.Application.CloudServiceProvider.Commands
{
    public record OrderSoftwareServiceCommand(int accountId, int softwareServiceId, int quantity) : IRequest;
    public class OrderSoftwareServiceCommandHandler(
        IValidator<OrderSoftwareServiceCommand> validator,
        ICcpClient ccpClient, 
        IAccountRepository accountRepository,
        IPurchasedSoftwareRepository purchasedSoftwareRepository) 
        : IRequestHandler<OrderSoftwareServiceCommand>
    {
        public async Task Handle(OrderSoftwareServiceCommand request, CancellationToken cancellationToken)
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var availableSoftwareListService = await ccpClient.GetSoftwareListAsync();
            var orderSoftwareService = availableSoftwareListService
                                        .FirstOrDefault(s => s.Id == request.softwareServiceId);

            if (orderSoftwareService == null)
            {
                throw new Exception($"Order available service failed. Order service not found for softwareId: {request.softwareServiceId} for accountId: {request.accountId}");
            }

            var account = await accountRepository.GetAccount(request.accountId);

            if (account == null) 
            {
                throw new Exception($"Order available service failed. Can not found account for accountId: {request.accountId}");
            }

            await purchasedSoftwareRepository.AddSofware(account.Id, orderSoftwareService.Id, orderSoftwareService.Name, request.quantity);
        }
    }
}
