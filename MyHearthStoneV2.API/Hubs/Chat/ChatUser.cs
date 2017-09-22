using MyHearthStoneV2.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHearthStoneV2.API.Hubs.Chat
{
    public class ChatUser : SignalRUser
    {
        public string GameCode { get; set; }
    }
}