using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Domain.Entities
{
    public class ColaboradoresEntity : BaseEntity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string? Cargo { get; private set; }
        public string? Telefone { get; private set; }
        public DateTime? Admissao { get; private set; } = DateTime.Now;
        public bool Ativo{ get; private set; } = true;

        protected ColaboradoresEntity() { }
        public ColaboradoresEntity(string nome, string email, string? cargo, string? telefone, DateTime? admissao, bool ativo)
        {
            Update(nome, email, cargo, telefone, admissao, ativo);
        }

        private void Update(string nome, string email, string? cargo, string? telefone, DateTime? admissao, bool ativo)
        {
           var nomeLimpo = nome?.Trim();
            if (string.IsNullOrWhiteSpace(nomeLimpo))
                throw new ArgumentException("Nome não pode ser nulo ou vazio.", nameof(nome));
            var emailLimpo = email?.Trim();
            if (string.IsNullOrWhiteSpace(emailLimpo))
                throw new ArgumentException("Email não pode ser nulo ou vazio.", nameof(email));
            Nome = nomeLimpo;
            Email = emailLimpo;
            Cargo = cargo?.Trim();
            Telefone = telefone?.Trim();
            Admissao = admissao ?? DateTime.Now;
            Ativo = ativo;
        }
    }
}