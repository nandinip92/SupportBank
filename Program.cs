using SupportBank.SupportBankManagement;

var fileName = "./data/Transactions2014.csv";

var Bank = new Bank();
Bank.ReadTransactionsFile(fileName);


Bank.GetAllRecords();

Console.WriteLine("Please Enter the Name of the person you want know the transaction details about");
var name = Console.ReadLine()??"";
Bank.GetAllTransactionsOfAccount(name.ToUpper());
