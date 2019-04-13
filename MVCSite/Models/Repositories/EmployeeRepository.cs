using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCSite.Models.Data;

namespace MVCSite.Models.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>//using class Employee from Data
    {
        public EmployeeRepository(MVCSiteDataContext mvcsiteEntities) : base(mvcsiteEntities)
        {

        }

        public Employee GetByID(int? id)
        {
            return GetAll(x => x.EmployeeID == id).FirstOrDefault();
        }

        public Employee GetByLastName(string lastName)
        {
            return GetAll(x => x.LastName == lastName).FirstOrDefault();
        }

        public override IQueryable<Employee> GetAll()
        {
            return base.GetAll(x => true);
        }

        public Employee CreateEmployee(Employee employee, string companyId)
        {
            Employee emp = new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Telephone = employee.Telephone,
                CompanyID = int.Parse(companyId)
            };
            base.Add(emp);
            return emp;
        }
    }
}