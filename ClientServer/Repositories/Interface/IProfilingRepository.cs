using API.Models;

namespace API.Repositories.Interface;

public interface IProfilingRepository
{
    IEnumerable<Profiling> GetAll();
    Profiling? GetById(string employee_nik);
    string Insert(Profiling profiling);
    string Update(Profiling profiling);
    string Delete(string employee_nik);
}
