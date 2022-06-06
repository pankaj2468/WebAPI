using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;

namespace DataAccesslayer
{
    public class EmployeeDataOperation
    {
        private ApplicationDbContext dbcontext;
        public EmployeeDataOperation()
        {
            dbcontext=new ApplicationDbContext();
        }
        public Employees CreateEmployee(Employees emp)
        {
            dbcontext.Employees.Add(emp);
            dbcontext.SaveChanges();
            return emp;
        }

        public bool DeleteEmployee(int id)
        {
            var emp = dbcontext.Employees.SingleOrDefault(e => e.Id == id);
            if (emp == null)
            {
                return false;
            }
            else
            {
                dbcontext.Employees.Remove(emp);
                dbcontext.SaveChanges();
                return true;
            }
        }

        public Employees GetEmployeeById(int id)
        {
            var emp = dbcontext.Employees.SingleOrDefault(e => e.Id == id);
            return emp;
        }

        public List<Employees> GetEmployees()
        {
            return dbcontext.Employees.ToList();
        }

        public Employees UpdateEmployee(Employees model)
        {
            dbcontext.Employees.Update(model);
            dbcontext.SaveChanges();
            return model;
        }
    }
}

   

