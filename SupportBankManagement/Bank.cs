namespace SupportBank.SupportBankManagement;

using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Microsoft.Extensions.Logging;
class Bank
{
    private readonly List<Transaction> _transactionRegister = [];
    private readonly Dictionary<string, Account> _account = [];
    private readonly ILogger<SupportBankApp> _logger;

    public Bank(ILogger<SupportBankApp> logger)
    {
        _logger = logger;
    }

    public void ReadTransactionsFile(string fileName)
    {
        try
        {
            using var fileReader = new StreamReader(fileName);
            // using var csvData = new CsvReader(fileReader, CultureInfo.InvariantCulture);
            // _transactionRegister = csvData.GetRecords<Transaction>().ToList();
            // _transactionRegister.ForEach(
            //     (transaction) =>
            //     {
            //         UpdateAccount(transaction);
            //     }
            // );
            // foreach(var transaction in csvData.GetRecords<Transaction>()){
            //      _transactionRegister.Add(transaction);
            //      UpdateAccount(transaction);
            // }

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                ReadingExceptionOccurred = args=>{
                    if (args.Exception is TypeConverterException){
                        _logger.LogWarning($"Bad Record Found {args.Exception.Context.Parser.RawRecord}");
                        return false;
                    }
                    return true;
                }
            };
            using var csvData = new CsvReader(fileReader, csvConfig);
            foreach (var transaction in csvData.GetRecords<Transaction>())
            {
                _transactionRegister.Add(transaction);
                UpdateAccount(transaction);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Sorry, {fileName} was not found");
        }
        catch (IOException)
        {
            Console.WriteLine(
                $"Sorry cannot open {fileName}, Please close the file if it is open in another process."
            );
        }
        // catch (CsvHelperException ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }
    }

    public void UpdateAccount(Transaction transaction)
    {
        //This method will update the transaction if the account is present
        //Then it will update the AmountOwed else it will create a new account for that person
        //Finally adds the trasaction to the Transactions list
        var nameKey = transaction.From.ToUpper(); // to ignore the case when input is given
        var name = transaction.From;
        if (_account.TryGetValue(nameKey, out Account? value))
        {
            value.AmountOwed += transaction.Amount;
        }
        else
        {
            var newAccount = new Account
            {
                Name = name,
                AmountOwed = transaction.Amount,
                AccountTransactions = [transaction]
            };
            _account[nameKey] = newAccount;
            _logger.LogInformation($"New account is created for {name}");
        }
        _account[nameKey].AccountTransactions.Add(transaction);
    }

    public void GetAllRecords()
    {
        //  Following method is for:
        // List All - prints out the names of each person, along with the total amount they owe or are owed, as before
        string border = String.Concat('\n', new string('-', 45), '\n');
        string header = string.Format("|{0,15} |{1,20} |", "Name", "Total Amount Owed");
        var table = String.Concat(border, header, border);
        foreach (var (name, account) in _account)
        {
            string row = String.Format("|{0,15} |{1,20} |", account.Name, account.AmountOwed);
            table = String.Concat(table, row, border);
        }
        Console.WriteLine(table);
    }

    public void GetAllTransactionsOfAccount(string name)
    {
        //Following method is for -
        //List [Account] - prints out every transaction (with date, narrative, to and amount) for the specific account the user asks for.
        try
        {
            Console.WriteLine(_account[name]);
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine($"Sorry, There is not account holder named '{name}'");
        }
    }
}
