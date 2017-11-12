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
using MyHearthStoneV2.Game;

namespace MyHearthStoneV2.API.Hubs
{
    public class BattleHub : Hub, IHub
    {
        [SignalRMethod]
        public string Online(string param)
        {
            JObject jobj = JObject.Parse(param);
            string userCode = jobj["UserCode"].TryParseString();
            string userName = jobj["NickName"].TryParseString();
            string gameCode = jobj["GameCode"].TryParseString();
            var res = ControllerProxy.GetGame(gameCode, userCode);
            if (res.code == (int)OperateResCodeEnum.成功)
            {
                ChessboardOutput chessBoard = ((APISingleModelResult<ChessboardOutput>)res).data;
                if (chessBoard != null && chessBoard.Players.Any(c => c.UserCode == userCode))
                {
                    return JsonStringResult.SuccessResult(chessBoard);
                }
            }
            return JsonStringResult.Error(OperateResCodeEnum.参数错误);
        }

        /// <summary>
        /// 开局换牌
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [SignalRMethod]
        public string SwitchCard(string param)
        {
            JObject jobj = JObject.Parse(param);
            string userCode = jobj["UserCode"].TryParseString();
            string gameCode = jobj["GameCode"].TryParseString();
            string switchCards = jobj["SwitchCards"].TryParseString();

            var res = ControllerProxy.GetGame(gameCode, userCode);
            if (res.code == (int)OperateResCodeEnum.成功)
            {
                res = ControllerProxy.SwitchCard(gameCode, userCode, switchCards.Split(",").ToList());
                var userCard = ((APISingleModelResult<BaseUserCards>)res).data;
                if (userCard != null)
                {
                    return JsonStringResult.SuccessResult(userCard);
                }
            }
            return JsonStringResult.Error(OperateResCodeEnum.参数错误);
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