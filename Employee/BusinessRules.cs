// File Prologue
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
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Employee
{
    sealed class BusinessRules
    {
        private static BusinessRules businessRules = null;
        private const int MIN_ID = 10000;
        //private Sorted Dictionary employee;
        private SortedDictionary<uint, Employee> employee;

        /// <summary>
        /// Get Instance Class
        /// </summary>
        /// <returns>bussinessrules</returns>
        public static BusinessRules GetInstance()
        {
            if (null == businessRules)
            {
                businessRules = new BusinessRules();
            }
            return businessRules;
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
                    return employee[index];
                }
                else
                {
                    throw new Exception("Error. Unable to get employee Info");
                }
            }
            set
            {
                if ((index >= 0) && !(value.EmployeeType == ETYPE.NONE) && !employee.ContainsKey(index))// && (count < MAXINDEX))
                {
                    //employee.Add(value.EmpID, value);
                    employee[index] = value;
                }
                else
                {
                    MessageBox.Show("Employee ID is Already Used");
                }
            }
        }
        /// <summary>
        /// Private Constructor
        /// </summary>
        public BusinessRules()
        {
            //employee = new DArray();
            employee = new SortedDictionary<uint, Employee>();
        }
        public void Write()
        {
            File_IO.Write(employee);
        }
        public void Read()
        {
            File_IO.Read(ref employee);
        }
        public void ReadFromFile()
        {
            File_IO.ReadFromFile(ref employee);
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
                foreach (KeyValuePair<uint, Employee> item in employee)
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
