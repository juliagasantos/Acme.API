﻿namespace Acme.API.DTOs
{
    public class ClienteOutputDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public int IdTipo { get; set; }
        public string Tipo { get; set; }
    }
}
