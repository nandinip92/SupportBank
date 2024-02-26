namespace SupportBank.SupportBankManagement;

using System.Globalization;
using CsvHelper;

class Bank
{
    private List<Transaction> _transactionRegister = [];
    private Dictionary<string, Account> _account = [];

    public void ReadTransactionsFile(string fileName)
    {
        try
        {
            var fileReader = new StreamReader(fileName);
            var csvData = new CsvReader(fileReader, CultureInfo.InvariantCulture);
            _transactionRegister = csvData.GetRecords<Transaction>().ToList();
            _transactionRegister.ForEach(
                (transaction) =>
                {
                    //Console.WriteLine(transaction);
                    CheckTransaction(transaction);
                    // Console.WriteLine($"{transaction.Date} | {transaction.From} | {transaction.To}|");
                }
            );
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
    }

    public void CheckTransaction(Transaction transaction)
    {
        var fromPersonAccount = GetFromAccount(transaction.From, transaction.Amount);
        var toPersonAccount = GetToAccount(transaction.To, transaction.Amount);
    }

    public void UpdateFromPersonAccount(Account fromPersonAccount, decimal amount)
    {
        fromPersonAccount.AmountRecievable += amount;
    }

    public void UpdateToPersonAccount(Account toPersonAccount, decimal amount)
    {
        toPersonAccount.AmountDue += amount;
    }

    public Account GetFromAccount(string name, decimal amount)
    {
        if (_account.ContainsKey(name))
        {
            return _account[name];
        }
        else
        {
            var newAccount = new Account
            {
                Name = name,
                AmountRecievable = amount,
                AmountDue = 0
            };
            _account.Add(name, newAccount);
            return newAccount;
        }
    }

    public Account GetToAccount(string name, decimal amount)
    {
        if (_account.ContainsKey(name))
        {
            UpdateToPersonAccount(_account[name], amount);
            return _account[name];
        }
        else
        {
            var newAccount = new Account
            {
                Name = name,
                AmountRecievable = 0,
                AmountDue = amount
            };
            _account.Add(name, newAccount);
            return newAccount;
        }
    }
    
}
