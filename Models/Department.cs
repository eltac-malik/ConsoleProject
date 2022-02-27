using System;
using System.Collections.Generic;
using System.Text;
using ConsoleProject22February2022.Models;
using ConsoleProject22February2022.Interfaces;
using ConsoleProject22February2022.Services;

namespace ConsoleProject22February2022.Models
{
    class Department
    {
        private double _salaryLimit;
        private string _name;
        private int _employeeLimit;
        private Employee[] Employees;

        public string Name
        {
            get => _name;
            set
            {
                while(!(value.Length >= 2))
                {
                    Console.WriteLine("Mimum 2 herf olmalidir");
                    value = Console.ReadLine();

                }
                _name = value;
            }
        }
        


        public int WorkerLimit
        {
            get => _employeeLimit;
            set
            {
                while(!(value >=1))
                {
                    Console.WriteLine("Duzgun daxil et");
                    int.TryParse(Console.ReadLine(), out value);
                    
                }
               
                _employeeLimit = value;
            }
        }
        public double SalaryLimit
        {
            get => _salaryLimit;

            set
            {
                if (value < 250)
                {
                    Console.WriteLine("Duzgun daxil et");

                    while (!double.TryParse(Console.ReadLine(), out value) && value < 250)
                    {
                        Console.WriteLine("Yeniden daxil et");
                        double.TryParse(Console.ReadLine(), out value);
                    }
                }
                _salaryLimit = value;

            }
        }

        
        public Department(string name, int employeeLimit, double salaryLimit)
        {
            Employees = new Employee[0];
            Name = name;
            WorkerLimit = employeeLimit;
            SalaryLimit = salaryLimit;
        }
        
        public Employee[] GetEmployees() => Employees;


        public override string ToString()
        {
            return $"Department {Name} \nMax Salary {SalaryLimit} \nWorkerlimit {WorkerLimit}\n {CalcSalaryAverage()}\n -------------------------------------------------";
        }


        public void AddEmployee(Employee employee)
        {
            if (Employees.Length < WorkerLimit)
            {
                Array.Resize(ref Employees, Employees.Length + 1);
                Employees[Employees.Length - 1] = employee;
            }
            else
            {
                Console.WriteLine("Department de yer yoxdur");
            }
        }

        public void RemoveEmployee(string departmentName, string no)
        {
            for (int i = 0; i < Employees.Length; i++)
            {
                if (Employees[i] !=null && Employees[i].No == no && Employees[i].DepartmentName == departmentName)
                {
                    Employees[i] = null;
                    return;
                }
            }
        }

        public double CalcSalaryAverage()
        {
            double sum = 0;
            int count = 0;



            foreach (Employee item in Employees)
            {

                Console.WriteLine(Employees);

            }
            return sum / count;
        }

    }
}
