using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Windows.Forms;

namespace MediaBazaarApp
{
    public static class DB
    {


        public static List<Employee> getAllUsers()
        {
            List<Employee> e = new List<Employee>();
            try
            {
                MySqlConnection conn = new MySqlConnection("server=	localhost;database=mediabazaar; Uid = root; Pwd = ;");
                string sql = "SELECT e.Position,e.Email,e.PhoneN,e.Address,e.BSN,e.Gender,p.FirstName,p.FamilyName,e.SalaryPerHour" +
" FROM extrainfo e" +
" LEFT JOIN people p" +
" ON e.Id = p.Id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string firstName = dr[6].ToString();
                    string lastName = dr[7].ToString();
                    string email = Convert.ToString( dr[1]);
                    string phoneN = dr[2].ToString(); ;
                    string address = dr[3].ToString();
                    int bsn = Convert.ToInt32(dr[4]) ;
                    string gender = dr[5].ToString() ;
                    double salary = Convert.ToDouble(dr[8]);

                    Position position;
                    if(dr[0].ToString() == "CUSTOMER_ASSISTANT")
                    {
                        position = Position.CUSTOMER_ASSISTANT;
                    }
                    else if (dr[0].ToString() == "CASHIER")
                    {
                        position = Position.CHASHIER;
                    }
                    else
                    {
                        position = Position.INVENTORY_MANAGER;
                    }

                    e.Add(new Employee(firstName,lastName,position,email,phoneN,address,bsn,gender));
                }
                conn.Close();
                return e;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString()) ;
                return null;

            }
        }

    }
}
