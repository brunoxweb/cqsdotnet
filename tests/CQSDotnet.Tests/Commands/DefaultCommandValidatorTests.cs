using CQSDotnet.Commands;
using CQSDotnet.Tests.Commands.Models;

namespace CQSDotnet.Tests.Commands
{
    [TestFixture]
    public class DefaultCommandValidatorTests
    {
        [Test]
        public void Validate_ReturnsNotNullValidationStatus()
        {
            // Arrange
            var validator = new DefaultCommandValidator<DummyCommand>();

            // Act
            var result = validator.Validate(new DummyCommand());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsValid);
        }
    }
}