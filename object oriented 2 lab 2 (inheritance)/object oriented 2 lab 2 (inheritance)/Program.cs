using object_oriented_2_lab_2__inheritance_.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace object_oriented_2_lab_2__inheritance_
{

    internal class Program
    {
        private static double salariedCount;
        private static double wagedCount;
        private static double partTimeCount;
        private static double salariedEmployees;
        private static double totalEmployees;
        private static double wagedEmployees;
        private static double partTimeEmployees;

        static void Main(string[] args)
        {
            // Relative path to employees.txt file
            string path = "employees.txt";

            // Get lines/rows in file as string array
            string[] lines = File.ReadAllLines(path);

            // Create list that holds any type of Employee
            List<Employee> employees = new List<Employee>();

            // Loop through each line/row
            foreach (string line in lines)
            {
                // Extract each part/cell from line/row
                string[] parts = line.Split(':');

                // First part is ID
                string id = parts[0];

                // Second part is name
                string name = parts[1];

                // TODO: Get remaining employee info from parts

                // Get first digit of ID
                string firstDigit;

                firstDigit = id.Substring(0, 1);

                /*if (firstDigit == "0" || firstDigit == "1" || firstDigit == "2" || firstDigit == "3" || firstDigit == "4")
                {
                }*/

                // Convert first digit from string to int.
                int firstDigitNum = int.Parse(firstDigit);

                // Test what range first digit falls into
                if (firstDigitNum >= 0 && firstDigitNum <= 4)
                {
                    // Salaried
                    double salary = double.Parse(parts[7]);

                    // Create instance of Salaried
                    Salaried salaried;

                    salaried = new Salaried(id, name, salary);

                    // Add to employees
                    employees.Add(salaried);
                }
                else if (firstDigitNum >= 5 && firstDigitNum <= 7)
                {
                    // Waged
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);

                    // TODO: Create Waged instance and add it to employee list.
                    Waged waged = new Waged(id, name, rate, hours);
                    employees.Add(waged);
                }
                else if (firstDigitNum >= 8 && firstDigitNum <= 9)
                {
                    // Part time
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);

                    // Create PartTime instance and add it to employee list.
                    PartTime partTime = new PartTime(id, name, rate, hours);
                    employees.Add(partTime);
                }


            }



            

            double averageWeeklyPay = CalcAverageWeeklyPay(employees);

            Console.WriteLine(string.Format("Average weekly pay: {0:C2}", averageWeeklyPay));

            Employee highestPaidWagedEmployee = FindHighestPaid(employees);

            double highestWagedPay = highestPaidWagedEmployee.Pay;



            Console.WriteLine("Highest waged pay: " + highestWagedPay.ToString("C2"));
            Console.WriteLine("Highest waged employee: " + highestPaidWagedEmployee.Name);



            Employee lowestSalariedEmployee = FindLowestPaid(employees);

            double lowestSalariedPay = lowestSalariedEmployee.Pay;

            Console.WriteLine("Lowest Salaried pay: " + lowestSalariedPay.ToString("C2"));
            Console.WriteLine("Lowest Salaried employee: " + lowestSalariedEmployee.Name);

            DetermineEmployeePercentage(employees);
            Console.ReadLine();

            Console.ReadKey();

            int totalCount = employees.Count;
            decimal salariedPercentage = (decimal)salariedCount / totalCount * 100;
            decimal partTimePercentage = (decimal)partTimeCount / totalCount * 100;
            decimal wagedPercentage = (decimal)wagedCount / totalCount * 100;

            Console.WriteLine("Salaried Employee Percentage: " + salariedPercentage + "%");
            Console.WriteLine("Wages Employee Percentage: " + wagedPercentage + "%");
            Console.WriteLine("Part Time Employee Percentage: " + partTimePercentage + "%");
            ;





        }

        private static double CalcAverageWeeklyPay(List<Employee> employees)
        {
            double weeklyPaySum = 0;

            // It's okay to use loop through employees multiple times.
            foreach (Employee employee in employees)
            {
                if (employee is PartTime partTime)
                {
                    //PartTime partTime= (PartTime)employee;
                    double pay = partTime.Pay;
                    weeklyPaySum += pay;
                }
                else if (employee is Waged waged)
                {
                    double pay = waged.Pay;

                    weeklyPaySum += pay;
                }
                else if (employee is Salaried salaried)
                {
                    double pay = salaried.Pay;

                    weeklyPaySum += pay;
                }
            }

            double averageWeeklyPay = weeklyPaySum / employees.Count;

            return averageWeeklyPay;
        }

        private static Waged FindHighestPaid(List<Employee> employees)
        {
            double highestWagedPay = 0;
            Waged highestWagedEmployee = null;

            foreach (Employee employee in employees)
            {
                if (employee is Waged waged)
                {
                    double pay = waged.Pay;

                    if (pay > highestWagedPay)
                    {
                        highestWagedPay = pay;
                        highestWagedEmployee = waged;
                    }
                }
            }

            return highestWagedEmployee;
        }

        private static Salaried FindLowestPaid(List<Employee> employees)
        {

            double lowestSalariedPay = double.MaxValue;

            Salaried lowestSalariedEmployee = null;

            foreach (Employee employee in employees)
            {

                if (employee is Salaried salaried)
                {
                    double salary = salaried.Pay;


                    if (salary < lowestSalariedPay)
                    {
                        lowestSalariedPay = salary;
                        lowestSalariedEmployee = salaried;
                    }
                }
            }

            return lowestSalariedEmployee;
        }

        private static void DetermineEmployeePercentage(List<Employee> employees)
        {
            
            int salariedEmployees = 0;
            int wagedEmployees = 0;
            int partTimeEmployees = 0;

            foreach (Employee employee in employees)
            {
                if (employee is Salaried)
                {
                    salariedCount++;
                }
                else if (employee is PartTime)
                {
                    partTimeCount++;
                }
                else if (employee is Waged)
                {
                    wagedCount++;
                }

            }
            int totalCount = employees.Count;
            decimal salariedPercentage = (decimal)salariedCount / totalCount * 100;
            decimal partTimePercentage = (decimal)partTimeCount / totalCount * 100;
            decimal wagedPercentage = (decimal)wagedCount / totalCount * 100;

            Console.WriteLine("Percentage of salaried employees: " + salariedPercentage + "%");
            Console.WriteLine("Percentage of waged employees: " + wagedPercentage + "%");
            Console.WriteLine("Percentage of part-time employees: " + partTimePercentage + "%");

            ;



        }
    }
}

