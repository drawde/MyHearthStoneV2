using Microsoft.AspNet.SignalR;
using MyHearthStoneV2.Common.JsonModel;
using System;
using System.Linq;
using MyHearthStoneV2.Common.Util;
using Newtonsoft.Json.Linq;
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.API.Monitor;
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.BLL;
using MyHearthStoneV2.CardLibrary.Controler.Proxy;
using Newtonsoft.Json;

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
                GameContextOutput chessBoard = ((APISingleModelResult<GameContextOutput>)res).data;
                if (chessBoard != null && chessBoard.Players.Any(c => c.UserCode == userCode))
                {
                    Groups.Add(Context.ConnectionId, gameCode);
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
                if (res.code == (int)OperateResCodeEnum.成功)
                {
                    var userCard = ((APISingleModelResult<BaseUserContext>)res).data;
                    if (userCard != null)
                    {
                        //如果双方都已经换完牌，则初始化手牌、游戏环境变量，之后通知玩家去获取游戏信息
                        if (userCard.TurnIndex > 0)
                        {
                            Clients.Group(gameCode, new string[0]).queryMyCards();
                        }
                        return JsonStringResult.SuccessResult(userCard);
                    }
                }
            }
            return JsonStringResult.Error(OperateResCodeEnum.参数错误);
        }

        [SignalRMethod]
        public string GetMyCards(string param)
        {
            JObject jobj = JObject.Parse(param);
            string userCode = jobj["UserCode"].TryParseString();
            string gameCode = jobj["GameCode"].TryParseString();

            var res = ControllerProxy.GetGame(gameCode, userCode);
            if (res.code == (int)OperateResCodeEnum.成功)
            {
                var gameContextOutput = ((APISingleModelResult<GameContextOutput>)res).data;
                return JsonStringResult.SuccessResult(gameContextOutput);
            }
            return JsonStringResult.Error(OperateResCodeEnum.参数错误);
        }

        [SignalRMethod]
        public string CastSpell(string param)
        {
            JObject jobj = JObject.Parse(param);
            string UserCode = jobj["UserCode"].TryParseString();
            string GameCode = jobj["GameCode"].TryParseString();
            string CardInGameCode = jobj["CardInGameCode"].TryParseString();
            int Target = jobj["Target"].TryParseInt(-1);

            var res = ControllerProxy.GetGame(GameCode, UserCode);
            if (res.code == (int)OperateResCodeEnum.成功)
            {
                var gameContextOutput = ((APISingleModelResult<GameContextOutput>)res).data;
                string enemyUserCode = gameContextOutput.Players.First(c => c.UserCode != UserCode).UserCode;
                res = ControllerProxy.CastSpell(GameCode, UserCode, CardInGameCode, Target);
                var gamContext = ControllerProxy.GetGame(GameCode, enemyUserCode);
                Clients.Group(GameCode, new string[0]).resetGameContext(JsonConvert.SerializeObject(gamContext), UserCode);
                return JsonConvert.SerializeObject(res);
            }
            return JsonStringResult.Error(OperateResCodeEnum.参数错误);
        }

        [SignalRMethod]
        public string CastServant(string param)
        {
            JObject jobj = JObject.Parse(param);
            string UserCode = jobj["UserCode"].TryParseString();
            string GameCode = jobj["GameCode"].TryParseString();
            string CardInGameCode = jobj["CardInGameCode"].TryParseString();
            int Location = jobj["Location"].TryParseInt();
            int Target = jobj["Target"].TryParseInt(-1);

            var res = ControllerProxy.GetGame(GameCode, UserCode);
            if (res.code == (int)OperateResCodeEnum.成功)
            {
                var gameContextOutput = ((APISingleModelResult<GameContextOutput>)res).data;
                string enemyUserCode = gameContextOutput.Players.First(c => c.UserCode != UserCode).UserCode;
                res = ControllerProxy.CastServant(GameCode, UserCode, CardInGameCode, Location, Target);
                var gamContext = ControllerProxy.GetGame(GameCode, enemyUserCode);
                Clients.Group(GameCode, new string[0]).resetGameContext(JsonConvert.SerializeObject(gamContext), UserCode);
                return JsonConvert.SerializeObject(res);
            }
            return JsonStringResult.Error(OperateResCodeEnum.参数错误);
        }

        [SignalRMethod]
        public string TurnEnd(string param)
        {
            JObject jobj = JObject.Parse(param);
            string UserCode = jobj["UserCode"].TryParseString();
            string GameCode = jobj["GameCode"].TryParseString();


            var res = ControllerProxy.GetGame(GameCode, UserCode);
            if (res.code == (int)OperateResCodeEnum.成功)
            {
                var gameContextOutput = ((APISingleModelResult<GameContextOutput>)res).data;
                string enemyUserCode = gameContextOutput.Players.First(c => c.UserCode != UserCode).UserCode;
                res = ControllerProxy.TurnEnd(GameCode, UserCode);
                var gamContext = ControllerProxy.GetGame(GameCode, enemyUserCode);
                Clients.Group(GameCode, new string[0]).resetGameContext(JsonConvert.SerializeObject(gamContext), UserCode);
                return JsonConvert.SerializeObject(res);
            }
            return JsonStringResult.Error(OperateResCodeEnum.参数错误);
        }

        [SignalRMethod]
        public string TurnStart(string param)
        {
            JObject jobj = JObject.Parse(param);
            string UserCode = jobj["UserCode"].TryParseString();
            string GameCode = jobj["GameCode"].TryParseString();


            var res = ControllerProxy.GetGame(GameCode, UserCode);
            if (res.code == (int)OperateResCodeEnum.成功)
            {
                var gameContextOutput = ((APISingleModelResult<GameContextOutput>)res).data;
                string enemyUserCode = gameContextOutput.Players.First(c => c.UserCode != UserCode).UserCode;
                res = ControllerProxy.TurnStart(GameCode, UserCode);
                var gamContext = ControllerProxy.GetGame(GameCode, enemyUserCode);
                Clients.Group(GameCode, new string[0]).resetGameContext(JsonConvert.SerializeObject(gamContext), UserCode);
                return JsonConvert.SerializeObject(res);
            }
            return JsonStringResult.Error(OperateResCodeEnum.参数错误);
        }

        public void Bordcast(string param)
        {
            throw new NotImplementedException();
        }

        public void LeaveRoom(string param)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 客户端发送消息
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="userName"></param>
        /// <param name="chatContent"></param>
        public void SendChat(string userCode, string chatContent, string gameCode)
        {
            //查找房间是否存在
            var game = GameBll.Instance.GetGame(gameCode);
            if (game != null && (game.FirstUserCode == userCode || game.SecondUserCode == userCode))
            {
                var user = UsersBll.Instance.GetUser(userCode);
                Clients.Group(game.GameCode, new string[0]).addNewMessageToPage(user.NickName, chatContent);
            }
        }
    }
}