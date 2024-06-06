using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MediaBazaarApp
{
    public class Company
    {
        private static List<Employee> employees;
        private static List<InventoryItem> inventory = new List<InventoryItem>();
        MySqlConnection conn = new MySqlConnection("server=	localhost;database=mediabazaar; Uid = root; Pwd = ;");


        public Company()
        {
            employees = new List<Employee>();
        }

        public void addEmployee(Employee e)
        {
            employees.Add(e);
        }
        public bool removeEmployee(int id)
        {
            return true;
        }
        public void addInventory(InventoryItem i)
        {
            inventory.Add(i);
        }

        public List<InventoryItem> returnInventory()
        {
            return inventory;
        }

        public List<InventoryItem> returnDBInventory()
        {
            List<InventoryItem> inventory = new List<InventoryItem>();
            string checksql = "SELECT * FROM inventory";
            MySqlCommand cmd = new MySqlCommand(checksql, conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            List<String> user = new List<String>();
            while (dr.Read())
            {
                int sku = Convert.ToInt32(dr[0]);
                string name = Convert.ToString(dr[1]);
                int stock = Convert.ToInt32(dr[2]);
                string category = Convert.ToString(dr[3]);
                InventoryItem i = new InventoryItem(sku, name, stock, category);
                inventory.Add(i);
            }
            dr.Close();
            conn.Close();
            return inventory;
        }
        public bool createNewUser(string username, string password, string position, string email, string phoneN, string address, int bsn, string gender, string firstName, string familyName)
        {
            try
            {        
                string sql = "SET FOREIGN_KEY_CHECKS=0;"+
                    "INSERT INTO `credentials`(`Username`, `Password`) VALUES (@username,@password);" +
                    "INSERT INTO `extrainfo`(`Position`, `Email`, `PhoneN`, `Address`, `BSN`, `Gender`,`SalaryPerHour`) VALUES (@position,@email,@phoneN,@address,@bsn,@gender,6);" +
                    "INSERT INTO `people`(`FirstName`, `FamilyName`, `Position`) VALUES (@firstName,@familyName,@position);"+
                    "SET FOREIGN_KEY_CHECKS=1;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@position", position);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phoneN", phoneN);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@bsn", bsn);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@familyName", familyName);
                conn.Open();
             
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Added to the DB!");
                return true;
                
            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public bool checkCredentialsOfEmployee(string username, string password)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM `credentials` WHERE Username = @username AND Password = @password";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                conn.Open();
                Object result = cmd.ExecuteScalar();
                int count = -1;
                if (result != null)
                {
                    count = Convert.ToInt32(result);
                    if (count == 1)
                    {
                        conn.Close();
                        return true;
                        
                    }
                    else
                    {
                        conn.Close();
                        return false;
                        
                    }
                }  
            }
            catch(Exception ex)
            {
                conn.Close();
                return false;
            }
            return false;
        }

        public List<String> ReturnEmployees()
        {
            List<String> employees = new List<String>();
            string employeessql = "SELECT Id, FirstName, FamilyName, Position FROM people ";
            MySqlCommand cmd = new MySqlCommand(employeessql, conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string name = "ID: " + dr[0] + " - Name: " + dr[1] + " " + dr[2] + " - Position: " + dr[3];
                employees.Add(name);
            }
            dr.Close();
            conn.Close();
            return employees;
        }

        public int ReturnIDOfEmployee(string username, string password)
        {
            string sql = "SELECT Id FROM `credentials` WHERE Username = @username AND Password = @password";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            conn.Open();
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return id;

        }

        public void UpdateEmployeePosition(string position, int id)
        {
            string sql = "UPDATE `extrainfo` SET `Position` = @position WHERE id = @id ";
            string sql2 = "UPDATE `people` SET `Position` = @position WHERE id = @id ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@position", position);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
            cmd2.Parameters.AddWithValue("@position", position);
            cmd2.Parameters.AddWithValue("@id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            conn.Close();
            
        }
        public void UpdateEmployeeWage(int id, int wage)
        {
            string sql = "UPDATE `extrainfo` SET `SalaryPerHour` = @salary WHERE id = @id ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@salary", wage);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void UpdateEmployeePassword(string newPass, int id)
        {
            string sql = "UPDATE `credentials` SET `Password` = @password WHERE Id = @id ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@password", newPass);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void FireEmployee(int id)
        {
            string sql = "DELETE FROM `extrainfo` WHERE id = @id ";
            string sql2 = "DELETE FROM `people` WHERE id = @id ";
            string sql3 = "DELETE FROM `credentials` WHERE id = @id ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
            cmd2.Parameters.AddWithValue("@id", id);
            MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
            cmd3.Parameters.AddWithValue("@id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            cmd3.ExecuteNonQuery();
            conn.Close();
        }



        public List<Employee> getAllEmployees()
        {
            try {
                List<Employee> e = new List<Employee>();
                string sql = "SELECT Position, Email, PhoneN, Address, BSN, Gender,SalaryPerHour FROM `extrainfo`  WHERE 1;" +
                    "SELECT `FirstName`, `FamilyName` FROM `people` WHERE 1; ";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                   
                    string position = dr[0].ToString();
                    string email = dr[1].ToString();
                    string phoneN = dr[2].ToString();
                    string address = dr[3].ToString();
                    int bsn = Convert.ToInt32(dr[4]);
                    string gender = dr[5].ToString();
                    string firstName = dr[6].ToString();
                    string familyName = dr[7].ToString();
                    Position p;
                    

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                return null;
            }
            return null;
        }

        public string GetNameFromID(int id)
        {
            string firstNameSql = "SELECT FirstName FROM people WHERE Id = @id";
            MySqlCommand firstNameCmd = new MySqlCommand(firstNameSql, conn);
            firstNameCmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            string firstName = Convert.ToString(firstNameCmd.ExecuteScalar());         
            conn.Close();
            string lastNameSql = "SELECT FamilyName FROM people WHERE Id = @id";
            MySqlCommand lastNameCmd = new MySqlCommand(lastNameSql, conn);
            lastNameCmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            string lastName = Convert.ToString(lastNameCmd.ExecuteScalar());
            conn.Close();
            string fullname = firstName + " " + lastName;
            return fullname;
        }

        public string GetPositionFromID(int id)
        {
            string firstNameSql = "SELECT Position FROM extrainfo WHERE Id = @id";
            MySqlCommand PositionCmd = new MySqlCommand(firstNameSql, conn);
            PositionCmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            string position = Convert.ToString(PositionCmd.ExecuteScalar());
            conn.Close();
            return position;
        }

    }
}
