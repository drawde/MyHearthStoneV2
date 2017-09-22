using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHearthStoneV2.API.Models;

namespace MyHearthStoneV2.API.Hubs.Chat
{
    public class ChatUserCompare : IEqualityComparer<ChatUser>
    {
        public bool Equals(ChatUser x, ChatUser y)
        {
            return x.UserCode == y.UserCode;
        }

        public int GetHashCode(ChatUser obj)
        {
            return obj.GetHashCode();
        }
    }
}