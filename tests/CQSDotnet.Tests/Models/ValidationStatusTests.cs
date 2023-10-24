using CQSDotnet.Models;

namespace CQSDotnet.Tests.Models
{
    [TestFixture]
    public class ValidationStatusTests
    {
        [Test]
        public void NewValidationStatusShouldBeValid()
        {
            // Arrange
            ValidationStatus validationStatus = new();

            // Assert
            Assert.That(validationStatus.IsValid, Is.True);
            Assert.That(validationStatus.Errors, Is.Empty);
        }

        [Test]
        public void AddErrorShouldMakeValidationStatusInvalid()
        {
            // Arrange
            ValidationStatus validationStatus = new();

            // Act
            validationStatus.AddError("ErrorCode", "Error Message");

            // Assert
            Assert.That(validationStatus.IsValid, Is.False);
            Assert.That(validationStatus.Errors, Has.Count.EqualTo(1));
            Assert.That(validationStatus.Errors.ContainsKey("ErrorCode"), Is.True);
            Assert.That(validationStatus.Errors["ErrorCode"], Is.EqualTo("Error Message"));
        }

        [Test]
        public void AddErrorShouldAddMultipleErrors()
        {
            // Arrange
            ValidationStatus validationStatus = new();

            // Act
            validationStatus.AddError("ErrorCode1", "Error Message 1");
            validationStatus.AddError("ErrorCode2", "Error Message 2");

            // Assert
            Assert.That(validationStatus.IsValid, Is.False);
            Assert.That(validationStatus.Errors, Has.Count.EqualTo(2));
            Assert.That(validationStatus.Errors.ContainsKey("ErrorCode1"), Is.True);
            Assert.That(validationStatus.Errors["ErrorCode1"], Is.EqualTo("Error Message 1"));
            Assert.That(validationStatus.Errors.ContainsKey("ErrorCode2"), Is.True);
            Assert.That(validationStatus.Errors["ErrorCode2"], Is.EqualTo("Error Message 2"));
        }
    }
}