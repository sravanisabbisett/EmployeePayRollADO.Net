using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayRolll
{
    public class EmployeeModel
    {
        public int employee_id { get; set; }
        public string Name { get; set; }
        public char Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public string Department { get; set; }
        public double Basic_Pay { get; set; }
        public double Deductions { get; set; }
        public double IncomeTax { get; set; }
        public double TaxablePay { get; set; }
        public double NetPay { get; set; }
        public int departmentId { get; set; }
    }
}
