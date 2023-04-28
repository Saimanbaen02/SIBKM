using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data;

public class ProfilingRepository : IProfilingRepository
{
    private readonly MyContext _context;
    public ProfilingRepository(MyContext context)
    {
        _context = context;
    }

    public IEnumerable<Profiling> GetAll()
    {
        return _context.Set<Profiling>().ToList();
    }

    public Profiling? GetById(string employee_nik)
    {
        return _context.Set<Profiling>().Find(employee_nik);
    }

    public string Insert(Profiling profiling)
    {
        _context.Set<Profiling>().Add(profiling);
        return _context.SaveChanges();
    }

    public int Update(Profiling profiling)
    {
        _context.Set<Profiling>().Update(profiling);
        return _context.SaveChanges();
    }

    public int Delete(string employee_nik)
    {
        var profiling = GetById(employee_nik);
        if (profiling == null)
            return 0;

        _context.Set<Profiling>().Remove(profiling);
        return _context.SaveChanges();
    }
}

