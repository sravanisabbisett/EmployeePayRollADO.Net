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
        /// Updates the employee to the table should return true.
        /// </summary>
        [TestMethod]
        public void UpdateEmployeeToTheTableShouldReturnTrue()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.employee_id = 2;
            employeeModel.Basic_Pay = 1100000.00;
            bool result=employeePayRolll.UpdateEmployee(employeeModel);
            Assert.IsTrue(result);
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
            employeeModel.NetPay = 8750000.00;
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
