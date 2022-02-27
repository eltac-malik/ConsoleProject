using System;
using System.Collections.Generic;
using System.Text;
using ConsoleProject22February2022.Interfaces;
using ConsoleProject22February2022.Models;
using ConsoleProject22February2022.Services;

namespace ConsoleProject22February2022.Services
{
    class DepartmentManagementService : IHumanResourceManager
    {
        private Department[] _departments;
        public Department[] Departments => _departments;


        public DepartmentManagementService()
        {
            _departments = new Department[0];
        }


        public void AddDepartment(string departmenName, int employeeLimit, double salaryLimit)
        {
                Department department = new Department(departmenName, employeeLimit, salaryLimit);
                Array.Resize(ref _departments, _departments.Length + 1);
                _departments[_departments.Length - 1] = department;
            
        }

        public void GetDepartments(Department[] departments)
        {
            foreach (Department item in Departments)
            {
                Console.WriteLine(item);
            }
        }

        public void EditDepartments(string departmenName, string newDepartmenName)
        {
            Department department = FindDepartment(departmenName);

            if (department != null)
            {
                department.Name = newDepartmenName;
            }
            else
            {
                Console.WriteLine("Ad tapilmadi");
            }
        }

        public void AddEmployee(string fullName, string position, double salary, string departmentName)
        {
            Department department = FindDepartment(departmentName);

            if (department != null)
            {
                Employee employee = new Employee(fullName, position, salary, departmentName);
                department.AddEmployee(employee);
                return;
            }
            else
            {
                Console.WriteLine($"Department name tapilmadi : { departmentName}");
            }
        }

        public void RemoveEmployee(string no, string departmentName)
        {
            Department department = FindDepartment(departmentName);
            if (department != null)
            {
                for (int i = 0; i < department.GetEmployees().Length; i++)
                {
                    if (department.GetEmployees()[i] != null && department.GetEmployees()[i].No == no)
                    {
                        department.GetEmployees()[i] = null;
                        return;
                    }
                }
            }
        }

        private Department FindDepartment(string departmentName)
        {
            foreach (Department item in _departments)
            {
                if (item.Name.ToLower()==departmentName.ToLower())
                {
                    return item;
                }
            }
            return null;
        }


        public Employee[] GetEmployee(string departmentName)
        {
            Department department = FindDepartment(departmentName);
            if (departmentName != null)
            {
                return department.GetEmployees();
            }
            return null;
        }

        public void EditEmployee(string empNo, string position, double salary, string depName)
        {
            Department employee = FindDepartment(depName);
            

            if (employee != null)
            {
                for (int i = 0; i < employee.GetEmployees().Length; i++)
                {
                    if (employee.GetEmployees()[i] != null && employee.GetEmployees()[i].No == empNo)
                    {
                        employee.GetEmployees()[i].Position = position;
                        Employee.Salary = salary;
                    }
                }
            }
            else
            {
                Console.WriteLine("evvelce Department yarat ");
            }
        }

        public Employee[] FindEmployee(string departmentName)
        {
            Department department = FindDepartment(departmentName);
            if (department != null)
            {
                return department.GetEmployees();
            }
            return null;
        }
    }
}
