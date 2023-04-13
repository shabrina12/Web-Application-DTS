using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using NuGet.Protocol.Plugins;
using System.Drawing.Drawing2D;
using System.Transactions;
using WebApplicationDTS.Contexts;
using WebApplicationDTS.Models;
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
            // Validasi apakah input university name ada di database/ tidak
            var university = new University
            {
                Name = registerVM.UniversityName,
            };

            if (!_context.Universities.Any(o => o.Name == university.Name))
            {
                _context.Universities.Add(university);
                _context.SaveChanges();
            }
            else
            {
                //_context.Universities.Where(o => o.Name == university.Name);
                //var SameUni = _context.Universities.Where(o => o.Name == university.Name);
                //university.Id = SameUni.Id;
                //_context.Universities.Add(university);
                //_context.SaveChanges();
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
                Password = registerVM.Password,
            };
            _context.Accounts.Add(account);
            _context.SaveChanges();

            var accountRole = new AccountRole()
            {
                AccountNik = registerVM.NIK,
                RoleId = 1
            };
            _context.AccountRoles.Add(accountRole);
            _context.SaveChanges();

            var profiling = new Profiling
            {
                EmployeeNik = registerVM.NIK,
                EducationId = education.Id,
            };
            _context.Profilings.Add(profiling);
            return _context.SaveChanges();
        }


        public bool Login(LoginVM loginVM)
        {
            var checkLogin = _context.Employees.Join(_context.Accounts, e => e.Nik, a => a.EmployeeNik,(e, a) => 
                new LoginVM
                {
                    Email = e.Email,
                    Password = a.Password
                }).FirstOrDefault(e => e.Email == loginVM.Email);

            if (checkLogin == null)
            {
                return false;
            }
            return PasswordValidation(loginVM.Password, checkLogin.Password);
        }
 
        private bool PasswordValidation(string password, string checkPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, checkPassword);
        }
    }
}
