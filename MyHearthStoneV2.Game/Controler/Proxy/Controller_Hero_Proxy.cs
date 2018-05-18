using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility;
using MyHearthStoneV2.Game.CardLibrary.CardAbility;
using MyHearthStoneV2.Game.CardLibrary.Equip;

namespace MyHearthStoneV2.Game.Controler.Proxy
{
    public partial class Controller_Base_Proxy
    {
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
            if (VictoryValidate(ctl.GameContext) == false)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.游戏已经结束);
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

            List<BaseBiology> taunts = ctl.GameContext.DeskCards.GetDeskCardsByIsFirst(player.IsFirst ? false : true).Where(c => c != null && c.HasTaunt).ToList();
            if (taunts != null && taunts.Count > 0 && taunts.Any(c => c.DeskIndex == target) == false)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.你必须先攻击有嘲讽技能的随从);
            }

            ctl.HeroAttack(hero, target);
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
            if (VictoryValidate(ctl.GameContext) == false)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.游戏已经结束);
            }
            var player = ctl.GameContext.GetActivationUserContext();
            if (player == null || player.UserCode != userCode || player.RemainingHeroPowerCastCount < 1)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }

            BaseHero hero = ctl.GameContext.GetHeroByActivation();

            if (player.Power < (hero.Abilities.First() as IHeroAbility).Cost)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.没有足够的法力值);
            }

            ctl.CastHeroPower(hero, target);
            return JsonModelResult.PackageSuccess(GameContextCache.GetContext(ctl.GameContext.GameCode).Output());
        }

        /// <summary>
        /// 装备一件装备
        /// </summary>
        /// <param name="gameCode"></param>
        /// <param name="userCode"></param>
        /// <param name="cardInGameCode"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static APIResultBase LoadEquip(string gameCode, string userCode, string cardInGameCode)
        {
            string res = JsonStringResult.VerifyFail();
            Controler_Base ctl = Validate(gameCode, userCode);
            if (ctl == null)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }
            if (VictoryValidate(ctl.GameContext) == false)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.游戏已经结束);
            }
            var player = ctl.GameContext.GetActivationUserContext();
            if (player == null || player.UserCode != userCode)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }

            if (ctl.GameContext.AllCard.Any(c => c != null && c.CardInGameCode == cardInGameCode && c.CardType == CardType.装备) == false)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }

            BaseHero hero = ctl.GameContext.GetHeroByActivation(player.IsActivation);
            Card card = player.HandCards.First(c => c.CardInGameCode == cardInGameCode);
            if (player.Power < card.Cost)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.没有足够的法力值);
            }
            ctl.LoadEquip(hero, card as BaseEquip);
            return JsonModelResult.PackageSuccess(GameContextCache.GetContext(ctl.GameContext.GameCode).Output());
        }
    }
}
