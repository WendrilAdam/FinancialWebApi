using System;
using System.Collections.Generic;

namespace FinancialWebApi.Project.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public string TelefoneFixo { get; set; }
        public string TelefoneCelular { get; set; }
    }
}
