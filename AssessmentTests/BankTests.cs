using Assessment.Accounts;

namespace Assessment;

public class BankTests
{
    [Test]
    public void TestBank()
    {
        Bank.Bank bank = new Bank.Bank("MyBestBank", new List<Account>()
        {
            new CheckingAccount(1000, new Owner("test1")),
            new SavingsAccount(1000, new Owner("test2")),

        });
        Assert.That(bank.accounts, Has.Count.EqualTo(2));
    }
}