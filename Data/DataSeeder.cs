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
            //Create 2 initial data
            for(int x = 1; x <= 2; x++) 
            {
                Guid newId = Guid.NewGuid();
                DateTime birthDate = DateTime.Parse("1995-05-05");
                var person = new Person { Id = newId, FirstName = string.Format("Test-{0}",x), MiddleName = string.Format("T-{0}", x), LastName = string.Format("Person-{0}", x), BirthDate = birthDate.AddYears(x), Gender = "Male" };

                dataContext.Add(person);
                dataContext.SaveChanges();
            }
            
        }
    }
}
