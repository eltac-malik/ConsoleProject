using System;
using System.Collections.Generic;
using System.Text;
using ConsoleProject22February2022.Interfaces;
using ConsoleProject22February2022.Models;
using ConsoleProject22February2022.Services;

namespace ConsoleProject22February2022.Models
{
    class Employee
    {
        private Employee[] Employees;
        private static int _count = 1000;
        public string No { get; set; }
        private string _fullName;
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                while (!CheckFullName(value))
                {
                    Console.WriteLine("Adi duzgun daxil et");
                    value = Console.ReadLine();
                }
                _fullName = value;
            }
        }
        
        private static double _salary;
        private string _position;
        public string Position
        {
            get => _position;
            set
            {
                while (!CheckPosition(value))
                {
                    Console.WriteLine("Duzgun position daxil et");
                    value = Console.ReadLine();
                }
                _position = value;
            }
        }
        public static double Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                while (!CheckSalary(value))
                {
                    Console.WriteLine("Duzgun maas limiti daxil et");
                    double.TryParse(Console.ReadLine(), out value);
                }
                _salary = value;
            }
        }
        public string DepartmentName { get; set; }
        

        public Employee(string fullName, string position, double salary, string departmentName)
        {
            FullName = fullName;
            Position = position;
            Salary = salary;
            _count++;
            DepartmentName = departmentName;
            No = $"{DepartmentName[0..2].ToUpper()}{_count}";
        }

        public override string ToString()
        {
            return $"FullName: {FullName} \nPosition: " +
                $"{Position} \nSalary: {Salary} \nDepartmentName: " +
                $"{DepartmentName}\nEmployeeNo:  {No}\n --------------------------------------";
        }

        public static bool CheckSalary(double salary)
        {
            return salary >= 250 ? true : false;
        }
        public bool CheckPosition(string position)
        {
            return position.Length >= 2 ? true : false; 
        }
        public bool CheckFullName(string fullName)
        {
            int count = 0;
            for (int i = 0; i < fullName.Length; i++)
            {
                if (char.IsUpper(fullName[i]) && i == 0)
                {
                    count++;
                }
                else if (char.IsWhiteSpace(fullName[i]))
                {
                    count++;
                    if (char.IsUpper(fullName[i + 1]))
                    {
                        count++;
                    }
                }
            }
            if (count == 3)
            {
                return true;
            }
            return false;
        }
    }
}
