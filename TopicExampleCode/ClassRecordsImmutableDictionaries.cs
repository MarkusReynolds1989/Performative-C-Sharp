namespace TopicExampleCode;

public static class ClassRecordsImmutableDictionaries
{
    public enum TransactionType
    {
        Deposit,
        Withdrawal
    }

    // The big difference is that a record is just a plain data type and it is immutable.
    public record Transaction(int Id, decimal Amount, TransactionType TransactionType);
    
    // It can also be pass by value. This means that it will copy to every method that uses it.
    public record struct Person(int id);

    public record Account(int Id, IList<Transaction> Transactions);

    // In this way you always have to update Account with the new value.
    // No variable gets mutated.
    public static Account InsertTransaction(this Account account, Transaction transaction)
    {
        var transactions = account.Transactions.Append(transaction).ToImmutableList();
        return account with {Transactions = transactions};
    }

    // Classes are more complicated, if you want to check their fields you will have to use reflection.
    // They are not immutable, and they are pass by reference.
    // They can also have methods attached to them.
    // The major downside here is that there is a virtual call made to every method.
    // VTables have to be generated and accessed in the course of the program.
    // The .NET runtime is extremely efficient at allocating classes and accessing VTables, however.
    // It usually pays to start with classes if you know that you will need to group data with functions and you need to 
    // be able to mutate it.
    public class Customer
    {
        private int _id;
        private string _name;

        public Customer(int id, string name)
        {
            _id = id;
            _name = name;
        }
    }

    // Major downside with dynamic is that you cannot AOT this code. This takes advantage of runtime type resolution.
    // Upside is that you can cycle through the keys of the dictionary instead of using reflection on a class.
    public static IDictionary<string, dynamic> CreateBank(int id,
                                                          string address,
                                                          decimal moneyAvailable)
    {
        var bank = new Dictionary<string, dynamic>
        {
            {"id", id},
            {"address", address},
            {"moneyAvailable", moneyAvailable},
        };

        return bank.ToImmutableDictionary();
    }
}