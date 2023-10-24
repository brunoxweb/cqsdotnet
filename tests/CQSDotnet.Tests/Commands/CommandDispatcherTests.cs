using CQSDotnet.Commands;
using CQSDotnet.Commands.Interfaces;
using CQSDotnet.Exceptions;
using CQSDotnet.Models;

namespace CQSDotnet.Tests.Commands
{
    [TestFixture]
    public class CommandDispatcherTests
    {
        [Test]
        public async Task ExecuteAsync_ValidCommand_CallsHandler()
        {
            // Arrange
            var command = new Mock<ICommand>();
            var handlerFactory = new Mock<ICommandHandlerFactory>();
            var handler = new Mock<ICommandHandler<ICommand>>();
            var validatorFactory = new Mock<ICommandValidatorFactory>();
            var validator = new Mock<ICommandValidator<ICommand>>();

            handlerFactory.Setup(f => f.GetHandler<ICommand>()).Returns(handler.Object);
            validatorFactory.Setup(f => f.GetValidator<ICommand>()).Returns(validator.Object);
            validator.Setup(v => v.Validate(command.Object)).Returns(new ValidationStatus());

            var dispatcher = new CommandDispatcher(handlerFactory.Object, validatorFactory.Object);

            // Act
            await dispatcher.ExecuteAsync(command.Object);

            // Assert
            handler.Verify(h => h.HandleAsync(command.Object, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public void ExecuteAsync_InvalidCommand_ThrowsValidationStatusException()
        {
            // Arrange
            var command = new Mock<ICommand>();
            var handlerFactory = new Mock<ICommandHandlerFactory>();
            var validatorFactory = new Mock<ICommandValidatorFactory>();
            var validator = new Mock<ICommandValidator<ICommand>>();

            handlerFactory.Setup(f => f.GetHandler<ICommand>());
            validatorFactory.Setup(f => f.GetValidator<ICommand>()).Returns(validator.Object);

            var validationStatus = new ValidationStatus();
            validationStatus.AddError("001", "ValidationStatus Error");

            validator.Setup(v => v.Validate(command.Object)).Returns(validationStatus);

            var dispatcher = new CommandDispatcher(handlerFactory.Object, validatorFactory.Object);

            // Assert
            Assert.Throws<ValidationStatusException>(() => dispatcher.ExecuteAsync(command.Object).Wait());
        }
    }
}