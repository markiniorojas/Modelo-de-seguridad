//using Business.Implementations.Base;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Model_Security
{
    public interface IUserBusiness : IBaseBusiness<User>
    {
        //Task<User?> GetByUsernameAsync(string username);
    }
}
