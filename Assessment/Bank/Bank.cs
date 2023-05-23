using Assessment.Accounts;

namespace Assessment.Bank;

public class Bank
{
    public string Name = "default bank";
    public List<Account> accounts = new List<Account>();

    public Bank(string name, List<Account> accountsList)
    {
        Name = name;
        accounts = accountsList;
    }

}