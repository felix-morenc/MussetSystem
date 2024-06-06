using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MediaBazaarApp
{


    public class InventoryItem
    {
        int sku;
        string name;
        int quantity;
        string category;
        MySqlConnection conn = new MySqlConnection("server=	localhost;database=mediabazaar; Uid = root; Pwd = ;");

        public InventoryItem(int sku, string name, int quantity, string category)
        {
            this.sku = sku;
            this.name = name;
            this.quantity = quantity;
            this.category = category;
            //string sql = "INSERT INTO bazaarinventory (name,quantity) VALUES(@name,@quantity);";
            //MySqlCommand cmd = new MySqlCommand(sql, conn);
            //cmd.Parameters.AddWithValue("@name", this.name);
            //cmd.Parameters.AddWithValue("@quantity", this.quantity);
            //conn.Open();
            //cmd.ExecuteNonQuery();
            //conn.Close();
        }

        public void WriteToDB()
        {
            string sql = "INSERT INTO inventory (name,quantity,category) VALUES(@name,@quantity,@category);";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", this.name);
            cmd.Parameters.AddWithValue("@quantity", this.quantity);
            cmd.Parameters.AddWithValue("@category", this.category);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void RemoveFromDB()
        {
            string sql = "DELETE FROM inventory WHERE sku = @sku;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@sku", this.sku);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DecreaseFromDB()
        {
            string sql = "UPDATE inventory SET quantity = quantity - 1 WHERE sku = @sku;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@sku", this.sku);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public bool LowerQuantity()
        {
            if(quantity > 0)
            {
                quantity--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ReturnItem()
        {
            string item = this.sku + " - " + this.name + " - Category: " + this.category + " - Stock: " + this.quantity;
            return item;
        }

        public int ReturnQuantity()
        {
            return this.quantity;
        }

        public int ReturnSku()
        {
            return this.sku;
        }
    }
}
