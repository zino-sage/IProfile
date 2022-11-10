using MazinoAPIs.DTOs;
using MazinoAPIs.Interfaces;
using MazinoAPIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MazinoAPIs.Repositories
{
    public class AccountRepo : IAccountRepo
    {
        private readonly APIModels context;
        public AccountDTO GetAccountById(int Id)
        {
            var account = (from c in context.ACCOUNTS_TBL
                           where c.DELETED == false && c.ACCOUNTID == Id
                           select new AccountDTO
                           {
                               companyName = c.COMPANYNAME,
                               webSite = c.WEBSITE,
                           }).FirstOrDefault();

            return account;
        }

        public IEnumerable<AccountDTO> GetAllAccounts()
        {
            var accounts = (from c in context.ACCOUNTS_TBL
                            where c.DELETED == false
                            select new AccountDTO
                            {
                                companyName = c.COMPANYNAME,
                                webSite = c.WEBSITE,
                            }).ToList();

            return accounts;
        }

        public bool UpdateAccount(int Id, AccountDTO model)
        {
            var acct = context.ACCOUNTS_TBL.FirstOrDefault(ac => ac.ACCOUNTID == Id);


            if (acct != null)
            {

                acct.COMPANYNAME = model.companyName;
                acct.WEBSITE = model.webSite;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool CreateAccount(AccountDTO model)
        {
            var accountExists = context.ACCOUNTS_TBL.Where(ac => ac.COMPANYNAME.ToLower() == model.companyName.ToLower()).FirstOrDefault();
            if (accountExists == null)
            {
                var newAccount = new ACCOUNTS_TBL();
                newAccount.COMPANYNAME = model.companyName;
                newAccount.WEBSITE = model.webSite;

                context.ACCOUNTS_TBL.Add(newAccount);
                context.SaveChanges();

                return true;
            }
            return false;
        }

        public bool DeleteAccount(int accountId)
        {
            var acc = context.USERS_TBL.FirstOrDefault(ac => ac.ACCOUNTID == accountId && ac.DELETED == false);

            if (acc != null)
            {
                var accountUsers = context.USERS_TBL.Where(us => us.ACCOUNTID == accountId).ToList();
                if(accountUsers != null)
                {
                    foreach (var user in accountUsers)
                    {
                        user.DELETED = true;
                    }
                }

                acc.DELETED = true;
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
