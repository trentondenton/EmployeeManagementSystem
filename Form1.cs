using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace Denton_CourseProject_Part2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void WriteEmpsToFile()
        {

            List<Employee> employees = new List<Employee>();
            foreach (Employee emp in EmployeesListBox.Items)
            {
                employees.Add(emp);
            }

            FileStream fs = new FileStream("EmployeeData.bin", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, employees);
            fs.Close();
        }

        private void ReadEmpsFromFile()
        {
            if (File.Exists("EmployeeData.bin") && new FileInfo("EmployeeData.bin").Length > 0)
            {
                FileStream fs = new FileStream("EmployeeData.bin", FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                List<Employee> employees = (List<Employee>)formatter.Deserialize(fs);
                fs.Close();

                foreach(Employee emp in employees)
                {
                    EmployeesListBox.Items.Add(emp);
                }
                
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            InputForm frmInput = new InputForm();
            using (frmInput)
            {
                DialogResult result = frmInput.ShowDialog();
                //Cancel Clicked
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                //Add Clicked. Create Employee Information
                string fname = frmInput.FirstNameTextBox.Text;
                string lname = frmInput.LastNameTextBox.Text;
                string ssn = frmInput.SSNTextBox.Text;
                string date = frmInput.HireDateTextBox.Text;
                DateTime hireDate = DateTime.Parse(date);
                string healthIns = frmInput.HealthInsTextbox.Text;
                double lifeIns = Double.Parse(frmInput.LifeInsTextbox.Text);
                int vacation = Int32.Parse(frmInput.VacationTextbox.Text);

                //Check Pay Type
                bool isSalary = frmInput.SalaryRadioButton.Checked;
                bool isHourly = frmInput.HourlyRadioButton.Checked;

                //Add Benefits
                Benefits benefits = new Benefits(healthIns, lifeIns, vacation);

                if (isSalary)
                {
                    double annualSalary = Double.Parse(frmInput.AnnualSalaryTextbox.Text);
                    Salary emp = new Salary(fname, lname, ssn, hireDate, benefits, annualSalary);
                    EmployeesListBox.Items.Add(emp);
                }
                if (isHourly)
                {
                    double hourlyRate = Double.Parse(frmInput.HourlyRateTextbox.Text);
                    double hoursWorked = Double.Parse(frmInput.HoursWorkedTextbox.Text);
                    Hourly emp = new Hourly(fname, lname, ssn, hireDate, benefits, hourlyRate, hoursWorked);
                    EmployeesListBox.Items.Add(emp);

                }
                
                WriteEmpsToFile();
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            int itemNumber = EmployeesListBox.SelectedIndex;
            if(itemNumber > -1)
            {
                EmployeesListBox.Items.RemoveAt(itemNumber);
                WriteEmpsToFile();

            }
            else
            {
                MessageBox.Show("Please Select an Employee to Remove");
            }
            
        }

        private void DisplayButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Displaying All Employees");
        }

        private void PrintPaychecksButton_Click(object sender, EventArgs e)
        {
            string displayStr = "";
            foreach (Employee emp in EmployeesListBox.Items)
            {
                Type t = emp.GetType();
                if (t.Equals(typeof(Salary)))
                {
                    Salary empSalary = (Salary)emp;
                    displayStr = displayStr + empSalary.ToString() + " and pay is: $" + empSalary.CalculatePay() + "\n";
                }
                if (t.Equals(typeof(Hourly)))
                {
                    Hourly empHourly = (Hourly)emp;
                    displayStr = displayStr + empHourly.ToString() + " and pay is: $" + empHourly.CalculatePay() + "\n";
                }
            }   
            MessageBox.Show(displayStr);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ReadEmpsFromFile();
        }

        private void EmployeesListBox_DoubleClick(object sender, EventArgs e)
        {
            int selectedIndex = EmployeesListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Please Select an Employee.");
                return;
            }
            InputForm frmInput = new InputForm();
            Employee emp = EmployeesListBox.SelectedItem as Employee;
            frmInput.FirstNameTextBox.Text = emp.firstName;
            frmInput.LastNameTextBox.Text = emp.lastName;
            frmInput.SSNTextBox.Text = emp.ssn;
            frmInput.HireDateTextBox.Text = emp.hireDate.ToString();
            frmInput.HealthInsTextbox.Text = emp.benefits.healthInsurance;
            frmInput.LifeInsTextbox.Text = emp.benefits.lifeInsurance.ToString();
            frmInput.VacationTextbox.Text = emp.benefits.vacation.ToString();
            DialogResult result = frmInput.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }
            //Remove Current Employee Object
            EmployeesListBox.Items.RemoveAt(selectedIndex);

            //Create & Add Employee Object
            string fname = frmInput.FirstNameTextBox.Text;
            string lname = frmInput.LastNameTextBox.Text;
            string ssn = frmInput.SSNTextBox.Text;
            string date = frmInput.HireDateTextBox.Text;
            DateTime hireDate = DateTime.Parse(date);
            string healthIns = frmInput.HealthInsTextbox.Text;
            double lifeIns = Double.Parse(frmInput.LifeInsTextbox.Text);
            int vacation = Int32.Parse(frmInput.VacationTextbox.Text);
            Benefits benefits = new Benefits(healthIns, lifeIns, vacation);


            Employee empl = new Employee(fname, lname, ssn, hireDate, benefits);
            EmployeesListBox.Items.Add(empl);
            WriteEmpsToFile();

        }
    }
}
