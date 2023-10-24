using CQSDotnet.Exceptions;
using CQSDotnet.Models;
using CQSDotnet.Queries;
using CQSDotnet.Queries.Interfaces;

namespace CQSDotnet.Tests.Queries
{
    [TestFixture]
    public class QueryDispatcherTests
    {
        [Test]
        public async Task ExecuteAsync_ValidQuery_ValidatesAndHandles()
        {
            // Arrange
            var query = new Mock<IQuery<string>>();
            var handlerFactory = new Mock<IQueryHandlerFactory>();
            var validatorFactory = new Mock<IQueryValidatorFactory>();
            var handler = new Mock<IQueryHandler<IQuery<string>, string>>();
            var validator = new Mock<IQueryValidator<IQuery<string>>>();

            handlerFactory.Setup(factory => factory.GetHandler<IQuery<string>, string>()).Returns(handler.Object);
            validatorFactory.Setup(factory => factory.GetValidator<IQuery<string>, string>()).Returns(validator.Object);
            validator.Setup(v => v.Validate(query.Object)).Returns(new ValidationStatus { IsValid = true });
            handler.Setup(h => h.HandleAsync(query.Object, CancellationToken.None)).Returns(Task.FromResult("Result"));

            var dispatcher = new QueryDispatcher(handlerFactory.Object, validatorFactory.Object);

            // Act
            var result = await dispatcher.ExecuteAsync<IQuery<string>, string>(query.Object);

            // Assert
            Assert.That(result, Is.EqualTo("Result"));
            handlerFactory.Verify(factory => factory.GetHandler<IQuery<string>, string>(), Times.Once);
            validatorFactory.Verify(factory => factory.GetValidator<IQuery<string>, string>(), Times.Once);
            validator.Verify(v => v.Validate(query.Object), Times.Once);
            handler.Verify(h => h.HandleAsync(query.Object, CancellationToken.None), Times.Once);
        }

        [Test]
        public void ExecuteAsync_InvalidQuery_ThrowsValidationStatusException()
        {
            // Arrange
            var query = new Mock<IQuery<string>>();
            var handlerFactory = new Mock<IQueryHandlerFactory>();
            var validatorFactory = new Mock<IQueryValidatorFactory>();
            var validator = new Mock<IQueryValidator<IQuery<string>>>();

            handlerFactory.Setup(factory => factory.GetHandler<IQuery<string>, string>()).Verifiable();
            validatorFactory.Setup(factory => factory.GetValidator<IQuery<string>, string>()).Returns(validator.Object);

            var validationStatus = new ValidationStatus();
            validationStatus.AddError("001", "ValidationStatus Error");

            validator.Setup(v => v.Validate(query.Object)).Returns(validationStatus);

            var dispatcher = new QueryDispatcher(handlerFactory.Object, validatorFactory.Object);

            // Act & Assert
            Assert.ThrowsAsync<ValidationStatusException>(() => dispatcher.ExecuteAsync<IQuery<string>, string>(query.Object));
            validatorFactory.Verify(factory => factory.GetValidator<IQuery<string>, string>(), Times.Once);
            validator.Verify(v => v.Validate(query.Object), Times.Once);
            handlerFactory.Verify(factory => factory.GetHandler<IQuery<string>, string>(), Times.Never);
        }
    }
}