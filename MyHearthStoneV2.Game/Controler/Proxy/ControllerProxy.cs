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
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.CardLibrary.CardAbility;

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

            GameContextCache.Init();
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
            if (ctl.GameContext.Players.Any(c => c.UserCode == userCode && c.SwitchDone == false) == false)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }
            List<int> initCardIndex = new List<int>();
            foreach (string idx in lstInitCardIndex)
            {
                initCardIndex.Add(idx.TryParseInt());
            }
            if (initCardIndex.Any(c => c < 0 || c > 3) || initCardIndex.Any(c => c >= ctl.GameContext.Players.First(x => x.UserCode == userCode).InitCards.Count))
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }
            var idxGroup = initCardIndex.GroupBy(c => c);
            if (idxGroup.Any(c => c.Count() > 1))
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }
            ctl.SwitchCard(userCode, initCardIndex);
            return JsonModelResult.PackageSuccess(GameContextCache.GetContext(ctl.GameContext.GameCode).Output().Players.First(c => c.UserCode == userCode));
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
            var player = ctl.GameContext.GetActivationUserContext();
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
            if (ctl.GameContext.DeskCards[location] != null)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.位置已被占用);
            }
            if (player.IsFirst && (location == 0 || location > 7))
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }
            else if (player.IsFirst == false && (location == 8 || location < 8))
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }
            Card card = player.HandCards.First(c => c.CardInGameCode == cardInGameCode);

            if (player.Power < card.Cost)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.没有足够的法力值);
            }

            ctl.CastServant((BaseServant)card, location, target);            
            return JsonModelResult.PackageSuccess(GameContextCache.GetContext(ctl.GameContext.GameCode).Output());
        }

        /// <summary>
        /// 使用英雄技能
        /// </summary>
        /// <param name="gameCode"></param>
        /// <param name="userCode"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static APIResultBase CastHeroPower(string gameCode, string userCode, int target = -1)
        {
            string res = JsonStringResult.VerifyFail();
            Controler_Base ctl = Validate(gameCode, userCode);
            if (ctl == null)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }

            var player = ctl.GameContext.GetActivationUserContext();
            if (player == null || player.UserCode != userCode || player.RemainingHeroPowerCastCount < 1)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }

            BaseHero hero = ctl.GameContext.GetHeroByActivation();

            if (player.Power < (hero.Abilities.First() as BaseHeroAbility).Cost)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.没有足够的法力值);
            }

            ctl.CastHeroPower(hero, target);
            return JsonModelResult.PackageSuccess(GameContextCache.GetContext(ctl.GameContext.GameCode).Output().Players.First(c => c.UserCode == userCode));
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
            var player = ctl.GameContext.GetActivationUserContext();
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
            return JsonModelResult.PackageSuccess(GameContextCache.GetContext(ctl.GameContext.GameCode).Output());
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

            var player = ctl.GameContext.GetActivationUserContext();
            if (player == null || player.UserCode != userCode)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }

            if (ctl.GameContext.DeskCards.Any(c => c != null && c.CardInGameCode == cardInGameCode) == false)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }

            if (player.IsFirst && target < 8)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }
            else if (player.IsFirst == false && target > 7)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }

            BaseServant servant = ctl.GameContext.DeskCards.First(c => c != null && c.CardInGameCode == cardInGameCode) as BaseServant;
            if (servant.RemainAttackTimes < 1)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }

            var taunts = ctl.GameContext.DeskCards.GetDeskCardsByIsFirst(player.IsFirst ? false : true).Where(c => c != null && c.Abilities.Any(x => x is Taunt)).ToList();
            for (int i = 0; i < taunts.Count; i++)
            {
                if (taunts[i].Abilities.Any(x => x is Taunt) && i != target)
                {
                    return JsonModelResult.PackageFail(OperateResCodeEnum.你必须先攻击有嘲讽技能的随从);
                }
            }
            ctl.ServantAttack(servant, target);
            return JsonModelResult.PackageSuccess(GameContextCache.GetContext(ctl.GameContext.GameCode).Output());
        }


        /// <summary>
        /// 英雄发起攻击
        /// </summary>
        /// <param name="gameCode"></param>
        /// <param name="userCode"></param>
        /// <param name="cardInGameCode"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static APIResultBase HeroAttack(string gameCode, string userCode, int target)
        {
            string res = JsonStringResult.VerifyFail();
            Controler_Base ctl = Validate(gameCode, userCode);
            if (ctl == null)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }

            var player = ctl.GameContext.GetActivationUserContext();
            if (player == null || player.UserCode != userCode)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }
            if (player.IsFirst && target < 8)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }
            else if (player.IsFirst == false && target > 7)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }

            BaseHero hero = ctl.GameContext.GetHeroByActivation(player.IsActivation);
            if (hero.RemainAttackTimes < 1)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }

            var taunts = ctl.GameContext.DeskCards.GetDeskCardsByIsFirst(player.IsFirst ? false : true).Where(c => c != null && c.Abilities.Any(x => x is Taunt)).ToList();
            for (int i = 0; i < taunts.Count; i++)
            {
                if (taunts[i].Abilities.Any(x => x is Taunt) && i != target)
                {
                    return JsonModelResult.PackageFail(OperateResCodeEnum.你必须先攻击有嘲讽技能的随从);
                }
            }

            ctl.HeroAttack(hero, target);
            return JsonModelResult.PackageSuccess(GameContextCache.GetContext(ctl.GameContext.GameCode).Output());
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
            var player = ctl.GameContext.GetActivationUserContext();
            if (player == null || player.UserCode != userCode)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }

            ctl.TurnEnd();
            return JsonModelResult.PackageSuccess(GameContextCache.GetContext(ctl.GameContext.GameCode).Output());
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
            var player = ctl.GameContext.GetActivationUserContext();
            if (player == null || player.UserCode != userCode)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }

            ctl.TurnStart();
            return JsonModelResult.PackageSuccess(GameContextCache.GetContext(ctl.GameContext.GameCode).Output());
        }
        private static Controler_Base Validate(string gameCode, string userCode)
        {
            Controler_Base ctl = new Controler_Base();
            var lstCtls = GameContextCache.GetContexts();
            if (lstCtls.All(c => c.GameCode != gameCode) || !lstCtls.Any(c => c.Players.Any(x => x.User.UserCode == userCode)))
            {
                return null;
            }
            ctl.GameContext = lstCtls.First(c => c.GameCode == gameCode);
            if (ctl.GameContext.Players.Any(c => c.UserCode == userCode) == false)
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
