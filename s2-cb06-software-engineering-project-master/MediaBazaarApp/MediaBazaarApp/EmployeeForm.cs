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
    public partial class EmployeeForm : Form
    {

        private Company company;
        private List<InventoryItem> inventoryItems;
        MySqlConnection conn = new MySqlConnection("server=	studmysql01.fhict.local;database=dbi432295; Uid = dbi432295; Pwd = qwerty;");
        int empid;

        public EmployeeForm(int id)
        {
            InitializeComponent();
            empid = id;
            company = new Company();
            inventoryItems = new List<InventoryItem>();
            lblEmp.Text = company.GetNameFromID(empid);
            if(company.GetPositionFromID(empid) == "INVENTORY_MANAGER")
            {
                groupBox3.Visible = true;
            }
            else
            {
                groupBox3.Visible = false;
            }
            
        }

        private void RefreshListbox()
        {
            listBox1.Items.Clear();
            inventoryItems.Clear();
            inventoryItems = company.returnDBInventory();
            foreach (InventoryItem i in inventoryItems)
            {
                listBox1.Items.Add(i.ReturnItem());
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshListbox();
        }

        private void BtnDecrease_Click(object sender, EventArgs e)
        {
            try
            {
                int selected = listBox1.SelectedIndex;
                if (inventoryItems[selected].LowerQuantity() == true)
                {
                    inventoryItems[selected].DecreaseFromDB();
                    MessageBox.Show("Quantity Successfully Decreased");
                    RefreshListbox();
                }
                else
                {
                    MessageBox.Show("Stock Already at 0!");
                }
            }
            catch
            {
                MessageBox.Show("Please Select An Item!");
            }
            


        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int selected = listBox1.SelectedIndex;
                if (inventoryItems[selected].ReturnQuantity() == 0)
                {
                    inventoryItems[selected].RemoveFromDB();
                    RefreshListbox();
                    MessageBox.Show("Item Removed!");
                }
            }
            catch
            {
                MessageBox.Show("Please Select An Item!");
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                InventoryItem i = new InventoryItem(0, tbName.Text, Convert.ToInt32(tbStock.Text), cbCategory.Text);
                i.WriteToDB();
                RefreshListbox();
                company.addInventory(i);
            }
            catch
            {
                MessageBox.Show("Please Enter a Valid Name and Stock Amount!");
            }
        }

        private void BtnGo_Click(object sender, EventArgs e)
        {
            try
            {
                lbShifts.Items.Clear();
                List<String> shifts = new List<String>();
                string date = monthCalendar1.SelectionRange.Start.ToShortDateString();
                string sql = "SELECT Shift FROM shifts WHERE Id = @id AND Date = @date";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@id", empid);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string shift = Convert.ToString(dr[0]);
                    shifts.Add(shift);
                }
                dr.Close();
                conn.Close();
                if (shifts.Count == 0)
                {
                    MessageBox.Show("You have no shifts for this day!");
                }
                else
                {
                    int i = 0;
                    while (shifts.Count() - 1 >= i)
                    {
                        string s = date + " " + shifts[i] + " Shift";
                        lbShifts.Items.Add(s);
                        i++;
                    }

                }
            }
            catch
            {
                MessageBox.Show("Enter a valid date!");
            }

        }

        private void BtnViewAllShifts_Click(object sender, EventArgs e)
        {
            try
            {
                lbShifts.Items.Clear();
                List<String> shifts = new List<String>();
                List<string> dates = new List<string>();
                string sql = "SELECT Shift,Date FROM shifts WHERE Id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", empid);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string shift = Convert.ToString(dr[0]);
                    shifts.Add(shift);
                    string d = Convert.ToString(dr[1]);
                    dates.Add(d);
                }
                dr.Close();
                conn.Close();
                if (shifts.Count == 0)
                {
                    MessageBox.Show("You have no shifts!");
                }
                else
                {
                    int i = 0;
                    while (shifts.Count() - 1 >= i)
                    {
                        string s = dates[i] + shifts[i] + " Shift";
                        lbShifts.Items.Add(s);
                        i++;
                    }

                }
            }
            catch
            {
                MessageBox.Show("Enter a valid date!");
            }
        }


        private void BtnPassChange_Click_1(object sender, EventArgs e)
        {
            try
            {
                string password = tbNewPassword.Text;
                company.UpdateEmployeePassword(password, empid);
                MessageBox.Show("Successfully Updated Password!");
            }
            catch
            {
                MessageBox.Show("Successfully Updated Password!");
            }
        }
    }
}
