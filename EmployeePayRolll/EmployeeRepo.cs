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
                    string query = @"Select employee_id,Name,Gender,PhoneNumber,Address from  employeeDetails";

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
                            Console.WriteLine("{0},{1},{2},{3},{4}", employeeModel.employee_id, employeeModel.Name, employeeModel.Gender, employeeModel.PhoneNumber,
                                employeeModel.Address);
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
                    command.Parameters.AddWithValue("@employee_id", model.employee_id);
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

        /// <summary>
        /// Adds the department.
        /// </summary>
        /// <param name="employeeModel">The employee model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool AddDepartment(EmployeeModel employeeModel)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddDemartment", this.connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Department", employeeModel.Department);
                    this.connection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
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
        /// Adds the employee into employee details.
        /// </summary>
        /// <param name="employeeModel">The employee model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool AddEmployeeIntoEmployeeDetails(EmployeeModel employeeModel)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddEmployeeDetails", this.connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Name", employeeModel.Name);
                    sqlCommand.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", employeeModel.PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@Address", employeeModel.Address);
                    this.connection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
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
        /// Adds the detals to pay roll table.
        /// </summary>
        /// <param name="employeeModel">The employee model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool AddDetalsToPayRollTable(EmployeeModel employeeModel)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddPayRollDetails", this.connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                    sqlCommand.Parameters.AddWithValue("@Basic_Pay", employeeModel.Basic_Pay);
                    sqlCommand.Parameters.AddWithValue("@Deductions", employeeModel.Deductions);
                    sqlCommand.Parameters.AddWithValue("@IncomeTax", employeeModel.IncomeTax);
                    sqlCommand.Parameters.AddWithValue("@TaxablePay", employeeModel.TaxablePay);
                    sqlCommand.Parameters.AddWithValue("@NetPay", employeeModel.NetPay);
                    sqlCommand.Parameters.AddWithValue("@employee_id", employeeModel.employee_id);
                    this.connection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
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
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public bool AddDetailsToDepartMentTable(EmployeeModel employeeModel)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddEmployeeDepartMent", this.connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Employee_Id", employeeModel.employee_id);
                    sqlCommand.Parameters.AddWithValue("@Department_Id", employeeModel.departmentId);
                    this.connection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
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
        /// Retrives the sum.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void RetriveSum()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"select gender,Sum(payroll.Basic_pay) as Max_Pay from payRoll payroll inner join employeeDetails emp on payroll.employee_id = emp.employee_id group by gender;";
                    SqlCommand sqlCommand = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = sqlCommand.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.Gender = Convert.ToChar(dr.GetString(0));
                            employeeModel.Basic_Pay = dr.GetDouble(1);
                            Console.WriteLine(employeeModel.Gender + " " + employeeModel.Basic_Pay);
                        }
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
        /// Retrives the average.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void RetriveAvg()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"select gender,Avg(payroll.Basic_pay) as Max_Pay from payRoll payroll inner join employeeDetails emp on payroll.employee_id = emp.employee_id group by gender;";
                    SqlCommand sqlCommand = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = sqlCommand.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.Gender = Convert.ToChar(dr.GetString(0));
                            employeeModel.Basic_Pay = dr.GetDouble(1);
                            Console.WriteLine(employeeModel.Gender + " " + employeeModel.Basic_Pay);
                        }
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
        /// Retrives the minimum.
        /// </summary>
        /// <exception cref="Exception"></exception>
/        public void RetriveMin()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"select gender,Min(payroll.Basic_pay) as Max_Pay from payRoll payroll inner join employeeDetails emp on payroll.employee_id = emp.employee_id group by gender;";
                    SqlCommand sqlCommand = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = sqlCommand.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.Gender = Convert.ToChar(dr.GetString(0));
                            employeeModel.Basic_Pay = dr.GetDouble(1);
                            Console.WriteLine(employeeModel.Gender + " " + employeeModel.Basic_Pay);
                        }
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
        /// Retrives the maximum.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void RetriveMax()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"select gender,Max(payroll.Basic_pay) as Max_Pay from payRoll payroll inner join employeeDetails emp on payroll.employee_id = emp.employee_id group by gender;";
                    SqlCommand sqlCommand = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = sqlCommand.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.Gender = Convert.ToChar(dr.GetString(0));
                            employeeModel.Basic_Pay = dr.GetDouble(1);
                            Console.WriteLine(employeeModel.Gender + " " + employeeModel.Basic_Pay);
                        }
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
        /// Selects the date in range.
        /// </summary>
        /// <exception cref="Exception"></exception>
/        public void SelectDateInRange()
        {
            try
            {
                using (this.connection)
                {
                    EmployeeModel employeeModel = new EmployeeModel();
                    string query = @"Select StartDate,employee_id from payroll where StartDate between CAST('2019-01-01' as DATE) and CAST('2020-12-31' as DATE)";
                    SqlCommand sqlCommand = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            employeeModel.StartDate = dataReader.GetDateTime(0);
                            employeeModel.employee_id = dataReader.GetInt32(1);
                            Console.WriteLine(employeeModel.StartDate + "," + employeeModel.employee_id);
                            Console.WriteLine("{0},{1}", employeeModel.StartDate, employeeModel.employee_id);
                        }
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
    }
}
