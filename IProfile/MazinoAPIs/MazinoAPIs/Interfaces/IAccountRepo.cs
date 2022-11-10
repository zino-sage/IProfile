using MazinoAPIs.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MazinoAPIs.Interfaces
{
    public interface IAccountRepo
    {
        IEnumerable<AccountDTO> GetAllAccounts();
        AccountDTO GetAccountById(int Id);
        bool UpdateAccount(int accountId, AccountDTO model);
        bool CreateAccount(AccountDTO model);
        bool DeleteAccount(int accountId);
    }
}
