namespace CQSDotnet
{
    public interface ITypeResolver
    {
        object Resolve(Type type);
    }
}