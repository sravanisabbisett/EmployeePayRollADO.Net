using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeePayRolll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            EmployeeModel employeeModel = new EmployeeModel();
            while (true)
            {
                Console.WriteLine("1)SumofsalarybyGender\n" + "2)Avg of salary by genger\n"
                                   + "3)Min of slary by gender\n" + "4)Max of salary\n"+"5)GetAllemployess\n"+"6)Select date in range");
                                   
                try
                {
                    var choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            employeeRepo.RetriveSum();
                            break;
                        case 2:
                            employeeRepo.RetriveAvg();
                            break;
                        case 3:
                            employeeRepo.RetriveMin();
                            break;
                        case 4:
                            employeeRepo.RetriveMax();
                            break;
                        case 5:
                            employeeRepo.GetAllemployee();
                            break;
                        case 6:
                            employeeModel.StartDate = new DateTime(2018, 01, 01);
                            employeeModel.StartDate = new DateTime(2019, 12, 31);
                            employeeRepo.SelectDateInRange(employeeModel);
                            break;
                        default:
                            Console.WriteLine("Please Enter correct option");
                            break;
                    }
                    Console.WriteLine("Do you want to continue(Y / N) ? ");
                    var variable = Console.ReadLine();
                    if (variable.Equals("y"))
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                catch (System.FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }
                
            }
            Console.ReadKey();
        }

    }
}

