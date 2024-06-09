using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Interfaces.Specifications;

namespace UserManagement.Repositories
{
	public abstract class Repository<T>: IDisposable where T: class
	{
        private bool disposedValue;

		public DbContext DbContext;

		public IMapper Mapper { get; private set; }

		public DbSet<T> DbSet { get; private set; }

		public Repository(DbContext dbContext, IMapper mapper)
		{
			DbContext = dbContext ?? throw new ArgumentNullException("dbContext");
			Mapper = mapper ?? throw new ArgumentNullException("mapper");
			DbSet = DbContext.Set<T>();
		}

		public virtual async Task<T>? GetAsync(Guid id)
		{
			return await DbSet.FindAsync(id);
		}

        public virtual async Task UpdateAsync(T entity)
		{
			DbSet.Update(entity);
			await DbContext.SaveChangesAsync();
		}

        public virtual async Task UpdateAsync(IEnumerable<T> entities)
        {
            DbSet.UpdateRange(entities);
            await DbContext.SaveChangesAsync();
        }

		public virtual async Task SaveAsync(T entity)
		{
			DbSet.Add(entity);
			await DbContext.SaveChangesAsync();
		}

        public virtual async Task SaveAsync(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
            await DbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            DbSet.Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
            await DbContext.SaveChangesAsync();
        }

        public virtual T? Get(ISpecification<T> specification)
        {
			return FindBySpecification(specification).AsNoTracking().SingleOrDefault();
        }

        public virtual TResult? Get<TResult>(ISpecification<T> specification, Expression<Func<T, TResult>> function)
        {
            return FindBySpecification(specification, function).SingleOrDefault();
        }

        public virtual async Task<T>? GetAsync(ISpecification<T> specification)
        {
            return await FindBySpecification(specification).AsNoTracking().SingleOrDefaultAsync();
        }

        public virtual async Task<TResult>? GetAsync<TResult>(ISpecification<T> specification, Expression<Func<T, TResult>> function)
        {
            return await FindBySpecification(specification, function).SingleOrDefaultAsync();
        }

        public IEnumerable<T> Find()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public virtual IEnumerable<T> Find(ISpecification<T> specification)
        {
			return DbSet.AsNoTracking().AsEnumerable();
        }

        public virtual IEnumerable<TResult> Find<TResult>(ISpecification<T> specification, Expression<Func<T, TResult>> function)
        {
            return FindBySpecification(specification, function).AsEnumerable();
        }

        public async Task<IEnumerable<T>> FindAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> FindAsync(ISpecification<T> specification)
        {
            return await FindBySpecification(specification).AsNoTracking().ToListAsync();
        }

        public virtual async Task<IEnumerable<TResult>>? FindAsync<TResult>(ISpecification<T> specification, Expression<Func<T, TResult>> function)
        {
            return await FindBySpecification(specification, function).ToListAsync();
        }

        public virtual IQueryable<T> FindQueryable(ISpecification<T> specification)
        {
            return FindBySpecification(specification).AsNoTracking();
        }

        private IQueryable<T> FindBySpecification(ISpecification<T> specification)
		{
			if(specification == null)
			{
				throw new ArgumentNullException("specification");
			}

			IQueryable<T> queryable = specification.Includes.Aggregate(DbSet.AsQueryable(), (IQueryable<T> current, Expression<Func<T, object>> include) => current.Include(include));

			if (specification.Criteria != null)
			{
				return queryable.Where(specification.Criteria).AsQueryable();
			}

			return queryable;
		}

        private IQueryable<TResult> FindBySpecification<TResult>(ISpecification<T> specification, Expression<Func<T, TResult>> function)
		{
			IQueryable<T> source = FindBySpecification(specification);
			return source.Select(function);
		}

        protected void Dispose(bool disposing)
		{
			if(!disposedValue)
			{
				if (disposing)
				{
					DbContext.Dispose();
				}

				disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}

