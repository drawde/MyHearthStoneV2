using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using MyHearthStoneV2.Web.Models;

namespace MyHearthStoneV2.Web.Hubs
{
    public class ChatHub:Hub, IChatHub
    {
        private IList<UserChat> userList = ChatUserCache.userList;

        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }

        public void SendChat(string id, string name, string message)
        {
            Clients.All.addNewMessageToPage(id, name + " " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"), message);
        }

        public void TriggerHeartbeat(string id, string name)
        {
            var userInfo = userList.Where(x => x.ID.Equals(id) && x.Name.Equals(name)).FirstOrDefault();
            userInfo.count = 0;  //收到心跳，重置计数器
        }

        public void SendLogin(string id,string name)
        {
            var userInfo = new UserChat() { ID = id, Name = name };
            userInfo.action += () =>
            {
                //用户20s无心跳包应答，则视为掉线，会抛出事件，这里会接住，然后处理用户掉线动作。
                SendLogoff(id, name);
            };

            var comparison = new ChatUserCompare();
            if (!userList.Contains<UserChat>(userInfo, comparison))
                userList.Add(userInfo);
            Clients.All.loginUser(userList);
            SendChat(id, name, "<====用户 " + name + " 加入了讨论组====>");
        }

        public void SendLogoff(string id,string name)
        {
            var userInfo = userList.Where(x => x.ID.Equals(id) && x.Name.Equals(name)).FirstOrDefault();
            if (userInfo != null)
            {
                if (userList.Remove(userInfo))
                {
                    Clients.All.logoffUser(userList);
                    SendChat(id, name, "<====用户 " + name + " 退出了讨论组====>");
                }
            }
        }
    }
}