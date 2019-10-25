using System;
using System.Collections.Generic;
using System.Text;


namespace BankingProject
{
    public class CheckingAcc
    {
        public int CheckAccNo { get; set; }
        public double Balance = 0;
        public int Customer_Id { get; set; }
        public Customer Customer { get; set; }

        public List<string> transactions { get; set; }

        public CheckingAcc()
        {
            transactions = new List<string>();
        }
        /*public CheckingAcc(Customer cus)
        {
            Customer = cus;
            CustId = Customer.Id;
            CheckingAccNo = IncrementUtility.AccountNextVal();
        }*/

    }
}
