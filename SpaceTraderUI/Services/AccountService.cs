using SpaceTraderUI.Model;

namespace SpaceTraderUI.Services;

// A playholder for all agents.
public class AccountService
{
    private Dictionary<string, Account> _acounts = new();

    public IEnumerable<Account> Accounts { get => _acounts.Values; }

    public void AddAccount(Account newAcount)
    {
        _acounts[newAcount.Agent.AccountId!] = newAcount;
    }

    public Account? GetByAccountId(string accountId)
    {
        Account? account;
        if (_acounts.TryGetValue(accountId, out account))
        {
            return account;
        }
        return null;
    }
}