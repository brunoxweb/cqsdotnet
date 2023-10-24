namespace CQSDotnet.Tests
{
    public class TestableTypeResolverTests
    {
        [Test]
        public void Resolve_ValidType_ResolvesSuccessfully()
        {
            // Arrange
            var typeResolver = new TestableTypeResolver(type => new object());

            // Act
            var resolvedObject = typeResolver.Resolve(typeof(string));

            // Assert
            Assert.That(resolvedObject, Is.Not.Null);
        }

        [Test]
        public void Resolve_InvalidType_ThrowsInvalidOperationException()
        {
            // Arrange
            var typeResolver = new TestableTypeResolver(type => { throw new Exception(); });

            // Act
            var delegateResult = new TestDelegate(() => typeResolver.Resolve(typeof(int)));

            // Assert
            Assert.Throws<InvalidOperationException>(delegateResult);
            Assert.That(Assert.Throws<InvalidOperationException>(delegateResult).Message, Is.EqualTo("Unable to resolve the type Int32"));
        }
    }
}