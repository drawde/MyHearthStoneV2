using BattleForAzeroth.Game.Util;
using System.Collections.Generic;
using System.Linq;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Model;
using Newtonsoft.Json;
using BattleForAzeroth.Game.Cache;

namespace BattleForAzeroth.Game.Controler.Proxy
{
    /// <summary>
    /// 游戏控制器代理
    /// </summary>
    public partial class Controller_Base_Proxy
    {
        private IGameCache _gameCache;
        public Controller_Base_Proxy(IGameCache gameCache)
        {
            _gameCache = gameCache;
        }
        /// <summary>
        /// 创建一局游戏
        /// </summary>
        /// <param name="firstPlayerCode">先手玩家</param>
        /// <param name="secondPlayerCode">后手玩家</param>
        /// <param name="fristCardGroupCode">先手玩家卡组</param>
        /// <param name="secondCardGroupCode">后手玩家卡组</param>
        /// <returns>游戏ID</returns>
        public string CreateGame(string tableCode, PlayerModel firstUser, PlayerModel secondUser, List<UserCardGroupDetailModel> firstCardGroup, 
            List<UserCardGroupDetailModel> secondCardGroup,GameModel game, string firstUserProfession, string secondUserProfession)
        {
            //if (firstPlayerCode.IsNullOrEmpty() || secondPlayerCode.IsNullOrEmpty() || fristCardGroupCode.IsNullOrEmpty() || secondCardGroupCode.IsNullOrEmpty())
            //{
            //    return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            //}

            //CUsers firstUser = UsersBll.Instance.GetUser(firstPlayerCode);
            if (firstUser == null)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.参数错误));
            }

            //CUsers secondUser = UsersBll.Instance.GetUser(secondPlayerCode);
            if (secondUser == null)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.参数错误));
            }
            //var lstCtl = ControllerCache.Lstctl;
            //if (lstCtl.Any(c => c.chessboard.Players.First(x => x.IsFirst).User.UserCode == firstPlayerCode || 
            //c.chessboard.Players.First(x => x.IsFirst == false).User.UserCode == secondPlayerCode))
            //{
            //    res = OperateJsonRes.Error(OperateResCodeEnum.无法多开游戏);
            //    return res;
            //}

            //List<HS_UserCardGroupDetail> firstCardGroup = UserCardGroupDetailBll.Instance.GetCardGroupDetail(fristCardGroupCode, firstPlayerCode);
            if (firstCardGroup == null || firstCardGroup.Count < 1)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.参数错误));
            }

            //List<HS_UserCardGroupDetail> secondCardGroup = UserCardGroupDetailBll.Instance.GetCardGroupDetail(secondCardGroupCode, secondPlayerCode);
            if (secondCardGroup == null || secondCardGroup.Count < 1)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.参数错误));
            }

            //GameContextCache.Init();
            //var game = GameBll.Instance.CreateGame(tableCode, firstPlayerCode, secondPlayerCode, fristCardGroupCode, secondCardGroupCode);

            //string firstUserProfession = UserCardGroupBll.Instance.GetCardGroup(fristCardGroupCode, firstPlayerCode).Profession;
            //string secondUserProfession = UserCardGroupBll.Instance.GetCardGroup(secondCardGroupCode, secondPlayerCode).Profession;
            Controler_Base ctl = new Controler_Base(_gameCache);
            ctl.GameStart(game, firstUser, secondUser, firstCardGroup, secondCardGroup, firstUserProfession, secondUserProfession);
            return JsonConvert.SerializeObject(JsonModelResult.PackageSuccess(_gameCache.GetContext(ctl.GameContext.GameCode).Output()));
        }

        /// <summary>
        /// 获取游戏的输出模型
        /// </summary>
        /// <param name="gameCode"></param>
        /// <returns></returns>
        public string GetGame(string gameCode, string userCode = "")
        {
            var gameContext = _gameCache.GetContext(gameCode);
            if (gameContext != null)
            {
                if (userCode.IsNullOrEmpty())
                    return JsonConvert.SerializeObject(JsonModelResult.PackageSuccess(gameContext.Output()));
                return JsonConvert.SerializeObject(JsonModelResult.PackageSuccess(gameContext.Output(userCode)));
            }            
            return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.参数错误));
        }

        private Controler_Base Validate(string gameCode, string userCode)
        {
            Controler_Base ctl = new Controler_Base(_gameCache);
            var context = _gameCache.GetContext(gameCode);
            if (context == null || !context.Players.Any(x => x.Player.UserCode == userCode))
            {
                return null;
            }
            ctl.GameContext = context;
            ctl.GameContext.GameCache = _gameCache;
            return ctl;
        }

        private bool VictoryValidate(GameContext gameContext)
        {
            return gameContext.GameStatus != GameStatus.进行中 && gameContext.GameStatus != GameStatus.无;
        }
        /// <summary>
        /// 验证参数的有效性
        /// </summary>
        /// <param name="gameCode"></param>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public bool ValidateControler(string gameCode, string userCode) => Validate(gameCode, userCode) != null;
    }
}
