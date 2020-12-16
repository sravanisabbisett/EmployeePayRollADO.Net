using System;

namespace EmployeePayRolll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            //employeeRepo.GetAllemployee();
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.Name = "Akhilesh";
            employeeModel.Gender = 'M';
            employeeModel.PhoneNumber = "7207321696";
            employeeModel.Address = "Perungudi";
            employeeModel.StartDate = new DateTime(2019, 09, 01);
            employeeModel.Department = "DataScience";
            employeeModel.Basic_Pay = 100000.00;
            employeeModel.Deductions = 25000.00;
            employeeModel.IncomeTax = 7890.00;
            employeeModel.TaxablePay = 17.00;
            employeeModel.NetPay = 975000;
            employeeRepo.AddEmployee(employeeModel);
            Console.ReadKey();
        }
    }
}
