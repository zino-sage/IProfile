using MazinoAPIs.DTOs;
using MazinoAPIs.Interfaces;
using MazinoAPIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MazinoAPIs.Repositories
{
    public class UserRepo: IUserRep
    {
        private readonly APIModels context;
        public UserDTO GetUserById(int accountId,int userId)
        {
            var User = (from c in context.USERS_TBL 
                           where c.DELETED == false && c.USERID == userId && c.ACCOUNTID == accountId
                           select new UserDTO
                           {
                               firstName = c.FIRSTNAME,
                               lastName = c.LASTNAME,
                               companyName = context.ACCOUNTS_TBL.Where(us =>us.ACCOUNTID == c.ACCOUNTID ).FirstOrDefault().COMPANYNAME,
                               email = c.EMAIL,
                           }).FirstOrDefault();

            return User;
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            var Users = (from c in context.USERS_TBL
                            where c.DELETED == false
                            select new UserDTO
                            {
                                firstName = c.FIRSTNAME,
                                lastName = c.LASTNAME,
                                companyName = context.ACCOUNTS_TBL.Where(us => us.ACCOUNTID == c.ACCOUNTID).FirstOrDefault().COMPANYNAME,
                                email = c.EMAIL,
                            }).ToList();

            return Users;
        }

        public bool UpdateUser(int accountId, int userId, UserDTO model)
        {
            var usr = context.USERS_TBL.FirstOrDefault(ac => ac.USERID == userId && ac.ACCOUNTID == accountId);


            if (usr != null)
            {

                usr.FIRSTNAME = model.firstName;
                usr.LASTNAME = model.lastName;
                usr.EMAIL = model.email;
                usr.ACCOUNTID = model.accountId;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteUser(int accountId, int userId)
        {
            var usr = context.USERS_TBL.FirstOrDefault(ac => ac.USERID == userId && ac.ACCOUNTID == accountId && ac.DELETED ==false);


            if (usr != null)
            {

                usr.DELETED = true;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool CreateUser(int id, UserDTO model)
        {
            var UserExists = context.USERS_TBL.Where(ac => ac.EMAIL.ToLower() == model.email.ToLower()).FirstOrDefault();
            if (UserExists == null)
            {
                var newUser = new USERS_TBL();
                newUser.FIRSTNAME = model.firstName;
                newUser.LASTNAME = model.lastName;
                newUser.EMAIL = model.email;
                newUser.ACCOUNTID = id;

                context.USERS_TBL.Add(newUser);
                context.SaveChanges();

                return true;
            }
            return false;
        }

        public IEnumerable< UserDTO> GetUserByAccountId(int id)
        {
            var User = (from c in context.USERS_TBL
                        where c.DELETED == false && c.ACCOUNTID == id
                        select new UserDTO
                        {
                            firstName = c.FIRSTNAME,
                            lastName = c.LASTNAME,
                            companyName = context.ACCOUNTS_TBL.Where(us => us.ACCOUNTID == c.ACCOUNTID).FirstOrDefault().COMPANYNAME,
                            email = c.EMAIL,
                        }).ToList();

            return User;
        }
    }
}