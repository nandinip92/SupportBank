namespace SupportBank.SupportBankManagement;

class Account
{
    public required string Name { get; set; }
    public required decimal AmountRecievable { get; set; }
    public required decimal AmountDue { get; set; }

    public override string ToString()
    {
        return String.Format("{0,20} |{1,20} |{2,20} |", Name, AmountRecievable,AmountDue);
    }
    //  public override bool Equals(object? obj)
    // {
    //     return obj is Account account && account.Name == Name ;
    // }
    //  public override int GetHashCode()
    // {
    //     return HashCode.Combine(Name);
    // }
}
