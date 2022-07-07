using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using NhaTraining.Repository.Context;
using NhaTraining.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaTraining.Repository.Repositories.Base.Impl
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly TrainingContext _context;
        protected readonly DbSet<T> _table;
        public BaseRepository(TrainingContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public void Add(T obj)
        {
            using (var context = new TrainingContext())
            {
                context.Database.EnsureCreatedAsync();
                var person = new Blog { Name = "Akos" };
                context.Blogs.Add(person);
                context.SaveChangesAsync();
            }
                //_context.Database.EnsureCreatedAsync();
                //_table.Add(obj);
                //_context.SaveChanges();
        }
        public void Update(T obj)
        {
            _context.Attach(obj);
            var entry = _context.Entry(obj);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
        }
        public bool Delete(string id)
        {
            T entity = _table.Find(id);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
        public T GetById(string id)
        {
            var result = _table.Where(x => x.Id.Equals(id));
            return result.FirstOrDefault();
        }
        public List<T> GetAll()
        {
            var result = new List<T>();
            
            result = _table.ToList();
            return result;
        }

    }
}
