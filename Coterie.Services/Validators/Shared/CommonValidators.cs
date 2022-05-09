namespace Coterie.Services.Validators.Shared
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class CommonValidators : ICommonValidators
    {
        private readonly ICoterieContext _context;

        public CommonValidators(ICoterieContext context)
        {
            _context = context;
        }

        public async Task<bool> IsExistingEntityRowAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            var query = _context.Set<TEntity>();
            return await query.AnyAsync(filter);
        }

        public async Task<TEntity> GetFirstOrDefaultEntityRowAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            var query = _context.Set<TEntity>();
            return await query.FirstOrDefaultAsync(filter);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}