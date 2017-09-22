using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Timers;
using MyHearthStoneV2.Common;

namespace MyHearthStoneV2.API.Models
{
    public class SignalRUser
    {
        public SignalRUser()
        {
            count = 0;
            if (Timer == null) Timer = new Timer();
            Timer.Interval = 15000;  //15s触发一次
            Timer.Start();
            Timer.Elapsed += (sender, args) =>
            {
                count++;
                if (count >= 20)
                {
                    action();  //该用户掉线了，抛出事件通知
                }
            };
        }

        private readonly Timer Timer;
        public event Action action;
        
        public string UserCode { get; set; }
        public string Name { get; set; }

        //内部计数器（每次递增1），如果服务端每5s能收到客户端的心跳包，那么count被重置为0；
        //如果服务端20s后仍未收到客户端心跳包，那么视为掉线
        public int count{get;set;}        
    }
}