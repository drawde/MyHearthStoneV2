using Microsoft.AspNet.SignalR;
using MyHearthStoneV2.APIMonitor;
using MyHearthStoneV2.Common.JsonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHearthStoneV2.Common.Util;
using Newtonsoft.Json;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.BLL;
using Newtonsoft.Json.Linq;
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.GameControler;
using MyHearthStoneV2.Model.CustomModels;
namespace MyHearthStoneV2.API.Hubs
{
    public class BattleHub : Hub, IHub
    {
        [SignalRMethod]
        public string Online(string param)
        {
            JObject jobj = JObject.Parse(param);
            string userCode = jobj["UserCode"].TryParseString();
            string gameCode = jobj["GameCode"].TryParseString();

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