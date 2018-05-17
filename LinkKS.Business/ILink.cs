using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkKS.Business
{
    interface ILink
    {
        string Shorten(string longLink, Guid? userId, string password, DateTime? expireDate, bool oneShot, bool notification); // ...
        void UpdateExpireDate(Guid linkId, DateTime? expireDate);
        void UpdatePassword(Guid linkId, string password);
        void UpdateNotification(Guid linkId, bool notification);
        void UpdateOneShot(Guid linkId, bool oneShot);

    }
}
