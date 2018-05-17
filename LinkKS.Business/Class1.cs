using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkKS.Business
{
    public class Class1
    {
        void Test()
        {
            // LinkKSDataContext ~ Veritabanı
            //using (var dc = new LinkKSDataContext())
            //{
            //    var result = dc.LINKs.Where(c => c.ShortLink == "wefgh4");

            //    var oneShot = result.First().OneShot;

            //    result.First().Password = "12345";

            //    dc.SubmitChanges();

            //    var eMail = result.First().USER.LINKs.Where(c => c.Status == 1).SelectMany(c => c.LINK_LOGs).OrderByDescending(c => c.Date).First();//.Select(c => c.LongLink);
            //}

            //using (var conn = new SQLConnect())
            //{
            //    conn.Open();

            //    var command = "SELECT * FROM LINK WHERE ShortLink='wefgh4'";

            //    var result = conn.ExecuteReader(command);

            //    var oneShot = (bool)result.Tables[0].Rows[0].Columns["OneShot"];
            //}
        }
    }
}
