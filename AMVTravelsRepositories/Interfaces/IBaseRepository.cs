using AMVTravelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AMVTravelsRepositories.Interfaces
{
    public interface IBaseRepository <T> where T : BaseModel
    {
        public Task<T> Add(T entity);
        public Task<T> Update(T entity);
        public Task<bool> Delete(T entity);
        public Task<ICollection<T>> GetAll();
        public Task<T> Get(string id);
        Task<T> Get(string id, params Expression<Func<T, object>>[] includes);
        public Task<T> Get(string id, bool disableTracking);

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicated = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<Expression<Func<T, object>>> includes = null,
            bool disabledTracking = true);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicated = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeString = null,
            bool disabledTracking = true);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicated = null,
            bool disabledTracking = true);
    }
}
