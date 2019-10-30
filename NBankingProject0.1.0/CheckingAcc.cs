using System;
using System.Collections.Generic;
using System.Text;

namespace NBankingProject0._1._0
{
    public class CheckingAcc : Account, IAccountType
    {
        public double InterestRate { get; }


        public CheckingAcc()
        {
            InterestRate = 0.0125;
            CreateAccount();
            Transactions = new List<string>();
        }

        public void CreateAccount() 
        {
            IsActive = true;
            AccountNum = UtilityIncrement.AccountNextVal();
        }
        
        public override void WithdrawAmount(double amountWithdrawn)
        {
            double expectedNewBalance = Balance - amountWithdrawn;
            if(expectedNewBalance < 0)
            {
                Console.WriteLine("\n\tSorry! Not Enough Funds Available!");
                Console.WriteLine("Current Balance: $" + Balance);
            }
            else
            {
                Balance = expectedNewBalance;
                UpdateTransaction(amountWithdrawn, "Withdrawn");
            }

        }

        //--- Could be called when adding interest on Remaining Balance on a particular day of month
        protected double AddInterest(double amountForInterest)
        {
            double interestEarned;
            interestEarned = amountForInterest * InterestRate;
            return interestEarned;
        }

        public override bool OkToClose()
        {
            bool toClose;
            if (Balance == 0 && IsActive)
            {
                toClose = true;
            }
            else
            {
                toClose = false;
                //Console.WriteLine("     Please Withdraw or Transfer the Balance");
            }
            return toClose;
        }

    }
}
