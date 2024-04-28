using AMVTravelDBContext;
using AMVTravelModels;
using AMVTravelsRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AMVTravelsRepositories.Implementation
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly AMVTravelDBContextIndentity AMVTravelDbContextIdentity;

        public BaseRepository(AMVTravelDBContextIndentity AMVTravelDbContext)
        {
            this.AMVTravelDbContextIdentity = AMVTravelDbContext;
        }
        public async Task<T> Add(T entity)
        {
            try
            {
                AMVTravelDbContextIdentity.Set<T>().Add(entity);
                AMVTravelDbContextIdentity.Entry(entity).State = EntityState.Added;
                await AMVTravelDbContextIdentity.SaveChangesAsync();
                return entity;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
   

        public async Task<bool> Delete(T entity)
        {
            try
            {
                AMVTravelDbContextIdentity.Set<T>().Remove(entity);
                await AMVTravelDbContextIdentity.SaveChangesAsync();
                
                return true;

            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<T> Get(string id)
        {

            try
            {
                var entity = await AMVTravelDbContextIdentity.Set<T>().Where(a => a.ID.Equals(id)).FirstOrDefaultAsync();
               
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<T> Get(string id, bool disableTracking = false)
        {
            try
            {
                var query = AMVTravelDbContextIdentity.Set<T>().Where(a => a.ID == id);

                if (disableTracking)
                {
                    query = query.AsNoTracking();
                }

                var entity = await query.FirstOrDefaultAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<T> Get(string id, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                var query = AMVTravelDbContextIdentity.Set<T>().Where(a => a.ID == id);

                foreach (var include in includes)
                {
                    query = query.Include(include);
                }

                var entity = await query.FirstOrDefaultAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<T>> GetAll()
        {
            try
            {

                return await AMVTravelDbContextIdentity.Set<T>().ToListAsync();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicated = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disabledTracking = true)
        {
            try
            {
                IQueryable<T> query = AMVTravelDbContextIdentity.Set<T>();

                if (disabledTracking) query = query.AsNoTracking();

                if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

                if (predicated != null) query = query.Where(predicated);

                if (orderBy != null) return await orderBy(query).ToListAsync();

                return await query.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        //
        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicated = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disabledTracking = true)
        {
            try
            {

                IQueryable<T> query = AMVTravelDbContextIdentity.Set<T>();

                if (disabledTracking) query = query.AsNoTracking();

                if (!string.IsNullOrEmpty(includeString)) query = query.Include(includeString);

                if (predicated != null) query = query.Where(predicated);

                if (orderBy != null) return await orderBy(query).ToListAsync();


                return await query.ToListAsync();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicated = null, bool disabledTracking = true)
        {
            try
            {

                IQueryable<T> query = AMVTravelDbContextIdentity.Set<T>();

                if (disabledTracking) query = query.AsNoTracking();

                if (predicated != null) query = query.Where(predicated);


                return await query.ToListAsync();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                AMVTravelDbContextIdentity.Entry(entity).State = EntityState.Modified;
                await AMVTravelDbContextIdentity.SaveChangesAsync();
                AMVTravelDbContextIdentity.Set<T>().Update(entity);

                return entity;

            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }

    }
}
