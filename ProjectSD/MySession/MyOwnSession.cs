using ProjectSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSD.MySession
{
    public class MyOwnSession
    {
        private static MyOwnSession session = new MyOwnSession();

        public static MyOwnSession getInstance() {
            return session;
        }

        public Users user { set; get; }
    }
}