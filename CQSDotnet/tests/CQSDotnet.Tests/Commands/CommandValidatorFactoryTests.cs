using CQSDotnet.Commands;
using CQSDotnet.Commands.Interfaces;
using CQSDotnet.Tests.Commands.Models;

namespace CQSDotnet.Tests.Commands
{
    [TestFixture]
    public class CommandValidatorFactoryTests
    {
        [Test]
        public void Constructor_WithValidResolver_ShouldNotThrowException()
        {
            // Arrange
            var resolver = new Mock<ITypeResolver>();

            // Act and Assert
            Assert.DoesNotThrow(() => new CommandValidatorFactory(resolver.Object));
        }

        [Test]
        public void GetValidator_WithRegisteredValidator_ShouldReturnValidator()
        {
            // Arrange
            var resolver = new Mock<ITypeResolver>();
            var validator = new Mock<ICommandValidator<DummyCommand>>();
            resolver.Setup(r => r.Resolve(typeof(ICommandValidator<DummyCommand>))).Returns(validator.Object);
            var factory = new CommandValidatorFactory(resolver.Object);

            // Act
            var result = factory.GetValidator<DummyCommand>();

            // Assert
            Assert.AreSame(validator.Object, result);
        }

        [Test]
        public void GetValidator_WithUnregisteredValidator_ShouldReturnDefaultValidator()
        {
            // Arrange
            var resolver = new Mock<ITypeResolver>();
            resolver.Setup(r => r.Resolve(typeof(ICommandValidator<DummyCommand>))).Returns(null);
            var factory = new CommandValidatorFactory(resolver.Object);

            // Act
            var result = factory.GetValidator<DummyCommand>();

            // Assert
            Assert.IsInstanceOf<DefaultCommandValidator<DummyCommand>>(result);
        }
    }
}