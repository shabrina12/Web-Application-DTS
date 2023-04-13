using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using NuGet.Protocol.Plugins;
using System.Drawing.Drawing2D;
using System.Transactions;
using WebApplicationDTS.Contexts;
using WebApplicationDTS.Models;
using WebApplicationDTS.Handlers;
using WebApplicationDTS.Repository.Contracts;
using WebApplicationDTS.ViewModels;

namespace WebApplicationDTS.Repository
{
    public class AccountRepository : GeneralRepository<Account, string, MyContext>, IAccountRepository
    {
        public AccountRepository(MyContext context) : base(context) { }

        public int Register(RegisterVM registerVM)
        {
            // Validasi untuk input masing" entitas jika gagal lakukan rollback
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                // Validasi apakah input university name ada di database/ tidak
                University university = new University
                {
                    Name = registerVM.UniversityName
                };

                if (_context.Universities.Any(o => o.Name == university.Name))
                {               
                    university.Id = _context.Universities.First(u => u.Name.Equals(university.Name)).Id;
                }
                else
                {
                    _context.Universities.Add(university);
                    _context.SaveChanges();
                }            

                var education = new Education
                {
                    Major = registerVM.Major,
                    Degree = registerVM.Degree,
                    Gpa = registerVM.GPA,
                    UniversityId = university.Id,
                };
                _context.Educations.Add(education);
                _context.SaveChanges();

                var employee = new Employee
                {
                    Nik = registerVM.NIK,
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    BirthDate = registerVM.BirthDate,
                    Gender = registerVM.Gender,
                    PhoneNumber = registerVM.PhoneNumber,
                    Email = registerVM.Email,
                    HiringDate = DateTime.Now
                };
                _context.Employees.Add(employee);
                _context.SaveChanges();

                var account = new Account
                {
                    EmployeeNik = registerVM.NIK,
                    Password = Hashing.HashPassword(registerVM.Password),
                };
                _context.Accounts.Add(account);
                _context.SaveChanges();

                var userRole = _context.Roles.FirstOrDefault(r => r.Name.Equals("User"));

                var accountRole = new AccountRole
                {
                    AccountNik = account.EmployeeNik,
                    RoleId = userRole.Id
                };

                _context.AccountRoles.Add(accountRole);
                _context.SaveChanges();

                var profiling = new Profiling
                {
                    EmployeeNik = registerVM.NIK,
                    EducationId = education.Id,
                };
                _context.Profilings.Add(profiling);
                _context.SaveChanges();
                transaction.Commit();
            
                return 1;
            } catch
            {
                transaction.Rollback();
                return 0;
            }
        }


        public bool Login(LoginVM loginVM)
        {
           var checkLogin = _context.Employees.Join(_context.Accounts, e => e.Nik, a => a.EmployeeNik, (e, a) =>
               new LoginVM
               {
                   Email = e.Email,
                   Password = a.Password
               }).FirstOrDefault(e => e.Email == loginVM.Email);
            
            return checkLogin is not null && Hashing.ValidatePassword(loginVM.Password, checkLogin.Password);
        }  
	}
}
