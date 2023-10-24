using CQSDotnet.Exceptions;
using CQSDotnet.Models;

namespace CQSDotnet.Tests.Exceptions
{
    [TestFixture]
    public class ValidationStatusExceptionTests
    {
        [Test]
        public void Constructor_WithValidationStatus_SetsValidationStatusProperty()
        {
            // Arrange
            ValidationStatus validationStatus = new ValidationStatus();

            // Act
            ValidationStatusException exception = new ValidationStatusException(validationStatus);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(exception.ValidationStatus, Is.EqualTo(validationStatus));
                Assert.That(validationStatus.IsValid, Is.False);
            });
        }
    }
}