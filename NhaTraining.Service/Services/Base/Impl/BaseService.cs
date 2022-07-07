using NhaTraining.Repository.Data;
using NhaTraining.Repository.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaTraining.Service.Services.Base.Impl
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _repository;
        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public void AddItemAsync(T item)
        {
            _repository.Add(item);
        }

        public void DeleteItemAsync(string id)
        {
            _repository.Delete(id);
        }

        public T GetItemAsync(string id)
        {
            return _repository.GetById(id);

        }

        public List<T> GetItemsAsync()
        {
            return _repository.GetAll();
        }

        public void UpdateItemAsync(T item)
        {
            _repository.Update(item);
        }
    }
}
