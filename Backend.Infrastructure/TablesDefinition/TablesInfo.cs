using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Infrastructure.TablesDefinition
{
    public class TablesInfo
    {
        public string Nome { get; set; }
        public string Schema { get; set; }
        public string Descrição { get; set; }

        public TablesInfo(string nome, string schema, string descrição)
        {
            Nome = nome;
            Schema = schema;
            Descrição = descrição;
        }
    }
}