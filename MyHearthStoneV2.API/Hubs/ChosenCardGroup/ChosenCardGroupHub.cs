using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using MyHearthStoneV2.Common;
using MyHearthStoneV2.Common.Util;
using Newtonsoft.Json;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.BLL;
using MyHearthStoneV2.APIMonitor;
using Newtonsoft.Json.Linq;
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.GameControler;
using MyHearthStoneV2.Model.CustomModels;
using MyHearthStoneV2.Game;

namespace MyHearthStoneV2.API.Hubs.ChosenCardGroup
{    
    public class ChosenCardGroupHub : Hub, IChosenCardGroupHub
    {
        public override Task OnConnected()
        {
            return base.OnConnected();
        }
        /// <summary>
        /// 用户进入游戏房间
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="userName"></param>
        /// <param name="tableID"></param>        
        [SignalRMethod]
        public string Online(string param)
        {
            JObject jobj = JObject.Parse(param);
            string userCode = jobj["UserCode"].TryParseString();
            string userName = jobj["NickName"].TryParseString();
            string password = jobj["Password"].TryParseString();
            string tableCode = jobj["TableCode"].Value<string>();

            var textRes = GameTableBll.Instance.ZhanZuoEr(tableCode, userCode, password);
            if (textRes.code != (int)OperateResCodeEnum.成功)
            {
                return JsonConvert.SerializeObject(textRes);
            }

            HS_GameTable table = GameTableBll.Instance.GetTable(tableCode);
            if (table != null)
            {                
                Groups.Add(Context.ConnectionId, table.TableCode);

                var user = UsersBll.Instance.GetUser(userCode);
                SendOnlineNotice(user, table.TableCode, "用户：" + userName + "进入房间");
                if (table.CreateUserIsReady && table.PlayerIsReady)
                {
                    var game = GameBll.Instance.GetGameByTableCode(tableCode);
                    if (game != null)
                    {
                        Clients.Group(tableCode, new string[0]).go(JsonStringResult.SuccessResult(game.GameCode));
                    }
                }
            }
            else
            {
                return JsonStringResult.VerifyFail();
            }
            return JsonStringResult.SuccessResult(table);
        }

        /// <summary>
        /// 重写Hub连接断开的事件
        /// </summary>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }

        [SignalRMethod]
        public string IAmReady(string param)
        {
            JObject jobj = JObject.Parse(param);
            string userCode = jobj["UserCode"].TryParseString();
            string tableCode = jobj["TableCode"].TryParseString();
            string cardGroupCode = jobj["CardGroupCode"].TryParseString();
            string nickName = jobj["NickName"].TryParseString();

            //查找房间是否存在
            var gameTable = GameTableBll.Instance.IAmReady(tableCode, userCode, cardGroupCode);
            //存在则进入删除
            if (gameTable != null)
            {
                //提示客户端                
                SendReadyNotice(tableCode, "用户：" + nickName + "已经准备好了", userCode);

                if (gameTable.CreateUserIsReady && gameTable.PlayerIsReady)
                {
                    Go(gameTable);
                }
                else if (gameTable.CreateUserIsReady == false)
                {
                    var user = UsersBll.Instance.GetUser(gameTable.CreateUserCode);
                    return JsonStringResult.SuccessResult(user.NickName);
                }
                else if (gameTable.PlayerIsReady == false)
                {
                    var user = UsersBll.Instance.GetUser(gameTable.PlayerUserCode);
                    return JsonStringResult.SuccessResult(user.NickName);
                }

                return JsonStringResult.SuccessResult();
            }
            return JsonStringResult.VerifyFail();
        }

        /// <summary>
        /// 重新选择卡组
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [SignalRMethod]
        public string Repick(string param)
        {
            JObject jobj = JObject.Parse(param);
            string userCode = jobj["UserCode"].TryParseString();
            string tableCode = jobj["TableCode"].TryParseString();
            string nickName = jobj["NickName"].TryParseString();

            bool isSuccess = GameTableBll.Instance.Repick(tableCode, userCode);
            if (isSuccess)
            {
                //提示客户端                
                SendReadyNotice(tableCode, "用户：" + nickName + "开始重新选择卡组", userCode);                                
                return JsonStringResult.SuccessResult();
            }
            return JsonStringResult.VerifyFail();
        }

        /// <summary>
        /// 客户端离开房间
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="tableID"></param>
        [SignalRMethod]
        public void LeaveRoom(string param)
        {
            JObject jobj = JObject.Parse(param);
            string userCode = jobj["UserCode"].TryParseString();
            string tableCode = jobj["TableCode"].TryParseString();
            //查找房间是否存在
            var gameTable = GameTableBll.Instance.LeaveRoom(userCode, tableCode);
            if (gameTable != null)
            {
                if (gameTable.PlayerUserCode == userCode)
                {
                    var user = UsersBll.Instance.GetUser(userCode);
                    //提示客户端                
                    SendBordcast(gameTable.TableCode, "用户：" + user.NickName + "已经退出房间", user.UserCode);
                }
            }
        }

        /// <summary>
        /// 双方都已选好卡组后，进入游戏
        /// </summary>
        private void Go(HS_GameTable gameTable)
        {
            int firstPlayerIndex = RandomUtil.CreateRandomInt(0, 1);
            string firstPlayerCode = "", secontPlayerCode = "", firstPlayerCardGroup = "", secondPlayerCardGroup = "";
            if (firstPlayerIndex == 0)
            {
                firstPlayerCode = gameTable.CreateUserCode;
                firstPlayerCardGroup = gameTable.CreateUserCardGroup;

                secontPlayerCode = gameTable.PlayerUserCode;
                secondPlayerCardGroup = gameTable.PlayerUserCardGroup;
            }
            else
            {
                firstPlayerCode = gameTable.PlayerUserCode;
                firstPlayerCardGroup = gameTable.PlayerUserCardGroup;

                secontPlayerCode = gameTable.CreateUserCode;
                secondPlayerCardGroup = gameTable.CreateUserCardGroup;
            }
            var game = GameBll.Instance.GetGameByTableCode(gameTable.TableCode);
            string gameCode = "";

            //如果游戏记录为空，则创建游戏
            if (game == null || ControllerProxy.GetGame(game.GameCode) == null)
            {
                var res = ControllerProxy.CreateGame(gameTable.TableCode, firstPlayerCode, secontPlayerCode, firstPlayerCardGroup, secondPlayerCardGroup);
                if (res.code == (int)OperateResCodeEnum.成功)
                {
                    ChessboardOutput chessBoard = ((APISingleModelResult<ChessboardOutput>)res).data;
                    gameCode = chessBoard.GameCode;
                }
                else
                {
                    Clients.Group(gameTable.TableCode, new string[0]).go(JsonStringResult.Error(OperateResCodeEnum.参数错误));
                }
            }
            else
            {
                gameCode = game.GameCode;
            }
            Clients.Group(gameTable.TableCode, new string[0]).go(JsonStringResult.SuccessResult(gameCode));
        }

        [SignalRMethod]
        public void Bordcast(string param)
        {
            
        }

        public void SendOnlineNotice(CUsers user, string tableCode, string chatContent)
        {
            Clients.Group(tableCode, new string[0]).receiveOnlineNotice(chatContent, JsonConvert.SerializeObject(user));
        }

        private void SendBordcast(string roomName, string message,string senderUserCode)
        {
            Clients.Group(roomName, new string[0]).receiveBordcast(message, senderUserCode);
        }

        private void SendReadyNotice(string tableCode, string message, string senderUserCode)
        {
            Clients.Group(tableCode, new string[0]).receiveReadyNotice(message, senderUserCode);
        }

        /// <summary>
        /// 客户端发送消息
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="userName"></param>
        /// <param name="chatContent"></param>
        public void SendChat(string userCode, string chatContent, string tableCode)
        {
            //查找房间是否存在
            var gameTable = GameTableBll.Instance.GetTable(tableCode);
            if (gameTable != null && (gameTable.CreateUserCode == userCode || gameTable.PlayerUserCode == userCode))
            {
                var user = UsersBll.Instance.GetUser(userCode);
                Clients.Group(gameTable.TableCode, new string[0]).addNewMessageToPage(user.NickName, chatContent);
            }
        }
    }
}