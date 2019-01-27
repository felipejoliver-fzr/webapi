using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Funcionario
    {
        [Key]
        public int IdFuncionario {get;set;}
        public string Nome{get;set;}

        public string Senha {get;set;}

        public string Email {get;set;}
        
    }
}