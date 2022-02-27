using System;
using System.Collections.Generic;
using System.Text;
using ConsoleProject22February2022.Models;
using ConsoleProject22February2022.Interfaces;
using ConsoleProject22February2022.Services;



namespace ConsoleProject22February2022.Interfaces
{
    interface IHumanResourceManager
    {
        Department[] Departments { get; }
        void GetDepartments(Department [] departments);
        Employee[] GetEmployee(string departmentName);
        Employee[] FindEmployee(string departmentName);
        void AddDepartment(string departmenName, int workerLimit, double salaryLimit);
        void EditDepartments(string departmenName, string newDepartmenName);
        void AddEmployee(string fullName, string position, double salary, string departmentName);
        void EditEmployee(string empNo, string position, double salary, string depName);
        void RemoveEmployee(string no, string departmentName);
        
    }
}
