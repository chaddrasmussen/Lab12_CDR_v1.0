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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{   
    public enum ETYPE
    {
        SALARY = 1, SALES, HOURLY, CONTRACT, NONE, BAD
    }
    public enum M_STATUS
    {
        MARRIED = 1, SINGLE, DIVORCED, WIDOWED, NONE
    }
    [Serializable]
    public abstract class Employee : object
    {    
        //--------------------------------------Member properties----------------
        // Property for Employee ID
        public uint EmployeeID { get; set; }
        // Property for Employee Type - see ETYPE
        public ETYPE EmployeeType { get; set; }
        // Property for Employee Name
        public string EmployeeName { get; set; }
        // Property for Employee Marital Status
        public M_STATUS EmployeeMaritalStatus { get; set; }
        // Property for employee Department name
        public string EmployeeDepartment { get; set; }
        // Property for employee title
        public string EmployeeTitle { get; set; }
        // Property for employee benefits
        public bool EmployeeBenefits { get; set; }
        // Property for coursesTaken/Approved
        public SortedDictionary<string,Education> EmployeeCoursesTaken { get; set; }
        // property for if employee attended UVU
        public bool EmployeeSchool { get; set; }
        //------------------------------------Constructors------------------------
        // Default Constructor
        public Employee()
            : base()
        {   
            EmployeeID = default(uint);
            EmployeeName = default(string);
            EmployeeType = ETYPE.NONE;
            EmployeeMaritalStatus = M_STATUS.NONE;
            EmployeeDepartment = default(string);
            EmployeeTitle = default(string);
            EmployeeBenefits = default(bool);
            EmployeeSchool = default(bool);
            EmployeeCoursesTaken = new SortedDictionary<string, Education>();
        }
        // Parameterized Constructor
        // param name "employeeID" - the EmployeeID
        // param name "employeeName" - the EmployeeName
        public Employee(uint employeeID, string employeeName, string employeeDepartment, string employeeTitle, bool employeeBenefits, bool employeeSchool, int maritalIndex)
        {
            EmployeeID = employeeID;
            EmployeeName = employeeName;
            EmployeeType = ETYPE.NONE;
            EmployeeMaritalStatus = M_STATUS.NONE;
            EmployeeDepartment = employeeDepartment;
            EmployeeTitle = employeeTitle;
            EmployeeBenefits = employeeBenefits;
            EmployeeCoursesTaken = new SortedDictionary<string, Education>();
            EmployeeMaritalStatus = (M_STATUS)maritalIndex;
        }

        // Paramaterized Constructor - with all string parameters
        // This is to take data from the form and convert it to correct data types
        public Employee(string employeeID, string employeeName, string employeeDepartment, string employeeTitle, bool employeeBenefits, bool employeeSchool, int maritalIndex)
            : base()
        {
            EmployeeID = uint.Parse(employeeID);
            EmployeeName = employeeName;
            EmployeeType = ETYPE.NONE;
            EmployeeMaritalStatus = M_STATUS.NONE;
            EmployeeDepartment = employeeDepartment;
            EmployeeTitle = employeeTitle;
            EmployeeBenefits = employeeBenefits;
            EmployeeCoursesTaken = new SortedDictionary<string, Education>();
            EmployeeMaritalStatus = (M_STATUS)maritalIndex;
        }       
         //-------------------------------------virtual member properties-------
         //All the virtual properties below are overriden in derived classes
         //Salary virtual members
         virtual public decimal MonthlySalary { get; set; }
         //hourly virtual members
         virtual public decimal HourlyRate { get; set; }
         virtual public double HoursWorked { get; set; }
         //sales virtual members
         virtual public double SalesCommission { get; set; }
         virtual public decimal GrossSales { get; set; }
         //contract virtual members
         virtual public decimal ContractSalary { get; set; }
         virtual public string ContractAgency { get; set; }
         virtual public int TotalCredits { get; set; }
     }// end class employee 
    // Derived class for hourly employees
    [Serializable]
    sealed class Hourly : Employee
    {
        //--------------Member Properties-----------------------
        public override decimal HourlyRate { get; set; }
        public override double HoursWorked { get; set; }
        public override int TotalCredits { get; set;}
            
        //--------------Default Constructor---------------------
        public Hourly()
            : base()
        {
            HourlyRate = default(decimal);
            HoursWorked = default(double);
            EmployeeType = ETYPE.HOURLY;
            EmployeeMaritalStatus = M_STATUS.NONE;
            TotalCredits = default(int);
            
        }
        //--------------Paremeterized Constructor---------------------
        public Hourly(uint employeeID, string employeeName, string employeeDepartment, string employeeTitle, bool employeeBenefits,bool employeeSchool, int maritalIndex, decimal hourlyRate, double hoursWorked)
            : base(employeeID, employeeName, employeeDepartment, employeeTitle, employeeBenefits, employeeSchool, maritalIndex)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
            EmployeeType = ETYPE.HOURLY;
            EmployeeMaritalStatus = (M_STATUS)maritalIndex;
        }
        //--------------Paremeterized Constructor---------------------
        public Hourly(string employeeID, string employeeName, string employeeDepartment, string employeeTitle, bool employeeBenefits, bool employeeSchool, int maritalIndex, string hourlyRate, string hoursWorked)
            : base(employeeID, employeeName, employeeDepartment, employeeTitle, employeeBenefits, employeeSchool, maritalIndex)
        {
            HourlyRate = decimal.Parse(hourlyRate);
            HoursWorked = double.Parse(hoursWorked);
            EmployeeType = ETYPE.HOURLY;
            EmployeeMaritalStatus = (M_STATUS)maritalIndex;
        }
    }
    [Serializable]
    sealed class Contract : Employee
    {
        public override string ContractAgency { get; set; }
        public override decimal ContractSalary { get; set; }
        //--------------Default Constructor---------------------
        public Contract()
            : base()
        {
            ContractAgency = default(string);
            ContractSalary = default(decimal);
            TotalCredits = default(int);
        }
        //--------------Paremeterized Constructor---------------------
        public Contract(uint employeeID, string employeeName, string employeeDepartment, string employeeTitle, bool employeeBenefits, bool employeeSchool,int maritalIndex, decimal contractSalary, string contractAgency)
            : base(employeeID, employeeName, employeeDepartment, employeeTitle, employeeBenefits, employeeSchool, maritalIndex)
        {
            ContractAgency = contractAgency;
            ContractSalary = contractSalary;
            EmployeeType = ETYPE.CONTRACT;
        }
        //--------------Paremeterized Constructor---------------------
        public Contract(string employeeID, string employeeName, string employeeDepartment, string employeeTitle, bool employeeBenefits, bool employeeSchool, int maritalIndex, string contractSalary, string contractAgency)
            : base(employeeID, employeeName, employeeDepartment, employeeTitle, employeeBenefits, employeeSchool, maritalIndex)
        {
            ContractAgency = contractAgency;
            ContractSalary = decimal.Parse(contractSalary);
            EmployeeType = ETYPE.CONTRACT;
        }
    }
    [Serializable]
    class Salary : Employee
    {
        public override decimal MonthlySalary { get; set; }
        public override int TotalCredits { get; set; }
        //--------------Default Constructor---------------------
        public Salary()
            : base()
        {
            TotalCredits = default(int);
            MonthlySalary = default(decimal);
            EmployeeType = ETYPE.SALARY;
        }
        //--------------Paremeterized Constructor---------------------
        public Salary(uint employeeID, string employeeName, string employeeDepartment, string employeeTitle, bool employeeBenefits, bool employeeSchool,int maritalIndex, decimal monthlySalary)
            : base(employeeID, employeeName, employeeDepartment, employeeTitle, employeeBenefits, employeeSchool, maritalIndex)
        {
            MonthlySalary = monthlySalary;
            EmployeeType = ETYPE.SALARY;
        }
        //--------------Paremeterized Constructor---------------------
        public Salary(string employeeID, string employeeName, string employeeDepartment, string employeeTitle, bool employeeBenefits, bool employeeSchool, int maritalIndex, string monthlySalary)
            : base(employeeID, employeeName, employeeDepartment, employeeTitle, employeeBenefits, employeeSchool, maritalIndex)
        {
            MonthlySalary = decimal.Parse(monthlySalary);
            EmployeeType = ETYPE.SALARY;
        }
    }//end salary class
    [Serializable]
    sealed class Sales : Salary
    {
        public override double SalesCommission { get; set; }
        public override decimal GrossSales { get; set; }
        public override int TotalCredits { get; set; }
        //--------------Default Constructor---------------------
        public Sales()
            : base()
        {
            TotalCredits = default(int);
            SalesCommission = default(double);
            GrossSales = default(decimal);
            EmployeeType = ETYPE.SALES;
        }
        //--------------Paremeterized Constructor---------------------
        public Sales(uint employeeID, string employeeName, string employeeDepartment, string employeeTitle, bool employeeBenefits,  bool employeeSchool, int maritalIndex, decimal monthlySalary, double salesCommission, decimal grossSales)
            : base(employeeID, employeeName, employeeDepartment, employeeTitle, employeeBenefits, employeeSchool, maritalIndex, monthlySalary)
        {
            SalesCommission = salesCommission;
            GrossSales = grossSales;
            EmployeeType = ETYPE.SALES;

        }
        //--------------Paremeterized Constructor---------------------
        public Sales(string employeeID, string employeeName, string employeeDepartment, string employeeTitle, bool employeeBenefits, bool employeeSchool, int maritalIndex, string monthlySalary, string salesCommission, string grossSales)
            : base(employeeID, employeeName, employeeDepartment, employeeTitle, employeeBenefits, employeeSchool, maritalIndex, monthlySalary)
        {
            SalesCommission = double.Parse(salesCommission);
            GrossSales = decimal.Parse(grossSales);
            EmployeeType = ETYPE.SALES;
        }
    }//end sales class
}
