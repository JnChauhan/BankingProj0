using System;
using System.Collections.Generic;
using System.Text;

namespace BankingProject
{
    public class BusinessAcc
    {
        public double Balance = 0;
        public int BusAccNo { get; set; }
        public int Customer_Id {get; set;}
        public Customer Customer { get; set; }
        public List<string> transactions { get; set; }

        public BusinessAcc()
        {
            transactions = new List<string>();
        }

        /*public BusinessAcc(Customer cus)
        {
            Customer = cus;
            custId = Customer.Id;
            BusinessAccNo = IncrementUtility.AccountNextVal();
        }

        public static void UpdateTransaction()
        {
            
        }*/
        
    }
}
