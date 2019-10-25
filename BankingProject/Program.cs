using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankingProject
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static Customer SelectedCustomer;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello \t World!");

            //UserInfoReceiveSelect();
            //UserOptions();


            CreateCust();
            PrintCustInfo();
            OpenAccount();
            AddBalaceChecking(1000, 1000001);
            AddBalaceBusiness(1000, 1000001);
            //PrintCustInfo();
            DisplayAllAccounts();

        }

        static void CreateCust()
        {

            var cust1 = new Customer()
            {
                Id = IncrementUtility.CustNextVal(),
                FirstName = "John",
                LastName = "Desk",
                Address = "8934 Guela Vala Ave",
                City = "Reston",
                State = "VA",
                Email = "john@gmail.com",
                SocialSec = 235538857
            };
            var cust2 = new Customer()
            {
                Id = IncrementUtility.CustNextVal(),
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
                Id = IncrementUtility.CustNextVal(),
                FirstName = "Jojo",
                LastName = "Rovinski",
                Address = "83 Adam St",
                City = "Silver Spring",
                State = "MD",
                Email = "jojorov@gmail.com",
                SocialSec = 324324324
            };
            customers.Add(cust1);
            //customers.Add(cust2);
            //customers.Add(cust3);
        }

        // Prints Existing Customers' Information
        static void PrintCustInfo()
        {
            foreach (var cust in customers)
            {
                //cust.ReturnSocial(out int social);
                Console.WriteLine($"-------------------\nCustomer Id: {cust.Id}\n Name: {cust.FirstName} {cust.LastName}\n Address: {cust.Address}, {cust.City}, " +
                    $"{cust.State}\n Email: {cust.Email}\n Social Security: {cust.SocialSec}");
                if (ExisitngBusAcc(cust))
                {
                    foreach (var busAcc in cust.Business)
                    {
                        Console.Write($"Business Account# : {busAcc.BusAccNo}");
                        Console.WriteLine($"	Balance: {busAcc.Balance}");
                    }
                }
                if (ExisitngCheckAcc(cust))
                {
                    foreach (var checkAcc in cust.Checking)
                    {
                        Console.WriteLine($"Checking Account#: {checkAcc.CheckAccNo}");
                        Console.WriteLine($"	Balance: {checkAcc.Balance}");
                    }

                }
            }
        }

        // Open a new account for selected customer
        static void OpenAccount()
        {
            // If there is already a customer selected
            if (SelectedCustomer == null)
            {
                UserInfoReceiveSelect();
                OpenAccount();
            }
            else
            {
                string userAccountDecision = "";
                Console.WriteLine("_______________________________________________\n\tSelected Customer: "+SelectedCustomer.FullName);
                Console.Write("\tPress 'OB' to open a New Business Account.\n   OR   Press 'OC' to open a New Checkings Account.\n" +
                    "   OR   Press 'S' to Select other Customer\n\t:  ");
                userAccountDecision = Console.ReadLine();
                switch (userAccountDecision)
                {
                    case "OB":
                        OpenBusinessAcc();
                        break;
                    case "OC":
                        OpenCheckingAcc();
                        break;
                    case "S":
                        UserInfoReceiveSelect();
                        OpenAccount();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid Answer!");
                        Console.WriteLine("Redirecting to Home Screen!\n");
                        UserOptions();
                        break;
                }
            }
        }

        //--- Takes user input to search for Existing Customer
        static void UserInfoReceiveSelect()
        {
            string fname, lname;
            int inputId;
            bool tryBack = false;
            try
            {
                Console.WriteLine("-----------------------------------------------\nPlease Enter Customer Information");
                Console.Write("\t(Case Sensitive)\n\t Enter First Name: ");
                fname = Console.ReadLine();
                Console.Write("\t Enter Last Name: ");
                lname = Console.ReadLine();
                Console.Write("\t Enter Customer ID: ");
                inputId = Convert.ToInt32(Console.ReadLine());

                if (fname != null && lname != null)
                {
                    CustomerSelect(fname, lname, inputId);
                }
                else
                {
                    Console.Write("Press 0 to go back or 1 to try again: ");
                    inputId = Convert.ToInt32(Console.ReadLine());
                    tryBack = ((inputId == 1) ? true : (inputId == 0) ? false : false);
                    if (inputId == 1)
                    {
                        Console.WriteLine("---Redirecting---");
                    }

                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(" Something Went wrong.\n " + ex.Message + "\n-----Redirecting-----");
                UserOptions();
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Something Went wrong.\n " + ex.Message + "\n-----Redirecting-----");
                UserOptions();
            }
        }
        //--- Selects a Customer after finishing search criteria
        static void CustomerSelect(string Fname, string Lname, int id)
        {
            // SelectedCustomer = customers.Where(c => c.FirstName.Equals(Fname) && c.LastName.Equals(Lname)).;
            SelectedCustomer = null;
            bool yesNo = false;
            foreach (var sCust in customers)
            {
                if (sCust.FirstName == Fname && sCust.LastName == Lname && sCust.Id == id)
                {
                    SelectedCustomer = sCust;
                    Console.WriteLine($" Customer Selected: {SelectedCustomer.FullName}");

                }
            }
            if (SelectedCustomer == null)
            {
                Console.WriteLine("\n\t Customer not found!");
                Console.Write("Do you want to Search Again?\n   Press 'Y' for yes / 'N' to go back");
                yesNo = (Console.ReadLine() != "Y") ? false : true;

                if (yesNo)
                    UserInfoReceiveSelect();
                else
                    UserOptions();

            }
        }

        static void OpenBusinessAcc()
        {
            var busAcc = new BusinessAcc()
            {
                BusAccNo = IncrementUtility.AccountNextVal(),
                Customer_Id = SelectedCustomer.Id,
                Customer = SelectedCustomer
            };
            SelectedCustomer.Business.Add(busAcc);
        }

        static void OpenCheckingAcc()
        {
            if (!ExisitngCheckAcc(SelectedCustomer))
            {
                var checkAcc = new CheckingAcc()
                {
                    CheckAccNo = IncrementUtility.AccountNextVal(),
                    Customer_Id = SelectedCustomer.Id,
                    Customer = SelectedCustomer
                };
                SelectedCustomer.Checking.Add(checkAcc);
            }
            else
            {
                Console.WriteLine("Already have an existing Checkings account");
                UserOptions();
            }
        }

        static void DisplayAllAccounts()
        {
            //--- To the developer: Use method Overloading in such types here
            Console.WriteLine("Displaying Accounts under " + SelectedCustomer.FullName + "(ID: "+ SelectedCustomer.Id + ")");
            if (ExisitngBusAcc(SelectedCustomer))
            {
                Console.WriteLine("\n\tBUSINESS ACCOUNTs INFO");
                foreach(var cust in SelectedCustomer.Business)
                {
                    Console.WriteLine($"\t\tAccount Number: {cust.BusAccNo}\t Current Balance: {cust.Balance}");
                }
            }
            else
            {
                Console.WriteLine("\n\tNO BUSINESS ACCOUNT FOUND");
            }
            if(ExisitngCheckAcc(SelectedCustomer))
            {
                Console.WriteLine("\n\tCHECKING ACCOUNTs INFO");
                foreach(var cust in SelectedCustomer.Checking)
                {
                    Console.WriteLine($"\t\tAccount Number: {cust.CheckAccNo}\t Current Balance: {cust.Balance}");
                }
            }
            else
            {
                Console.WriteLine("\n\tNO CHECKING ACCOUNT FOUND");
            }
        }

        //------------Deal with Balance start
		//---Methods to add balance in business or checking account
        static void AddBalaceBusiness(double amt, int accId)
        {
            if(ExisitngBusAcc(SelectedCustomer))
			{
				foreach (var cust in SelectedCustomer.Business)
                {
                    if(cust.BusAccNo == accId)
                    {
                        cust.Balance += amt;
                        string transIn = (DateTime.Now.ToString()) + "  Deposit Amount: $" + amt + "    New Balance: $" + cust.Balance;
                        cust.transactions.Add(transIn);
                        printNewBal(cust.Balance);
                    }
                    
                }
            }
			else 
			{
                noAccFound("Business");
            }
        }
		 
		static void AddBalaceChecking(double amt, int accId)
        {
            if(ExisitngCheckAcc(SelectedCustomer))
			{
                foreach (var cust in SelectedCustomer.Checking)
                {
                    if (cust.CheckAccNo == accId)
                    {
                        cust.Balance += amt;
                        string transIn = (DateTime.Now.ToString()) + "  Deposit Amount: $" + amt + "    New Balance: $" + cust.Balance;
                        cust.transactions.Add(transIn);
                        printNewBal(cust.Balance);
                    }
                }
            }
			else 
			{
                noAccFound("Checking");
			}
        }
        //---Methods to deduct balance from business or checking account
        static void WithDrawBusiness(double amt, int accId)
        {
            if(ExisitngBusAcc(SelectedCustomer))
			{
                foreach (var cust in SelectedCustomer.Business)
                {
                    if (cust.BusAccNo == accId)
                    {
                        cust.Balance -= amt;
                        string transIn = (DateTime.Now.ToString()) + "  Deposit Amount: $" + amt + "    New Balance: $" + cust.Balance;
                        cust.transactions.Add(transIn);
                        printNewBal(cust.Balance);

                    }

                }
            }
			else 
			{
                noAccFound("Business");
			}
        }
		
        static void WithDrawChecking(double amt, int accId)
        {
			double afterBal;
            if(ExisitngCheckAcc(SelectedCustomer))
			{
                foreach (var cust in SelectedCustomer.Checking)
                {
                    afterBal = cust.Balance - amt;
                    if (afterBal >= 0)
                    {
                        cust.Balance -= amt;
                        string transIn = (DateTime.Now.ToString()) + "  Withdraw Amount: $" + amt + "    New Balance: $" + cust.Balance;
                        cust.transactions.Add(transIn);
                        printNewBal(amt);
                    }
                    else
                    {
                        Console.WriteLine($"Current Balance in account: {cust.Balance}");
                        Console.WriteLine($"Not enough funds to withdraw: ${amt}");
                    }
                }
				
			}
			else 
			{
                noAccFound("Checking");
			}
        }

        static void printNewBal(double newBal)
        {
            Console.WriteLine($"\n\tTransaction Successful! \n\tNew Balance: {newBal}\n");
        }
		
		static void noAccFound(string accType)
		{
			Console.WriteLine($"\nCannot Find a {accType} Account associated with the selected User");
			Console.WriteLine("Redirecting to the Main Screen");
			UserOptions();
		}
        //------------Deal with Balance End

        static void CloseAccount()
        {

        }

        static bool ExisitngBusAcc(Customer cust)
        {
            bool test = false;
            if (cust.Business.Count != 0)
                test = true;
            else
                test = false;
            return test;
        }

        static bool ExisitngCheckAcc(Customer cust)
        {
            bool test = false;
            if (cust.Checking.Count != 0)
                test = true;
            else
                test = false;
            return test;
        }

        static void UserOptions()
        {

        }
        


    }
}
