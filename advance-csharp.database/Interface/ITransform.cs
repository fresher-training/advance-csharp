namespace advance_csharp.database.Interface
{
    public interface ITransform<out T>
    {
        T Transform();
    }
}
