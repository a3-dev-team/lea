using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace A3.Library.Mvc
{
    public abstract class DalBase<T> where T : class { }

    /// <summary>
    /// Classe de base pour les DALs permettant de simplifier, masquer la manipulation liée à EF
    /// </summary>
    /// <typeparam name="TSelf">DalBase</typeparam>
    public abstract class EntityFrameworkDalBase<T> : DalBase<T>
       where T : class
    {
        protected DbContext DbContext { get; }

        protected EntityFrameworkDalBase(DbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.DbContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.DbContext.Set<T>()
                .Where(expression);
        }

        public void Create(T entity, bool saveChanges = true)
        {
            this.DbContext.Set<T>().Add(entity);
        }

        public void Create<T1>(T1 entity)
        where T1 : class
        {
            this.DbContext.Set<T1>().Add(entity);
        }

        public void Update(T entity)
        {
            this.DbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.DbContext.Set<T>().Remove(entity);
        }

        public async Task CreateAndSaveAsync(T entity, bool saveChanges = true)
        {
            this.DbContext.Set<T>().Add(entity);
            await this.SaveAsync();
        }

        public async Task CreateAndSaveAsync<T1>(T1 entity)
        where T1 : class
        {
            this.DbContext.Set<T1>().Add(entity);
            await this.SaveAsync();
        }

        public async Task UpdateAndSaveAsync(T entity)
        {
            this.DbContext.Set<T>().Update(entity);
            await this.SaveAsync();
        }

        public async Task DeleteAndSave(T entity)
        {
            this.DbContext.Set<T>().Remove(entity);
            await this.SaveAsync();
        }

        public async Task SaveAsync()
        {
            await this.DbContext.SaveChangesAsync();
        }
    }
}
