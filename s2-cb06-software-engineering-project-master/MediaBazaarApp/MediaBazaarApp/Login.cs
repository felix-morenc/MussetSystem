using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MediaBazaarApp
{
    public partial class Login : Form
    {

        private ManagerForm mf;
        private EmployeeForm ef;
        private Company company;


        public Login()
        {
            InitializeComponent();
            company = new Company();
            mf = new ManagerForm();
            //BELOW IS CODE TO TEST INVENTORY SYSTEM FUNCTIONALITY
            //int t = 0;
            //while (t < 5)
            //{
            //    InventoryItem i = new InventoryItem("Bluetooth Speaker", 26);
            //    company.addInventory(i);
            //    t++;
            //}
            //InventoryItem x = new InventoryItem("Television", 1);
            //company.addInventory(x);


        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {         
                string username = tbUsername.Text;
                string password = tbPassword.Text;

                if (company.checkCredentialsOfEmployee(username, password))
                {
                    int empid = company.ReturnIDOfEmployee(username, password);
                    string job = company.GetPositionFromID(empid);
                    if(job == "MANAGER")
                    {
                        MessageBox.Show("You succsesfully logged in as a manager!");
                        mf.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Employee succsesfully logged in!");
                        ef = new EmployeeForm(empid);
                        ef.Show();
                        this.Hide();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Problem logging in!");
                }
        }
    }
}
