using Microsoft.AspNet.SignalR;
using MyHearthStoneV2.APIMonitor;
using MyHearthStoneV2.Common.JsonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHearthStoneV2.API.Hubs
{
    public class BattleHub : Hub, IHub
    {
        [SignalRMethod]
        public string Online(string param)
        {
            return JsonStringResult.SuccessResult();
        }
        public void Bordcast(string param)
        {
            throw new NotImplementedException();
        }

        public void LeaveRoom(string param)
        {
            throw new NotImplementedException();
        }

        public void SendChat(string userCode, string chatContent, string roomCode)
        {
            throw new NotImplementedException();
        }
    }
}