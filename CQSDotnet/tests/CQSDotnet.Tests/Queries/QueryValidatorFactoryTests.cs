using CQSDotnet.Queries;
using CQSDotnet.Queries.Interfaces;
using CQSDotnet.Tests.Queries.Models;

namespace CQSDotnet.Tests.Queries
{
    [TestFixture]
    public class QueryValidatorFactoryTests
    {
        [Test]
        public void GetValidator_WhenValidatorIsRegistered_ShouldReturnResolvedValidator()
        {
            // Arrange
            var resolverMock = new Mock<ITypeResolver>();
            var validatorMock = new Mock<IQueryValidator<DummyQuery>>();

            resolverMock.Setup(r => r.Resolve(typeof(IQueryValidator<DummyQuery>))).Returns(validatorMock.Object);

            var factory = new QueryValidatorFactory(resolverMock.Object);

            // Act
            var result = factory.GetValidator<DummyQuery, string>();

            // Assert
            Assert.That(validatorMock.Object, Is.InstanceOf<IQueryValidator<DummyQuery>>());
        }

        [Test]
        public void GetValidator_WhenValidatorIsNotRegistered_ShouldReturnDefaultValidator()
        {
            // Arrange
            var resolverMock = new Mock<ITypeResolver>();

            resolverMock.Setup(r => r.Resolve(typeof(IQueryValidator<DummyQuery>))).Returns(null);

            var factory = new QueryValidatorFactory(resolverMock.Object);

            // Act
            var validator = factory.GetValidator<DummyQuery, string>();

            // Assert
            Assert.That(validator, Is.InstanceOf<DefaultQueryValidator<DummyQuery>>());
        }
    }
}