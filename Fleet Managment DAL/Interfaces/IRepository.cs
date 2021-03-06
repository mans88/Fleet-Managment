﻿using System.Collections.Generic;

namespace Fleet_Managment_DAL.Interfaces
{
    public interface IRepository<TType> where TType : class
    {
        TType Insert(TType entity);

        IEnumerable<TType> GetAll();

        TType GetByID(int id);

        bool RemoveById(int id);

        bool Remove(TType entity);

        TType Update(TType entity);
    }
}