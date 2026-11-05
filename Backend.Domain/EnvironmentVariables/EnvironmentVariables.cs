using System.ComponentModel.DataAnnotations;

namespace Backend.Domain.EnvironmentVariables;

public static class EnvironmentVariables
{
    public static string DbHost => GetRequired("DB_HOST");
    public static string DbPort => GetRequired("DB_PORT");
    public static string DbUser => GetRequired("DB_USER");
    public static string DbPassword => GetRequired("DB_PASSWORD");
    public static string DbDatabase => GetRequired("DB_DATABASE");
    public static string DbSchema => GetOptional("DB_SCHEMA", "sac");



    private static readonly string[] _obrigatorias =
        ["DB_HOST", "DB_PORT", "DB_USER", "DB_PASSWORD", "DB_DATABASE"];

    public static void Validate()
    {
        var faltando = _obrigatorias
            .Where(nome => string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(nome)))
            .ToList();


        if (faltando.Count == 0)
        {
            Console.WriteLine("Todas as variáveis de ambiente obrigatórias estão definidas.");
            return;
        }

        foreach (var nome in faltando)
        {
            Console.WriteLine($"A variável de ambiente obrigatória '{nome}' não está definida.");
            throw new ValidationException($"A variável de ambiente obrigatória '{nome}' não está definida.");
        }
    }

    private static string GetRequired(string nome) =>
        Environment.GetEnvironmentVariable(nome)
        ?? throw new ValidationException($"A variavel {nome} não foi definida.");
    private static string GetOptional(string nome, string padrao) =>
        Environment.GetEnvironmentVariable(nome) ?? padrao;
}


