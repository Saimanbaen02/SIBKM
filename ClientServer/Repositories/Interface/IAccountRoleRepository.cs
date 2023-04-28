using API.Models;

namespace API.Repositories.Interface;

public interface IAccountRoleRepository
{
    IEnumerable<AccountRole> GetAll();
    AccountRole? GetById(int id);
    int Insert(AccountRole account_role);
    int Update(AccountRole account_role);
    int Delete(int id);
}
