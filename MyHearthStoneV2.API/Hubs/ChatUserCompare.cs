using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHearthStoneV2.API.Models;

namespace MyHearthStoneV2.API.Hubs
{
    public class ChatUserCompare : IEqualityComparer<UserChat>
    {
        public bool Equals(UserChat x, UserChat y)
        {
            return x.ID == y.ID;
        }

        public int GetHashCode(UserChat obj)
        {
            return obj.GetHashCode();
        }
    }
}