using System.Collections.Generic;

namespace PokemonLib.Service
{
    public interface IDataProvider<T>
    {
        T GetById(int id);

        void Edit(T newEntity);

        void Add(T entity);

        void Remove(int id);

        IEnumerable<T> GetAll();

        void SaveChanges();
    }
}