using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHearthStoneV2.API.Models;

namespace MyHearthStoneV2.API.Hubs
{
    public static class ChatUserCache
    {
        public static IList<UserChat> userList = new List<UserChat>();
    }
}