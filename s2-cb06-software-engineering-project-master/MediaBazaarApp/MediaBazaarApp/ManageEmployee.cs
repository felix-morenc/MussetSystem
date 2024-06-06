using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaarApp
{
    public partial class ManageEmployee : Form
    {

        Company company;
        public ManageEmployee()
        {
            InitializeComponent();
            company = new Company();
            RefreshListbox();
        }

        public void RefreshListbox()
        {
            lbEmployees.Items.Clear();
            List<string> employees = company.ReturnEmployees();
            int i = 0;
            while (employees.Count() - 1 >= i)
            {
                lbEmployees.Items.Add(employees[i]);
                i++;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int index = cmbPosition.SelectedIndex;
                Position p = (Position)index;
                string position = Convert.ToString(p);
                int id = Convert.ToInt32(tbID.Text);
                company.UpdateEmployeePosition(position, id);
                RefreshListbox();

            }
            catch
            {
                MessageBox.Show("Please Enter A Valid Employee ID!");
            }
            

        }

        private void BtnChangeWage_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(tbID.Text);
                int wage = Convert.ToInt32(tbWage.Text);
                company.UpdateEmployeeWage(id,wage);
                RefreshListbox();

            }
            catch
            {
                MessageBox.Show("Please Enter A Valid Employee ID and/or Wage!");
            }
        }

        private void BtnFire_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(tbID.Text);
                company.FireEmployee(id);
                RefreshListbox();

            }
            catch
            {
                MessageBox.Show("Please Enter A Valid Employee ID!");
            }
        }

        private void TbID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
