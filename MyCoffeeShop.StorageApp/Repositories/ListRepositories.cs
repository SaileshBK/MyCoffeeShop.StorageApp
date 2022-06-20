using MyCoffeeShop.StorageApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyCoffeeShop.StorageApp.Repositories
{
    // implying T must be of type EntityBase or class constrain and IEntity interface with EntityBase.
    // here we can also define struct constrain to say T must be value type and Syste.Enum to say  T is an Enum.
    public class ListRepositories<T> : IRepositories<T> where T : IEntity // ,new();
    {
        // protected can still access on sub classes.
        private readonly List<T> _item = new();

        //public T CreateIem()
        //{
        //    return new T();

        //}
        public IEnumerable<T> GetAll()
        {
            return _item.ToList();
        }

        public T GetById(int id)
        {
            return _item.Single(item => item.Id == id);
            //return null;

        }

        public void Add(T item)
        {
            item.Id = _item.Count + 1;
            _item.Add(item);
        }

        public void Save()
        {
            //foreach (var item in _item)
            //{
            //    Console.WriteLine(item);
            //}
            
            // Everything is saved already in the List<T>.


        }
        public void Remove(T item)
        {
            _item.Remove(item);
        }

        
    }
    // Sub class
    //public class GenericRepositoriesWithRemove<T> : GenericRepositories<T>
    //{
    //    public void Remove( T item)
    //    {
    //        _item.Remove(item);
    //    }

    //}
}
