using NhaTraining.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaTraining.Repository.Repositories.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        T GetById(string id);
        void Add(T obj);
        void Update(T obj);
        bool Delete(string id);
    }
}
