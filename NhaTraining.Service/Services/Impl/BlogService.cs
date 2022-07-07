using NhaTraining.Repository.Data;
using NhaTraining.Repository.Repositories.Base;
using NhaTraining.Service.Services.Base.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaTraining.Service.Services.Impl
{
    public class BlogService : BaseService<Blog>, IBlogService
    {
        public BlogService(IBaseRepository<Blog> repository) : base(repository)
        {
            
        }
    }
}
