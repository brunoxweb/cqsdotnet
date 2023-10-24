using CQSDotnet.Commands;
using CQSDotnet.Commands.Interfaces;
using CQSDotnet.Exceptions;
using CQSDotnet.Tests.Commands.Models;

namespace CQSDotnet.Tests.Commands
{
    [TestFixture]
    public partial class CommandHandlerFactoryTests
    {
        [Test]
        public void GetHandler_WithValidType_ReturnsHandler()
        {
            // Arrange
            var resolverMock = new Mock<ITypeResolver>();
            var factory = new CommandHandlerFactory(resolverMock.Object);

            resolverMock.Setup(r => r.Resolve(typeof(ICommandHandler<MyCommand>)))
                       .Returns(new MyCommandHandler());

            // Act
            var handler = factory.GetHandler<MyCommand>();

            // Assert
            Assert.That(handler, Is.InstanceOf<MyCommandHandler>());
        }

        [Test]
        public void GetHandler_WithInvalidType_ThrowsHandlerNotFoundException()
        {
            // Arrange
            var resolverMock = new Mock<ITypeResolver>();
            var factory = new CommandHandlerFactory(resolverMock.Object);

            resolverMock.Setup(r => r.Resolve(typeof(ICommandHandler<InvalidCommand>)))
                       .Throws(new Exception());

            // Act
            var handler = new TestDelegate(() => factory.GetHandler<InvalidCommand>());

            // Assert
            Assert.Throws<HandlerNotFoundException>(handler);
            Assert.That(Assert.Throws<HandlerNotFoundException>(handler).Message, Is.EqualTo($"Handler not found for {nameof(InvalidCommand)}"));
        }
    }
}