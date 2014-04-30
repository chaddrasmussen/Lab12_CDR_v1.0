﻿// File Prologue
// Chad Rasmussen
// Lab12
// created 4/28/14
// CS 3260 section 001
//-----------------------------------------------
// I declare that the following source code was written by me, or provided
// by the instructor for this project. I understand that copying 
// source code from any other source constitutes cheating, and that I will
// receive a zero grade on this project if I am found in violation of
// this policy
using System;
using System.Collections.Generic;
namespace Employee
{
    /// <summary>
    /// a class that creates test employee objects
    /// </summary>
    class TestData
    {
        public List<Employee> employeeData;
        public List<Employee> GetEmployee { get { return employeeData; } }

        /// <summary>
        /// creates an employee data list and fills with employee objects.
        /// </summary>
        public TestData()
        {
            employeeData = new List<Employee>();
            employeeData.Add(new Salary(10000, "Roy", "I.T.", "Irishman", false, false, 2, 1000));
            employeeData.Add(new Hourly(10001, "Moss", "I.T.", "Fire!", false, false, 15, 2, 40));
            employeeData.Add(new Sales(10002, "Jen", "I.T.", "Relationship Manager", false, false, 2, 800, 50, 20));
            employeeData.Add(new Contract(10003, "Mr. Renham", "Management", "C.E.O", false, false, 3, 50000, "D.O.C."));
            Employee tempEmp = new Salary();
            tempEmp.EmployeeType = ETYPE.NONE;
            employeeData.Add(tempEmp);
            tempEmp = new Salary();
            tempEmp.EmployeeType = ETYPE.BAD;
            employeeData.Add(tempEmp);
        }
    }
}
