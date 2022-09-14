using System.ComponentModel.DataAnnotations;

namespace ProgramacaoWeb3
{
    public class Client
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Cpf é obrigatório")]
        [MaxLength(11, ErrorMessage = "Deve conter no máximo 11 digitos")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome só pode ter 80 caracteres")]
        [MinLength(3, ErrorMessage = "O nome deve ter mais que 2 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Data de nascimento é obrigatória")]
        public DateTime DataNascimento { get; set; }

        public int Idade => DateTime.Now.DayOfYear < DataNascimento.DayOfYear ?
            DateTime.Now.Year - DataNascimento.Year - 1 : DateTime.Now.Year - DataNascimento.Year;

        public string Permissao { get; set; } 
    }

}