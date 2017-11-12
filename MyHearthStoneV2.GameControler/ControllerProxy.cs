using MyHearthStoneV2.BLL;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game;
using MyHearthStoneV2.GameControler;
using MyHearthStoneV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Redis;
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.Model.CustomModels;

namespace MyHearthStoneV2.GameControler
{
    /// <summary>
    /// 游戏控制器代理
    /// </summary>
    public class ControllerProxy
    {
        /// <summary>
        /// 创建一局游戏
        /// </summary>
        /// <param name="firstPlayerCode">先手玩家</param>
        /// <param name="secondPlayerCode">后手玩家</param>
        /// <param name="fristCardGroupCode">先手玩家卡组</param>
        /// <param name="secondCardGroupCode">后手玩家卡组</param>
        /// <returns>游戏ID</returns>
        public static APIResultBase CreateGame(string tableCode, string firstPlayerCode, string secondPlayerCode, string fristCardGroupCode, string secondCardGroupCode)
        {
            if (firstPlayerCode.IsNullOrEmpty() || secondPlayerCode.IsNullOrEmpty() || fristCardGroupCode.IsNullOrEmpty() || secondCardGroupCode.IsNullOrEmpty())
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }

            CUsers firstUser = UsersBll.Instance.GetUser(firstPlayerCode);
            if (firstUser == null)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }

            CUsers secondUser = UsersBll.Instance.GetUser(secondPlayerCode);
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

            List<HS_UserCardGroupDetail> firstCardGroup = UserCardGroupDetailBll.Instance.GetCardGroupDetail(fristCardGroupCode, firstPlayerCode);
            if (firstCardGroup == null || firstCardGroup.Count < 1)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }

            List<HS_UserCardGroupDetail> secondCardGroup = UserCardGroupDetailBll.Instance.GetCardGroupDetail(secondCardGroupCode, secondPlayerCode);
            if (secondCardGroup == null || secondCardGroup.Count < 1)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }

            ControllerCache.Init();
            var game = GameBll.Instance.CreateGame(tableCode, firstPlayerCode, secondPlayerCode, fristCardGroupCode, secondCardGroupCode);
            Controler ctl = new Controler();
            ctl.GameStart(game, firstUser, secondUser, firstCardGroup, secondCardGroup);            
            return JsonModelResult.PackageSuccess(ControllerCache.GetControler(ctl.GameCode).chessboardOutput);
        }

        /// <summary>
        /// 获取游戏的输出模型
        /// </summary>
        /// <param name="gameCode"></param>
        /// <returns></returns>
        public static APIResultBase GetGame(string gameCode, string userCode = "")
        {
            var ctl = ControllerCache.GetControler(gameCode);
            if (ctl != null)
                return JsonModelResult.PackageSuccess(GetChessboardOutputByUser(ctl, userCode));
            return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
        }

        /// <summary>
        /// 根据玩家返回对应的游戏输出模型
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="userCode"></param>
        /// <returns></returns>
        private static ChessboardOutput GetChessboardOutputByUser(Controler ctl, string userCode)
        {
            ChessboardOutput output = new ChessboardOutput
            {
                GameCode = ctl.GameCode,
                Players = new List<BaseUserCards>()
            };

            foreach (UserCards cd in ctl.chessboard.Players)
            {
                if (cd.UserCode == userCode)
                {
                    output.Players.Add(new UserCardsOutput()
                    {
                        DeskCards = cd.DeskCards,
                        HandCards = cd.HandCards,
                        InitCards = cd.InitCards,
                        IsActivation = cd.IsActivation,
                        IsFirst = cd.IsFirst,
                        Power = cd.Power,
                        StockCards = cd.StockCards.Count,
                        SwitchDone = cd.SwitchDone,
                        UserCode = cd.UserCode
                    });
                }
                else
                {
                    output.Players.Add(new UserCardsSimpleOutput()
                    {
                        DeskCards = cd.DeskCards,
                        HandCards = cd.HandCards.Count,
                        InitCards = cd.InitCards.Count,
                        IsActivation = cd.IsActivation,
                        IsFirst = cd.IsFirst,
                        Power = cd.Power,
                        StockCards = cd.StockCards.Count,
                        SwitchDone = cd.SwitchDone,
                        UserCode = cd.UserCode
                    });
                }
            }
            return output;
        }

        public void RoundEnd()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 开场换牌
        /// </summary>
        /// <param name="gameCode"></param>
        /// <param name="userCode"></param>
        /// <param name="lstInitCardIndex"></param>
        /// <returns></returns>
        public static APIResultBase SwitchCard(string gameCode, string userCode, List<string> lstInitCardIndex)
        {
            string res = JsonStringResult.VerifyFail();
            Controler ctl = null;
            var lstCtls = ControllerCache.GetControls();
            if (!lstCtls.Any(c => c.GameCode == gameCode) || !lstCtls.Any(c => c.chessboard.Players.Any(x => x.User.UserCode == userCode)))
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }
            ctl = lstCtls.First(c => c.GameCode == gameCode);
            //if (ctl.roundIndex != 2)
            //{
            //    return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            //}
            if (ctl.chessboard.Players.Any(c => c.UserCode == userCode && c.SwitchDone == false) == false)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }
            List<int> initCardIndex = new List<int>();
            foreach (string idx in lstInitCardIndex)
            {
                initCardIndex.Add(idx.TryParseInt());
            }
            if (initCardIndex.Any(c => c < 0 || c > 3) || initCardIndex.Any(c => c >= ctl.chessboard.Players.First(x => x.UserCode == userCode).InitCards.Count))
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }
            var idxGroup = initCardIndex.GroupBy(c => c);
            if (idxGroup.Any(c => c.Count() > 1))
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }
            ctl.SwitchCard(userCode, initCardIndex);
            return JsonModelResult.PackageSuccess(ControllerCache.GetControler(ctl.GameCode).chessboardOutput.Players.First(c => c.UserCode == userCode));
        }

        public void PickUpACard(string userCode)
        {
            throw new NotImplementedException();
        }

        public void RoundStart()
        {
            throw new NotImplementedException();
        }
    }
}
