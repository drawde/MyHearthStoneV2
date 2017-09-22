using MyHearthStoneV2.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHearthStoneV2.API.Hubs.ChosenCardGroup
{
    public class ChosenCardGroupUserCache
    {
        public static IList<SignalRUser> userList = new List<SignalRUser>();
    }
}