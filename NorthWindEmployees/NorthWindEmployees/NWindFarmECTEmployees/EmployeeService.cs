using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWindEmployees;

namespace NorthWindEmployees.NWindFarmECTEmployees
{
    public partial class EmployeeService
    {
        public static Employee ReadItem(int employeeID)
        {
            NorthWindDataContext dataContext = new NorthWindDataContext
            ("Data Source=Farm1Server1ADSQL;Initial Catalog=Northwind;uid=BCSUser1;pwd=YourPasswordHere");

            Employee Employee =
            (from employees in dataContext.Employees.AsEnumerable().Take(20)
             where employees.EmployeeID == employeeID
             select employees).Single();
            return Employee;
        }

        public static IEnumerable<Employee> ReadList()
        {
            NorthWindDataContext dataContext = new NorthWindDataContext
            ("Data Source=Farm1Server1ADSQL;Initial Catalog=Northwind;uid=BCSUser1;pwd=YourPasswordHere");


            IEnumerable<Employee> Employees =
                from employees in dataContext.Employees
                select employees;
            return Employees;
        }

        public static Employee Create(Employee newEmployee)
        {
            NorthWindDataContext dataContext = new NorthWindDataContext
            ("Data Source=Farm1Server1ADSQL;Initial Catalog=Northwind;uid=BCSUser1;pwd=YourPasswordHere");


            Employee emp = new Employee();

            emp.FirstName = newEmployee.FirstName;
            emp.LastName = newEmployee.LastName;
            emp.Title = newEmployee.Title;
            emp.TitleOfCourtesy = newEmployee.TitleOfCourtesy;
            emp.BirthDate = newEmployee.BirthDate;
            emp.HireDate = newEmployee.HireDate;
            emp.Address = newEmployee.Address;
            emp.City = newEmployee.City;
            emp.Region = newEmployee.Region;
            emp.PostalCode = newEmployee.PostalCode;
            emp.Country = newEmployee.Country;
            emp.HomePhone = newEmployee.HomePhone;
            emp.Extension = newEmployee.Extension;
            emp.Notes = newEmployee.Notes;

            dataContext.Employees.InsertOnSubmit(emp);
            dataContext.SubmitChanges();
            return emp;
        }

        public static void Update(Employee employee, int parameter)
        {
            NorthWindDataContext dataContext = new NorthWindDataContext
            ("Data Source=Farm1Server1ADSQL;Initial Catalog=Northwind;uid=BCSUser1;pwd=YourPasswordHere");

            var employeeToUpdate = (from employees in dataContext.Employees
                                   where employees.EmployeeID == parameter
                                   select employees).Single();

            employeeToUpdate.FirstName = employee.FirstName;
            employeeToUpdate.LastName = employee.LastName;
            employeeToUpdate.Title = employee.Title;
            employeeToUpdate.TitleOfCourtesy = employee.TitleOfCourtesy;
            employeeToUpdate.BirthDate = employee.BirthDate;
            employeeToUpdate.HireDate = employee.HireDate;
            employeeToUpdate.Address = employee.Address;
            employeeToUpdate.City = employee.City;
            employeeToUpdate.Region = employee.Region;
            employeeToUpdate.PostalCode = employee.PostalCode;
            employeeToUpdate.Country = employee.Country;
            employeeToUpdate.HomePhone = employee.HomePhone;
            employeeToUpdate.Extension = employee.Extension;
            employeeToUpdate.Notes = employee.Notes;
            dataContext.SubmitChanges();
        }

        public static void Delete(int employeeID)
        {
            NorthWindDataContext dataContext = new NorthWindDataContext
            ("Data Source=Farm1Server1ADSQL;Initial Catalog=Northwind;uid=BCSUser1;pwd=YourPasswordHere");

            Employee Employee =
            (from employees in dataContext.Employees.AsEnumerable().Take(20)
             where employees.EmployeeID == employeeID
             select employees).Single();


            dataContext.Employees.DeleteOnSubmit(Employee);
            dataContext.SubmitChanges();

        }
    }
}
