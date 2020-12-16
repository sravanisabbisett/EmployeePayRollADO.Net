using EmployeePayRolll;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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

        /// <summary>
        /// Retrives the data in date range.
        /// </summary>
        [TestMethod]
        public void RetriveDataInDateRange()
        {
            List<string> result = employeePayRolll.GetEmployeeInDateRange("Select * from employee where StartDate between CAST('2019-01-01' as DATE) and CAST('2020-12-31' as DATE)");
            int CountNoOfPersons = result.Count;
            Assert.AreEqual(3, CountNoOfPersons);
        }

        /// <summary>
        /// Deletes the employee.
        /// </summary>
        [TestMethod]
        public void DeleteEmployee()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.Name = "Sravani";
            bool result = employeePayRolll.DeltePerson(employeeModel);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void addDetailsInDepartmentTable()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.Department = "Finance";
            bool result = employeePayRolll.AddDepartment(employeeModel);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddDetailsinEmployeeDetailsTable()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.Name = "Sailaja";
            employeeModel.Gender = 'F';
            employeeModel.PhoneNumber = "9295702642";
            employeeModel.Address = "1Town";
            bool result = employeePayRolll.AddEmployeeIntoEmployeeDetails(employeeModel);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddDetailsInPayrollTable()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.StartDate = new DateTime(2019, 10, 01);
            employeeModel.Basic_Pay = 900000.00;
            employeeModel.Deductions = 7000.00;
            employeeModel.IncomeTax = 3000.00;
            employeeModel.TaxablePay = 600.00;
            employeeModel.NetPay = 8750000;
            employeeModel.employee_id = 3;
            bool result = employeePayRolll.AddDetalsToPayRollTable(employeeModel);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddDetailsToEmployeeDepartmentTable()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.employee_id = 3;
            employeeModel.departmentId = 3;
            bool result = employeePayRolll.AddDetailsToDepartMentTable(employeeModel);
            Assert.IsTrue(result);
        }
    }
}
