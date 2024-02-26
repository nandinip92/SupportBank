namespace SupportBank.SupportBankManagement;

class Account
{
    public required string Name { get; set; }
    public required decimal AmountOwed { get; set; }
    public required List<Transaction> AccountTransactions { get; init; } = [];

    public override string ToString()
    {
        Console.WriteLine(String.Format("{0,20} |{1,20} |", Name, AmountOwed));
        string border = String.Concat('\n', new string('-', 52), '\n');
        string headings = string.Format("|{0,10} |{1,15} |{2,20} |", "Date", "Owed To", "Amount");
        string table = String.Concat(border, headings, border);
        AccountTransactions.ForEach(transaction =>
        {
            string row = String.Format(
                "|{0,10} |{1,15} |{2,20} |",
                transaction.Date,
                transaction.To,
                transaction.Amount
            );
            table = String.Concat(table, row, border);
        });
        return table;
    }
}
