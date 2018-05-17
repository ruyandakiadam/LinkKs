using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkKS.Business
{
    interface IUser
    {
        Guid SignUp(string name, string eMail, string password);
        Guid? SignIn(string eMail, string password);
        void Update(Guid userId, string name, string eMail, string password);
    }
}
