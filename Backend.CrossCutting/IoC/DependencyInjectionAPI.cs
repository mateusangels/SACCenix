using Backend.Domain.EnvironmentVariables;
using Backend.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Backend.Infrastructure.TablesDefinition;

using Npgsql;

namespace Backend.CrossCutting.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection ServiceInjection(this IServiceCollection services)
        {
            ConfigureDatabase(services);
            return services;

        }
        private static void ConfigureDatabase(IServiceCollection services)
        {
            var connectionString = new NpgsqlConnectionStringBuilder
            {
                Host = EnvironmentVariables.DbHost,
                Port = int.Parse(EnvironmentVariables.DbPort),
                Username = EnvironmentVariables.DbUser,
                Password = EnvironmentVariables.DbPassword,
                Database = EnvironmentVariables.DbDatabase

            }.ConnectionString;
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString, npgsql =>
            npgsql.MigrationsHistoryTable("__EFMigrationsHistory", Tables.DefaultSchema)));
        }
    }
}
