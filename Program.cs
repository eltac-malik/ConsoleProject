using System;
using ConsoleProject22February2022.Models;
using ConsoleProject22February2022.Interfaces;
using ConsoleProject22February2022.Services;


namespace ConsoleProject22February2022
{
    class Program
    {
        static void Main(string[] args)
        {



            DepartmentManagementService departmentManagementService = new DepartmentManagementService();

            do
            {
                Console.WriteLine("***************************");
                Console.WriteLine("Seciminizi daxil edin");
                Console.WriteLine("***************************");
                Console.WriteLine("__________________________________________________");
                Console.WriteLine("1. Departmentleri Goster");
                Console.WriteLine("__________________________________________________");
                Console.WriteLine("2. Department Yarat");
                Console.WriteLine("__________________________________________________");
                Console.WriteLine("3. Departmenti Editle");
                Console.WriteLine("__________________________________________________");
                Console.WriteLine("4. Iscileri Goster");
                Console.WriteLine("__________________________________________________");
                Console.WriteLine("5. Iscileri Editle");
                Console.WriteLine("__________________________________________________");
                Console.WriteLine("6. Isci Elave et");
                Console.WriteLine("__________________________________________________");
                Console.WriteLine("7. Iscileri Sil");
                Console.WriteLine("__________________________________________________");
                Console.WriteLine("8. Iscileri axtar");
                Console.WriteLine("__________________________________________________");
                Console.WriteLine("9. Cixis");
                Console.WriteLine("");
                Console.WriteLine("***************************");
                

                string str = Console.ReadLine();
                int choose;

                while (!int.TryParse(str, out choose) || choose < 1 || choose > 9)
                {
                    Console.WriteLine("1 -- 9 arasi bir secim edin");
                    str = Console.ReadLine();
                }

                switch (choose)
                {
                    case 1:
                        GetDepartments(ref departmentManagementService);
                        break;
                    case 2:
                        AddDepartment(ref departmentManagementService);
                        break;
                    case 3:
                        EditDepartments(ref departmentManagementService);
                        break;
                    case 4:
                        GetEmployees(ref departmentManagementService);
                        break;
                    case 5:
                        EditEmployee(ref departmentManagementService);
                        break;
                    case 6:
                        AddEmployee(ref departmentManagementService);
                        break;
                    case 7:
                        RemoveEmployee(ref departmentManagementService);
                        break;
                    case 8:
                        FindEmployee(ref departmentManagementService);
                        break;
                    case 9:
                        Console.WriteLine("Cixis edildi");
                        Console.ReadKey();
                        return;
                }

            } while (true);
        }


        static void AddDepartment(ref DepartmentManagementService departmentManagementService)
        {
            Console.WriteLine("Department adini daxli edin");
            string departmentName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(departmentName))
            {
                Console.WriteLine("Department adini duzgun daxil et");
                departmentName = Console.ReadLine();
            }

            Console.WriteLine("Isci limitini daxil et...");
            string limit = Console.ReadLine();
            int employeeLimit;

            while (!int.TryParse(limit, out employeeLimit) || employeeLimit < 1 || employeeLimit > 30)
            {
                Console.WriteLine("Isci limitini duzgun daxil et");
                limit = Console.ReadLine();
            }

            Console.WriteLine("Maas limitini daxil edin");
            string salary = Console.ReadLine();
            double salaryLimit;

            while (!double.TryParse(salary, out salaryLimit) || salaryLimit < 250)
            {
                Console.WriteLine("Duzgun maas limitini daxil et");
                salary = Console.ReadLine();
            }

            departmentManagementService.AddDepartment(departmentName, employeeLimit, salaryLimit);

            Console.WriteLine($" {departmentName} adinda department yaradildi");
        }
        private static void AddEmployee(ref DepartmentManagementService departmentManagementService)
        {
            if (departmentManagementService.Departments.Length > 0)
            {

                foreach (Department department in departmentManagementService.Departments)
                {
                    Console.WriteLine(department);
                }
            }
            else
            {
                Console.WriteLine("Evvelce Department yaradin");

            }


            Console.WriteLine("Department adini daxil edin");
            string departmentName = Console.ReadLine();
            Console.WriteLine("Iscinin adini daxil edin");
            string employeeFullName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(employeeFullName))
            {
                Console.WriteLine("Duzgun daxil et");
                employeeFullName = Console.ReadLine();
            }

            Console.WriteLine("Position daxil et");
            string employeePosition = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(employeePosition))
            {
                Console.WriteLine("Duzgun daxil et");
                employeePosition = Console.ReadLine();
            }

            Console.WriteLine("Maas daxil et");
            string employeeSalary = Console.ReadLine();
            double checkSalary;

            while (!(double.TryParse(employeeSalary, out checkSalary)) || checkSalary < 250)
            {
                Console.WriteLine("Maasi duzgun daxil et");
                employeeSalary = Console.ReadLine();
            }

            departmentManagementService.AddEmployee(employeeFullName, employeePosition, checkSalary, departmentName);


        }
        static void GetDepartments(ref DepartmentManagementService departmentManagementService)
        {
            if (departmentManagementService.Departments.Length > 0)
            {

                foreach (Department department in departmentManagementService.Departments)
                {
                    Console.WriteLine(department);
                }
            }
            else
            {
                Console.WriteLine("Evvelce department yaradin ...");

            }
        }
        public static void GetEmployees(ref DepartmentManagementService departmentManagementService)
        {
            foreach (var item in departmentManagementService.Departments)
            {
                foreach (var employee in item.GetEmployees())
                {
                    Console.WriteLine(employee);
                }
            }
        }
        public static void EditDepartments(ref DepartmentManagementService departmentManagementService)
        {
            if (departmentManagementService.Departments.Length > 0)
            {
                foreach (Department department in departmentManagementService.Departments)
                {
                    Console.WriteLine(department);
                }

            }
            else
            {
                Console.WriteLine("Department yarat");
            }
            Console.WriteLine("Evvelki department adini daxil et");
            string oldName = Console.ReadLine();
            Console.WriteLine("Yeni department adini daxil et");
            string newName = Console.ReadLine();

            departmentManagementService.EditDepartments(oldName, newName);
            Console.WriteLine("Department adi yenilendi");
        }
        static void RemoveEmployee(ref DepartmentManagementService departmentManagementService)
        {
            if (departmentManagementService.Departments.Length > 0)
            {
                foreach (var item in departmentManagementService.Departments)
                {
                    foreach (var employee in item.GetEmployees())
                    {
                        Console.WriteLine(employee);
                    }
                }

                Console.WriteLine("Department adini daxil edin: ");
                string departmentName = Console.ReadLine();
                Console.WriteLine("Isci nomresini daxil edin:");
                string removeEmployee = Console.ReadLine();
                departmentManagementService.RemoveEmployee(removeEmployee, departmentName);
            }
            else
            {
                Console.WriteLine("Once Deparment yarat");
            }
        }
        static void FindEmployee(ref DepartmentManagementService departmentManagementService)
        {
            if (departmentManagementService.Departments.Length > 0)
            {
                Console.WriteLine("Department adini daxil edin");
                
            }
            else
            {
                Console.WriteLine("Evvelce Deparment yarat");
            }
            string departmentsName = Console.ReadLine();

            if (departmentManagementService.FindEmployee(departmentsName)!= null)
            {
                foreach (Employee employee in departmentManagementService.FindEmployee(departmentsName))
                {
                    if (employee != null)
                    {
                        Console.WriteLine(employee);
                    }
                }
            }
            else
            {
                Console.WriteLine("Department movcud deyil");
            }
            
        }
        static void EditEmployee(ref DepartmentManagementService departmentManagementService)
        {
            if (departmentManagementService.Departments.Length > 0)
            {
                foreach (var item in departmentManagementService.Departments)
                {
                    foreach (var employee in item.GetEmployees())
                    {
                        Console.WriteLine(employee);
                    }
                }
            }
            else
            {
                Console.WriteLine("Evvelce Deparment yarat");
            }


            Console.WriteLine("Isci nomresini daxil et");
            string empNum = Console.ReadLine();
            Console.WriteLine("Yeni position daxil et");
            string newPos = Console.ReadLine();
            Console.WriteLine("Yeni maas daxil et");
            double newSalary;
            double.TryParse(Console.ReadLine(), out newSalary);
            Console.WriteLine("Department adini daxil edin");
            string depName = Console.ReadLine();

            



            departmentManagementService.EditEmployee(empNum, newPos, newSalary, depName);
            
        }

    }
}
