using LinkKS.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkKS.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var link = new Link();
            //var shortLink = link.Shorten("http://www.empatik.com", null, "12345");
            link.Update(new Guid("B5BFBE6F-7DBB-4A2E-9787-1BC785D83204"), "abcde");

        }
    }
}
