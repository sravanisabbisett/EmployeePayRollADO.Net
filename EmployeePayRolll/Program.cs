using System;

namespace EmployeePayRolll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            employeeRepo.GetAllemployee();
            Console.ReadKey();
        }
    }
}
