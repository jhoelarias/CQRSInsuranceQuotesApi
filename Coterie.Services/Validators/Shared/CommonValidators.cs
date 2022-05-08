namespace Coterie.Services.Validators.Shared
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Data.Model;
    using Microsoft.EntityFrameworkCore;
using Coterie.Services.Validators.Shared;

    public class CommonValidators : ICommonValidators
    {
        private readonly ICommissionsContext _context;

        public CommonValidators(ICommissionsContext context)
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
