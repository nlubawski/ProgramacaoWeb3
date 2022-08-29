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

        public string Cpf { get; set; }

        public string Name { get; set; }

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