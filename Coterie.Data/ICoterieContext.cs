namespace Coterie.Data
{
    using System;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public interface ICoterieContext : IDisposable
    {
        DbSet<Business> Businesses { get; set; }
        DbSet<State> States { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}