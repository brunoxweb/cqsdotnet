using CQSDotnet.Exceptions;
using CQSDotnet.Queries;
using CQSDotnet.Queries.Interfaces;
using CQSDotnet.Queries.Models;
using CQSDotnet.Tests.Queries.Models;

namespace CQSDotnet.Tests.Queries
{
    [TestFixture]
    public class QueryHandlerFactoryTests
    {
        [Test]
        public void GetHandler_ReturnsCorrectHandler()
        {
            // Arrange
            var resolverMock = new Mock<ITypeResolver>();
            var factory = new QueryHandlerFactory(resolverMock.Object);
            var queryHandlerMock = new Mock<IQueryHandler<DummyQuery, string>>();

            resolverMock.Setup(r => r.Resolve(typeof(IQueryHandler<DummyQuery, string>)))
                       .Returns(queryHandlerMock.Object);

            // Act
            var handler = factory.GetHandler<DummyQuery, string>();

            // Assert
            Assert.That(handler, Is.Not.Null);
            Assert.That(handler, Is.InstanceOf<IQueryHandler<DummyQuery, string>>());
        }

        [Test]
        public void GetHandler_WithUnregisteredHandler_ThrowsHandlerNotFoundException()
        {
            // Arrange
            var resolverMock = new Mock<ITypeResolver>();
            var factory = new QueryHandlerFactory(resolverMock.Object);

            resolverMock.Setup(r => r.Resolve(typeof(IQueryHandler<UnregisteredQuery, int>)))
                       .Throws(new Exception());

            // Act
            var handler = new TestDelegate(() => factory.GetHandler<UnregisteredQuery, int>());

            // Assert
            Assert.Throws<HandlerNotFoundException>(handler);
            Assert.That(Assert.Throws<HandlerNotFoundException>(handler).Message, Is.EqualTo($"Handler not found for {nameof(UnregisteredQuery)}"));
        }
    }
}