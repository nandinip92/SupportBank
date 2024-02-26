using SupportBank.SupportBankManagement;

var fileName = "./data/Transactions2014.csv";

var Bank = new Bank();
Bank.ReadTransactionsFile(fileName);

Console.WriteLine("Helooo....!!!");
Console.WriteLine("Please select from the following options");
Console.WriteLine("[1] Get All the Records");
Console.WriteLine("[2] Get Transactions of a specific person");
var option = int.Parse(Console.ReadLine() ?? "0");

switch (option)
{
    case 1:
        Bank.GetAllRecords();
        break;
    case 2:
        Console.WriteLine(
            "Please Enter the person name you want know the transaction details >>> "
        );
        var name = Console.ReadLine() ?? "";
        Bank.GetAllTransactionsOfAccount(name.ToUpper());
        break;
    default:
        Console.WriteLine("Invalid option, Please Enter a valid option...!!!");
        break;
}
