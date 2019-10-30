using System;
using System.Collections.Generic;
using System.Text;

namespace NBankingProject0._1._0
{
    public class Account
    {
        public int AccountNum { get; set; }

        public double Balance = 0;
        public int Customer_Id { get; set; }
        public bool IsActive { get; set; }
        
        public Customer Customer { get; set; }

        public List<string> Transactions { get; set; }

        
        
        public void CloseAccount()
        {
            IsActive = false;
            Console.WriteLine("\n Account is Closed");
        }
        
        public virtual bool OkToClose()
        {
            if (IsActive)
                return true;
            return false;
        }

        public void AddBalance(double amount)
        {
            Balance += amount;
            UpdateTransaction(amount, "Deposit");
        }
        public virtual void WithdrawAmount(double amountWithdrawn)
        {
            if (Balance >= amountWithdrawn)
            {
                Balance -= amountWithdrawn;
                UpdateTransaction(amountWithdrawn, "Withrawn");
            }
            else
            {
                Console.WriteLine("\n\tSorry! Not Enough Funds Available!");
            }
        }

        protected virtual void UpdateTransaction(double amount, string transactionType)
        {
            string transIn = (DateTime.Now.ToString()) + "\t" + transactionType + " Amount: $" + amount + "    New Balance: $" + Balance;
            Transactions.Add(transIn);
            Console.WriteLine("\n\tTransaction Updated!");
        }
    }
}
