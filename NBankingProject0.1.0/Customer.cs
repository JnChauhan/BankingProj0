using System;
using System.Collections.Generic;
using System.Text;

namespace NBankingProject0._1._0
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

        //public List<Account> Accounts { get; set; }
        public List<CheckingAcc> Checking { get; set; }
        public List<BusinessAcc> Business { get; set; }
        public List<TermDepositAccount> TDC { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }

        public Customer()
        {
            Id = UtilityIncrement.CustNextVal();
            Checking = new List<CheckingAcc>();
            Business = new List<BusinessAcc>();
            TDC = new List<TermDepositAccount>();
        }



    }
}
