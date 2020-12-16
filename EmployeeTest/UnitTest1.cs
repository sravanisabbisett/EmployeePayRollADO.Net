using EmployeePayRolll;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmployeeTest
{
    [TestClass]
    public class UnitTest1
    {
        EmployeeRepo employeePayRolll;

        public UnitTest1()
        {
            employeePayRolll = new EmployeeRepo();
        }

        /// <summary>
        /// Adds the employee to the table should return true.
        /// </summary>
        [TestMethod]
        public void AddEmployeeToTheTable_ShouldReturnTrue()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.Name = "Srilakshmi";
            employeeModel.Gender = 'F';
            employeeModel.PhoneNumber = "9290815127";
            employeeModel.Address = "Madhapur";
            employeeModel.StartDate = new DateTime(2020, 09, 01);
            employeeModel.Department = "HR";
            employeeModel.Basic_Pay = 100000.00;
            employeeModel.Deductions = 25000.00;
            employeeModel.IncomeTax = 7890.00;
            employeeModel.TaxablePay = 17.00;
            employeeModel.NetPay = 975000;
            bool result=employeePayRolll.AddEmployee(employeeModel);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Updates the employee to the table should return true.
        /// </summary>
        [TestMethod]
        public void UpdateEmployeeToTheTableShouldReturnTrue()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.Name = "Akhilesh";
            employeeModel.Basic_Pay = 1100000.00;
            bool result=employeePayRolll.UpdateEmployee(employeeModel);
            Assert.IsTrue(result);
        }
    }
}
