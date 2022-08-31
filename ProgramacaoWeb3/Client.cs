using System.ComponentModel.DataAnnotations;

namespace ProgramacaoWeb3
{
    public class Client
    {
        [Required(ErrorMessage = "Cpf � obrigat�rio")]
        [MaxLength(11, ErrorMessage = "Deve conter no m�ximo 11 digitos")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Nome � obrigat�rio")]
        [MaxLength(100, ErrorMessage = "O nome s� pode ter 80 caracteres")]
        [MinLength(3, ErrorMessage = "O nome deve ter mais que 2 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Data de nascimento � obrigat�ria")]
        public DateTime BirthDate { get; set; }

        public int Age => DateTime.Now.DayOfYear < BirthDate.DayOfYear ?
            DateTime.Now.Year - BirthDate.Year - 1 : DateTime.Now.Year - BirthDate.Year;
    }

}