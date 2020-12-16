﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayRolll
{
    class EmployeeRepo
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeePayRollService;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        /// <summary>
        /// Retrive all date from the employee table
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void GetAllemployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"Select employee_id,Name,Gender,PhoneNumber,Address,StartDate,Department,Basic_Pay,Deductions,IncomeTax,TaxablePay,NetPay from employee";

                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.employee_id = dr.GetInt32(0);
                            employeeModel.Name = dr.GetString(1);
                            employeeModel.Gender = Convert.ToChar(dr.GetString(2));
                            employeeModel.PhoneNumber = dr.GetString(3);
                            employeeModel.Address = dr.GetString(4);
                            employeeModel.StartDate = dr.GetDateTime(5);
                            employeeModel.Department = dr.GetString(6);
                            employeeModel.Basic_Pay = dr.GetDouble(7);
                            employeeModel.Deductions = dr.GetDouble(8);
                            employeeModel.IncomeTax = dr.GetDouble(9);
                            employeeModel.TaxablePay = dr.GetDouble(10);
                            employeeModel.NetPay = dr.GetDouble(11);

                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", employeeModel.employee_id, employeeModel.Name, employeeModel.Gender, employeeModel.PhoneNumber,
                                employeeModel.Address, employeeModel.StartDate, employeeModel.Department, employeeModel.Basic_Pay, employeeModel.Deductions, employeeModel.IncomeTax,
                                employeeModel.TaxablePay, employeeModel.NetPay);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    dr.Close();
                    this.connection.Close();
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
    }
}
