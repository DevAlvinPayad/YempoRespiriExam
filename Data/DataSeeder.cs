using APIModels;

namespace YempoRespiriExam.Data
{
    public class DataSeeder
    {
        private readonly DataContext dataContext;

        public DataSeeder(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Seed()
        {
            Guid newId = Guid.Parse("eb851051-7484-4321-8a39-eaabedee59fd");
            DateTime birthDate = DateTime.Parse("1995-05-05");
            var person = new Person { Id = newId, FirstName = "Luffy", MiddleName = "D", LastName = "Monkey", BirthDate = birthDate, Gender = "Male"};

            dataContext.Add(person);
            dataContext.SaveChanges();
        }
    }
}
