using Assessment.Accounts;

namespace Assessment;

public class AccountTests
{
    [Test]
    public void TestWithdrawalSavings()
    {
        Account savingsAccount = new SavingsAccount(10000, new Owner("test"));
        Assert.That(savingsAccount.Withdraw(10), Is.EqualTo(10));
        Assert.That(savingsAccount.checkBalance(), Is.EqualTo(9990));
        Assert.That(savingsAccount.Withdraw(2000), Is.EqualTo(2000));
        Assert.That(savingsAccount.checkBalance(), Is.EqualTo(7990));
        Assert.Throws(typeof(WithdrawalException), () => savingsAccount.Withdraw(8000));
    }
    
    [Test]
    public void TestWithdrawalChecking()
    {
        Account checkingAccount = new CheckingAccount(10000, new Owner("test"));
        Assert.That(checkingAccount.Withdraw(10), Is.EqualTo(10));
        Assert.That(checkingAccount.checkBalance(), Is.EqualTo(9990));
        Assert.That(checkingAccount.Withdraw(2000), Is.EqualTo(2000));
        Assert.That(checkingAccount.checkBalance(), Is.EqualTo(7990));
        Assert.Throws(typeof(WithdrawalException), () => checkingAccount.Withdraw(8000));
    }

    [Test]
    public void TestWithdrawalIndividualChecking()
    {
        Account individualCheckoutAccount = new IndividualCheckoutAccount(1011, new Owner("test"));
        Assert.That(individualCheckoutAccount.Withdraw(10), Is.EqualTo(10));
        Assert.That(individualCheckoutAccount.checkBalance(), Is.EqualTo(1001));
        Assert.Throws(typeof(WithdrawalException), () => individualCheckoutAccount.Withdraw(1001));
        Assert.That(individualCheckoutAccount.checkBalance(), Is.EqualTo(1001));
        individualCheckoutAccount.Withdraw(500);
        Assert.Throws(typeof(WithdrawalException), () => individualCheckoutAccount.Withdraw(1000));
    }
    
    [Test]
    public void TestDeposit()
    {
        Account savingsAccount = new SavingsAccount(10000, new Owner("test"));
        Assert.That(savingsAccount.checkBalance(), Is.EqualTo(10000));
        savingsAccount.Deposit(2000);
        Assert.That(savingsAccount.checkBalance(), Is.EqualTo(12000));
    }
    

    [Test]
    public void TestTransfer()
    {
        Account savingsAccount = new SavingsAccount(10000, new Owner("test"));
        Account checkingAccount = new CheckingAccount(100, new Owner("test"));
        Assert.That(savingsAccount.checkBalance(), Is.EqualTo(10000));
        Assert.That(checkingAccount.checkBalance(), Is.EqualTo(100));
        savingsAccount.Transfer(2000, checkingAccount);
        Assert.That(savingsAccount.checkBalance(), Is.EqualTo(8000));
        Assert.That(checkingAccount.checkBalance(), Is.EqualTo(2100));
    }
}
