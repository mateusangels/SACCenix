using Backend.Infrastructure.TablesDefinition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Infrastructure.Context
{
    public class ApplicationDbContextDesignTimeFactory :IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseNpgsql("Host=localhost;Database=designtime;Username=postgres;Password=postgres",
                npgsql => npgsql.MigrationsHistoryTable("__EFMigrationsHistory", Tables.DefaultSchema))
            .Options;

            return new ApplicationDbContext(options);
        }
    }
}