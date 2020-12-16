using System;
using System.Collections.Generic;

namespace EmployeePayRolll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            //employeeRepo.GetAllemployee();
            //List<string> result=employeeRepo.GetEmployeeInDateRange("Select * from employee where StartDate between CAST('2019-01-01' as DATE) and CAST('2020-12-31' as DATE)");
            //int count = result.Count;
            //Console.WriteLine(count);
            // employeeRepo.SumOfSalaryGenderWise();
            //employeeRepo.MaxSalaryGenderWise();
            //employeeRepo.MinSalaryGenderWise();
     //     employeeRepo.CountEmployeeGenderWise();
            //employeeRepo.SumOfSalaryGenderWise();
           while (true)
            {
                Console.WriteLine("1)SumofsalarybyGender\n" + "2)Maxof salary by genger\n"
                                   + "4)Min of slary by gender\n" + "5)CountPersonByGender\n");
                                   
                try
                {
                    var choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            employeeRepo.SumOfSalaryGenderWise();
                            break;
                        case 2:
                            employeeRepo.MaxSalaryGenderWise();
                            break;
                        case 3:
                            employeeRepo.MinSalaryGenderWise();
                            break;
                        case 4:
                            employeeRepo.CountEmployeeGenderWise();
                            break;
                        default:
                            Console.WriteLine("Please Enter correct option");
                            break;
                    }
                    Console.WriteLine("\n");
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
                    Console.WriteLine(formatException);
                }
                
            }
            Console.ReadKey();
        }
        
    }
}
