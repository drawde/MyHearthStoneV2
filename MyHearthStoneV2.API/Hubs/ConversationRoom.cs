using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyHearthStoneV2.API.Hubs
{
    /// <summary>
    /// 游戏房间，也可以用做用户分组
    /// </summary>
    public class ConversationRoom
    {
        [Key]
        public int TableID { get; set; }
        //房间名称        
        public string RoomName { get; set; }
        //用户集合
        public virtual List<SignalRUser> Users { get; set; } = new List<SignalRUser>();
    }
}