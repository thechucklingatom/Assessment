namespace Assessment.Accounts;

public class IndividualCheckoutAccount : CheckingAccount
{
    public IndividualCheckoutAccount(decimal balance, Owner accountOwner) : base(balance, accountOwner)
    {
    }
    
    public override decimal Withdraw(decimal amountToWithdraw)
    {
        if (amountToWithdraw > 1000)
        {
            throw new WithdrawalException("Withdrawal limit of $1000 reached");
        }
        return base.Withdraw(amountToWithdraw);
    }

}