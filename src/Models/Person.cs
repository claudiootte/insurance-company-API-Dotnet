namespace src.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string? CPF { get; set; }
        public bool Active { get; set; }
        public List<Contract> Contracts { get; set; }

        public Person()
        {
            this.Name = String.Empty;
            this.Age = 0;
            this.Contracts = new List<Contract>();
            this.Active = false;
        }

        public Person(string name, int age, string cpf, bool active = true)
        {
            Name = name;
            Age = age;
            CPF = cpf;
            Contracts = new List<Contract>();
            Active = active;
        }

    }
}