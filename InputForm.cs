using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Denton_CourseProject_Part2
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

        private void InputForm_Load(object sender, EventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;
        }

        private void SalaryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            AnnualSalaryLabel.Visible = false;
            AnnualSalaryTextbox.Visible = false;
            HourlyRateLabel.Visible = false;
            HourlyRateTextbox.Visible = false;
            HoursWorkedLabel.Visible = false;
            HoursWorkedTextbox.Visible = false;

            if(SalaryRadioButton.Checked)
            {
                AnnualSalaryLabel.Visible = true;
                AnnualSalaryTextbox.Visible = true;
            }

        }

        private void HourlyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            AnnualSalaryLabel.Visible = false;
            AnnualSalaryTextbox.Visible = false;
            HourlyRateLabel.Visible = false;
            HourlyRateTextbox.Visible = false;
            HoursWorkedLabel.Visible = false;
            HoursWorkedTextbox.Visible = false;

            if(HourlyRadioButton.Checked)
            {
                HourlyRateLabel.Visible = true;
                HourlyRateTextbox.Visible = true;
                HoursWorkedLabel.Visible = true;
                HoursWorkedTextbox.Visible = true;

            }
        }

    }
}
