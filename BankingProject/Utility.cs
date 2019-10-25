using System;
using System.Collections.Generic;
using System.Text;

namespace BankingProject
{
    static class Utility
    {
        public enum UserSelection
        {
            RegisterCustomer = 1,
            OpenNewAccount = 2,
            CloseAccount = 3,
            MakeTransaction = 4,
            TransferFunds = 5,
            PayLoanInstallment = 6,
            ViewAllAccounts = 7,
            ViewTransactions = 8,
            ExitProgram = 9
        }
    }
}
