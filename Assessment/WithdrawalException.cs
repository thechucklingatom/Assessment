using System.Transactions;

namespace Assessment;

public class WithdrawalException : Exception
{
    public WithdrawalException(string message) : base(message)
    {
        
    }
}