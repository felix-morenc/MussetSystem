using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp
{
    public class Employee:Person
    {
        private Position position;
        private string email;
        private string phoneN;
        private string address;
        private int bsn;
        private string gender;
        Dictionary<String,SHIFT> shifts;
        private double salaryPerHour;

        public string Email
        {
            get { return this.email; }
        }
        public int BSN
        {
            get { return this.bsn; }
        }
        public string PhoneN
        {
            get { return this.phoneN; }
        }
        public Employee(string firstName, string lastName,  Position position, string email, string phoneN, string address, int bsn, string gender): base(firstName,lastName)
        {
            this.position = position;
            this.email = email;
            this.phoneN = phoneN;
            this.address = address;
            this.bsn = bsn;
            this.gender = gender;
            shifts = new Dictionary<String, SHIFT>();
            this.salaryPerHour = 6;
        }
        public Employee(string firstName, string lastName, Position position, string email, string phoneN, string address, int bsn, string gender,double salaryPerHour) : base(firstName, lastName)
        {
            this.position = position;
            this.email = email;
            this.phoneN = phoneN;
            this.address = address;
            this.bsn = bsn;
            this.gender = gender;
            shifts = new Dictionary<String, SHIFT>();
            this.salaryPerHour = salaryPerHour;
        }

    }

}
