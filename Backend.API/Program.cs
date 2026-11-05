using System.Globalization;
using Backend.CrossCutting.IoC;
using Backend.Domain.EnvironmentVariables;
using Backend.Infrastructure.Context;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

// Porutgues do Brasil em todo o sistema (datas e números)
var ptBr = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentCulture = ptBr;
CultureInfo.DefaultThreadCurrentUICulture = ptBr;


// Carrega as variáveis de ambiente do arquivo .env
DotEnv.Load();
EnvironmentVariables.Validate();


var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner.
builder.Services.AddControllers();
builder.Services.ServiceInjection();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Sac.API",
        Version = "v1.0",
        Description = "API do sistema SAC",
    });
});
var app = builder.Build();

await ApplicationDbContextMigrator.MigrateAsync(app.Services);

app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/alive", () => Results.Json(new

{
    status = "alive",
    sistema = "Sac",
    horario = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
    version = "1.0.0"
}))
    .WithTags("Status")
    .WithSummary("Confere se a API está funcionando");

app.MapGet("/banco", async (ApplicationDbContext db) => Results.Json(new
{
    conectado = await db.Database.CanConnectAsync(),
    banco = EnvironmentVariables.DbDatabase,
    schema = EnvironmentVariables.DbSchema,
}))
.WithTags("Status")
.WithSummary("Confere a conexão com o PostGreSQL");

app.MapGet("/banco/script", (ApplicationDbContext db) => db.Database.GenerateCreateScript())
    .WithTags("Status").WithSummary("Mostra o CREATE TABLE gerado pelo EF");

app.MapGet("/Colaboradores/all", async (ApplicationDbContext db) => await db.Colaboradores.IgnoreQueryFilters().ToListAsync())
    .WithTags("Colaboradores").WithSummary("Mostra todos os colaboradores cadastrados no banco, incluindo os soft deleted");
app.MapGet("/Colaboradores", async (ApplicationDbContext db) => await db.Colaboradores.ToListAsync())
    .WithTags("Colaboradores").WithSummary("Mostra os colaboradores cadastrados no banco");



app.MapControllers();
app.Run();
