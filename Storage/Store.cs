﻿using System;
using System.Collections.Generic;

namespace Storage
{
    public class Store<T> where T : IStorable
    {
        private Dictionary<string, IStorable> storage = new Dictionary<string, IStorable>();

        public int Count()
        {
            return storage.Count;
        }

        public void Insert(IStorable item)
        {
            throw new NotImplementedException();
        }

        public void InsertMany(List<IStorable> items)
        {
            throw new NotImplementedException();
        }

        public IStorable GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, IStorable> GetAllDictionary()
        {
            throw new NotImplementedException();
        }

        public List<IStorable> GetAllList()
        {
            throw new NotImplementedException();
        }

        public void Sell(string id, int amount)
        {
            throw new NotImplementedException();
        }

        public void Buy(IStorable item)
        {
            throw new NotImplementedException();
        }

        public void Buy(string id, int amount)
        {
            throw new NotImplementedException();
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }

        public void Remove(IStorable item)
        {
            throw new NotImplementedException();
        }
    }
}
