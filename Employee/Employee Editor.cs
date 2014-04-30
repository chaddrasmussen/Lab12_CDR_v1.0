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
        BusinessRules Singleton;
        string errorMessage = "";
        public Employee_Editor()
        {
            InitializeComponent();
            txtbxEmpID_1.Text = EmpID_Edit.ToString();
            Singleton = new BusinessRules();
        }
        public string EmpID_Edit 
        {
            get { return txtbxEmpID_1.Text; }
            set { txtbxEmpID_1.Text = value; }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateEmp_Click(object sender, EventArgs e)
        {
            Employee emp = null;
            //if ()
            //{
                
            //}
            if (!Regex.IsMatch(txtbxEmpID_1.Text,@"[0-9]{5}"))
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
                        Singleton[uint.Parse(txtbxEmpID_1.Text)] = emp;
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
                        Singleton[uint.Parse(txtbxEmpID_1.Text)] = emp;
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
                        Singleton[uint.Parse(txtbxEmpID_1.Text)] = emp;
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
                        Singleton[uint.Parse(txtbxEmpID_1.Text)] = emp;
                        this.Close();
                    }
                }
            }            
            if (!rbContract_1.Checked && !rbHourly_1.Checked && !rbSalary_1.Checked && !rbSales_1.Checked)
            {
                MessageBox.Show(invalidEmpError);
            }
            
        }
    }
}
