using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHearthStoneV2.Web.Models;

namespace MyHearthStoneV2.Web.Hubs
{
    public static class ChatUserCache
    {
        public static IList<UserChat> userList = new List<UserChat>();
    }
}