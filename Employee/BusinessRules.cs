// File Prologue
// Mason McEwen
// Lab12
// created 4/28/14
// CS 3260 section 001
//-----------------------------------------------
// I worked on this with Chad Rasmussen
// I declare that the following source code was written by me, or provided
// by the instructor for this project. I understand that copying 
// source code from any other source constitutes cheating, and that I will
// receive a zero grade on this project if I am found in violation of
// this policy
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Employee
{
    sealed class BusinessRules
    {
        /// <summary>
        /// Purpose: Creates a readonly instance of the business rules class
        /// </summary>
        private static readonly BusinessRules instance = new BusinessRules();
        /// <summary>
        /// Purpose: Default constructor
        /// </summary>
        private BusinessRules() { }
        /// <summary>
        /// Purpose: provides a way to access the readonly instance of the business rules class
        /// </summary>
        public static BusinessRules Instance
        {
            get { return instance; }
        }

        private const int MIN_ID = 10000;
        //private Sorted Dictionary employee;
        SortedDictionary<uint, Employee> employeeData = new SortedDictionary<uint, Employee>();
        public void EditEmployee(Employee emp)
        {
            employeeData[emp.EmployeeID] = emp;
        }
        /// <summary>
        /// Employee indexer
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Employee this[uint index]
        {
            get
            {
                if ((index >= 0))
                {
                    return employeeData[index];
                }
                else
                {
                    throw new Exception("Error. Unable to get employee Info");
                }
            }
            set
            {
                if ((index >= 0) && !(value.EmployeeType == ETYPE.NONE) && !employeeData.ContainsKey(index))// && (count < MAXINDEX))
                {
                    //employee.Add(value.EmpID, value);
                    employeeData[index] = value;
                }
                else
                {
                    MessageBox.Show("Employee ID is Already Used");
                }
            }
        }
        public void deleteEmp(uint i)
        {
            employeeData.Remove(i);
        }
        public void Write()
        {
            File_IO.Write(employeeData);
        }
        public void Read()
        {
            File_IO.Read(ref employeeData);
        }
        public void ReadFromFile()
        {
            File_IO.ReadFromFile(ref employeeData);
        }
        public SortedDictionary<uint, Employee> search(string s)
        {
            SortedDictionary<uint, Employee> l = new SortedDictionary<uint, Employee>();
            if (Regex.IsMatch(s, "[0-9]{5}"))
            {
                l.Add(uint.Parse(s), this[uint.Parse(s)]);
                return l;
            }
            else
            {
                s = s.ToUpper();
                foreach (KeyValuePair<uint, Employee> item in employeeData)
                {
                    if (item.Value.EmployeeName.ToUpper().Contains(s))
                    {
                        l.Add(item.Key, item.Value);
                    }
                }
            }
            return l;
        }
    }
}
