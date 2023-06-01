﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace HXINTL_HFT_2022232.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected MotorsDBContext db;

        public Repository(MotorsDBContext db)
        {
            this.db = db;
        }

        public void Create(T obj)
        {
            db.Add(obj);
            db.SaveChanges();
        }


        public abstract T Read(int id);
        public IQueryable<T> ReadAll()
        {
            return db.Set<T>();
        }
        public abstract void Update(T obj);
        public abstract void Delete(int id);
    }
}