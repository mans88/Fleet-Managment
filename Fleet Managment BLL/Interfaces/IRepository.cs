using System.Collections.Generic;

namespace Fleet_Managment_BLL.Interfaces
{
    public interface IRepository<TType> where TType : class
    {
        TType Insert(TType entity);

        List<TType> GetAll();

        TType GetById(int id);

        bool RemoveById(int id);

        TType Update(TType entity);
    }
}