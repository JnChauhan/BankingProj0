using System;
using System.Collections.Generic;
using System.Text;

namespace NBankingProject0._1._0
{
    public static class ListOfMenu
    {

        static List<Customer> Customers = new List<Customer>();
        static Customer SelectedCustomer;


       public  static void UserOptions()
        {
            
            try
            {
                int selection = 0;
                Console.WriteLine("______________________________________________________________________");
                Console.WriteLine("Please choose one of the Following options:");
                Console.WriteLine("\tPress 1 to Register new Customer.");
                Console.WriteLine("\tPress 2 to Open a New Account after Selecting a Customer");
                Console.WriteLine("\tPress 3 to Close an Existing Account");
                Console.WriteLine("\tPress 4 to Make a Transaction (Deposit OR Withdraw) OR View Transactions");
                Console.WriteLine("\tPress 5 to Transfer Money between Accounts");
                Console.WriteLine("\tPress 6 to Pay Loan Installments");
                Console.WriteLine("\tPress 7 to View All Existing Customer");
                Console.WriteLine("\tPress 8 to View All Existing Accounts of an Existing Customer");
                Console.Write("\tPress 9 to Exit\n\t\tUser Response: ");
                selection = Convert.ToInt32(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        CreateCustomer();
                        ListCustomers();
                        break;
                    case 2:
                        NewAccountChoose();
                        break;
                    case 3:
                        BeforeClosingAccount();
                        break;
                    case 4:
                        MakeTransaction();
                        break;
                    case 5:
                        TransfersInAccounts();
                        break;
                    case 6:
                        Console.WriteLine("\nFunction Under Maintainance");
                        break;
                    case 7:
                        ListCustomers();
                        break;
                    case 8:
                        ViewSelectedCustomer();
                        DisplayAccountsInfo();
                        break;
                    case 9:
                        Environment.Exit(0);
                        Console.WriteLine("\nTHANK YOU! \nGOOD BYE!");
                        break;
                    default:
                        Console.WriteLine("\nInput Mismatch...");
                        break;
                }
                ExitUserOptions();
            }
            catch (FormatException)
            {
                Console.WriteLine(" Something Went wrong.\t Response was not in a Correct Format \n-----Redirecting-----");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Something Went wrong.\n " + ex.Message + "\n-----Redirecting-----");
            }
        }


        public static void ExitUserOptions()
        {
            string proceed;
            Console.Write("\n_____________________________________________________" +
                "\nEnter '1' to Show Main Menu again or 'N' To Cancel and Exit:        ");
            proceed = Console.ReadLine().ToLower();
            if (proceed == "1")
            {
                UserOptions();
                //retry = true;
            }
            else if (proceed == "n")
            {
                //retry = false;
                Console.WriteLine("\nThank You for your time see you soon....\n\n");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid Input!\tTry Again!");
                ExitUserOptions();
                //retry = ExitUserOptions();
            }
        }

        static void CreateCustomer()
        {
            var cust1 = new Customer()
            {
                FirstName = ("John").ToUpper(),
                LastName = ("Desk").ToUpper(),
                Address = "8934 Guate Val Ave",
                City = "Reston",
                State = "VA",
                Email = "john@gmail.com",
                SocialSec = 235538857
            };
            var cust2 = new Customer()
            {
                FirstName = "Alex",
                LastName = "Musk",
                Address = "8563 AvenueWale Ave",
                City = "Dulles",
                State = "VA",
                Email = "alexm1@gmail.com",
                SocialSec = 987456897
            };
            var cust3 = new Customer()
            {
                FirstName = "Jojo",
                LastName = "Rovinski",
                Address = "83 Adam St",
                City = "Silver Spring",
                State = "MD",
                Email = "jojorov@gmail.com",
                SocialSec = 324324324
            };
            Customers.Add(cust1);
            //customers.Add(cust2);
            //customers.Add(cust3);
        }
        static void ListCustomers()
        {
            if (Customers.Count != 0)
            {
                foreach (var cust in Customers)
                {
                    Console.WriteLine($"-------------------\nCustomer Id: {cust.Id}\n Name: {cust.FirstName} {cust.LastName}\n Address: {cust.Address}, {cust.City}, " +
                        $"{cust.State}\n Email: {cust.Email}\n Social Security: {cust.SocialSec}");
                }
            }
            else
            {
                Console.WriteLine("NO EXISTING CUSTOMERS AVAILABLE");
            }
        }

        static void ViewSelectedCustomer()
        {
            string userInput;
            if (SelectedCustomer != null)
            {
                Console.WriteLine("_______________________________________________\n\tSelected Customer: " + SelectedCustomer.FullName);
                Console.Write("\tWish to Continue? Press 1\n\t OR Select a new Customer Press 0:   ");
                userInput = Console.ReadLine();
                if (userInput == "0")
                {
                    CustSelectInfo();
                }
            }
            else
            {
                CustSelectInfo();
            }
        }

        //--- Asks for User Input, Selects a Customer, if provided details, deletes current customer and search for a new one!
        static void CustSelectInfo()
        {
            string fName, lName;
            int inputId, tryAgain;
            try
            {
                Console.WriteLine("-----------------------------------------------\nPlease Enter Customer Information");
                Console.Write("\n\t Enter First Name: ");
                fName = Console.ReadLine().ToUpper();
                Console.Write("\t Enter Last Name: ");
                lName = Console.ReadLine().ToUpper();
                Console.Write("\t Enter Customer ID: ");
                inputId = Convert.ToInt32(Console.ReadLine());

                if (fName != null && lName != null)
                {
                    CustomerSelect(fName, lName, inputId);
                }
                else
                {
                    Console.Write("\n No input provided\n Press 0 to go back 1 to try again: ");
                    tryAgain = Convert.ToInt32(Console.ReadLine());
                    //tryAgain = ((inputId == 1) ? true : (inputId == 0) ? false : false);
                    if (tryAgain == 1)
                    {
                        CustSelectInfo();
                    }

                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(" Something Went wrong.\n " + ex.Message + "\n-----Redirecting-----");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Something Went wrong.\n " + ex.Message + "\n-----Redirecting-----");
            }
        }

        static void CustomerSelect(string Fname, string Lname, int id)
        {
            // SelectedCustomer = customers.Where(c => c.FirstName.Equals(Fname) && c.LastName.Equals(Lname)).;
            SelectedCustomer = null;
            foreach (var sCust in Customers)
            {
                if (sCust.FirstName == Fname && sCust.LastName == Lname && sCust.Id == id)
                {
                    SelectedCustomer = sCust;
                    Console.WriteLine($" Customer Selected: {SelectedCustomer.FullName}");

                }
            }
            if (SelectedCustomer == null)
            {
                bool yesNo = false;
                Console.WriteLine("\n\t Customer not found!");
                Console.Write("Do you want to Search Again?\n   Press 'Y' for yes / 'N' to go back   ");
                yesNo = (Console.ReadLine().ToUpper() == "Y") ? true : false;

                if (yesNo)
                    CustSelectInfo();

            }
        }
        
        static void NewAccountChoose()
        {
            ViewSelectedCustomer();
            if (SelectedCustomer != null)
            {
                string accountInType = null;
                Console.WriteLine("\nWould you like to open a Business Account or Checking Account?");
                Console.Write("\tPress \"OB\" for Business\n\tOR \"OC\" for Checking\n\tOR \"TDC\" for Term Deposit Certificate: ");
                accountInType = Console.ReadLine().ToUpper();
                if (accountInType == "OB")
                {
                    OpenBusinessAcc();
                }
                else if (accountInType == "OC")
                {
                    OpenCheckingAcc();
                }
                else if (accountInType == "TDC")
                {
                    OpenTermDeposit();
                }
                else
                    Console.WriteLine(" INVALID INPUT! try again later...");
            }
            else
            {
                Console.WriteLine("\n\tNO CUSTOMER SELECTED!\n\tTry Again Later.");
            }

        }
        static void OpenBusinessAcc()
        {
            var busAcc = new BusinessAcc()
            {
                Customer_Id = SelectedCustomer.Id,
                Customer = SelectedCustomer
            };
            SelectedCustomer.Business.Add(busAcc);
            Console.WriteLine(CongratulationNewAccount(busAcc.AccountNum));
        }
        static void OpenCheckingAcc()
        {
            var checkAcc = new CheckingAcc()
            {
                Customer_Id = SelectedCustomer.Id,
                Customer = SelectedCustomer
            };
            SelectedCustomer.Checking.Add(checkAcc);
            Console.WriteLine(CongratulationNewAccount(checkAcc.AccountNum));
        }
        static void OpenTermDeposit()
        {
            double depositAmt = 1000;
            double interestRate = 0.0125;
            int durationMonths = 12;
            var depositAccount = new TermDepositAccount(depositAmt, interestRate, durationMonths)
            {
                Customer_Id = SelectedCustomer.Id,
                Customer = SelectedCustomer
            };
            SelectedCustomer.TDC.Add(depositAccount);
            Console.WriteLine(CongratulationNewAccount(depositAccount.AccountNum));
        }
        static string CongratulationNewAccount(int acctNum)
        {
            string congo = "\n\tCongratulations on Your New account!\n\tDon't forget your Account #, which is " + acctNum;
            return congo;
        }

        static void MakeTransaction()
        {
            ViewSelectedCustomer();
            if (SelectedCustomer != null)
            {
                string accountOpt;

                Console.WriteLine("\n   Press \"VA\" to View all Accounts OR Press \"EA\" To Enter the Account Number and Account Type");
                Console.Write("\t\t(You may enter anything else to Go Back):  ");
                accountOpt = Console.ReadLine().ToLower();
                if (accountOpt == "va")
                {

                    DisplayAccountsInfo();
                    FindAccToTransact();

                }
                else if (accountOpt == "ea")
                {
                    FindAccToTransact();
                }
                else
                {
                    Console.WriteLine("Input didn't match the criteria\n-----Redirecting-----");
                    return;
                }
            }
            else
            {
                Console.WriteLine("\nNo Customer Selected\n-----Redirecting-----");
            }


        }
        
        static void FindAccToTransact()
        {
            string accountType;
            int accountNum = 0;
            try
            {
                accountType = EnterAccNumType(ref accountNum);
                switch (accountType)
                {
                    case "bz":
                        TransInBusiness(FindBusinessAcc(accountNum));
                        break;
                    case "ck":
                        TransInChecking(FindCheckingAcc(accountNum));
                        break;
                    case "tdc":
                        TransInTDC(FindTermDeposit(accountNum));
                        break;
                    default:
                        Console.WriteLine("\nInvalid Input! Try again\n");
                        MakeTransaction();
                        break;
                }

            }
            catch (FormatException ex)
            {
                Console.WriteLine(" Something Went wrong.\n " + ex.Message + "\n-----Redirecting-----");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Something Went wrong.\n " + ex.Message + "\n-----Redirecting-----");
            }
        }

        static void TransInBusiness(BusinessAcc account)
        {
            if (account != null)
            {
                string transactSel;
                Console.Write(MessageForTransIn(account.Balance));
                transactSel = Console.ReadLine().ToLower();
                switch (transactSel)
                {
                    case "d":
                        DepositBusiness(account);
                        break;
                    case "w":
                        WithdrawFromBusiness(account);
                        break;
                    case "t":
                        ViewTransaction(account);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                return;
            }
            else
            {
                Console.WriteLine("\n\tNo Business Account");
            }
        }
        /* __ */
        static void TransInChecking(CheckingAcc account)
        {
            if (account != null)
            {
                string transactSel;
                Console.WriteLine(MessageForTransIn(account.Balance));
                transactSel = Console.ReadLine().ToLower();
                switch (transactSel)
                {
                    case "d":
                        DepositChecking(account);
                        break;
                    case "w":
                        WithdrawFromChecking(account);
                        break;
                    case "t":
                        ViewTransaction(account);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                return;
            }
            else
            {
                Console.WriteLine("\n\tNo Checking Account");
            }
        }

        static void TransInTDC(TermDepositAccount account)
        {
            if (account != null)
            {
                Console.WriteLine("\n   Account Found!\n Available Funds: $" + account.Balance);
                if (CompareTwoDates(DateTime.Now, account.MaturityDate) == -1)
                {
                    Console.WriteLine("\n\tCannot make any transaction.\n\tMaturity date is: " + account.MaturityDate.ToString());
                }
                else
                {
                    Console.WriteLine("\n\tYour TDC (Term Deposit Certificate) has Matured on: " + account.MaturityDate.ToString());
                    Console.WriteLine("You can Close and Transfer the funds in another account or Withdraw in Cash");
                }
                return;
            }
            else
            {
                Console.WriteLine("\n\tNo Term Deposit Certificate Account found");
            }
        }

        /*___*/
        static int CompareTwoDates(DateTime dateNow, DateTime dateCheckWith)
        {
            int value = DateTime.Compare(dateNow, dateCheckWith);
            return value;
        }
        static string MessageForTransIn(double balance)
        {
            string message = "\n   Account Found!\n Available Funds: $" + balance;
            message += "\n\tEnter 'D' for Deposit \n\t'W' to Withdraw\n\tOR 'T' to View Account Transactions: ";
            return message;
        }

        static BusinessAcc FindBusinessAcc(int accNum)
        {
            BusinessAcc account = null;

            foreach (var acc in SelectedCustomer.Business)
            {
                if (acc.AccountNum == accNum && acc.IsActive)
                {
                    account = acc;
                }
            }
            return account;
        }
        static CheckingAcc FindCheckingAcc(int accNum)
        {
            CheckingAcc account = null;
            foreach (var acc in SelectedCustomer.Checking)
            {
                if (acc.AccountNum == accNum && acc.IsActive)
                {
                    account = acc;
                }
            }
            return account;
        }
        static TermDepositAccount FindTermDeposit(int accNum)
        {
            TermDepositAccount account = null;
            foreach (var acc in SelectedCustomer.TDC)
            {
                if (acc.AccountNum == accNum && acc.IsActive)
                {
                    account = acc;
                }
            }
            return account;
        }

        static void TransfersInAccounts()
        {
            ViewSelectedCustomer();
            if (SelectedCustomer != null)
            {
                Account fromAcc = null;
                Account toAcc;
                int accountNum = 0;
                string accTypeIn;
                double amount = 0;
                Console.WriteLine(" ");
                try
                {
                    Console.WriteLine("  Enter Account Number 'FROM' which you want to transfer");
                    accTypeIn = EnterAccNumType(ref accountNum);
                    switch (accTypeIn)
                    {
                        case "bz":
                            fromAcc = FindBusinessAcc(accountNum);
                            break;
                        case "ck":
                            fromAcc = FindCheckingAcc(accountNum);
                            break;
                        case "tdc":
                            //fromAcc = FindTermDeposit(accountNum);
                            Console.WriteLine("\n\tYou may transfer while closing the account");
                            return;
                        default:
                            Console.WriteLine("\n Selected an unvalid option\n-----Redirecting-----\n");
                            return;
                    }
                    Console.WriteLine("\n  Enter Account Number 'INTO' which you want to transfer");
                    accTypeIn = EnterAccNumType(ref accountNum);
                    switch (accTypeIn)
                    {
                        case "bz":
                            toAcc = FindBusinessAcc(accountNum);
                            break;
                        case "ck":
                            toAcc = FindCheckingAcc(accountNum);
                            break;
                        default:
                            Console.WriteLine("\nAccount Not Found!\n-----Redirecting-----\n");
                            return;
                    }

                    if (fromAcc != null && toAcc != null)
                    {
                        TransferAmountInput(ref amount);
                        if (amount != 0)
                        {
                            TransferInAccount(fromAcc, toAcc, amount);
                        }
                        else
                        {
                            Console.WriteLine("\n\tNot a Valid Amount to make a transaction");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n Unable to find an account");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(" Something Went wrong.\n " + ex.Message + "\n-----Redirecting-----");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Something Went wrong.\n " + ex.Message + "\n-----Redirecting-----");
                }
            }
        }
        static string EnterAccNumType(ref int accNum)
        {
            string accountType;
            Console.Write("\n\tEnter Account Number:  ");
            accNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\tEnter \"BZ\" or \"CK\" or \"TDC\" for Business or Checking or Term Deposit Account");
            Console.Write("\t\t(You may enter anything else to Go Back):  ");
            accountType = Console.ReadLine().ToLower();
            return accountType;
        }

        static void TransferAmountInput(ref double amount)
        {
            try
            {
                Console.Write("\n\t\tEnter the Amount to transfer:   $");
                amount = Convert.ToDouble(Console.ReadLine());

            }
            catch (FormatException ex)
            {
                Console.WriteLine(" Something Went wrong.\n " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Something Went wrong.\n " + ex.Message);
            }
        }

        static void TransferInAccount(Account fromAcc, Account toAcc, double transferAmount)
        {
            fromAcc.WithdrawAmount(transferAmount);
            if (transferAmount <= fromAcc.Balance)
            {
                toAcc.AddBalance(transferAmount);
            }

        }
        static void DepositBusiness(BusinessAcc account)
        {
            try
            {
                double amount;
                Console.Write("\n\tEnter Amount you want to Deposit: $");
                amount = Convert.ToDouble(Console.ReadLine());
                account.AddBalance(amount);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(" Input only Real numbers for amount.\n " + ex.Message + "\n-----Redirecting-----");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Something Went wrong.\n " + ex.Message + "\n-----Redirecting-----");
            }

        }

        static void WithdrawFromBusiness(BusinessAcc account)
        {
            try
            {
                double amount;
                Console.Write("\n\tEnter Amount you want to Withdraw: $");
                amount = Convert.ToDouble(Console.ReadLine());
                account.WithdrawAmount(amount);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(" Input only Real numbers for amount.\n " + ex.Message + "\n-----Redirecting-----");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Something Went wrong.\n " + ex.Message + "\n-----Redirecting-----");
            }
        }

        static void DepositChecking(CheckingAcc account)
        {
            try
            {
                double amount;
                Console.Write("\n\tEnter Amount you want to Deposit: $");
                amount = Convert.ToDouble(Console.ReadLine());
                account.AddBalance(amount);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(" Input only Real numbers for amount.\n " + ex.Message + "\n-----Redirecting-----");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Something Went wrong.\n " + ex.Message + "\n-----Redirecting-----");
            }
        }
        static void WithdrawFromChecking(CheckingAcc account)
        {
            try
            {
                double amount;
                Console.Write("\n\tEnter Amount you want to Withdraw: $");
                amount = Convert.ToDouble(Console.ReadLine());
                account.WithdrawAmount(amount);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(" Input only Real numbers for amount.\n " + ex.Message + "\n-----Redirecting-----");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Something Went wrong.\n " + ex.Message + "\n-----Redirecting-----");
            }
        }

        static void DisplayAccountsInfo()
        {
            if (ExistingBusAcc())
            {
                Console.WriteLine("\n\tBUSINESS ACCOUNTs INFO");
                foreach (var account in SelectedCustomer.Business)
                {
                    if (account.IsActive)
                    {
                        Console.WriteLine($"\t\tAccount Number: {account.AccountNum}\t Current Balance: ${account.Balance}\t Overdraft: ${account.getOverdraftAmount()}");
                    }
                }
            }
            if (ExistingCheckAcc())
            {
                Console.WriteLine("\n\tCHECKING ACCOUNTs INFO");
                foreach (var account in SelectedCustomer.Checking)
                {
                    if (account.IsActive)
                    {
                        Console.WriteLine($"\t\tAccount Number: {account.AccountNum}\t Current Balance: ${account.Balance}");
                    }
                }
            }
            if (ExistingTDC())
            {
                Console.WriteLine("\n\t TERM DEPOSIT CERTIFICATES ");
                foreach (var account in SelectedCustomer.TDC)
                {
                    if (account.IsActive)
                    {
                        Console.WriteLine($"\t\tAccount Number: {account.AccountNum}\t Create Date: {account.OpenDate.ToString()}" +
                            $"\t Maturity Date: {account.MaturityDate.ToString()}\n\t\t\tInterest Earned: ${account.InterestAmount}" +
                            $"\t Deposit Amount: ${account.Balance}");
                    }
                }
            }
            Console.WriteLine("");
        }

        static void ViewTransaction(Account account)
        {
            if (account.Transactions.Count != 0)
            {
                int i = 1;
                foreach (var trans in account.Transactions)
                {
                    Console.WriteLine($"{i}.  {trans}");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("\n\tNo Record Found!");
            }
        }

        static void BeforeClosingAccount()
        {
            ViewSelectedCustomer();
            if (SelectedCustomer != null)
            {
                try
                {
                    int accNum;
                    Console.Write("\n\tEnter Account # to close: ");
                    accNum = Convert.ToInt32(Console.ReadLine());
                    SetCloseAccount(accNum);
                }
                catch (FormatException)
                {
                    Console.WriteLine(" Something Went wrong.\t Response was not in a Correct Format \n-----Redirecting-----");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Something Went wrong.\n " + ex.Message + "\n-----Redirecting-----");
                }
            }

        }

        static void SetCloseAccount(int accNum)
        {
            BusinessAcc busAcc = FindBusinessAcc(accNum);
            //CheckingAcc checkAcc = FindCheckingAcc(accNum);
            //TermDepositAccount tdcAcc = FindTermDeposit(accNum);
            if(busAcc == null)
            {
                CheckingAcc checkAcc = FindCheckingAcc(accNum);
                if (checkAcc == null)
                {
                    TermDepositAccount tdcAcc = FindTermDeposit(accNum);
                    if(tdcAcc == null)
                    {
                        Console.WriteLine("\n\tCannot Find Account!");
                    }
                    else
                    {
                        if (tdcAcc.OkToClose())
                        {
                            //---transfer funds
                            int toAcc;
                            double cash = 0;
                            bool closedAccount;
                            Console.Write("Enter Account Number to transfer Money in or Enter '1' to withdraw in Cash: ");
                            try
                            {
                                toAcc = Convert.ToInt32(Console.ReadLine());
                                if (toAcc != 1)
                                {
                                    closedAccount = TransferToCloseTDC(tdcAcc, toAcc);
                                    if (closedAccount)
                                    {
                                        Console.WriteLine("\n\t\tTDC ACCOUNT CLOSED SUCCESSFULLY");
                                    }
                                }
                                else
                                {
                                    tdcAcc.CloseAccount(ref cash);
                                    Console.WriteLine("\n\t\tCash Withdrawan: $" + cash);
                                }

                            }
                            catch(FormatException)
                            {
                                Console.WriteLine("Account Number was not in Correct Format");
                            }
                            //tdcAcc.CloseAccount();
                        }
                        else
                        {
                            Console.WriteLine(UnableToProcess());
                            Console.WriteLine($"\t\tAccount Number: {tdcAcc.AccountNum}\t Create Date: {tdcAcc.OpenDate.ToString()}" +
                            $"\t Maturity Date: {tdcAcc.MaturityDate.ToString()}\n\t\t\tInterest Earned: ${tdcAcc.InterestAmount}" +
                            $"\t Deposit Amount: ${tdcAcc.Balance}");
                        }
                        
                    }
                }
                else
                {
                    if(checkAcc.OkToClose())
                    {
                        checkAcc.CloseAccount();
                    }
                    else
                    {
                        Console.WriteLine(UnableToProcess());
                        Console.WriteLine($"\t\tAccount Number: {checkAcc.AccountNum}\t Current Balance: ${checkAcc.Balance}");
                    }
                }
            }
            else
            {
                if (busAcc.OkToClose())
                {
                    busAcc.CloseAccount();
                }
                else
                {
                    Console.WriteLine(UnableToProcess());
                    Console.WriteLine($"\t\tAccount Number: {busAcc.AccountNum}\t Current Balance: ${busAcc.Balance}" +
                        $"\t Overdraft: ${busAcc.getOverdraftAmount()}");
                }
            }
        }
        static bool TransferToCloseTDC(TermDepositAccount fromAccount,int toAccNum)
        {
            bool successfulClose = false;
            var busAcc = FindBusinessAcc(toAccNum);
            var checkAcc = FindCheckingAcc(toAccNum);
            double tdcAmount = 0;
            if(busAcc != null)
            {
                fromAccount.CloseAccount(ref tdcAmount);
                busAcc.AddBalance(tdcAmount);
                successfulClose = true;
            }
            else if(checkAcc != null)
            {
                fromAccount.CloseAccount(ref tdcAmount);
                checkAcc.AddBalance(tdcAmount);
                successfulClose = true;
            }
            else
            {
                Console.WriteLine("\n\tNO ACCOUNT FOUND\n-----REDIRECTING-----");
            }
            return successfulClose;
        }
        static string UnableToProcess()
        {
            string unableProcess = "Unable to Process Request...";
            unableProcess += "\n\tPrinting Details...";
            return unableProcess;
        }

        #region existing accounts bool type functions
        /// <summary>
        /// Make sure you already selected a customer before calling any of these "Existing" methods
        /// This Methods returns true if there are records is any business account
        /// </summary>
        /// <returns>Boolean</returns>
        static bool ExistingBusAcc()
        {
            if (SelectedCustomer.Business.Count != 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Make sure you already selected a customer before calling any of these "Existing" methods
        /// </summary>
        /// <returns>Boolean</returns>
        static bool ExistingCheckAcc()
        {
            if (SelectedCustomer.Checking.Count != 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Make sure you already selected a customer before calling any of these "Existing" methods
        /// </summary>
        /// <returns>Boolean</returns>
        static bool ExistingTDC()
        {
            if (SelectedCustomer.TDC.Count != 0)
            {
                return true;
            }
            return false;
        }
        #endregion
        /*___ */


    }
}
