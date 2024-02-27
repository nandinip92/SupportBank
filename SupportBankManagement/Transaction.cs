namespace SupportBank.SupportBankManagement;

class Transaction
{
    public required string Date { get; set; }
    public required string From { get; set; }
    public required string To { get; set; }
    public required string Narrative { get; set; }
    public decimal Amount { get; set; }

    public override string ToString()
    {
        return String.Format("{0,20} |{1,20} |{2,20} |{3,20}|",Date,From,To,Amount);
    }

   
}