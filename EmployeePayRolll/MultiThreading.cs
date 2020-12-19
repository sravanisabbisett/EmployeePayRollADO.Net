using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeePayRolll
{
    public class MultiThreading
    {
        public List<EmployeeModel> employeeDataList = new List<EmployeeModel>();
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeePayRollService;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public bool AddEmployee(EmployeeModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spAddEmployee", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", model.Name);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@StartDate", model.StartDate);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Basic_Pay", model.Basic_Pay);
                    command.Parameters.AddWithValue("@Deductions", model.Deductions);
                    command.Parameters.AddWithValue("@IncomeTax", model.IncomeTax);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    command.Parameters.AddWithValue("@NetPay", model.NetPay);

                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public void AddEmployeeToPayRoll(List<EmployeeModel> empList)
        {
            empList.ForEach(employee =>
            {
                Console.WriteLine("Employee being added" + employee.Name);
                this.AddEmployeePayroll(employee);
                Console.WriteLine("Employee added: " + employee.Name);
            });
            Console.WriteLine(this.employeeDataList.ToString());
        }

        public bool AddMultipleElementToDB(List<EmployeeModel> employeeModels)
        {
            foreach(EmployeeModel employee in employeeModels)
            {
                Console.WriteLine("Employee being added:" + employee.Name);
                bool result = AddEmployee(employee);
                Console.WriteLine("Employee Added:" + employee.Name);
                if (result == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Adds the employeee with multi threading.
        /// </summary>
        /// <param name="employees">The employees.</param>
        public void AddEmployeeeWithMultiThreading(List<EmployeeModel> employees)
        {
            employees.ForEach(employee =>
            {
                Task task = new Task(() =>
                  {
                      Console.WriteLine("Employee being added" + employee.Name);
                      this.AddEmployeePayroll(employee);
                      Console.WriteLine("Employee added: " + employee.Name);
                  });
                task.Start();
            });
            Console.WriteLine(this.employeeDataList.Count);
        }


        /// <summary>
        /// Adds the multiple employee to data base with threading.
        /// </summary>
        /// <param name="employees">The employees.</param>
        /// <returns></returns>
        public bool AddMultipleEmployeeToDataBaseWithThreading(List<EmployeeModel> employees)
        {
            bool result = false;
            employees.ForEach(employeeData =>
            {
                Thread thread = new Thread(() =>
                {
                    result = AddEmployee(employeeData);
                    Console.WriteLine("Employee added" + employeeData.Name);
                });
                // Start all the threads
                thread.Start();
                thread.Join();
            });
            return result;
        }

        public void AddEmployeePayroll(EmployeeModel employee)
        {
            this.employeeDataList.Add(employee);
        }

    }
}
