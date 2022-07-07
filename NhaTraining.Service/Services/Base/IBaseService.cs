using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaTraining.Service.Services.Base
{
    public interface IBaseService<T>
    {
        public void AddItemAsync(T item);

        public void DeleteItemAsync(string id);

        public T GetItemAsync(string id);

        public List<T> GetItemsAsync();

        public void UpdateItemAsync(T item);
    }
}
