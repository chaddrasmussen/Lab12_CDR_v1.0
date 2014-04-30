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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Employee
{
    public partial class Employee_Editor : Form
    {
        //anti magic label and text box values
        string strContract = "Contract";
        string strHourly = "Hourly";
        string strSalary = "Salary";
        string strSales = "Sales";
        string strContractSalary = "Contract Salary";
        string strContractAgency = "Contract Agency";
        string strHourlyRate = "Hourly Rate";
        string strHoursWorked = "Hours Worked";
        string strMonthlySalary = "Monthly Salary";
        string strComSales = "Commission Sales";
        string strGrossSales = "Gross Sales";

        //anti magic error messages
        string defaultLabelValue = "value";
        string invalidEmpError = "Invalid Employee Type";
        string invalidTypError = "Invalid Type";
        string errorEnterName = "Please enter employee name";
        string errorMnthSalary = "Please enter in monthly salary";
        string errorHrlyRt = "Please enter in hourly rate";
        string errorHrsWrkd = "Please enter the hours worked";
        string errorCmmsnSales = "Please enter in commission sales";
        string errorGrssSales = "Please enter in gross sales";
        string errorCntrctSls = "Please enter in contract sales";
        string errorLowSalary = "Please enter in a salary greater than 1";
        string errorMaritalStatus = "Please Select Marital Status";
        string errorEnterDepartment = "Please Enter a Department";
        string errorEnterJobTitle = "Please Enter a Job Title";
        string errorCourseID = "Invalid Course ID";
        string errorGrade = "Please select the grade for the course";
        string errorCourseDescription = "Please enter a course description";
        string errorCredits = "Enter the amount of credits for the test";
        uint EmployeeID;
        string errorMessage = "";
        public Employee_Editor()
        {
            InitializeComponent();
        }
        public string EmpID_Edit_String 
        {
            get { return txtbxEmpID_1.Text; }
            set { txtbxEmpID_1.Text = value; }
        }
        public uint EmpID_Edit
        {
            get { return uint.Parse(txtbxEmpID_1.Text); }
            set { EmployeeID = uint.Parse(txtbxEmpID_1.Text); }
        }
        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            uint tempID = uint.Parse(txtbxEmpID_1.Text);
            BusinessRules.Instance.deleteEmp(tempID);
        }

        private void btnUpdateEmp_Click(object sender, EventArgs e)
        {
            Employee emp = null;
            if (!Regex.IsMatch(txtbxEmpID_1.Text, @"[0-9]{5}"))
            {
                errorMessage += "Enter a valid employee number";
                MessageBox.Show(errorMessage);
            }
            else
            {
                if (rbSalary_1.Checked)
                {
                    errorMessage = "";
                    if (cmbobxMaritalStatus_1.SelectedIndex == 0)
                    {
                        errorMessage += errorMaritalStatus + "\r\n";
                    }
                    if (txtboxDepartment_1.Text == "")
                    {
                        txtboxDepartment_1.BackColor = Color.Red;
                        errorMessage += errorEnterDepartment + "\r\n";
                    }
                    if (txtbxJobTitle_1.Text == "")
                    {
                        errorMessage += errorEnterJobTitle + "\r\n";
                    }
                    if (txtbxEmpName_1.Text == "")
                    {
                        txtbxEmpName_1.BackColor = Color.Red;
                        errorMessage += errorEnterName + "\r\n";
                    }
                    if (txtbxVal1_1.Text == "")
                    {
                        txtbxVal1_1.BackColor = Color.Red;
                        errorMessage += errorMnthSalary + "\r\n";
                    }
                    if (txtbxVal1_1.Text != "" && double.Parse(txtbxVal1_1.Text) <= 1)
                    {
                        txtbxVal1_1.BackColor = Color.Red;
                        errorMessage += errorLowSalary + "\r\n";
                        MessageBox.Show(errorMessage);
                    }
                    else if (txtbxEmpName_1.Text == "" || txtbxVal1_1.Text == "")
                    {
                        MessageBox.Show(errorMessage);
                    }
                    else
                    {
                        txtbxEmpName_1.BackColor = Color.White;
                        txtbxVal1_1.BackColor = Color.White;
                        emp = new Salary(txtbxEmpID_1.Text, txtbxEmpName_1.Text, txtboxDepartment_1.Text, txtbxJobTitle_1.Text, false, false, cmbobxMaritalStatus_1.SelectedIndex, txtbxVal1_1.Text);
                        BusinessRules.Instance.EditEmployee(emp);
                        this.Close();
                    }
                }
                else if (rbHourly_1.Checked)
                {
                    errorMessage = "";
                    if (cmbobxMaritalStatus_1.SelectedIndex == 0)
                    {
                        errorMessage += errorMaritalStatus + "\r\n";
                    }
                    if (txtboxDepartment_1.Text == "")
                    {
                        txtboxDepartment_1.BackColor = Color.Red;
                        errorMessage += errorEnterDepartment + "\r\n";
                    }
                    if (txtbxJobTitle_1.Text == "")
                    {
                        errorMessage += errorEnterJobTitle + "\r\n";
                    }
                    if (txtbxEmpName_1.Text == "")
                    {
                        txtbxEmpName_1.BackColor = Color.Red;
                        errorMessage += errorEnterName + "\r\n";
                    }
                    if (txtbxVal1_1.Text == "")
                    {
                        txtbxVal1_1.BackColor = Color.Red;
                        errorMessage += errorHrlyRt + "\r\n";
                    }
                    if (txtbxVal2_1.Text == "")
                    {
                        txtbxVal2_1.BackColor = Color.Red;
                        errorMessage += errorHrsWrkd;
                    }
                    if (txtbxEmpName_1.Text == "" || txtbxVal1_1.Text == "" || txtbxVal2_1.Text == "")
                    {
                        MessageBox.Show(errorMessage);
                    }
                    else
                    {
                        txtbxEmpName_1.BackColor = Color.White;
                        txtbxVal1_1.BackColor = Color.White;
                        txtbxVal2_1.BackColor = Color.White;
                        emp = new Hourly(txtbxEmpID_1.Text, txtbxEmpName_1.Text, txtboxDepartment_1.Text, txtbxJobTitle_1.Text, false, false, cmbobxMaritalStatus_1.SelectedIndex, txtbxVal1_1.Text, txtbxVal2_1.Text);
                        BusinessRules.Instance.EditEmployee(emp);
                        this.Close();
                    }
                }
                else if (rbSales_1.Checked)
                {
                    errorMessage = "";
                    if (cmbobxMaritalStatus_1.SelectedIndex == 0)
                    {
                        errorMessage += errorMaritalStatus + "\r\n";
                    }
                    if (txtboxDepartment_1.Text == "")
                    {
                        txtboxDepartment_1.BackColor = Color.Red;
                        errorMessage += errorEnterDepartment + "\r\n";
                    }
                    if (txtbxJobTitle_1.Text == "")
                    {
                        errorMessage += errorEnterJobTitle + "\r\n";
                    }
                    if (txtbxEmpName_1.Text == "")
                    {
                        txtbxEmpName_1.BackColor = Color.Red;
                        errorMessage += errorEnterName + "\r\n";
                    }
                    if (txtbxVal1_1.Text == "")
                    {
                        txtbxVal1_1.BackColor = Color.Red;
                        errorMessage += errorMnthSalary + "\r\n";
                    }
                    if (txtbxVal2_1.Text == "")
                    {
                        txtbxVal2_1.BackColor = Color.Red;
                        errorMessage += errorCmmsnSales + "\r\n";
                    }
                    if (txtbxVal3_1.Text == "")
                    {
                        txtbxVal3_1.BackColor = Color.Red;
                        errorMessage += errorGrssSales + "\r\n";
                    }

                    if (txtbxVal1_1.Text != "" && double.Parse(txtbxVal1_1.Text) <= 1)
                    {
                        txtbxVal1_1.BackColor = Color.Red;
                        errorMessage += errorLowSalary + "\r\n";
                        MessageBox.Show(errorMessage);
                    }
                    else if (txtbxEmpName_1.Text == "" || txtbxVal1_1.Text == "" || txtbxVal2_1.Text == "" || txtbxVal3_1.Text == "")
                    {
                        MessageBox.Show(errorMessage);
                    }
                    else
                    {
                        txtbxEmpName_1.BackColor = Color.White;
                        txtbxVal1_1.BackColor = Color.White;
                        txtbxVal2_1.BackColor = Color.White;
                        txtbxVal3_1.BackColor = Color.White;
                        emp = new Sales(txtbxEmpID_1.Text, txtbxEmpName_1.Text, txtboxDepartment_1.Text, txtbxJobTitle_1.Text, false, false, cmbobxMaritalStatus_1.SelectedIndex, txtbxVal1_1.Text, txtbxVal2_1.Text, txtbxVal3_1.Text);
                        BusinessRules.Instance.EditEmployee(emp);
                        this.Close();
                    }
                }
                else if (rbContract_1.Checked)
                {
                    errorMessage = "";
                    if (cmbobxMaritalStatus_1.SelectedIndex == 0)
                    {
                        errorMessage += errorMaritalStatus + "\r\n";
                    }
                    if (txtboxDepartment_1.Text == "")
                    {
                        txtboxDepartment_1.BackColor = Color.Red;
                        errorMessage += errorEnterDepartment + "\r\n";
                    }
                    if (txtbxJobTitle_1.Text == "")
                    {
                        errorMessage += errorEnterJobTitle + "\r\n";
                    }
                    if (txtbxEmpName_1.Text == "")
                    {
                        txtbxEmpName_1.BackColor = Color.Red;
                        errorMessage += errorEnterName + "\r\n";
                    }
                    if (txtbxVal1_1.Text == "")
                    {
                        txtbxVal1_1.BackColor = Color.Red;
                        errorMessage += errorCntrctSls + "\r\n";
                    }
                    if (txtbxEmpName_1.Text == "" || txtbxVal1_1.Text == "")
                    {
                        MessageBox.Show(errorMessage);
                    }
                    else
                    {
                        txtbxEmpName_1.BackColor = Color.White;
                        txtbxVal1_1.BackColor = Color.White;
                        emp = new Contract(txtbxEmpID_1.Text, txtbxEmpName_1.Text, txtboxDepartment_1.Text, txtbxJobTitle_1.Text, false, false, cmbobxMaritalStatus_1.SelectedIndex, txtbxVal1_1.Text, txtbxVal2_1.Text);
                        BusinessRules.Instance.EditEmployee(emp);
                        this.Close();
                    }
                }
            }            
            if (!rbContract_1.Checked && !rbHourly_1.Checked && !rbSalary_1.Checked && !rbSales_1.Checked)
            {
                MessageBox.Show(invalidEmpError);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Employee_Editor_Load(object sender, EventArgs e)
        {
            txtbxEmpID_1.Text = EmpID_Edit_String;
            uint empID = EmployeeID;
            txtbxEmpName_1.Text = BusinessRules.Instance[empID].EmployeeName;
            txtboxDepartment_1.Text = BusinessRules.Instance[empID].EmployeeDepartment;
            txtbxJobTitle_1.Text = BusinessRules.Instance[empID].EmployeeTitle;
            txtbxEmpType_1.Text = BusinessRules.Instance[empID].EmployeeType.ToString();
            switch (BusinessRules.Instance[empID].EmployeeType)
            {
                case ETYPE.CONTRACT:
                    rbContract_1.Checked = true;
                    txtbxVal1_1.Text = BusinessRules.Instance[empID].ContractSalary.ToString();
                    txtbxVal2_1.Text = BusinessRules.Instance[empID].ContractAgency.ToString();
                    break;
                case ETYPE.HOURLY:
                    rbHourly_1.Checked = true;
                    txtbxVal1_1.Text = BusinessRules.Instance[empID].HourlyRate.ToString();
                    txtbxVal2_1.Text = BusinessRules.Instance[empID].HoursWorked.ToString();
                    break;
                case ETYPE.SALARY:
                    rbSalary_1.Checked = true;
                    txtbxVal1_1.Text = BusinessRules.Instance[empID].MonthlySalary.ToString();
                    break;
                case ETYPE.SALES:
                    rbSales_1.Checked = true;
                    txtbxVal1_1.Text = BusinessRules.Instance[empID].MonthlySalary.ToString();
                    txtbxVal2_1.Text = BusinessRules.Instance[empID].GrossSales.ToString();
                    txtbxVal3_1.Text = BusinessRules.Instance[empID].SalesCommission.ToString();
                    break;
            }

        }
        private void resetValues()
        {
            txtbxVal2_1.Hide();
            txtbxVal3_1.Hide();
            lblVal2_1.Hide();
            lblVal3_1.Hide();
            txtbxJobTitle_1.Show();
            txtboxDepartment_1.Show();
            lblDepartment_1.Show();
            lblJobTitle_1.Show();
            txtbxJobTitle_1.Text = "";
            txtboxDepartment_1.Text = "";
            txtbxVal1_1.Text = "";
            txtbxVal2_1.Text = "";
            txtbxVal3_1.Text = "";
            txtbxEmpName_1.BackColor = Color.White;
            txtbxVal1_1.BackColor = Color.White;
            txtbxVal2_1.BackColor = Color.White;
            txtbxVal3_1.BackColor = Color.White;
        }
        private void rbSalary_1_CheckedChanged(object sender, EventArgs e)
        {
            resetValues();
            txtbxJobTitle_1.Show();
            txtboxDepartment_1.Show();
            lblDepartment_1.Show();
            lblJobTitle_1.Show();
            txtbxEmpType_1.Text = strSalary;
            lblVal1_1.Text = strMonthlySalary;
        }

        private void rbHourly_1_CheckedChanged(object sender, EventArgs e)
        {
            resetValues();
            txtbxJobTitle_1.Show();
            txtboxDepartment_1.Show();
            lblDepartment_1.Show();
            lblJobTitle_1.Show();
            txtbxEmpType_1.Text = strHourly;
            lblVal1_1.Text = strHourlyRate;
            lblVal2_1.Text = strHoursWorked;
            lblVal2_1.Show();
            txtbxVal2_1.Show();
        }

        private void rbSales_1_CheckedChanged(object sender, EventArgs e)
        {
            resetValues();
            txtbxJobTitle_1.Show();
            txtboxDepartment_1.Show();
            lblDepartment_1.Show();
            lblJobTitle_1.Show();
            txtbxEmpType_1.Text = strSales;
            lblVal1_1.Text = strMonthlySalary;
            lblVal3_1.Text = strGrossSales;
            lblVal2_1.Text = strComSales;
            lblVal2_1.Show();
            lblVal3_1.Show();
            txtbxVal2_1.Show();
            txtbxVal3_1.Show();
        }

        private void rbContract_1_CheckedChanged(object sender, EventArgs e)
        {
            resetValues();
            txtbxJobTitle_1.Show();
            txtboxDepartment_1.Show();
            lblDepartment_1.Show();
            lblJobTitle_1.Show();
            txtbxEmpType_1.Text = strContract;
            lblVal1_1.Text = strContractSalary;
            lblVal2_1.Text = strContractAgency;
            txtbxVal2_1.Show();
            lblVal2_1.Show();
        }
    }
}
