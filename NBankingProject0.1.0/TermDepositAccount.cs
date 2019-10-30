using System;
using System.Collections.Generic;
using System.Text;

namespace NBankingProject0._1._0
{
    public class TermDepositAccount : Account, IAccountType
    {
        public DateTime OpenDate;

        public DateTime MaturityDate;

        public int TermMonths;

        //---If later, want fees and let Term Deposit break before maturity
        //public double TermBreakFees;

        public double InterestAmount; 

        public TermDepositAccount(double depositAmt, double interestRate, int months)
        {
            //OpenDate = DateTime.Now.ToString();
            
            CreateAccount();
            Balance = depositAmt;
            MaturityDate = OpenDate.AddMonths(months);
            TermMonths = months;
            InterestAmount = (Balance * interestRate);
        }

        public void CreateAccount()
        {
            IsActive = true;
            AccountNum = UtilityIncrement.AccountNextVal();
            OpenDate = DateTime.Now;
        }

        public void CloseAccount(ref double balance)
        {
            if (OkToClose())
            {
                balance = WithdrawAmount();
                IsActive = false;
            }
            else
            {
                balance = 0;
            }
        }

        public double WithdrawAmount()
        {
            double matureAmount;
            matureAmount = Balance + InterestAmount;
            Balance = 0;
            UpdateTransaction(matureAmount, "Term Deposit");
            CloseAccount();
            return matureAmount;
        }

        public override bool OkToClose()
        {
            bool toClose = false;
            if(DateTime.Now > MaturityDate && IsActive)
            {
                toClose = true;
            }
            return toClose;
        }
    }
}
