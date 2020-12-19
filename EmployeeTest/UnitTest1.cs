using EmployeePayRolll;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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

        /// <summary>
        /// Adds the details to multiple tables in single transction.
        /// </summary>
        [TestMethod]
        public void addDetailsToMultipleTablesInSingleTransction()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.Name = "Rupika";
            employeeModel.Gender = 'F';
            employeeModel.PhoneNumber = "929081527";
            employeeModel.Address = "Madhapur";
            employeeModel.Basic_Pay = 80000.00;
            employeeModel.StartDate = new DateTime(2020, 10, 10);
            employeeModel.departmentId = 2;
            bool result = employeePayRolll.AddEmployeeDetailsMultipleTables(employeeModel);
            Assert.IsTrue(result);
        }

        public  List<EmployeeModel> AddingDataToList()
        {
            List<EmployeeModel> employeeModels = new List<EmployeeModel>();
            employeeModels.Add(new EmployeeModel { Name = "Sravani", Gender = 'F', PhoneNumber = "8712443377", Address = "GanadhiChowk", StartDate = new DateTime(2018,12,19), Department = "Fianace", Basic_Pay = 908765, Deductions = 567, IncomeTax = 9087, TaxablePay = 0987, NetPay = 900000 });
            employeeModels.Add(new EmployeeModel { Name = "Rupika", Gender = 'F', PhoneNumber = "5712443377", Address = "GanadhiChowk", StartDate = new DateTime(2018,12,19), Department = "Fianace", Basic_Pay = 908765, Deductions = 567, IncomeTax = 9087, TaxablePay = 0987, NetPay = 900000 });
            employeeModels.Add(new EmployeeModel { Name = "Shanu", Gender = 'F', PhoneNumber = "9712443377", Address = "VyjayanthiTraders", StartDate = new DateTime(2018,12,19), Department = "Fianace", Basic_Pay = 908765, Deductions = 567, IncomeTax = 9087, TaxablePay = 0987, NetPay = 900000 });
            employeeModels.Add(new EmployeeModel { Name = "Sravi", Gender = 'F', PhoneNumber = "9712443377", Address = "GanadhiChowk", StartDate = new DateTime(2018,12,19), Department = "Fianace", Basic_Pay = 908765, Deductions = 567, IncomeTax = 9087, TaxablePay = 0987, NetPay = 900000 });
            employeeModels.Add(new EmployeeModel { Name = "Laskmi", Gender = 'F', PhoneNumber = "7712443377", Address = "GanadhiChowk", StartDate = new DateTime(2018,12,19), Department = "Fianace", Basic_Pay = 908765, Deductions = 567, IncomeTax = 9087, TaxablePay = 0987, NetPay = 900000 });
            employeeModels.Add(new EmployeeModel { Name = "sri", Gender = 'F', PhoneNumber = "9712443377", Address = "GanadhiChowk", StartDate = new DateTime(2018,12,19), Department = "Fianace", Basic_Pay = 908765, Deductions = 567, IncomeTax = 9087, TaxablePay = 0987, NetPay = 900000 });
            employeeModels.Add(new EmployeeModel { Name = "sravanaLakshmi", Gender = 'F', PhoneNumber = "7712443377", Address = "GanadhiChowk", StartDate = new DateTime(2018,12,19), Department = "Fianace", Basic_Pay = 908765, Deductions = 567, IncomeTax = 9087, TaxablePay = 0987, NetPay = 900000 });
            return employeeModels;
        }

        /// <summary>
        /// Adds to list with out threading.
        /// </summary>
        [TestMethod]
        public void AddToListWithOutThreading()
        {
            List<EmployeeModel> empList = AddingDataToList();
            bool expected = true;
            MultiThreading multiThreading = new MultiThreading();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool actual=multiThreading.AddMultipleElementToDB(empList);
            stopwatch.Stop();
            Console.WriteLine("Time taken to add to db without threads is :{0} ms", stopwatch.ElapsedMilliseconds);
            Assert.AreEqual(expected, actual);

        }

    }
}

