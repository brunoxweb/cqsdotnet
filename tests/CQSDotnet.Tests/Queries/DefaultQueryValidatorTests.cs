using CQSDotnet.Models;
using CQSDotnet.Queries;
using CQSDotnet.Tests.Queries.Models;

namespace CQSDotnet.Tests.Queries
{
    [TestFixture]
    public class DefaultQueryValidatorTests
    {
        [Test]
        public void Validate_ReturnsValidationStatus()
        {
            // Arrange
            var validator = new DefaultQueryValidator<DummyQuery>();

            // Act
            var result = validator.Validate(new DummyQuery());

            // Assert
            Assert.That(result, Is.InstanceOf<ValidationStatus>());
        }

        [Test]
        public void Validate_ReturnsNonNullValidationStatus()
        {
            // Arrange
            var validator = new DefaultQueryValidator<DummyQuery>();

            // Act
            var result = validator.Validate(new DummyQuery());

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Validate_ReturnsValidationStatusWithDefaultValues()
        {
            // Arrange
            var validator = new DefaultQueryValidator<DummyQuery>();

            // Act
            var result = validator.Validate(new DummyQuery());

            // Assert
            Assert.That(result.Errors.Count, Is.EqualTo(0));
            Assert.That(result.IsValid, Is.EqualTo(true));
        }
    }
}