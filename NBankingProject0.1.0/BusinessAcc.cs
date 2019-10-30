using System;
using System.Collections.Generic;
using System.Text;

namespace NBankingProject0._1._0
{
    public class BusinessAcc : Account, IAccountType
    {
        public double OverdraftInterest { get; }
        protected double OverdraftAmount;
        public BusinessAcc()
        {
            CreateAccount();
            OverdraftInterest = 0.0325;
            Transactions = new List<string>();
        }

        public void CreateAccount()
        {
            IsActive = true;
            AccountNum = UtilityIncrement.AccountNextVal();
        }

        public new void AddBalance(double amount)
        {
            if(OverdraftAmount > 0)
            {
                OverdraftAmount -= amount;
                if(OverdraftAmount < 0)
                {
                    Balance = 0 - OverdraftAmount;
                    OverdraftAmount = 0;
                }
            }
            else
            {
                Balance += amount;
            }
            UpdateTransaction(amount, "Deposit");
        }

        public override void WithdrawAmount(double amountWithdrawn)
        {
            Balance -= amountWithdrawn;
            if (Balance < 0)
            {
                GenerateOverDraft();

            }
            UpdateTransaction(amountWithdrawn, "Withdrawn");
        }
        
        private void GenerateOverDraft()
        {
            double draftAmount;
            draftAmount = 0 - Balance;
            Console.WriteLine($"\tLow Balance");
            Balance = 0;
            draftAmount += AddInterestOnOD(draftAmount);
            Console.WriteLine($"\tGenerating Overdraft of ${draftAmount}");
            OverdraftAmount += draftAmount;
            Console.WriteLine($"\tNew Overdraft Balance: ${OverdraftAmount}");
        }
        
        public double getOverdraftAmount()
        {
            return OverdraftAmount;
        }

        private double AddInterestOnOD(double amount)
        {
            double interestCharged = amount * OverdraftInterest;
            return interestCharged;
        }

        protected override void UpdateTransaction(double amount, string transactionType)
        {
            string transIn = (DateTime.Now.ToString()) + "\t" + transactionType + " Amount: $" + amount + "\tNew Balance: $" + Balance;
            transIn += "\n\tCurrent Outstanding Overdraft Amount: $" + OverdraftAmount;
            Transactions.Add(transIn);
            Console.WriteLine("\n\tTransaction Updated!");
        }


        public override bool OkToClose()
        {
            bool toClose;
            if (Balance == 0 && OverdraftAmount == 0 && IsActive)
            {
                toClose = true;
            }
            else
            {
                toClose = false;
                //Console.WriteLine("     Please Withdraw or Deposit the Balance or Overdraft");
                //Console.WriteLine($"    Available Balance: ${Balance}\t Existing Overdraft: ${OverdraftAmount}");
            }
            return toClose;
        }
    }
}
