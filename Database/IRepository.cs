using msgr.Models.Interfaces;
using System;

namespace msgr.Database
{
    public interface IRepository<T> : IRepository<T, Guid> where T : IAggregateRoot<Guid>
    {}
    public interface IRepository<T, K> where T : IAggregateRoot<K>
    {
        T Get(K id);
        void Add(T obj);
    }
}