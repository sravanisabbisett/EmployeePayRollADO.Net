using System;
using System.Collections.Generic;

namespace EmployeePayRolll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            //employeeRepo.GetAllemployee();
            List<string> result=employeeRepo.GetEmployeeInDateRange("Select * from employee where StartDate between CAST('2019-01-01' as DATE) and CAST('2020-12-31' as DATE)");
            int count = result.Count;
            Console.WriteLine(count);
            //employeeRepo.GetEmployeesJoiningAfterADate("Select * from employee where StartDate between CAST('2019-01-01' as DATE) and CAST('2020-12-31' as DATE)");
            Console.ReadKey();
        }
    }
}
