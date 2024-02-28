namespace SupportBank.SupportBankManagement;

using Microsoft.Extensions.Logging;

class UserInterface
{
    private readonly ILogger<SupportBankApp> _logger;

    public UserInterface(ILogger<SupportBankApp> logger)
    {
        _logger = logger;
    }

    public void RunUI()
    {
        // var fileName = "./data/Transactions2014.csv";
        var fileName = "./data/DodgyTransactions2015.csv";

        var Bank = new Bank(_logger);
        Bank.ReadTransactionsFile(fileName);

        Console.WriteLine("Helooo Welcome....!!!");
        Console.WriteLine("[1] Get All the Records");
        Console.WriteLine("[2] Get Transactions of a specific person");
        Console.Write("Please select an option from the above >>>");

        var option = int.Parse(Console.ReadLine() ?? "0");

        switch (option)
        {
            case 1:
                Bank.GetAllRecords();
                break;
            case 2:
                Console.Write(
                    "Please Enter the person name you want know the transaction details >>> "
                );
                var name = Console.ReadLine() ?? "";
                Bank.GetAllTransactionsOfAccount(name.ToUpper());
                break;
            default:
                Console.WriteLine("Invalid option, Please Enter a valid option...!!!");
                break;
        }
    }
}
