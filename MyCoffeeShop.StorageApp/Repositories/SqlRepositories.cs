﻿using Microsoft.EntityFrameworkCore;
using MyCoffeeShop.StorageApp.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MyCoffeeShop.StorageApp.Repositories
{
    // A delegate is like a method pointer.This delegate returns void and has a contravariant generic T parameter.
    public delegate void ItemAdded<T>(T item);
    public class SqlRepositories<T> : IRepositories<T> where T : class, IEntity // ,new();
    {
        // protected can still access on sub classes.
        //private readonly List<T> _item = new();

        //public T CreateIem()
        //{
        //    return new T();

        //}
        private readonly DbContext _dbcontext;
        private readonly ItemAdded<T>? _itemAddedCallback;
        private readonly DbSet<T> _dbSet;

        

        public SqlRepositories(DbContext dbContext, ItemAdded<T>? itemAddedCallback = null)
        {
            _dbcontext = dbContext;
            _itemAddedCallback = itemAddedCallback;
            _dbSet = _dbcontext.Set<T>();

        }

        public IEnumerable<T> GetAll()
        {
            // getting items ordered by Id.
            return _dbSet.OrderBy(item => item.Id).ToList();
        }

        public T GetById(int id)
        {
            //return _item.Single(item => item.Id == id);
            //return null;
            return _dbSet.Find(id);


        }

        public void Add(T item)
        {
            //item.Id = _item.Count + 1;
            //_item.Add(item);
            _dbSet.Add(item);
            // delegate here will Invoke the method.
            _itemAddedCallback?.Invoke(item);
        }
        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }

        public void Save()
        {
            _dbcontext.SaveChanges();


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
