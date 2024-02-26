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

   public void CheckTransaction(){}

}
