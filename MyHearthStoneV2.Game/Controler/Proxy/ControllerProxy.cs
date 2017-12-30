using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Model.CustomModels;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.CardLibrary.Spell;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;

namespace MyHearthStoneV2.Game.Controler.Proxy
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

            ControllerCache.Init();
            //var game = GameBll.Instance.CreateGame(tableCode, firstPlayerCode, secondPlayerCode, fristCardGroupCode, secondCardGroupCode);

            //string firstUserProfession = UserCardGroupBll.Instance.GetCardGroup(fristCardGroupCode, firstPlayerCode).Profession;
            //string secondUserProfession = UserCardGroupBll.Instance.GetCardGroup(secondCardGroupCode, secondPlayerCode).Profession;
            Controler_Base ctl = new Controler_Base();
            ctl.GameStart(game, firstUser, secondUser, firstCardGroup, secondCardGroup, firstUserProfession, secondUserProfession);
            return JsonModelResult.PackageSuccess(ControllerCache.GetControler(ctl.GameCode).gameContextOutput);
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
        private static GameContextOutput GetChessboardOutputByUser(Controler_Base ctl, string userCode)
        {
            GameContextOutput output = new GameContextOutput
            {
                GameCode = ctl.GameCode,
                TurnIndex = ctl.TurnIndex,
                Players = new List<BaseUserContext>()
            };

            foreach (UserContext cd in ctl.gameContext.Players)
            {
                if (cd.UserCode == userCode)
                {
                    output.Players.Add(new UserContextOutput()
                    {
                        DeskCards = cd.DeskCards,
                        HandCards = cd.HandCards,
                        InitCards = cd.InitCards,
                        IsActivation = cd.IsActivation,
                        IsFirst = cd.IsFirst,
                        Power = cd.Power,
                        StockCards = cd.StockCards.Count,
                        SwitchDone = cd.SwitchDone,
                        UserCode = cd.UserCode,
                        TurnIndex = cd.TurnIndex,
                        FullPower = cd.FullPower,
                        Hero = cd.Hero
                    });
                }
                else
                {
                    output.Players.Add(new UserContextSimpleOutput()
                    {
                        DeskCards = cd.DeskCards,
                        HandCards = cd.HandCards.Count,
                        InitCards = cd.InitCards.Count,
                        IsActivation = cd.IsActivation,
                        IsFirst = cd.IsFirst,
                        Power = cd.Power,
                        StockCards = cd.StockCards.Count,
                        SwitchDone = cd.SwitchDone,
                        UserCode = cd.UserCode,
                        TurnIndex = cd.TurnIndex,
                        FullPower = cd.FullPower,
                        Hero = cd.Hero
                    });
                }
            }
            return output;
        }

        public void TurnEnd()
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
            Controler_Base ctl = Validate(gameCode, userCode);
            if (ctl == null)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }
            //if (ctl.TurnIndex != 2)
            //{
            //    return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            //}
            if (ctl.gameContext.Players.Any(c => c.UserCode == userCode && c.SwitchDone == false) == false)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }
            List<int> initCardIndex = new List<int>();
            foreach (string idx in lstInitCardIndex)
            {
                initCardIndex.Add(idx.TryParseInt());
            }
            if (initCardIndex.Any(c => c < 0 || c > 3) || initCardIndex.Any(c => c >= ctl.gameContext.Players.First(x => x.UserCode == userCode).InitCards.Count))
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }
            var idxGroup = initCardIndex.GroupBy(c => c);
            if (idxGroup.Any(c => c.Count() > 1))
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }
            ctl.SwitchCard(userCode, initCardIndex);
            return JsonModelResult.PackageSuccess(ControllerCache.GetControler(ctl.GameCode).gameContextOutput.Players.First(c => c.UserCode == userCode));
        }

        /// <summary>
        /// 将一名随从从手牌中移到场上
        /// </summary>
        /// <param name="gameCode"></param>
        /// <param name="userCode"></param>
        /// <param name="cardInGameCode"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public static APIResultBase CastServant(string gameCode, string userCode, string cardInGameCode, int location, int target)
        {
            string res = JsonStringResult.VerifyFail();
            Controler_Base ctl = Validate(gameCode, userCode);
            if (ctl == null)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }
            var player = ctl.gameContext.GetActivationUserContext();
            if (player == null || player.UserCode != userCode)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }
            if (player.HandCards.Any(c => c.CardInGameCode == cardInGameCode) == false)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }
            if (location == 0 || location == 8)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }
            if (player.IsFirst && player.DeskCards[location] != null)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.位置已被占用);
            }
            else if (player.IsFirst == false && player.DeskCards[location - 8] != null)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.位置已被占用);
            }
            Card card = player.HandCards.First(c => c.CardInGameCode == cardInGameCode);

            if (player.Power < card.Cost)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.没有足够的法力值);
            }

            ctl.CastServant((BaseServant)card, location, target);            
            return JsonModelResult.PackageSuccess(ControllerCache.GetControler(ctl.GameCode).gameContextOutput);
        }

        /// <summary>
        /// 打出一张法术牌
        /// </summary>
        /// <param name="gameCode"></param>
        /// <param name="userCode"></param>
        /// <param name="cardInGameCode"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static APIResultBase CastSpell(string gameCode, string userCode, string cardInGameCode, int target)
        {
            string res = JsonStringResult.VerifyFail();
            Controler_Base ctl = Validate(gameCode, userCode);
            if (ctl == null)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }
            var player = ctl.gameContext.GetActivationUserContext();
            if (player == null || player.UserCode != userCode)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }
            if (player.HandCards.Any(c => c.CardInGameCode == cardInGameCode) == false)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }

            Card card = player.HandCards.First(c => c.CardInGameCode == cardInGameCode);

            if (player.Power < card.Cost)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.没有足够的法力值);
            }

            ctl.CastSpell((BaseSpell)card, target);
            return JsonModelResult.PackageSuccess(ControllerCache.GetControler(ctl.GameCode).gameContextOutput);
        }
        /// <summary>
        /// 随从发起攻击
        /// </summary>
        /// <param name="gameCode"></param>
        /// <param name="userCode"></param>
        /// <param name="cardInGameCode"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static APIResultBase ServantAttack(string gameCode, string userCode, string cardInGameCode, int target)
        {
            string res = JsonStringResult.VerifyFail();
            Controler_Base ctl = Validate(gameCode, userCode);
            if (ctl == null)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }
            var player = ctl.gameContext.GetActivationUserContext();
            if (player == null || player.UserCode != userCode)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }
            if (player.DeskCards.Any(c => c.CardInGameCode == cardInGameCode) == false)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }

            BaseServant servant = player.DeskCards.First(c => c.CardInGameCode == cardInGameCode) as BaseServant;
            if (servant.RemainAttackTimes < 1)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }
            //BaseBiology bb = ctl.GetCardByLocation(target) as BaseBiology;
            var taunts = ctl.gameContext.GetNotActivationUserContext().DeskCards.Where(c => c.Abilities.Any(x => x is Taunt));
            var dskCards = ctl.gameContext.GetNotActivationUserContext().DeskCards;
            for (int i = 0; i < dskCards.Count; i++)
            {
                if (dskCards[i] != null && dskCards[i].Abilities.Any(x => x is Taunt) && i != target)
                {
                    return JsonModelResult.PackageFail(OperateResCodeEnum.你必须先攻击有嘲讽技能的随从);
                }
            }
            return JsonModelResult.PackageSuccess(ControllerCache.GetControler(ctl.GameCode).gameContextOutput);
        }

        /// <summary>
        /// 回合结束
        /// </summary>
        /// <param name="gameCode"></param>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public static APIResultBase TurnEnd(string gameCode, string userCode)
        {
            string res = JsonStringResult.VerifyFail();
            Controler_Base ctl = Validate(gameCode, userCode);
            if (ctl == null)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }
            var player = ctl.gameContext.GetActivationUserContext();
            if (player == null || player.UserCode != userCode)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }

            ctl.TurnEnd();
            return JsonModelResult.PackageSuccess(ControllerCache.GetControler(ctl.GameCode).gameContextOutput);
        }

        /// <summary>
        /// 回合结束
        /// </summary>
        /// <param name="gameCode"></param>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public static APIResultBase TurnStart(string gameCode, string userCode)
        {
            string res = JsonStringResult.VerifyFail();
            Controler_Base ctl = Validate(gameCode, userCode);
            if (ctl == null)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }
            var player = ctl.gameContext.GetActivationUserContext();
            if (player == null || player.UserCode != userCode)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }

            ctl.TurnStart();
            return JsonModelResult.PackageSuccess(ControllerCache.GetControler(ctl.GameCode).gameContextOutput);
        }
        private static Controler_Base Validate(string gameCode, string userCode)
        {
            Controler_Base ctl = null;
            var lstCtls = ControllerCache.GetControls();
            if (!lstCtls.Any(c => c.GameCode == gameCode) || !lstCtls.Any(c => c.gameContext.Players.Any(x => x.User.UserCode == userCode)))
            {
                return null;
            }
            ctl = lstCtls.First(c => c.GameCode == gameCode);
            if (ctl.gameContext.Players.Any(c => c.UserCode == userCode) == false)
            {
                return null;
            }
            return ctl;
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
