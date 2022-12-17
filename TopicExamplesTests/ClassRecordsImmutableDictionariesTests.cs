using System.Collections.Immutable;
using TopicExampleCode;

namespace Tests;

public static class ClassRecordsImmutableDictionariesTests
{
    [Fact]
    public static void RecordUpdateTest()
    {
        var account =
            new ClassRecordsImmutableDictionaries.Account(0, new List<ClassRecordsImmutableDictionaries.Transaction>());

        account = account.InsertTransaction(
            new ClassRecordsImmutableDictionaries.Transaction(
                0, 200, ClassRecordsImmutableDictionaries.TransactionType.Deposit));


        Assert.Equal(200, account.Transactions[0].Amount);
    }
}