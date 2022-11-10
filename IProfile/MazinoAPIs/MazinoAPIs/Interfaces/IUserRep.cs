using MazinoAPIs.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MazinoAPIs.Interfaces
{
    public interface IUserRep
    {
        IEnumerable<UserDTO> GetAllUsers();
        UserDTO GetUserById(int accountId, int userId);
        bool UpdateUser(int accountId, int userId, UserDTO model);
        bool CreateUser(int id, UserDTO model);
        IEnumerable<UserDTO> GetUserByAccountId(int id);
        bool DeleteUser(int accountId, int userId);
    }
}
