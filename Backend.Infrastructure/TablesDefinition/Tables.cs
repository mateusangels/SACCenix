using Backend.Domain.EnvironmentVariables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Infrastructure.TablesDefinition
{
    public static class Tables
    {
        public static string DefaultSchema => EnvironmentVariables.DbSchema;

        public static TablesInfo ColaboradoresTable => new TablesInfo("Colaboradores", DefaultSchema, "Tabela de colaboradores da empresa");
    }
}