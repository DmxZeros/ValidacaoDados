using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Valida.Validacao;

namespace Valida.Models
{
    public class Pessoa
    {
        [Required(ErrorMessage = "Nome deve ser preenchido")]
        public string Nome { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "A observação deve ter entre 5 e 50 caracteres")]
        [Required(ErrorMessage = "Preencha a observação")]
        public string Observacao { get; set; }

        [Range(18, 99, ErrorMessage = "Idade entre 18 e 50")]
        [Required(ErrorMessage = "Informe uma idade")]
        public int Idade { get; set; }

        [Required(ErrorMessage ="O CPF deve ser informado")]
        [Cpf(ErrorMessage = "CPF inválido !")]
        public string CPF { get; set; }

        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "O email informado não é valido")]
        public string Email { get; set; }

        [RegularExpression(@"[a-zA-Z]{5,15}", ErrorMessage = "Login deve possuir somente letras e deve ter de 5 a 15 caracteres")]
        [Required(ErrorMessage = "O Login deve ser preenchido")]
        [Remote("LoginUnico", "Pessoa", ErrorMessage = "Este nome de Login já existe")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha deve ser informada")]
        public string Senha { get; set; }
        
        [Compare("Senha", ErrorMessage = "As senhas não conferem")]
        public string ConfirmarSenha { get; set; }
    }
}
