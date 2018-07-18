using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.Context;
using System.Collections.Generic;
using System.Linq;
using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.CardLibrary.CardAbility;
using BattleForAzeroth.Game.CardLibrary.Equip;
using BattleForAzeroth.Game.Util;
using Newtonsoft.Json;
using BattleForAzeroth.Game.Cache;

namespace BattleForAzeroth.Game.Controler.Proxy
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
        public string HeroAttack(string gameCode, string userCode, int target)
        {
            string res = JsonStringResult.VerifyFail();
            Controler_Base ctl = Validate(gameCode, userCode);
            if (ctl == null)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据));
            }
            if (VictoryValidate(ctl.GameContext))
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.游戏已经结束));
            }
            var player = ctl.GameContext.GetActivationUserContext();
            if (player == null || player.UserCode != userCode)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据));
            }
            if (player.IsFirst && target < 8)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.参数错误));
            }
            else if (player.IsFirst == false && target > 7)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.参数错误));
            }

            BaseHero hero = ctl.GameContext.GetHeroByActivation(player.IsActivation);
            if (hero.RemainAttackTimes < 1)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据));
            }

            List<BaseBiology> taunts = ctl.GameContext.DeskCards.GetDeskCardsByIsFirst(player.IsFirst ? false : true).Where(c => c != null && c.HasTaunt).ToList();
            if (taunts != null && taunts.Count > 0 && taunts.Any(c => c.DeskIndex == target) == false)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.你必须先攻击有嘲讽技能的随从));
            }

            ctl.HeroAttack(hero, target);
            return JsonConvert.SerializeObject(JsonModelResult.PackageSuccess(_gameCache.GetContext(ctl.GameContext.GameCode).Output()));
        }


        /// <summary>
        /// 使用英雄技能
        /// </summary>
        /// <param name="gameCode"></param>
        /// <param name="userCode"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public string CastHeroPower(string gameCode, string userCode, int target = -1)
        {
            string res = JsonStringResult.VerifyFail();
            Controler_Base ctl = Validate(gameCode, userCode);
            if (ctl == null)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据));
            }
            if (VictoryValidate(ctl.GameContext))
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.游戏已经结束));
            }
            var player = ctl.GameContext.GetActivationUserContext();
            if (player == null || player.UserCode != userCode || player.RemainingHeroPowerCastCount < 1)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据));
            }

            BaseHero hero = ctl.GameContext.GetHeroByActivation();

            if (player.Power < (hero.Abilities.First() as IHeroAbility).Cost)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.没有足够的法力值));
            }

            ctl.CastHeroPower(hero, target);
            return JsonConvert.SerializeObject(JsonModelResult.PackageSuccess(_gameCache.GetContext(ctl.GameContext.GameCode).Output()));
        }

        /// <summary>
        /// 装备一件装备
        /// </summary>
        /// <param name="gameCode"></param>
        /// <param name="userCode"></param>
        /// <param name="cardInGameCode"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public string LoadEquip(string gameCode, string userCode, string cardInGameCode)
        {
            string res = JsonStringResult.VerifyFail();
            Controler_Base ctl = Validate(gameCode, userCode);
            if (ctl == null)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据));
            }
            if (VictoryValidate(ctl.GameContext))
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.游戏已经结束));
            }
            var player = ctl.GameContext.GetActivationUserContext();
            if (player == null || player.UserCode != userCode)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据));
            }

            if (ctl.GameContext.AllCard.Any(c => c != null && c.CardInGameCode == cardInGameCode && c.CardType == CardType.装备) == false)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据));
            }

            BaseHero hero = ctl.GameContext.GetHeroByActivation(player.IsActivation);
            Card card = player.HandCards.First(c => c.CardInGameCode == cardInGameCode);
            if (player.Power < card.Cost)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.没有足够的法力值));
            }
            ctl.LoadEquip(hero, card as BaseEquip);
            return JsonConvert.SerializeObject(JsonModelResult.PackageSuccess(_gameCache.GetContext(ctl.GameContext.GameCode).Output()));
        }
    }
}
