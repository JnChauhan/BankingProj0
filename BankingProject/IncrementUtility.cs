using System;
using System.Collections.Generic;
using System.Text;

namespace BankingProject
{
    static class IncrementUtility
    {
        private static int _CustId = 1001;
        private static int _AccIncrement = 1000001;

        public static int CustNextVal()
        {
            int id = _CustId++;
            return id;
        }
        public static int AccountNextVal()
        {
            int accNum = _AccIncrement++;
            return accNum;
        }
        
    }
}
