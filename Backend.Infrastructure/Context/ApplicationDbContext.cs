using Backend.Domain.Entities;
using Backend.Domain.EnvironmentVariables;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
namespace Backend.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<ColaboradoresEntity> Colaboradores => Set<ColaboradoresEntity>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(EnvironmentVariables.DbSchema);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            ApplySoftDeleteQueryFilter(modelBuilder);

        }

        private static void ApplySoftDeleteQueryFilter(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");

                    var deletedAt = Expression.Property(parameter, nameof(ISoftDelete.Deleted_At));
                    var body = Expression.Equal(deletedAt, Expression.Constant(null, typeof(DateTime?)));
                    var filter = Expression.Lambda(body, parameter);

                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
                }
            }
        }

    }
}
