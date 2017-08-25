using System;
namespace MyHearthStoneV2.Web.Hubs
{
    interface IChatHub
    {
        //服务器下发消息到各个客户端
        void SendChat(string id, string name, string message);

        //用户上线通知
        void SendLogin(string id, string name);

        //用户下线通知
        void SendLogoff(string id, string name);

        //接收客户端发送的心跳包并处理
        void TriggerHeartbeat(string id, string name);
    }
}
