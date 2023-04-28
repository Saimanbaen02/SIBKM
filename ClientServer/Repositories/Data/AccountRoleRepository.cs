using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data;

public class AccountRoleRepository : IAccountRoleRepository
{
    private readonly MyContext _context;
    public AccountRoleRepository(MyContext context)
    {
        _context = context;
    }

    public IEnumerable<AccountRole> GetAll()
    {
        return _context.Set<AccountRole>().ToList();
    }

    public AccountRole? GetById(int id)
    {
        return _context.Set<AccountRole>().Find(id);
    }

    public int Insert(AccountRole account_role)
    {
        _context.Set<AccountRole>().Add(account_role);
        return _context.SaveChanges();
    }

    public int Update(AccountRole account_role)
    {
        _context.Set<AccountRole>().Update(account_role);
        return _context.SaveChanges();
    }

    public int Delete(int id)
    {
        var account_role = GetById(id);
        if (account_role == null)
            return 0;

        _context.Set<AccountRole>().Remove(account_role);
        return _context.SaveChanges();
    }
}

