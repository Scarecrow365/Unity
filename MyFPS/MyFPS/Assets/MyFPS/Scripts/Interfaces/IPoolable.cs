namespace MyFPS
{
    public interface IPoolable
    {
        string PoolId { get; }
        int ObjectCount { get; }
    }
}
