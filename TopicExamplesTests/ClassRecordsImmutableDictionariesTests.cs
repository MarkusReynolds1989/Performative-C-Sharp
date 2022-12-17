using static TopicExampleCode.ClassRecordsImmutableDictionaries;

namespace Tests;

public static class ClassRecordsImmutableDictionariesTests
{
    [Fact]
    public static void RecordUpdateTest()
    {
        var account = new Account(0, new List<Transaction>());
        account = account.InsertTransaction(new Transaction(0, 200, TransactionType.Deposit));
        Assert.Equal(200, account.Transactions[0].Amount);
    }
}