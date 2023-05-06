using API.Context;
using API.Models;
using API.Repositories.Interface;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories.Data;

public class AccountRepository : GeneralRepository<Account, string, MyContext>, IAccountRepository
{
    public AccountRepository(MyContext context) : base(context) { }
    public int Register(RegisterVM registerVM)
    {
        int result = 0;
        // Insert to University Table
        var university = new University
        {
            Name = registerVM.UniversityName
        };
        // Sebelum insert lakukan pengecekan apakah universitas sudah ada atau belum
        if (_context.Universities.Any(u => u.Name.Contains(registerVM.UniversityName)))
        {
            university.Id = _context.Universities.FirstOrDefault(u => u.Name.Contains(registerVM.UniversityName))!.Id;
        }
        else
        {
            _context.Universities.Add(university);
            result = _context.SaveChanges();
        }

        //Insert to Education table,
        var education = new Education
        {
            Major = registerVM.Major,
            Degree = registerVM.Degree,
            GPA = registerVM.GPA,
            UniversityId = university.Id
        };
        _context.Set<Education>().Add(education);
        result += _context.SaveChanges();

        // Insert to Employee table
        var employee = new Employee
        {
            NIK = registerVM.NIK,
            FirstName = registerVM.FirstName,
            LastName = registerVM.LastName,
            Gender = registerVM.Gender,
            BirthDate = registerVM.BirthDate,
            Email = registerVM.Email,
            HiringDate = DateTime.Now,
            PhoneNumber = registerVM.PhoneNumber,
        };
        _context.Set<Employee>().Add(employee);
        result += _context.SaveChanges();

        // Insert to Account table
        var account = new Account
        {
            EmployeeNIK = registerVM.NIK,
            Password = registerVM.Password
        };
        _context.Set<Account>().Add(account);
        result += _context.SaveChanges();

        // Insert to Profiling table
        var profiling = new Profiling
        {
            EmployeeNIK = registerVM.NIK,
            EducationId = education.Id,
        };
        _context.Set<Profiling>().Add(profiling);
        result += _context.SaveChanges();

        // Insert to Account Role table
        var accountRole = new AccountRole
        {
            AccountNIK = registerVM.NIK,
            RoleId = 1
        };
        _context.Set<AccountRole>().Add(accountRole);
        result += _context.SaveChanges();

        return result;
    }
    public bool Login(LoginVM loginVM)
    {
        //Ambil data dari Database berdasarkan Email di table employee
        var employeeEmail = _context.Employees.FirstOrDefault(e => e.Email == loginVM.Email);
        if (employeeEmail == null)
        {
            return false;
        }

        //Gabungkan data dari table employee dengan tabel account berdasarkan NIK
        var accountByNIK = _context.Accounts.FirstOrDefault(a => a.EmployeeNIK == employeeByEmail.NIK);

        //Cocokkan data tersebut dengan password yang diinputkan
        //Cek Apakah data valid atau tidak
        if (accountByNIK !=null && loginVM.Password == accountByNIK.Password)
        {
            return true;
        }
        return false;

    }
}

