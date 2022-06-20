using MyCoffeeShop.StorageApp.Entities;
using System.Collections.Generic;

namespace MyCoffeeShop.StorageApp.Repositories
{

    public interface IWriteRepositories<in T>
    {
        void Add(T item);
        void Remove(T item);
        void Save();

    }

    public interface IReadRepositories<out T>
    {
        // GetAll method with return type of IEnumerable of type T.
        IEnumerable<T> GetAll();
        T GetById(int id);


    }
    // Inherating IRepositories interface from IReadRepositories interface (generic interface from generic interface).
    public interface IRepositories<T> : IReadRepositories<T>, IWriteRepositories<T>
        where T : IEntity
    {



    }

    // Inherating non generic interface from a generoc interface.
    //public interface IEmployeeRepositories : IRepositories<Employee> 
    //{
        

    //}

    // Inherating Generic interface from a generic interface.
    //public interface ISuperRepositories<T, TKey> : IRepositories<T> where T : IEntity
    //{
    //    TKey Key { get; }

    //}
}