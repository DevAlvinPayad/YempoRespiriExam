using APIModels;

namespace YempoRespiriExam.Services
{
    public interface IPersonServices
    {
        Task<List<Person>> Get();
        Task<Person> GetPerson(string id);
    }
}
