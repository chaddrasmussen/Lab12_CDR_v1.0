// File Prologue
// Chad Rasmussen
// Lab06
// created 4/21/14
// CS 3260 section 001
//-----------------------------------------------
// I declare that the following source code was written by me, or provided
// by the instructor for this project. I understand that copying 
// source code from any other source constitutes cheating, and that I will
// receive a zero grade on this project if I am found in violation of
// this policy
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
namespace Employee
{
    
    public partial class frmEmp : Form
    {
        const int HOURLYCREDITS = 3;
        const int SALARYCREDITS = 6;
        const int SALESCREDITS = 5;
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

        //regular variables
        int count = 0;
        string errorMessage;
        private TestData tData;
        private  List<Employee> employeeList;
        BusinessRules Singleton;
        private void frmEmp_Load(object sender, EventArgs e)
        {           
            tData = new TestData();
            employeeList = tData.GetEmployee;
            Singleton = new BusinessRules();
            Singleton.Read();
        }
        public frmEmp()
        {
            InitializeComponent();
            txtbxJobTitle.Show();
            txtboxDepartment.Show();
            lblDepartment.Show();
            lblJobTitle.Show();
            cmboboxGrade.SelectedIndex = 0;
            cmbobxMaritalStatus.SelectedIndex = 0;
        }
        /// <summary>
        /// allows only valid input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbxVal1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && txtbxVal1.Text.Contains("."))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && txtbxVal1.Text.Length < 1)
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// allows only valid input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbxVal2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!rbContract.Checked)
            {
                if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' && txtbxVal2.Text.Contains("."))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' && txtbxVal2.Text.Length < 1)
                {
                    e.Handled = true;
                }
            }   
        }
        /// <summary>
        /// allows only valid input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbxVal3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && txtbxVal3.Text.Contains("."))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && txtbxVal3.Text.Length < 1)
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// clears away text values, labels, and text boxes;
        /// </summary>
        private void resetValues()
        {
            txtbxVal2.Hide();
            txtbxVal3.Hide();
            lblVal2.Hide();
            lblVal3.Hide();
            txtbxJobTitle.Show();
            txtboxDepartment.Show();
            lblDepartment.Show();
            lblJobTitle.Show();
            txtbxJobTitle.Text = "";
            txtbxCourseID.Text = "";
            txtboxDepartment.Text = "";
            txtSearch.Text = "";
            txtbxVal1.Text = "";
            txtbxVal2.Text = "";
            txtbxVal3.Text = "";
            txtbxEmpName.BackColor = Color.White;
            txtbxVal1.BackColor = Color.White;
            txtbxVal2.BackColor = Color.White;
            txtbxVal3.BackColor = Color.White;
        }
        /// <summary>
        /// resets form for selected employee type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbContract_CheckedChanged(object sender, EventArgs e)
        {
            resetValues();
            txtbxJobTitle.Show();
            txtboxDepartment.Show();
            lblDepartment.Show();
            lblJobTitle.Show();
            txtbxEmpType.Text = strContract;
            lblVal1.Text = strContractSalary;
            lblVal2.Text = strContractAgency;
            txtbxVal2.Show();
            lblVal2.Show();
            
        }
        /// <summary>
        /// resets form for selected employee type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbHourly_CheckedChanged(object sender, EventArgs e)
        {
            resetValues();
            txtbxJobTitle.Show();
            txtboxDepartment.Show();
            lblDepartment.Show();
            lblJobTitle.Show();
            txtbxEmpType.Text = strHourly;
            lblVal1.Text = strHourlyRate; 
            lblVal2.Text = strHoursWorked;
            lblVal2.Show();
            txtbxVal2.Show();
        }
        /// <summary>
        /// resets form for selected employee type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbSalary_CheckedChanged(object sender, EventArgs e)
        {
            resetValues();
            txtbxJobTitle.Show();
            txtboxDepartment.Show();
            lblDepartment.Show();
            lblJobTitle.Show();
            txtbxEmpType.Text = strSalary;
            lblVal1.Text = strMonthlySalary;
        }
        /// <summary>
        /// resets form for selected employee type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbSales_CheckedChanged(object sender, EventArgs e)
        {
            resetValues();
            txtbxJobTitle.Show();
            txtboxDepartment.Show();
            lblDepartment.Show();
            lblJobTitle.Show();
            txtbxEmpType.Text = strSales;
            lblVal1.Text = strMonthlySalary;
            lblVal3.Text = strGrossSales;
            lblVal2.Text = strComSales;
            lblVal2.Show();
            lblVal3.Show();
            txtbxVal2.Show();
            txtbxVal3.Show();
        }
        /// <summary>
        /// clears data from all entries and sets them to null
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            rbContract.Checked = false;
            rbHourly.Checked = false;
            rbSalary.Checked = false;
            rbSales.Checked = false;
            cmbobxMaritalStatus.SelectedIndex = 0;         
            txtbxEmpName.Text = "";
            txtbxEmpType.Text = "";
            txtbxCourseCredits.Text = "";
            txtbxCourseID.Text = "";
            txtbxVal1.Text = "";
            txtbxVal2.Text = "";
            txtbxVal3.Text = "";
            txtbxVal1.Show();
            txtbxVal2.Show();
            txtbxVal3.Show();
            lblVal1.Show();
            lblVal2.Show();
            lblVal3.Show();  
            lblVal1.Text = defaultLabelValue;
            lblVal2.Text = defaultLabelValue;
            lblVal3.Text = defaultLabelValue;
            //rTxtBxEmpData.Text = rtxtBxDefaultText;
        }
        /// <summary>
        /// The test button will show the data from the employee object located at employeeList[count]
        /// each time the button is clicked count is increased until the entire array has been accessed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            if (count >= employeeList.Count)
            {
                btnClear_Click(sender, e);
                return;
            }
            txtbxEmpID.Text = employeeList[count].EmployeeID.ToString();
            employeeList[count].EmployeeID = uint.Parse(txtbxEmpID.Text);
            txtbxEmpName.Text = employeeList[count].EmployeeName;
            txtbxEmpType.Text = "" + employeeList[count].EmployeeType;

            switch (employeeList[count].EmployeeType)
            {
                case ETYPE.SALARY:
                    rbSalary_CheckedChanged(sender, e);
                    rbSalary.Checked = true;
                    txtbxVal1.Text = employeeList[count].MonthlySalary.ToString();
                    count++;
                    btnSave_Click(sender, e);
                    break;
                case ETYPE.HOURLY:
                    rbHourly_CheckedChanged(sender, e);
                    rbHourly.Checked = true;
                    txtbxVal1.Text = employeeList[count].HourlyRate.ToString();
                    txtbxVal2.Text = employeeList[count].HoursWorked.ToString();
                    count++;
                    btnSave_Click(sender, e);
                    break;
                case ETYPE.SALES:
                    rbSales_CheckedChanged(sender, e);
                    rbSales.Checked = true;
                    txtbxVal1.Text = employeeList[count].MonthlySalary.ToString();
                    txtbxVal2.Text = employeeList[count].SalesCommission.ToString();
                    txtbxVal3.Text = employeeList[count].GrossSales.ToString();
                    count++;
                    btnSave_Click(sender, e);
                    break;
                case ETYPE.CONTRACT:
                    rbContract_CheckedChanged(sender, e);
                    rbContract.Checked = true;
                    txtbxVal1.Text = employeeList[count].MonthlySalary.ToString();
                    count++;
                    btnSave_Click(sender, e);
                    break;
                case ETYPE.NONE:
                    rbSalary.Checked = false;
                    rbHourly.Checked = false;
                    rbSales.Checked = false;
                    rbContract.Checked = false;
                    txtbxEmpID.Text = "" + employeeList[count].EmployeeID;
                    txtbxEmpName.Text = employeeList[count].EmployeeName;
                    txtbxEmpType.Text = "" + employeeList[count].EmployeeType;
                    count++;
                    break;
                default:
                    rbSalary.Checked = false;
                    rbHourly.Checked = false;
                    rbSales.Checked = false;
                    rbContract.Checked = false;
                    MessageBox.Show(invalidEmpError, invalidTypError, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    txtbxEmpID.Clear();
                    txtbxEmpName.Clear();
                    txtbxEmpType.Text = "" + employeeList[count].EmployeeType;
                    count++;
                    break;
            }
        } //end btn test
        /// <summary>
        /// closes the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Checks that all visible fields have data, parses the data and saves to array
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Employee emp = null;
            
            if (!Regex.IsMatch(txtbxEmpID.Text,@"[0-9]{5}"))
            {
                errorMessage += "Enter a valid employee number";
                MessageBox.Show(errorMessage);
            }
            else
            {
                if (rbSalary.Checked)
                {
                    errorMessage = "";
                    if (cmbobxMaritalStatus.SelectedIndex == 0)
                    {
                        errorMessage += errorMaritalStatus + "\r\n";
                    }
                    if (txtboxDepartment.Text == "")
                    {
                        txtboxDepartment.BackColor = Color.Red;
                        errorMessage += errorEnterDepartment + "\r\n";
                    }
                    if (txtbxJobTitle.Text == "")
                    {
                        errorMessage += errorEnterJobTitle + "\r\n";
                    }
                    if (txtbxEmpName.Text == "")
                    {
                        txtbxEmpName.BackColor = Color.Red;
                        errorMessage += errorEnterName + "\r\n";
                    }
                    if (txtbxVal1.Text == "")
                    {
                        txtbxVal1.BackColor = Color.Red;
                        errorMessage += errorMnthSalary + "\r\n";
                    }
                    if (txtbxVal1.Text != "" && double.Parse(txtbxVal1.Text) <= 1)
                    {
                        txtbxVal1.BackColor = Color.Red;
                        errorMessage += errorLowSalary + "\r\n";
                        MessageBox.Show(errorMessage);
                    }
                    else if (txtbxEmpName.Text == "" || txtbxVal1.Text == "")
                    {
                        MessageBox.Show(errorMessage);
                    }
                    else
                    {
                        txtbxEmpName.BackColor = Color.White;
                        txtbxVal1.BackColor = Color.White;
                        emp = new Salary(txtbxEmpID.Text, txtbxEmpName.Text, txtboxDepartment.Text, txtbxJobTitle.Text, false, false, cmbobxMaritalStatus.SelectedIndex, txtbxVal1.Text);
                        Singleton[uint.Parse(txtbxEmpID.Text)] = emp;
                    }
                }
                else if (rbHourly.Checked)
                {
                    errorMessage = "";
                    if (cmbobxMaritalStatus.SelectedIndex == 0)
                    {
                        errorMessage += errorMaritalStatus + "\r\n";
                    }
                    if (txtboxDepartment.Text == "")
                    {
                        txtboxDepartment.BackColor = Color.Red;
                        errorMessage += errorEnterDepartment + "\r\n";
                    }
                    if (txtbxJobTitle.Text == "")
                    {
                        errorMessage += errorEnterJobTitle + "\r\n";
                    }
                    if (txtbxEmpName.Text == "")
                    {
                        txtbxEmpName.BackColor = Color.Red;
                        errorMessage += errorEnterName + "\r\n";
                    }
                    if (txtbxVal1.Text == "")
                    {
                        txtbxVal1.BackColor = Color.Red;
                        errorMessage += errorHrlyRt + "\r\n";
                    }
                    if (txtbxVal2.Text == "")
                    {
                        txtbxVal2.BackColor = Color.Red;
                        errorMessage += errorHrsWrkd;
                    }
                    if (txtbxEmpName.Text == "" || txtbxVal1.Text == "" || txtbxVal2.Text == "")
                    {
                        MessageBox.Show(errorMessage);
                    }
                    else
                    {
                        txtbxEmpName.BackColor = Color.White;
                        txtbxVal1.BackColor = Color.White;
                        txtbxVal2.BackColor = Color.White;
                        emp = new Hourly(txtbxEmpID.Text, txtbxEmpName.Text, txtboxDepartment.Text, txtbxJobTitle.Text, false, false, cmbobxMaritalStatus.SelectedIndex, txtbxVal1.Text, txtbxVal2.Text);
                        Singleton[uint.Parse(txtbxEmpID.Text)] = emp;                     
                    }
                }
                else if (rbSales.Checked)
                {
                    errorMessage = "";
                    if (cmbobxMaritalStatus.SelectedIndex == 0)
                    {
                        errorMessage += errorMaritalStatus + "\r\n";
                    }
                    if (txtboxDepartment.Text == "")
                    {
                        txtboxDepartment.BackColor = Color.Red;
                        errorMessage += errorEnterDepartment + "\r\n";
                    }
                    if (txtbxJobTitle.Text == "")
                    {
                        errorMessage += errorEnterJobTitle + "\r\n";
                    }
                    if (txtbxEmpName.Text == "")
                    {
                        txtbxEmpName.BackColor = Color.Red;
                        errorMessage += errorEnterName + "\r\n";
                    }
                    if (txtbxVal1.Text == "")
                    {
                        txtbxVal1.BackColor = Color.Red;
                        errorMessage += errorMnthSalary + "\r\n";
                    }
                    if (txtbxVal2.Text == "")
                    {
                        txtbxVal2.BackColor = Color.Red;
                        errorMessage += errorCmmsnSales + "\r\n";
                    }
                    if (txtbxVal3.Text == "")
                    {
                        txtbxVal3.BackColor = Color.Red;
                        errorMessage += errorGrssSales + "\r\n";
                    }

                    if (txtbxVal1.Text != "" && double.Parse(txtbxVal1.Text) <= 1)
                    {
                        txtbxVal1.BackColor = Color.Red;
                        errorMessage += errorLowSalary + "\r\n";
                        MessageBox.Show(errorMessage);
                    }
                    else if (txtbxEmpName.Text == "" || txtbxVal1.Text == "" || txtbxVal2.Text == "" || txtbxVal3.Text == "")
                    {
                        MessageBox.Show(errorMessage);
                    }
                    else
                    {
                        txtbxEmpName.BackColor = Color.White;
                        txtbxVal1.BackColor = Color.White;
                        txtbxVal2.BackColor = Color.White;
                        txtbxVal3.BackColor = Color.White;
                        emp = new Sales(txtbxEmpID.Text, txtbxEmpName.Text, txtboxDepartment.Text, txtbxJobTitle.Text, false, false, cmbobxMaritalStatus.SelectedIndex, txtbxVal1.Text, txtbxVal2.Text, txtbxVal3.Text);
                        Singleton[uint.Parse(txtbxEmpID.Text)] = emp;               
                    }
                }
                else if (rbContract.Checked)
                {
                    errorMessage = "";
                    if (cmbobxMaritalStatus.SelectedIndex == 0)
                    {
                        errorMessage += errorMaritalStatus + "\r\n";
                    }
                    if (txtboxDepartment.Text == "")
                    {
                        txtboxDepartment.BackColor = Color.Red;
                        errorMessage += errorEnterDepartment + "\r\n";
                    }
                    if (txtbxJobTitle.Text == "")
                    {
                        errorMessage += errorEnterJobTitle + "\r\n";
                    }
                    if (txtbxEmpName.Text == "")
                    {
                        txtbxEmpName.BackColor = Color.Red;
                        errorMessage += errorEnterName + "\r\n";
                    }
                    if (txtbxVal1.Text == "")
                    {
                        txtbxVal1.BackColor = Color.Red;
                        errorMessage += errorCntrctSls + "\r\n";
                    }
                    if (txtbxEmpName.Text == "" || txtbxVal1.Text == "")
                    {
                        MessageBox.Show(errorMessage);
                    }
                    else
                    {
                        txtbxEmpName.BackColor = Color.White;
                        txtbxVal1.BackColor = Color.White;
                        emp = new Contract(txtbxEmpID.Text, txtbxEmpName.Text, txtboxDepartment.Text, txtbxJobTitle.Text, false, false, cmbobxMaritalStatus.SelectedIndex, txtbxVal1.Text, txtbxVal2.Text);
                        Singleton[uint.Parse(txtbxEmpID.Text)] = emp;
                        //rTxtBxEmpData.AppendText(BusinessRules.Instance[empID].EmployeeID + "\r\n");
                        //rTxtBxEmpData.AppendText(BusinessRules.Instance[empID].EmployeeName + "\r\n");
                        //rTxtBxEmpData.AppendText(BusinessRules.Instance[empID].EmployeeType + "\r\n");
                        //rTxtBxEmpData.AppendText(BusinessRules.Instance[empID].ContractSalary + "\r\n");
                    }
                }
            }            
            if (!rbContract.Checked && !rbHourly.Checked && !rbSalary.Checked && !rbSales.Checked)
            {
                MessageBox.Show(invalidEmpError);
            }
            resetValues();
        }
        private void btnSaveEducation_Click(object sender, EventArgs e)
        {
            errorMessage = "";
            txtbxCourseID.Text = txtbxCourseID.Text.ToUpper();
            if (Regex.IsMatch(txtbxCourseID.Text, @"^[A-Z]{2}\s[0-9]{4}") && txtCourseDescription.Text != "" && cmboboxGrade.SelectedIndex != 0 && Regex.IsMatch(txtbxCourseCredits.Text, @"^[0-9]{1}"))
            {
                uint empIndex = uint.Parse(txtboxEmpIDEducation.Text);
                try
                {
                    Singleton[empIndex].EmployeeCoursesTaken.Add(txtbxCourseID.Text, new Education(txtbxCourseID.Text, txtCourseDescription.Text, cmboboxGrade.SelectedIndex, int.Parse(txtbxCourseCredits.Text)));
                    Singleton[empIndex].TotalCredits += int.Parse(txtbxCourseCredits.Text);
                    switch (Singleton[empIndex].EmployeeType)
                    {
                        case ETYPE.HOURLY:
                            if (Singleton[empIndex].TotalCredits >= HOURLYCREDITS)
                            {
                                rbBenefitsTrue.Checked = true;
                            }
                            else
                            {
                                rbBenefitsTrue.Checked = false;
                            }
                            break;
                        case ETYPE.SALARY:
                            if (Singleton[empIndex].TotalCredits >= SALARYCREDITS)
                            {
                                rbBenefitsTrue.Checked = true;
                            }
                            else
                            {
                                rbBenefitsTrue.Checked = false;
                            }
                            break;
                        case ETYPE.SALES:
                            if (Singleton[empIndex].TotalCredits >= SALESCREDITS)
                            {
                                rbBenefitsTrue.Checked = true;
                            }
                            else
                            {
                                rbBenefitsTrue.Checked = false;
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch
                {
                    MessageBox.Show("course Id already exists");
                    return;
                }
                txtbxCourseID.Text = "";
                txtCourseDescription.Text = "";
                cmboboxGrade.SelectedIndex = 0;
                txtbxCourseCredits.Text = "";
                return;
            }
            if (txtCourseDescription.Text == "")
            {
                txtCourseDescription.BackColor = Color.Red;
                errorMessage += errorCourseDescription + "\r\n";
            }
            if (!Regex.IsMatch(txtbxCourseID.Text, @"^[A-Z]{2}\s[0-9]{4}"))
            {
                txtbxCourseID.BackColor = Color.Red;
                errorMessage += errorCourseID +"\r\n";
            }
            if (!Regex.IsMatch(txtbxCourseCredits.Text, @"^[0-9]{1}"))
            {
                txtbxCourseCredits.BackColor = Color.Red;
                errorMessage += errorCredits+ "\r\n";
            }                   
            if (cmboboxGrade.SelectedIndex == 0)
            {
                cmboboxGrade.BackColor = Color.Red;
                errorMessage += errorGrade + "\r\n";
            }
            if (!Regex.IsMatch(txtbxCourseID.Text, @"^[A-Z]{2}\s[0-9]{4}") || txtCourseDescription.Text == "" || cmboboxGrade.SelectedIndex == 0 || !Regex.IsMatch(txtbxCourseCredits.Text, @"^[0-9]{1}"))
            {
                MessageBox.Show(errorMessage);
                txtbxCourseID.Text = "";
                txtCourseDescription.Text = "";
                cmboboxGrade.SelectedIndex = 0;
                txtbxCourseCredits.Text = "";
                txtCourseDescription.BackColor = Color.White;
                txtbxCourseID.BackColor = Color.White;
                txtbxCourseCredits.BackColor = Color.White;
                cmboboxGrade.BackColor = Color.White;
            }
        }
        private void btnSearchEmpData_Click(object sender, EventArgs e)
        {
            txtbxEmpData.Clear();
            SortedDictionary<uint, Employee> temp = Singleton.search(txtbxSearchEmp.Text);
            foreach (KeyValuePair<uint, Employee> n in temp)
            {
                if (n.Value != null)
                {
                    
                    txtbxEmpData.Text += "ID: " + n.Key.ToString() + "\nName: " + n.Value.EmployeeName + "\n";
                    string courses = "Courses Taken\n";
                    switch (n.Value.EmployeeType)
                    {
                        case ETYPE.SALARY:
                            
                            foreach(KeyValuePair<string,Education> o in n.Value.EmployeeCoursesTaken)
                            {
                                courses += "   Description: " + o.Value.CourseDescription.ToString() + "\n";
                                courses += "   ID: " + o.Value.CourseID + "\n" + "  Grade: " + o.Value.CourseGrade + "\n" + "  Credits: " + o.Value.CourseCredits + "\n";
                                courses += "   Approval Date: " + o.Value.ApprovalDate.ToShortDateString() + "\n\n";
                            }
                            txtbxEmpData.Text += "Monthly Salary: " + n.Value.MonthlySalary.ToString("C") +"\n" + n.Value.TotalCredits.ToString() + "\n" + courses + "\n\n";
                            break;
                        case ETYPE.HOURLY:
                            foreach(KeyValuePair<string,Education> o in n.Value.EmployeeCoursesTaken)
                            {
                                
                                courses += "   Description: " + o.Value.CourseDescription.ToString() + "\n";
                                courses += "   ID: " + o.Value.CourseID + "   " + "Grade: " + o.Value.CourseGrade + "\n";
                                courses += "   Approval Date: " + o.Value.ApprovalDate.ToShortDateString() + "\n\n";
                            }
                            txtbxEmpData.Text += "Rate: " + n.Value.HourlyRate.ToString("C") + "\nHours Worked: " + n.Value.HoursWorked + "\n" + courses + "\n\n";
                            break;
                        case ETYPE.CONTRACT:
                            txtbxEmpData.Text += "Contract: " + n.Value.ContractSalary.ToString("C") + "\n\n";
                            break;
                        case ETYPE.SALES:
                            foreach(KeyValuePair<string,Education> o in n.Value.EmployeeCoursesTaken)
                            {
                                
                                courses += "   Description: " + o.Value.CourseDescription.ToString() + "\n";
                                courses += "   ID: " + o.Value.CourseID + "   " + "Grade: " + o.Value.CourseGrade + "\n";
                                courses += "   Approval Date: " + o.Value.ApprovalDate.ToShortDateString() + "\n\n";
                            }
                            txtbxEmpData.Text += "Commission: " + n.Value.SalesCommission + "%\nGross Sales: " + n.Value.GrossSales.ToString("C") +
                                "\nMonthly Salary: " + n.Value.MonthlySalary.ToString("C") + "\n" + courses + "\n\n";
                            break;
                        default: break;
                    }


                }
            }
        }
        private void frmEmp_FormClosing(object sender, FormClosingEventArgs e)
        {
            Singleton.Write();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            lstbxEmployeeData.Items.Clear();
            SortedDictionary<uint, Employee> temp = Singleton.search(txtSearch.Text);
            foreach (KeyValuePair<uint, Employee> n in temp)
            {
                if (n.Value != null)
                {
                    if(n.Value.EmployeeType != ETYPE.CONTRACT)
                        lstbxEmployeeData.Items.Add(n.Value.EmployeeID + "\t" + n.Value.EmployeeName);
                }
            }
        }
        private void lstbxEmployeeData_SelectedIndexChanged(object sender, EventArgs e)
        {
            int courseCredits;
            string tempEmpID = lstbxEmployeeData.SelectedItem.ToString();
            string myValue = tempEmpID.Substring(0, 5);
            txtboxEmpIDEducation.Text = myValue;
            
        }

        private void lstbxEmployeeData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string tempEmpID = lstbxEmployeeData.SelectedItem.ToString();
            string myValue = tempEmpID.Substring(0, 5);
            Employee_Editor edit = new Employee_Editor();
            edit.EmpID_Edit = myValue;
            edit.Show();
        } //end save button
    }
}
