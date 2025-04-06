using Crayon.TechExercise.CloudSales.Application.Account;
using Crayon.TechExercise.CloudSales.Application.CloudServiceProvider;
using Crayon.TechExercise.CloudSales.Application.CloudServiceProvider.Commands;
using Crayon.TechExercise.CloudSales.Application.PurchasedSoftware;
using FakeItEasy;
using FluentValidation;
using FluentValidation.Results;
using Shouldly;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Crayon.TechExercise.CloudSales.Application.Tests
{
    [TestFixture]
    public class OrderSoftwareServiceCommandHandlerTests
    {
        private IValidator<OrderSoftwareServiceCommand> _validator;
        private ICcpClient _ccpClient;
        private IAccountRepository _accountRepository;
        private IPurchasedSoftwareRepository _purchasedSoftwareRepository;
        private OrderSoftwareServiceCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _validator = A.Fake<IValidator<OrderSoftwareServiceCommand>>();
            _ccpClient = A.Fake<ICcpClient>();
            _accountRepository = A.Fake<IAccountRepository>();
            _purchasedSoftwareRepository = A.Fake<IPurchasedSoftwareRepository>();

            _handler = new OrderSoftwareServiceCommandHandler(
                _validator,
                _ccpClient,
                _accountRepository,
                _purchasedSoftwareRepository
            );
        }

        [Test]
        public async Task Should_Not_Proceed_When_Validation_Fails()
        {
            // Arrange
            var command = new OrderSoftwareServiceCommand(1, 1, 5);
            A.CallTo(() => _validator.Validate(command))
                .Returns(new ValidationResult(new List<ValidationFailure> { new("quantity", "Invalid") }));

            // Act & Assert
            var ex = await Should.ThrowAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));

            ex.Errors.ShouldHaveSingleItem();
            A.CallTo(() => _ccpClient.GetSoftwareListAsync()).MustNotHaveHappened();
            A.CallTo(() => _accountRepository.GetAccount(A<int>._)).MustNotHaveHappened();
            A.CallTo(() => _purchasedSoftwareRepository.AddSofware(A<int>._, A<int>._, A<string>._, A<int>._)).MustNotHaveHappened();
        }

        [Test]
        public async Task Should_Throw_When_Software_Not_Found()
        {
            // Arrange
            var command = new OrderSoftwareServiceCommand(1, 42, 1);
            A.CallTo(() => _validator.Validate(command)).Returns(new ValidationResult());
            A.CallTo(() => _ccpClient.GetSoftwareListAsync()).Returns(new List<CcpSoftwareResult>());

            // Act & Assert
            var ex = await Should.ThrowAsync<Exception>(() => _handler.Handle(command, CancellationToken.None));
            ex.Message.ShouldContain("Order service not found");
        }

        [Test]
        public async Task Should_Throw_When_Account_Not_Found()
        {
            // Arrange
            var command = new OrderSoftwareServiceCommand(1, 1, 2);
            A.CallTo(() => _validator.Validate(command)).Returns(new ValidationResult());
            A.CallTo(() => _ccpClient.GetSoftwareListAsync())
                .Returns(new List<CcpSoftwareResult>() { new(1, "NAME", "PROVIDER_NAME") });

            A.CallTo(() => _accountRepository.GetAccount(1)).Returns((Domain.Account)null);

            // Act & Assert
            var ex = await Should.ThrowAsync<Exception>(() => _handler.Handle(command, CancellationToken.None));
            ex.Message.ShouldContain("Can not found account");
        }

        [Test]
        public async Task Should_Call_Repository_When_Valid()
        {
            // Arrange
            var command = new OrderSoftwareServiceCommand(10, 5, 3);
            var software = new CcpSoftwareResult(5, "NAME1", "AWS" );
            var account = new Domain.Account { Id = 10, Name = "ACCOUNT1", CustomerId = 1 };

            A.CallTo(() => _validator.Validate(command)).Returns(new ValidationResult());
            A.CallTo(() => _ccpClient.GetSoftwareListAsync()).Returns(new List<CcpSoftwareResult> { software });
            A.CallTo(() => _accountRepository.GetAccount(command.accountId)).Returns(account);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            A.CallTo(() => _purchasedSoftwareRepository.AddSofware(
                account.Id,
                software.Id,
                software.Name,
                command.quantity
            )).MustHaveHappenedOnceExactly();
        }
    }
}