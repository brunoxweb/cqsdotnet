namespace CQSDotnet.Tests
{
    public class TestableTypeResolver : ITypeResolver
    {
        private readonly Func<Type, object> resolver;

        public TestableTypeResolver(Func<Type, object> resolver)
        {
            this.resolver = resolver;
        }

        public object Resolve(Type type)
        {
            try
            {
                return resolver(type);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Unable to resolve the type {type.Name}", ex);
            }
        }
    }
}
