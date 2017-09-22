using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHearthStoneV2.API.Hubs
{
    public class UserContext
    {
        //用户集合
        public List<SignalRUser> Users { get; set; } = new List<SignalRUser>();
        //连接集合
        public List<Connection> Connections { get; set; } = new List<Connection>();
        //房间集合
        public List<ConversationRoom> Rooms { get; set; } = new List<ConversationRoom>();
    }
}