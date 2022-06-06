using DataAccesslayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository.Contract;

namespace WebAPI.Repository
{
    public class EmployeeService : IEmployee
    {
        private readonly EmployeeDataOperation dataoperation;

        public EmployeeService()
        {
            this.dataoperation = new EmployeeDataOperation();
        }
        public Employees CreateEmployee(Employees emp)
        {
            var result= dataoperation.CreateEmployee(emp);
            return result;
        }

        public bool DeleteEmployee(int id)
        {
            var emp = dataoperation.DeleteEmployee(id);
            return emp;
        }

        public Employees GetEmployeeById(int id)
        {
            var emp = dataoperation.GetEmployeeById(id);
            return emp;
        }

        public List<Employees> GetEmployees()
        {
            var emps = dataoperation.GetEmployees();
            return emps;
        }

        public Employees UpdateEmployee(Employees model)
        {
            var result = dataoperation.UpdateEmployee(model);
            return result;
        }
    }
}
