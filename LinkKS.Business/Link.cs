using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkKS.Business
{
    public class Link : ILink
    {
       
        #region methods
        public string Shorten(string longLink, Guid? userId, string password, DateTime? expireDate, bool oneShot, bool notification)
        {
            using (var dc = new LinkKSDataContext())
            {
                var item = new LINK(); //veri tabanında yeni satır oluşturduk

                item.Id = Guid.NewGuid();
                item.LongLink = longLink;
                item.ShortLink = this.GenerateShortLink(dc);
                item.UserId = userId;
                item.Password = password;
                item.CreateDate = DateTime.Now;
                item.OneShot = oneShot;
                item.Notification = notification;

                dc.LINKs.InsertOnSubmit(item);
                dc.SubmitChanges();

                return item.ShortLink;
            }
        }
        public void UpdateExpireDate(Guid linkId, DateTime? expireDate)
        {
            using (var dc = new LinkKSDataContext())
            {
                var item = dc.LINKs.First(c => c.Id == linkId);

                item.ExpireDate = expireDate;
                item.UpdateTime = DateTime.Now;

                dc.SubmitChanges();
            }
        }
        public void UpdatePassword(Guid linkId, string password)
        {
            using (var dc = new LinkKSDataContext())
            {
                var item = dc.LINKs.First(c => c.Id == linkId);

                item.Password = password;
                item.UpdateTime = DateTime.Now;

                dc.SubmitChanges();
            }
        }
        public void UpdateNotification(Guid linkId, bool notification)
        {
            using (var dc = new LinkKSDataContext())
            {
                var item = dc.LINKs.First(c => c.Id == linkId);

                item.Notification = notification;
                item.UpdateTime = DateTime.Now;

                dc.SubmitChanges();

            }
        }
        public void UpdateOneShot(Guid linkId, bool oneShot)
        {
            using (var dc = new LinkKSDataContext())
            {
                var item = dc.LINKs.First(c => c.Id == linkId);

                item.OneShot = oneShot;
                item.UpdateTime = DateTime.Now;

                dc.SubmitChanges();
            }
        }

        #region GenerateShortLink
        private const string ValidChars = "0123456789abcdefghijklmnopqrstuwvxyz";
        private string GenerateShortLink()
        {
            var rnd = new Random();
            var shortLink = "";

            for (int i = 0; i < 6; i++)
            {
                var index = rnd.Next(Link.ValidChars.Length);

                shortLink += Link.ValidChars[index];
            }

            return shortLink;
        }
        private string GenerateShortLink(LinkKSDataContext dc)
        {
            var rnd = new Random();

            while (true)
            {
                var shortLink = "";

                for (int i = 0; i < 6; i++)
                {
                    var index = rnd.Next(Link.ValidChars.Length);

                    shortLink += Link.ValidChars[index];
                }

                if (!dc.LINKs.Any(c => c.ShortLink == shortLink))
                {
                    return shortLink;
                }
            }
        }
        #endregion
        #endregion
    }
}
