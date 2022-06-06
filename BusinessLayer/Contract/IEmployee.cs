using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository.Contract
{
    public interface IEmployee
    {
        List<Employees> GetEmployees();
        Employees CreateEmployee(Employees emp);
        bool DeleteEmployee(int id);
        Employees GetEmployeeById(int id);
        Employees UpdateEmployee(Employees model);
        
    }
}
