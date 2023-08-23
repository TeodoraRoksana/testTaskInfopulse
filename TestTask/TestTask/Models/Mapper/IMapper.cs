namespace TestTask.API.Models.Mapper
{
    public interface IMapper<T, V>
    {
        public V Map(T data);
        public T Unmap(V data);
    }
}
