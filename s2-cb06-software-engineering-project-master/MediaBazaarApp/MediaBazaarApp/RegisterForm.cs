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
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;



namespace MediaBazaarApp
{
    public partial class RegisterForm : Form
    {
        Company company;
        List<Employee> employees;
        public RegisterForm()
        {
            InitializeComponent();
            company = new Company();
            employees = DB.getAllUsers();
        }

        private string CreateRandomPassword(int length)
        {
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }
        private bool EmailExists(string email)
        {
            foreach(Employee e in employees)
            {
                if (e.Email == email)
                {
                    return true;
                }
            }
            return false;
        }
        private bool PhoneNExists(string phoneN)
        {
            foreach (Employee e in employees)
            {
                if (e.PhoneN == phoneN)
                {
                    return true;
                }
            }
            return false;
        }
        private bool BSNExists(int bsn)
        {
            foreach (Employee e in employees)
            {
                if (e.BSN == bsn)
                {
                    return true;
                }
            }
            return false;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = tbFirstName.Text;
                string lastName = tbLastName.Text;
                string email = tbEmail.Text;
                string address = tbAddress.Text;
                string phoneN = tbPhoneN.Text;
                int bsn = Convert.ToInt32(tbBSN.Text);
                int index = cmbPosition.SelectedIndex;
                Position p = (Position)index;
                string position = Convert.ToString(p);
                string gender = "male";
                if (rbMale.Checked)
                {
                    gender = "male";
                }
                if (rbFemale.Checked)
                {
                    gender = "female";
                }
                string password = CreateRandomPassword(10);

                bool lastNameRegex = Regex.IsMatch(lastName, @"^[a-zA-Z]+$");
                bool firstNameRegex = Regex.IsMatch(firstName, @"^[a-zA-Z]+$");
                bool emailRegex = Regex.IsMatch(email, @"^[a-zA-z\S]{1,}@{1,}[a-zA-Z\S]{1,}[.]{1}[a-zA-Z.]{1,}$");
                bool phoneNRegex = Regex.IsMatch(phoneN, @"^[+]{1}[\d]{3,10}$");
                if (!lastNameRegex)
                {
                    MessageBox.Show("Last name should contain only letters");
                    return;
                }
                else if (!firstNameRegex)
                {
                    MessageBox.Show("First name should contain only letters");
                    return;
                }
                else if (!emailRegex)
                {
                    MessageBox.Show("Incorrect email!");
                    return;
                }
                else if (!phoneNRegex)
                {
                    MessageBox.Show("Phone patern is '+<your phone>', and the digits after '+' should be between 3 and 10");
                    return;
                }
                else if (EmailExists(email))
                {
                    MessageBox.Show("Email already exists");
                    return;
                }
                else if (BSNExists(bsn))
                {
                    MessageBox.Show("BSN already exists!");
                    return;
                }
                else if (PhoneNExists(phoneN))
                {
                    MessageBox.Show("Phone number already exists!");
                    return;
                }
                else
                {
                    Employee emp = new Employee(firstName, lastName, p, email, phoneN, address, bsn, gender);
                    company.addEmployee(emp);
                    if (company.createNewUser(Convert.ToString(bsn), password, position, email, phoneN, address, bsn, gender, firstName, lastName))
                    {

                        try
                        {
                            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                            client.EnableSsl = true;
                            client.Timeout = 10000;
                            client.DeliveryMethod = SmtpDeliveryMethod.Network;
                            client.UseDefaultCredentials = false;
                            client.Credentials = new NetworkCredential("mediabazaarS2@gmail.com", "MediaBymfm");
                            MailMessage msg = new MailMessage();
                            msg.To.Add(email);
                            msg.From = new MailAddress("mediabazaarS2@gmail.com");
                            msg.Subject = "You are hired!";
                            msg.Body = "Congratulations! You are hired as a " + position + " at MediaBazaar!";
                            client.Send(msg);
                            MessageBox.Show("Email to employee sent!");
                            ManagerForm mF = new ManagerForm();
                            this.Hide();
                            mF.Show();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(Convert.ToString(ex));
                        }
                    }
                  
                }
                }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

     

        private void BtnClose_Click(object sender, EventArgs e)
        {
            ManagerForm mF = new ManagerForm();
            this.Hide();
            mF.Show();
        }
    }
}

        

   
   
