using CAProject.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAProject.Core.IRepositories.BaseRepo
{
    public interface IRepository<T> where T : BaseModel
    {
        public Task AddAsync(T model);

        public Task<T> GetAsync(Func<T, bool> expression);

        public Task<List<T>> GetAllAsync();

        public Task RemoveAsync(T model);
    }
}
