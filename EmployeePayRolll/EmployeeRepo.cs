using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayRolll
{
    public class EmployeeRepo
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

        /// <summary>
        /// Adds the Record to the employee.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.connection)
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

        /// <summary>
        /// Updates the person with name.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool UpdateEmployee(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spUpdateemployee", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Basic_Pay", model.Basic_Pay);
                    command.Parameters.AddWithValue("@Name", model.Name);
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

        /// <summary>
        /// Gets the employee in date range.
        /// </summary>
        /// <param name="dateRangeQuery">The date range query.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">
        /// No data found
        /// or
        /// </exception>
        public List<string> GetEmployeeInDateRange(string dateRangeQuery)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            List<string> results = new List<string>();
            try
            {
                using (this.connection)
                {
                    string query = dateRangeQuery;
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
                            results.Add(employeeModel.Name);
                            Console.WriteLine(employeeModel.Name);
                        }
                        dr.Close();
                        return results;
                    }
                    else
                    {
                        throw new Exception("No data found");
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

        //UC6
        /// <summary>
        /// Sums the of salary gender wise.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        public void SumOfSalaryGenderWise()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    EmployeeModel employeeModel = new EmployeeModel();
                    string query = @"select Gender,Sum(Basic_Pay) as Salary from employee group by Gender";
                    SqlCommand sqlCommand = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = sqlCommand.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Console.WriteLine(dr.GetString(0));
                            Console.WriteLine(dr.GetDouble(1));
                        }
                        dr.Close();
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }


        /// <summary>
        /// Maximums the salary gender wise.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void MaxSalaryGenderWise()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    EmployeeModel employeeModel = new EmployeeModel();
                    string query = @"select Gender,Max(Basic_Pay) as Salary from employee group by Gender";
                    SqlCommand sqlCommand = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = sqlCommand.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Console.WriteLine(dr.GetString(0)+"\t");
                            Console.WriteLine(dr.GetDouble(1));
                        }
                        dr.Close();
                    }
                    else
                    {
                        Console.WriteLine("No data found");
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

        /// <summary>
        /// Minimums the salary gender wise.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void MinSalaryGenderWise()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    EmployeeModel employeeModel = new EmployeeModel();
                    string query = @"select Gender,Min(Basic_Pay) as Salary from employee group by Gender";
                    SqlCommand sqlCommand = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = sqlCommand.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Console.WriteLine(dr.GetString(0)+"\t");
                            Console.WriteLine(dr.GetDouble(1));
                        }
                        dr.Close();
                    }
                    else
                    {
                        Console.WriteLine("No data found");
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

        /// <summary>
        /// Counts the employee gender wise.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void CountEmployeeGenderWise()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    EmployeeModel employeeModel = new EmployeeModel();
                    string query = @"select Gender,Count(Gender) as Salary from employee group by Gender";
                    SqlCommand sqlCommand = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = sqlCommand.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Console.WriteLine(dr.GetString(0)+"\t");
                            Console.WriteLine(dr.GetInt32(1));
                        }
                        dr.Close();
                    }
                    else
                    {
                        Console.WriteLine("No data found");
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

        /// <summary>
        /// Deltes the person.
        /// </summary>
        public bool DeltePerson(EmployeeModel employeeModel)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spDeleteEmployee", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", employeeModel.Name);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
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
    }
}
