using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankingProject
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public int SocialSec { get; set; }

        public List<CheckingAcc> Checking { get; set; }
        public List<BusinessAcc> Business { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }

        public Customer()
        {
            Checking = new List<CheckingAcc>();
            Business = new List<BusinessAcc>();
        }


        /*public Customer(string fname, string lname, string eMail)
        {
            this.Id = IncrementUtility.CustNextVal();
            this.FirstName = fname;
            this.LastName = lname;
            this.Email = eMail;
        }*/

        /*public void UploadAddress(string address, string city, string state)
        {
            this.Address = address;
            this.City = city;
            this.State = state;
        }

        public void SetSocial(int social)
        {
            this._socialSec = social;
        }

        public void ReturnSocial(out int social)
        {
            social = this._socialSec;
        }*/
    }
}
