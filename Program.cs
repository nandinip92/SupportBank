using SupportBank.SupportBankManagement;

var fileName = "./data/Transactions2014.csv";

var Bank = new Bank();
Bank.ReadTransactionsFile(fileName);

// Console.WriteLine(transactionList);
// transactionList.ForEach(
//     (transaction) =>
//     {
//         Console.WriteLine(
//             $"{transaction.Date} | {transaction.From} | {transaction.To}|"
//         );
//     }
// );
