using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkKS.Business
{
    public class User : IUser
    {
        #region Methods
        public Guid SignUp(string name, string eMail, string password)
        {
            using (var dc = new LinkKSDataContext())
            {
                var item = new USER();
                
                item.Id = new Guid();
                item.Name = name;
                item.EMail = eMail;
                item.Password = password;
                item.CreateDate = DateTime.Now;

                dc.USERs.InsertOnSubmit(item);

                dc.SubmitChanges();

                return item.Id;
            }
        }
        public Guid? SignIn(string eMail, string password)
        {
            using (var dc = new LinkKSDataContext())
            {
                var userId = dc.USERs.Where(c => c.EMail== eMail && c.Password == password).Select(c => c.Id).FirstOrDefault();

                if (userId == default(Guid))
                {
                    return null;
                }

                return userId;


            }

        }
        public void Update(Guid userId, string name, string eMail, string password)
        {
            using (var dc = new LinkKSDataContext())
            {
                var item = dc.USERs.Where(c => c.Id == userId).First();

                item.Name = name;
                item.EMail = eMail;
                item.Password = password;
                item.UpdateDate = DateTime.Now;

                dc.SubmitChanges();

            }
        }
        #endregion
    }
}
