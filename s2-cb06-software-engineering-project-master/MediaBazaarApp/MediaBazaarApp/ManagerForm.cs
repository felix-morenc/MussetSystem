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
    public partial class ManagerForm : Form
    {
      
        Company company;
        MySqlConnection conn = new MySqlConnection("server=	localhost;database=mediabazaar; Uid = root; Pwd = ;");

        public ManagerForm()
        {
            InitializeComponent();
            company = new Company();
            //lbInventory.Items.Add(Convert.ToString(company.GetNameFromID(2)));
            List<String> employees = new List<String>();
            string employeessql = "SELECT FirstName, FamilyName FROM people ";
            MySqlCommand cmd = new MySqlCommand(employeessql, conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string name = dr[0] + " " + dr[1];
                employees.Add(name);
            }
            dr.Close();
            conn.Close();
            int i = 0;
            while(employees.Count() - 1 >= i)
            {
                cbName.Items.Add(employees[i]);
                i++;
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            
           

            RegisterForm register = new RegisterForm();
            this.Hide();
            register.Show();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            lbInventory.Items.Clear();
            foreach (InventoryItem it in company.returnInventory())
            {
                lbInventory.Items.Add(it.ReturnItem());
            }
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void BtnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                string fullName = cbName.Text;
                List<String> name = fullName.Split(' ').ToList();
                string sql = "SELECT Id FROM people WHERE FirstName = @name AND FamilyName = @name2";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name[0]);
                cmd.Parameters.AddWithValue("@name2", name[1]);
                conn.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                lbInventory.Items.Add(Convert.ToString(id));
                if(id == 0)
                {
                    MessageBox.Show("Employee not found in system!");
                }
                else
                {
                    string dateToAssign = mCal.SelectionRange.Start.ToShortDateString();
                    string shiftToAssign = cbShift.Text;
                    string createsql = "SET FOREIGN_KEY_CHECKS=0;" +
                        "INSERT INTO shifts(Id, Date, Shift,SalaryPerHour) VALUES(@id, @date, @shift,6);" +
                    "SET FOREIGN_KEY_CHECKS=1;";
                    MySqlCommand createcmd = new MySqlCommand(createsql, conn);
                    createcmd.Parameters.AddWithValue("@id", id);
                    createcmd.Parameters.AddWithValue("@date", dateToAssign);
                    createcmd.Parameters.AddWithValue("@shift", shiftToAssign);
                    conn.Open();
                    createcmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            lbShifts.Items.Clear();
            string dateToView = mCal.SelectionRange.Start.ToShortDateString();
            List<int> empids = new List<int>();
            List<string> time = new List<string>();
            List<string> date = new List<string>();
            List<String> shiftNames = new List<String>();
            string sql = "SELECT Id, Shift,Date FROM shifts WHERE Date = @date";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@date", dateToView);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int id = Convert.ToInt32(dr[0]);
                empids.Add(id);
                string shift = Convert.ToString(dr[1]);
                time.Add(shift);
                string d = Convert.ToString(dr[2]);
                date.Add(d);
            }
            dr.Close();
            conn.Close();
            if(empids.Count == 0)
            {
                MessageBox.Show("No shifts assigned for selected date!");
            }
            else
            {
                int amtShifts = empids.Count();


                int y = 0;
                while (amtShifts - 1 >= y)
                {
                    string name = company.GetNameFromID(empids[y]);
                    shiftNames.Add(name);
                    y++;
                }

                int x = 0;
                while (shiftNames.Count() - 1 >= x)
                {
                    string output = shiftNames[x] + " is working the " + time[x] + " shift on "+ date[x]+ "- €6";
                    lbShifts.Items.Add(output);
                    x++;
                }
            }

        }

        private void MCal_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {

        }

        private void BtnManageEmployee_Click(object sender, EventArgs e)
        {
            ManageEmployee manage = new ManageEmployee();
            manage.Show();
        }
    }
}