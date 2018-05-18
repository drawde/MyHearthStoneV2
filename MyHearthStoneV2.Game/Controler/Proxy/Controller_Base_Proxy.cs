using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Model;
using System.Collections.Generic;
using System.Linq;
using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Model.CustomModels;
using MyHearthStoneV2.Game.Context;

namespace MyHearthStoneV2.Game.Controler.Proxy
{
    /// <summary>
    /// 游戏控制器代理
    /// </summary>
    public partial class Controller_Base_Proxy
    {
        /// <summary>
        /// 创建一局游戏
        /// </summary>
        /// <param name="firstPlayerCode">先手玩家</param>
        /// <param name="secondPlayerCode">后手玩家</param>
        /// <param name="fristCardGroupCode">先手玩家卡组</param>
        /// <param name="secondCardGroupCode">后手玩家卡组</param>
        /// <returns>游戏ID</returns>
        public static APIResultBase CreateGame(string tableCode, CUsers firstUser, CUsers secondUser, List<HS_UserCardGroupDetail> firstCardGroup, 
            List<HS_UserCardGroupDetail> secondCardGroup,HS_Game game, string firstUserProfession, string secondUserProfession)
        {
            //if (firstPlayerCode.IsNullOrEmpty() || secondPlayerCode.IsNullOrEmpty() || fristCardGroupCode.IsNullOrEmpty() || secondCardGroupCode.IsNullOrEmpty())
            //{
            //    return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            //}

            //CUsers firstUser = UsersBll.Instance.GetUser(firstPlayerCode);
            if (firstUser == null)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }

            //CUsers secondUser = UsersBll.Instance.GetUser(secondPlayerCode);
            if (secondUser == null)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
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
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }

            //List<HS_UserCardGroupDetail> secondCardGroup = UserCardGroupDetailBll.Instance.GetCardGroupDetail(secondCardGroupCode, secondPlayerCode);
            if (secondCardGroup == null || secondCardGroup.Count < 1)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }

            //GameContextCache.Init();
            //var game = GameBll.Instance.CreateGame(tableCode, firstPlayerCode, secondPlayerCode, fristCardGroupCode, secondCardGroupCode);

            //string firstUserProfession = UserCardGroupBll.Instance.GetCardGroup(fristCardGroupCode, firstPlayerCode).Profession;
            //string secondUserProfession = UserCardGroupBll.Instance.GetCardGroup(secondCardGroupCode, secondPlayerCode).Profession;
            Controler_Base ctl = new Controler_Base();
            ctl.GameStart(game, firstUser, secondUser, firstCardGroup, secondCardGroup, firstUserProfession, secondUserProfession);
            return JsonModelResult.PackageSuccess(GameContextCache.GetContext(ctl.GameContext.GameCode).Output());
        }

        /// <summary>
        /// 获取游戏的输出模型
        /// </summary>
        /// <param name="gameCode"></param>
        /// <returns></returns>
        public static APIResultBase GetGame(string gameCode, string userCode = "")
        {
            var gameContext = GameContextCache.GetContext(gameCode);
            if (gameContext != null)
            {
                if (userCode.IsNullOrEmpty())
                    return JsonModelResult.PackageSuccess(gameContext.Output());
                return JsonModelResult.PackageSuccess(gameContext.Output(userCode));
            }            
            return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
        }

        private static Controler_Base Validate(string gameCode, string userCode)
        {
            Controler_Base ctl = new Controler_Base();
            var context = GameContextCache.GetContext(gameCode);
            if (context == null || !context.Players.Any(x => x.User.UserCode == userCode))
            {
                return null;
            }
            ctl.GameContext = context;
            return ctl;
        }

        private static bool VictoryValidate(GameContext gameContext)
        {
            return gameContext.GameStatus != GameStatus.进行中 && gameContext.GameStatus != GameStatus.无;
        }
        /// <summary>
        /// 验证参数的有效性
        /// </summary>
        /// <param name="gameCode"></param>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public static bool ValidateControler(string gameCode, string userCode) => Validate(gameCode, userCode) != null;
    }
}
