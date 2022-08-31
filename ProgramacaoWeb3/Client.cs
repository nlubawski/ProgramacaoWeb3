using System.ComponentModel.DataAnnotations;

namespace ProgramacaoWeb3
{
    public class Client
    {
        public Client()
        {

        }
        public Client(string name, string cpf, DateTime birthDate)
        {
            Cpf = cpf;
            Name = name;
            BirthDate = birthDate;
            Age = CalculateAge(BirthDate);
        }

        [Required(ErrorMessage = "Cpf é obrigatório")]
        [MaxLength(11, ErrorMessage = "Deve conter no máximo 11 digitos")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Data de nascimento é obrigatória")]
        public DateTime BirthDate { get; set; }

        public int Age { get; set; }

        private int CalculateAge(DateTime BirthDate)
        {
            int age = DateTime.Now.Year - BirthDate.Year;
            if(DateTime.Now.DayOfYear < BirthDate.DayOfYear)
            {
                age--;
            }
            return age;
        }

    }
}