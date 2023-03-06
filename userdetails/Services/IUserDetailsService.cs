using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userdetails.Models;

namespace userdetails.Services
{
    public interface IUserDetailsService
    {
        UserDetails GetUserDetails();

        int InsertNewUser(UserDetails user);

        void DeleteUser(int id);
    }
}
