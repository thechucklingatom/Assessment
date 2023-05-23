namespace Assessment.Accounts;

public abstract class Account
{
    private decimal _balance;
    private Owner _accountOwner;

    protected Account(decimal balance, Owner accountOwner)
    {
        _balance = balance;
        _accountOwner = accountOwner;
    }

    /// <summary>
    /// Method to withdraw money from an account. Throws a <see cref="BalanceException"/> if the account does not support
    /// the balance.
    /// </summary>
    /// <param name="amountToWithdraw">The amount the user wants to withdraw</param>
    /// <returns>The amount of money withdrawn</returns>
    /// <exception cref="WithdrawalException">If the user overdraws the account</exception>
    public virtual decimal Withdraw(decimal amountToWithdraw)
    {
        if (amountToWithdraw > _balance)
        {
            throw new WithdrawalException("Insufficient funds");
        }

        _balance -= amountToWithdraw;
        return amountToWithdraw;
    }

    /// <summary>
    /// Method to deposit money into an account.
    /// </summary>
    /// <param name="amountToDeposit">The amount of money the user would like to deposit</param>
    public void Deposit(decimal amountToDeposit)
    {
        _balance += amountToDeposit;
    }

    /// <summary>
    /// Method to transfer money between accounts.
    /// </summary>
    /// <param name="amountToTransfer">The amount of money the user would like to transfer</param>
    /// <param name="targetAccount">The Account the user would like to transfer to</param>
    /// <exception cref="WithdrawalException">Thrown if the user does not have enough funds in the account to transfer</exception>>
    public void Transfer(decimal amountToTransfer, Account targetAccount)
    {
        decimal amountWithdrawn = Withdraw(amountToTransfer);
        targetAccount.Deposit(amountWithdrawn);
    }

    /// <summary>
    /// method to check the balance of an account.
    /// </summary>
    /// <returns></returns>
    public Decimal checkBalance()
    {
        return _balance;
    }
}